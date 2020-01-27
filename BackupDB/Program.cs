using SLDClient;
using SLDClient.Model;
using SLDServerProgramHub;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupDB
{
    public class Program
    {
        static ServerProgramHub hub = null;
        /*
         * SEMPRE:
         *  [0] Comando
         *  [1] Ambiente
         *  [2] Parametros
         * */
        public static void Main(string[] args)
        {
          //  args = new string[] { "execute", "ABC", @"caminhoDestino=C:\Backup\" };

            hub = new ServerProgramHub("BackupDB");
            hub.AdicionarParametro("caminhoDestino", "Caminho completo do destino do backup");

            hub.DoExecute += Hub_DoExecute;
            hub.ProcessaPontoInicio(args);
        }

        private static void Hub_DoExecute(List<ParamValuePair> execParams)
        {
            SqlConnection conn = null;
            try
            {
                string caminho = hub.GetValorParametro("caminhoDestino");
                if (!Directory.Exists(caminho))
                    Directory.CreateDirectory(caminho);

                DirectoryInfo di = new DirectoryInfo(caminho);
                foreach (DirectoryInfo d in di.GetDirectories())
                    Directory.Delete(d.FullName, true);

                Ambiente amb = new AmbienteController().GetAmbiente(hub.NomeAmbiente);
              
                string sql = $@"BACKUP DATABASE {amb.Base}  
TO DISK = '{caminho}\Backup {amb.Base} - dia {DateTime.Now.ToString("dd-MM-yyyy")} as {DateTime.Now.ToString("HH-mm")}h.bak'  
   WITH FORMAT,  
      MEDIANAME = '{amb.Base}',  
      NAME = '{amb.Base}'";

                 conn = hub.GetConexaoAmbiente();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandTimeout = 9999999;
                cmd.ExecuteNonQuery();
                conn.Close();

                hub.WriteLog($"O procedimento de backup foi concluído com êxito!");
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();

                string msg = ex.Message;
                if (ex.InnerException != null)
                    msg += $"\n{ex.InnerException.Message}";
                hub.WriteLog($@"O procedimento de backup foi concluído com erros:
{msg}");
            }
        }
    }
}
