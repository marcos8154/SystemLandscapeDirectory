using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLD.Model
{
    public class Licenca
    {
        public int Id { get; set; }
        public string ClienteId { get; set; }
        public string ContratoId { get; set; }
        public string CPUID { get; set; }
        public string OS { get; set; }
        public string ProdutoId { get; set; }
        public string ProdutoDescricao { get; set; }
        public string MaximoUsuarios { get; set; }
        public int ModeloLicenca { get; set; }
        public string Cnpj { get; set; }
        public string Situacao { get; set; }
    }
}
