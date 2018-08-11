using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SLD.Model
{
    public class MonitorExecucaoPrograma
    {
        private Timer Timer { get; set; }
        public ProgramaServidor Programa { get; set; }

        public MonitorExecucaoPrograma(ProgramaServidor programa)
        {
            Programa = programa;
            Timer = new Timer();
            Timer.Interval = (programa.IntervaloExecucao * 60000);
            Timer.Elapsed += Timer_Elapsed;
        }
    
        public void Start()
        {
            Timer.Start();
        }

        public void Stop()
        {
            Timer.Stop();
            Timer.Dispose();
            Timer = null;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Executar();
        }

        public void Executar()
        {
            string path = $@".\ServerPrograms\{Programa.Nome}.exe";

            ProcessStartInfo info = new ProcessStartInfo();
            info.WorkingDirectory = @".\ServerPrograms\";
            info.FileName = $"{Programa.Nome}.exe";
            info.Arguments = $"execute {Programa.Ambiente} {Programa.ValoresParametros}";
            info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            Process.Start(info);
            
            System.Threading.Thread.Sleep(1000);

            while (Process.GetProcessesByName(Programa.Nome).Length > 0)
            {
                //aguardando termino do processo para prosseguir
            }
        }
    }
}
