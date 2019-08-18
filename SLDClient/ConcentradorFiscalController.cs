using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLDClient
{
    public class ConcentradorFiscalController
    {
        public void Reiniciar()
        {
            Parar();
            Iniciar();
        }

        private void Parar()
        {
            Client c = new Client();
            RequestBody rb = RequestBody.Create("ConcentradorFiscalController", "Parar");
            c.SendRequest(rb);
            c.ReadResponse();
        }

        private void Iniciar()
        {
            Client c = new Client();
            RequestBody rb = RequestBody.Create("ConcentradorFiscalController", "Iniciar");
            c.SendRequest(rb);
            c.ReadResponse();
        }

        public void BuscarAtualizacoes()
        {
            Parar();
            Client c = new Client();
            RequestBody rb = RequestBody.Create("ConcentradorFiscalController", "BuscarAtualizacao");
            c.SendRequest(rb);
            c.ReadResponse();
            Iniciar();
        }
    }
}
