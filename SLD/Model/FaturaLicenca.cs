using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLD.Model
{
    public class FaturaLicenca
    {
        public int Id { get; set; }
        public int LicencaId { get; set; }
        public string DataVencimento { get; set; }
        public string IdPagamento { get; set; }
        public bool Prorrogado { get; set; }
    }
}
