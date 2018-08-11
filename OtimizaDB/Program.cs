using SLDServerProgramHub;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtimizaDB
{
    class Program
    {
        static ServerProgramHub hub = null;
        static void Main(string[] args)
        {
       //     args = new string[] { "execute", "TESTE_MIX", @"caminhoScript=C:\Backup\OtimizaDb.sql" };
            hub = new ServerProgramHub("OtimizaDB");
            hub.AdicionarParametro("caminhoScript", "Caminho completo do script de manutenção e otimização da base");
            hub.DoExecute += Hub_DoExecute;
            hub.ProcessaPontoInicio(args);
        }

        private static void Hub_DoExecute(List<ParamValuePair> execParams)
        {
            SqlConnection conn = null;

            try
            {
                string caminho = hub.GetValorParametro("caminhoScript");
                string[] linhas = File.ReadAllText(caminho).Split(';');

                conn = hub.GetConexaoAmbiente();

                for(int i = 0; i < linhas.Length; i++)
                {

                    hub.WriteLog("Executando a linha " + i + 1);
                    string sql = linhas[i];
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandTimeout = 9999999;
                    cmd.ExecuteNonQuery();
                }

                conn.Close();

                hub.WriteLog("O procedimento de manutenção foi concluído com êxito");
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();

                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += $"\n{ex.InnerException.Message}";
                hub.WriteLog($@"O procedimento de manutenção dos Índices do banco de dados foram concluídos com erros: 
{msg}");
            }
        }
    }
}
