using MobileAppServer.ServerObjects;
using RegistroNET.Models;
using SLD.Controller;
using SLD.Model;
using SLD.RegistroNET;
using SLD.Tasks;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace SLD
{
    public class Program
    {
        public static List<MonitorExecucaoPrograma> Monitores = new List<MonitorExecucaoPrograma>();
        public static void Main(string[] args)
        {
            Server server = new Server();
            server.Port = 55555;

            server.RegisterAllModels(Assembly.GetExecutingAssembly(), "SLD.Model");
            server.RegisterAllControllers(Assembly.GetExecutingAssembly(), "SLD.Controller");
            server.ActionInvoked += Server_ActionInvoked;

            AtualizaFaturasTask task = new AtualizaFaturasTask();
            task.Execute(1);

            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(60000 * 1);
                    AtualizaFaturasTask t = new AtualizaFaturasTask();
                    t.Execute(1);
                }
            }).Start();


            List<ProgramaServidor> programas = new ServerProgramController().GetProgramasBanco();
            foreach (ProgramaServidor programa in programas)
            {
                MonitorExecucaoPrograma monitor = new MonitorExecucaoPrograma(programa);
                Monitores.Add(monitor);
                if (programa.ExecutaNaInicializacao)
                    monitor.Executar();

                monitor.Start();
            }

            server.Start();
        }

        private static void T_Elapsed(object sender, ElapsedEventArgs e)
        {
            AtualizaFaturasTask task = new AtualizaFaturasTask();
            task.Execute(1);
        }

        private static void Server_ActionInvoked()
        {

        }
    }
}












/*       IHa ha = new Ha();
        PropertyInfo[] pInfos = ha.GetType().GetProperties(BindingFlags.NonPublic | 
            BindingFlags.Public | 
            BindingFlags.Instance |
            BindingFlags.Static);

        PropertyInfo p = pInfos.Where(e => e.Name == "Valor").FirstOrDefault();
        decimal d = (decimal)p.GetValue(ha, null);
        */
