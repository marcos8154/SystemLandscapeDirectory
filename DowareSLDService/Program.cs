using System;
using System.Collections.Generic;
using System.Configuration.Install;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DowareSLDService
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        static void Main(string[] args)
        {
            if (args.Length == 0)
                args = new string[] { "-i" };

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new Service1()
            };

            if (System.Environment.UserInteractive)
            {
                try
                {
                    string parameter = string.Concat(args);
                    if (parameter == "-i")
                    {
                        try
                        {
                            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                        }
                        catch (Exception ex)
                        {
                        }

                        ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                    }

                    if (parameter == "-u")
                    {
                        Console.WriteLine("Tentando desinstalar o serviço...");
                        ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ServiceBase.Run(new Service1());
            }
        }
    }
}
