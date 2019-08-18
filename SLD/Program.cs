using MobileAppServer.ServerObjects;
using SLD.Controller;
using SLD.Model;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
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

            var conc = new ConcentradorFiscalController();
            conc.Parar();
            conc.Iniciar();

            new Thread(() =>
            {
                try
                {
                    server.Start();
                }
                catch (Exception ex)
                {
                    string msg = ex.Message;
                    if (ex.InnerException != null)
                        msg += $"\n{ex.InnerException.Message}";

                    LogController.WriteLog("FALHA NA INICIALIZAÇÃO DO SERVIDOR DO SLD: " + msg);
                }
            }).Start();

            Thread.Sleep(10000);

            new Thread(() =>
            {
                //  MonitorarSincronizacaoServidorWeb();
                IniciarMonitorExecucaoProgramas();
            }).Start();

            Console.ReadKey();
        }

        public static void ReiniciarMonitorExecucaoProgramas()
        {
            Console.Write("*** INTERROMPENDO MONITORAMENTO DE PROGRAMAS DO SERVIDOR ***");
            Monitores.ForEach(m => m.Stop());
            Monitores = null;
            Monitores = new List<MonitorExecucaoPrograma>();
            Thread.Sleep(1000);
            IniciarMonitorExecucaoProgramas();
        }

        private static void IniciarMonitorExecucaoProgramas()
        {
            try
            {
                Console.Write("*** INICIANDO MONITORAMENTO DE PROGRAMAS DO SERVIDOR ***");
                List<ProgramaServidor> programas = new ServerProgramController().GetProgramasBanco();
                foreach (ProgramaServidor programa in programas)
                {
                    MonitorExecucaoPrograma monitor = new MonitorExecucaoPrograma(programa);
                    Monitores.Add(monitor);
                    if (programa.ExecutaNaInicializacao)
                        monitor.Executar();

                    monitor.Start();
                }
            }
            catch (Exception ex)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ex.Message);
                Console.Write("\n" + ex.StackTrace);
                Console.ForegroundColor = color;
            }
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
