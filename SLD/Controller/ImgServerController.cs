using MobileAppServer.ServerObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SLD.Controller
{
    public class ImgServerController : IController
    {
        public ActionResult Reiniciar()
        {
            ActionLocker.AddLock(this, "Reiniciar");
            Parar();
            Iniciar();
            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Reiniciado", true));
        }

        public void Iniciar()
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();

                string curDir = Directory.GetCurrentDirectory();
                string caminhoImageServer = Path.Combine(curDir, @"..\FSImageServer\");

                info.FileName = $@"{caminhoImageServer}\FSImageServer.exe";
                info.WorkingDirectory = caminhoImageServer;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process.Start(info);
                Thread.Sleep(1000);
            }
            catch (Exception ex) { }
        }

        public void Parar()
        {
            try
            {
                foreach (Process proc in Process.GetProcessesByName("FSImageServer"))
                    proc.Kill();
            }
            catch { }
        }
    }
}
