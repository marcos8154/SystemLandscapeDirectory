using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLDClient
{
    public enum TipoRetornoLicenca
    {
        LicencaOK = 1,
        MaximoUsuariosExcedido = -10,
        LicencaExpirada = -30,
        LicencaExpiradaPodeProrrogar = -35,
        AvisoDiasParaExpirar = -40,
        LicencaNaoEncontrada = -20,
        CnpjInvalido = -65
    }
}
