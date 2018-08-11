using SLDClient;
using SLDClient.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLDServerProgramHub
{
    public class ServerProgramHub
    {
        public ServerProgramHub(string programName)
        {
            MyProgramName = programName;
        }

        public delegate void ExecuteEvent(List<ParamValuePair> execParams);
        public event ExecuteEvent DoExecute;

        private List<ParamValuePair> Params = new List<ParamValuePair>();
        public string MyProgramName { get; set; }
        public string NomeAmbiente { get; set; }

        public void WriteLog(string msg)
        {
            if (!Directory.Exists($@".\Logs\{MyProgramName}\"))
                Directory.CreateDirectory($@".\Logs\{MyProgramName}\");

            string texto = $@"Doware SLD Server Program Hub - Detalhamento de logs do programa

Programa: {MyProgramName}
Data/Hora: {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}
Detalhes: {msg}";

            string fileName = $@".\Logs\{MyProgramName}\{MyProgramName} {DateTime.Now.ToString("dd-MM-yyyy")}.txt";

            if (File.Exists(fileName))
                File.AppendAllText(fileName, "\n" + texto);
            else
                File.WriteAllText(fileName, texto);
        }

        private void Registrar()
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "SalvarPrograma")
                .AddParameter("nome", MyProgramName)
                .AddParameter("parametros", ParamsStr)
                .AddParameter("ambiente", NomeAmbiente)
                .AddParameter("valores", ParamsVlr);
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult op = client.GetResult();
        }

        private void WriteParamsOutPut()
        {
            File.WriteAllText(@".\ParamsOutPut.txt", "");
            File.WriteAllLines(@".\ParamsOutPut.txt", ParamsStr.Split(';'));
        }

        public string GetValorParametro(string valorParametro)
        {
            try
            {
                return Params.Find(e => e.ParamName == valorParametro).ParamValue;
            }
            catch
            {
                return string.Empty;
            }
        }

        private string ParamsVlr
        {
            get
            {
                string res = string.Empty;
                Params.ForEach(p => res += $"{p.ParamName}={p.ParamValue};");
                return res;
            }
        }

        private string ParamsStr
        {
            get
            {
                string res = string.Empty;
                Params.ForEach(p => res += $"{p.ParamName}:{p.Description};");
                return res;
            }
        }

        public void AdicionarParametro(string name, string description)
        {
            Params.Add(new ParamValuePair() { ParamName = name, Description = description });
        }

        public void ProcessaPontoInicio(string[] paramStartup)
        {
            if (paramStartup.Length == 0)
            {
                Console.WriteLine("Este programa não pode ser executado de forma manual ou por intermédio do usuário");
                Console.WriteLine("Pressione uma tecla para continuar...");
                Console.ReadKey();
                Environment.Exit(1);
            }

            if (paramStartup[0] == "paramList")
            {
                WriteParamsOutPut();
                Environment.Exit(1);
            }

            NomeAmbiente = paramStartup[1];

            string paramsStr = paramStartup[2];
            string[] paramsArray = paramsStr.Split(';');
            foreach (string par in paramsArray)
            {
                if (string.IsNullOrEmpty(par))
                    continue;

                string name = par.Split('=')[0];
                string value = par.Split('=')[1];

                ParamValuePair pair = Params.Find(p => p.ParamName.Equals(name));
                pair.ParamValue = value;
            }

            if (paramStartup[0] == "register")
                Registrar();

            if (paramStartup[0] == "execute")
                DoExecute?.Invoke(Params);
        }

        public SqlConnection GetConexaoAmbiente()
        {
            Ambiente amb = new AmbienteController().GetAmbiente(NomeAmbiente);
            if (amb == null)
                return null;

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = amb.Servidor;
            sb.UserID = amb.Usuario;
            sb.Password = amb.Senha;
            sb.InitialCatalog = amb.Base;

            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            conn.Open();
            return conn;
        }
    }
}