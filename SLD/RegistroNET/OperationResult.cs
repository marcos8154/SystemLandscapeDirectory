using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLD.RegistroNET
{
    public class OperationResult
    {
        public int Status { get; set; }

        public string Message { get; set; }

        public object Entity { get; set; }
    }
}
