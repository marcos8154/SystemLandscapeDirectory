using SLDClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLDClient
{
    public class AmbienteController
    {
        public void RegistrarServidor(string servidor, string usuario, string senha)
        {
            RequestBody rb = RequestBody.Create("AmbienteController", "RegistrarServidor")
                .AddParameter("servidor", servidor)
                .AddParameter("usuario", usuario)
                .AddParameter("senha", senha);

            Client client = new Client();
            client.SendRequest(rb);

            OperationResult result = client.GetResult();

            if (result.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(result.Message);
        }

        public bool ServidorRegistrado()
        {
            RequestBody rb = RequestBody.Create("AmbienteController", "ServidorRegistrado");
            Client client = new Client();
            client.SendRequest(rb);

            if (client.GetResult().Status != (int)StatusResult.OPERACAO_OK)
                return false;

            return true;
        }

        public bool AmbienteOnline(string nome)
        {
            try
            {
                RequestBody rb = RequestBody.Create("AmbienteController", "GetStatus")
                    .AddParameter("ambiente", nome);
                Client client = new Client();
                client.SendRequest(rb);
                OperationResult result = client.GetResult(typeof(bool));
                return (bool)result.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void CriarAmbiente(string nome,
            string servidor, string usuario, string senha,
            string banco)
        {
            try
            {
                RequestBody request = RequestBody.Create("AmbienteController", "CriarAmbiente")
                    .AddParameter("nome", nome)
                    .AddParameter("servidor", servidor)
                    .AddParameter("usuario", usuario)
                    .AddParameter("senha", senha)
                    .AddParameter("banco", banco);

                Client client = new Client();
                client.SendRequest(request);
                OperationResult result = client.GetResult(typeof(Ambiente));
                if (result.Status != (int)StatusResult.OPERACAO_OK)
                    throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Testar(string nomeAmbiente)
        {
            RequestBody r = RequestBody.Create("AmbienteController", "TestarAmbiente")
                .AddParameter("ambiente.Nome", nomeAmbiente);
            Client c = new Client();
            c.SendRequest(r);
            c.ReadResponse();
        }

        public List<Ambiente> ListarAmbientes(string nome)
        {
            try
            {
                RequestBody r = RequestBody.Create("AmbienteController", "ListarAmbientes")
                    .AddParameter("nome", nome);
                Client client = new Client();
                client.SendRequest(r);
                OperationResult result = client.GetResult(typeof(List<Ambiente>));
                if (result.Status != (int)StatusResult.OPERACAO_OK)
                    throw new Exception(result.Message);
                return (List<Ambiente>)result.Entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void RemoverAmbiente(string nome)
        {
            RequestBody rb = RequestBody.Create("AmbienteController", "RemoverAmbiente")
                .AddParameter("nome", nome);
            Client client = new Client();
            client.SendRequest(rb);
            OperationResult op = client.GetResult();
            if (op.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(op.Message);
        }

        public Ambiente GetAmbiente(string nome)
        {
            return ListarAmbientes(nome).FirstOrDefault();
        }

        public void SetStatus(string ambiente, bool status)
        {
            try
            {
                RequestBody rb = RequestBody.Create("AmbienteController", "SetStatus")
                    .AddParameter("ambiente", ambiente)
                    .AddParameter("online", status);
                Client client = new Client();
                client.SendRequest(rb);
                OperationResult result = client.GetResult();
                if (result.Status != (int)StatusResult.OPERACAO_OK)
                    throw new Exception(result.Message);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ValidarConexao(string servidor, string usuario, string senha,
            string banco)
        {
            RequestBody rb = RequestBody.Create("AmbienteController", "ValidarConexao")
                .AddParameter("servidor", servidor)
                .AddParameter("usuario", usuario)
                .AddParameter("senha", senha)
                .AddParameter("banco", banco);
            Client client = new Client();
            client.SendRequest(rb);
            OperationResult result = client.GetResult();
            if (result.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(result.Message);
        }
    }
}
