using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.Controller
{
    public class GoogleDriveController
    {
        public static Google.Apis.Auth.OAuth2.UserCredential Autenticar()
        {
            Google.Apis.Auth.OAuth2.UserCredential credenciais;

            using (var stream = new System.IO.FileStream(@".\client_id.json", System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                var diretorioAtual = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                var diretorioCredenciais = System.IO.Path.Combine(diretorioAtual, "credential");

                credenciais = Google.Apis.Auth.OAuth2.GoogleWebAuthorizationBroker.AuthorizeAsync(
                    Google.Apis.Auth.OAuth2.GoogleClientSecrets.Load(stream).Secrets,
                    new[] { Google.Apis.Drive.v3.DriveService.Scope.DriveReadonly },
                    "user",
                    System.Threading.CancellationToken.None,
                    new Google.Apis.Util.Store.FileDataStore(diretorioCredenciais, true)).Result;
            }

            return credenciais;
        }

        public static Google.Apis.Drive.v3.DriveService AbrirServico(Google.Apis.Auth.OAuth2.UserCredential credenciais)
        {
            return new Google.Apis.Drive.v3.DriveService(new Google.Apis.Services.BaseClientService.Initializer()
            {
                HttpClientInitializer = credenciais
            });
        }

        public static string[] ProcurarArquivoId(Google.Apis.Drive.v3.DriveService servico,
            string nome, bool procurarNaLixeira = false)
        {
            var retorno = new List<string>();

            var request = servico.Files.List();
            request.Q = string.Format("name = '{0}'", nome);
            if (!procurarNaLixeira)
            {
                request.Q += " and trashed = false";
            }
            request.Fields = "files(id)";
            var resultado = request.Execute();
            var arquivos = resultado.Files;

            if (arquivos != null && arquivos.Any())
            {
                foreach (var arquivo in arquivos)
                {
                    retorno.Add(arquivo.Id);
                }
            }

            return retorno.ToArray();
        }

        public static void Download(Google.Apis.Drive.v3.DriveService servico, string nome, string destino)
        {
            var ids = ProcurarArquivoId(servico, nome);
            if (ids != null && ids.Any())
            {
                var request = servico.Files.Get(ids.First());
                using (var stream = new System.IO.FileStream(destino,
                    System.IO.FileMode.Create, System.IO.FileAccess.Write))
                {
                    request.Download(stream);
                }
            }
        }
    }
}
