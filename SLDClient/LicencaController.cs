using SLDClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLDClient
{
    public class LicencaController
    {
        public void ProrrogarFatura(int produtoId, string CPUID, string dataFatura)
        {
            RequestBody rb = RequestBody.Create("LicencaController", "ProrrogarFatura")
                .AddParameter("produtoId", produtoId)
                .AddParameter("CPUID", CPUID)
                .AddParameter("dataFatura", dataFatura);
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult result = client.GetResult();
            if (result.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(result.Message);
        }

        public Tuple<TipoRetornoLicenca, string> ValidaLicenca(int produtoId, int usuarios,
            string CPUID, string cnpj)
        {
            RequestBody rb = RequestBody.Create("LicencaController", "ValidaLicenca")
                .AddParameter("produtoId", produtoId)
                .AddParameter("usuarios", usuarios)
                .AddParameter("CPUID", CPUID)
                .AddParameter("cnpj", cnpj);

            Client client = new Client();
            client.SendRequest(rb);
            OperationResult res = client.GetResult();

            int codigo = int.Parse(res.Message.Split(':')[0]);
            TipoRetornoLicenca enumRetorno = (TipoRetornoLicenca)codigo;
            string msg = res.Message.Split(':')[1];
            Tuple<TipoRetornoLicenca, string> result = new Tuple<TipoRetornoLicenca, string>(enumRetorno, msg);
            return result;
        }

        public List<Licenca> ListarLicencas()
        {
            RequestBody rb = RequestBody.Create("LicencaController", "ListarLicencas");
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult result = client.GetResult(typeof(List<Licenca>));
            List<Licenca> list = (List<Licenca>)result.Entity;
            return list;
        }

        public List<FaturaLicenca> ListarFaturas(int licencaId)
        {
            RequestBody rb = RequestBody.Create("LicencaController", "ListarFaturas")
                .AddParameter("licencaId", licencaId);
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult result = client.GetResult(typeof(List<FaturaLicenca>));
            List<FaturaLicenca> list = (List<FaturaLicenca>)result.Entity;
            return list;
        }

        public void RegistrarSistema(int contratoId, string cnpj, string CPUID)
        {
            RequestBody rb = RequestBody.Create("LicencaController", "RegistrarSistema")
                .AddParameter("contratoId", contratoId)
                .AddParameter("cnpj", cnpj)
                .AddParameter("CPUID", CPUID);

            Client client = new Client();
            client.SendRequest(rb);

            OperationResult result = client.GetResult();
            if (result.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(result.Message);
        }

        public Licenca GetLicenca(int produtoId, string CPUID, string cnpj)
        {
            RequestBody rb = RequestBody.Create("LicencaController", "GetLicenca")
                   .AddParameter("produtoId", produtoId)
                   .AddParameter("CPUID", CPUID)
                   .AddParameter("cnpj", cnpj);

            Client c = new Client();
            c.SendRequest(rb);

            OperationResult res = c.GetResult(typeof(Licenca));
            return (Licenca)res.Entity;
        }
    }
}
