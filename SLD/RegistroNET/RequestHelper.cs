using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using MobileAppServer.ServerObjects;

namespace SLD.RegistroNET
{
    public class RequestHelper
    {
        private string parameters = string.Empty;
        public bool isHandled = false;

        public OperationResult Result { get; set; }

        public bool HasSuccess
        {
            get
            {
                if (Result == null)
                    return false;
                if (Result.Status == 600)
                    return true;
                else if (Result.Status == 680)
                {
              //      MessageBox.Show(Result.Msg, "Resposta do serviço", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (isHandled)
                        return false;
          //          if (!string.IsNullOrEmpty(Result.Msg))
           //             MessageBox.Show(Result.Msg, "Resposta do serviço", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return false;
            }
        }

        public string Send(string action)
        {
            Configuration.LoadFromLocalSettings();
            if (isHandled)
                return string.Empty;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Configuration.GetApplication + action);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                if (!string.IsNullOrEmpty(parameters))
                {
                    byte[] b = Encoding.UTF8.GetBytes(parameters);
                    request.ContentLength = b.Length;

                    Stream stream = request.GetRequestStream();

                    stream.Write(b, 0, b.Length);
                    stream.Close();
                }
                
                WebResponse response = request.GetResponse();
                
                Stream data = response.GetResponseStream();
                StreamReader reader = new StreamReader(data);
                string result = reader.ReadToEnd();

                reader.Close();
                response.Close();

                Result = JsonConvert.DeserializeObject<OperationResult>(result);
                return string.IsNullOrEmpty(result) ? string.Empty : result;
            }
            catch (Exception ex)
            {
                LogController.WriteLog(ex.Message);
              //  Console.WriteLine(ex.Message);
            }
            
            return string.Empty;
        }

        public void AddParameter(string paramName, object paramValue)
        {
            if (paramValue == null)
                paramValue = string.Empty;

            if (paramValue.ToString().Contains("%"))
            {
                isHandled = true;
                MessageBox.Show("Caracteres inválidos encontrados (" + paramName + " = %)");
                Result = new OperationResult() { Status = 100, Message = string.Empty, Entity = new object() };
                return;
            }
            if (!string.IsNullOrEmpty(parameters))
                parameters += "&";

            double doubleValue = 0;

            if (double.TryParse(paramValue.ToString(), out doubleValue))
                parameters += paramName + "=" + paramValue.ToString().Replace(",", ".");
            else
                parameters += paramName + "=" + paramValue.ToString().Replace("&", "%26");
        }
    }

}
