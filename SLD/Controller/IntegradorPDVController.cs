using MobileAppServer.ServerObjects;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SLD.Controller
{
    public class IntegradorPDVController : IController
    {
        public ActionResult Parar()
        {
            ActionLocker.AddLock(this, "Parar");
            try
            {
                foreach (Process proc in Process.GetProcessesByName("IntegradorPDV"))
                    proc.Kill();
            }
            catch { }

            return ActionResult.Json(true);
        }

        public ActionResult Iniciar()
        {
            ActionLocker.AddLock(this, "Iniciar");
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();

                string curDir = Directory.GetCurrentDirectory();
                string caminhoConcentrador = Path.Combine(curDir, @"..\IntegradorPDV\");

                info.FileName = $@"{caminhoConcentrador}\IntegradorPDV.exe";
                info.WorkingDirectory = caminhoConcentrador;
                info.CreateNoWindow = true;
                info.WindowStyle = ProcessWindowStyle.Hidden;

                Process.Start(info);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                return ActionResult.Json(false, 500, "Erro ao iniciar o InitegradorPDV no Servidor");
            }

            return ActionResult.Json(true);
        }
    }
}
