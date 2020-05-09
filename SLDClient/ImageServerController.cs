using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLDClient
{
    public class ImageServerController
    {
        public void Reiniciar()
        {
            Client c = new Client();
            RequestBody rb = RequestBody.Create("ImgServerController", "Reiniciar");
            c.SendRequest(rb);
            var result = c.GetResult();
        }
    }
}
