using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLDClient.Model
{
    public class ProgramaServidor
    {
        public int Id { get; set; }
        public string Ambiente { get; set; }
        public string Nome { get; set; }
        public string Parametros { get; set; }
        public string ValoresParametros { get; set; }
        public int IntervaloExecucao { get; set; }
        public bool ExecutaNaInicializacao { get; set; }
    }
}