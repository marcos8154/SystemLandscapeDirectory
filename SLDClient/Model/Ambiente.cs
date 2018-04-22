using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLDClient.Model
{
    public class Ambiente
    {
        public string Nome { get; set; }
        public string Servidor { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Base { get; set; }
        public string Versao { get; set; }
        public bool Online { get; set; }
    }
}
