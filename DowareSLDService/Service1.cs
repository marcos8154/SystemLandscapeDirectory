using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceProcess;

namespace DowareSLDService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string caminho = $@"{Assembly.GetExecutingAssembly().Location.Replace("SLDService\\DowareSLDService.exe", "")}";
            try
            {
                ProcessStartInfo p = new ProcessStartInfo();
                p.FileName = $@"{caminho}\SLDServer\SLD.exe";
                p.WorkingDirectory = $@"{caminho}\SLDServer\";
                p.UseShellExecute = true;

                Process.Start(p);
            }
            catch (Exception ex)
            {
                StreamWriter w = new StreamWriter(@"C:\Temp\SLDService.txt");
                w.WriteLine(ex.Message + $"\n Caminho: {caminho}");
                w.Close();
            }
        }

        protected override void OnStop()
        {
            try
            {
                foreach (Process p in Process.GetProcesses())
                {
                    if (p.ProcessName.Equals("SLD") ||
                        p.ProcessName.Equals("IntegradorPDV") ||
                        p.ProcessName.Equals("ConcentradorNFe") ||
                        p.ProcessName.Equals("FSImageServer") ||
                        p.ProcessName.Equals("ServContaEstoque"))
                    {
                        p.Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                File.WriteAllText(@"C:\Temp\SLDService.txt", ex.Message);
            }
        }
    }
}
