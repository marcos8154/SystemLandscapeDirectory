using MobileAppServer.ServerObjects;
using SLD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SLD.Controller
{
    public class ServerProgramController : IController
    {
        public ServerProgramController()
        {

        }

        public ActionResult Executar(string nomePrograma, string ambiente)
        {
            MonitorExecucaoPrograma monitor = Program.Monitores.Where(m => m.Programa.Nome.Equals(nomePrograma) &&
              m.Programa.Ambiente.Equals(ambiente)).FirstOrDefault();
            if (monitor != null)
                monitor.Executar();

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, (monitor == null
                ? "O programa não está na lista de monitoramento"
                : "A solicitação foi enviada ao monitor do programa"), true));
        }

        public ActionResult AlterarIntervaloExecucao(string nomePrograma, string ambiente,
             int intervalo, bool executaNoInicio)
        {
            ProgramaServidor programa = GetProgramasBanco().FirstOrDefault(p => p.Nome.Equals(nomePrograma) && p.Ambiente.Equals(ambiente));

            string sql = @"update ProgramaServidor set IntervaloExecucao = @intervalo, ExecutaNaInicializacao = @executaInit 
where Nome = @nome and ambiente = @ambiente";

            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@nome", nomePrograma);
            cmd.Parameters.AddWithValue("@ambiente", ambiente);
            cmd.Parameters.AddWithValue("@intervalo", intervalo);
            cmd.Parameters.AddWithValue("@executaInit", executaNoInicio);
            cmd.ExecuteNonQuery();
            conn.Close();

            Program.ReiniciarMonitorExecucaoProgramas();
            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", true));
        }

        public ActionResult RemoverPrograma(string programa, string ambiente)
        {
            string sql = "delete from ProgramaServidor where Nome = @Nome and Ambiente = @Ambiente";

            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nome", programa);
            cmd.Parameters.AddWithValue("@Ambiente", ambiente);
            cmd.ExecuteNonQuery();
            conn.Close();

            Program.ReiniciarMonitorExecucaoProgramas();
            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", true));
        }

        public ActionResult ListarParametros(string programa)
        {
            string path = $@".\ServerPrograms\{programa}.exe";
            File.WriteAllText(@".\ServerPrograms\ParamsOutPut.txt", "");

            ProcessStartInfo info = new ProcessStartInfo();
            info.WorkingDirectory = @".\ServerPrograms\";
            info.FileName = $"{programa}.exe";
            info.Arguments = $"paramList";
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            Process p = new Process();
            p.StartInfo = info;
            p.Start();
            p.WaitForExit();

            string[] parametros = File.ReadAllLines(@".\ServerPrograms\ParamsOutPut.txt");
            if (parametros.Length == 0)
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_VALIDACAO, "Este executável não é um programa de servidor SLD", ""));
            else
                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", parametros));
        }

        public List<ProgramaServidor> GetProgramasBanco()
        {
            string sql = "select * from ProgramaServidor";
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<ProgramaServidor> list = new List<ProgramaServidor>();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    list.Add(new ProgramaServidor()
                    {
                        Id = dr.GetInt32(0),
                        Ambiente = dr.GetString(1),
                        Nome = dr.GetString(2),
                        Parametros = dr.GetString(3),
                        ValoresParametros = dr.GetString(4),
                        IntervaloExecucao = dr.GetInt32(5),
                        ExecutaNaInicializacao = dr.GetBoolean(6)
                    });
                }
            }

            return list;
        }

        public ActionResult ListarProgramasBanco()
        {
            List<ProgramaServidor> list = GetProgramasBanco();
            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", list));
        }

        public ActionResult ListarProgramasDiretorio()
        {
            DirectoryInfo info = new DirectoryInfo(@".\ServerPrograms\");
            FileInfo[] files = info.GetFiles().Where(e => e.Extension.EndsWith(".exe")).ToArray();
            List<string> names = files.Select(e => e.Name.Replace(".exe", "")).ToList();

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", names));
        }

        public ActionResult SalvarPrograma(string nome, string parametros, string ambiente,
            string valores)
        {
            SqlConnection conn = null;
            try
            {
                string sql = @"insert into ProgramaServidor (Nome, Parametros, Ambiente, ValoresParametros, IntervaloExecucao, ExecutaNaInicializacao)
 values (@1, @2, @3, @4, 59, 0)";
                conn = ConnectionManager.GetConnection();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@1", nome);
                cmd.Parameters.AddWithValue("@2", parametros);
                cmd.Parameters.AddWithValue("@3", ambiente);
                cmd.Parameters.AddWithValue("@4", valores);
                cmd.ExecuteNonQuery();
                conn.Close();

                Program.ReiniciarMonitorExecucaoProgramas();
                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Programa registrado com exito", true));
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();

                return ActionResult.Json(new OperationResult(StatusResult.FALHA_INTERNA, $"Erro: {ex.Message}", false));
            }
        }

        public ActionResult Registrar(string nome, string ambiente, string parametros)
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.WorkingDirectory = @".\ServerPrograms\";
            info.FileName = $"{nome}.exe";
            info.Arguments = $"register {ambiente} {parametros}";
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            Process.Start(info);
            Thread.Sleep(3000);

            bool registrado = ProgramaRegistrado(nome, ambiente);
            return ActionResult.Json(new OperationResult((registrado ? StatusResult.OPERACAO_OK : StatusResult.FALHA_INTERNA),
                "", registrado));
        }

        private bool ProgramaRegistrado(string nome, string ambiente)
        {
            string sql = "select count(*) from ProgramaServidor where Nome = @1 and Ambiente = @2";
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@1", nome);
            cmd.Parameters.AddWithValue("@2", ambiente);

            int count = (int)cmd.ExecuteScalar();

            conn.Close();
            return (count > 0);
        }
    }
}
