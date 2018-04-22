using SLDClient.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLDClient
{
    public class ServerProgramController
    {
        public void Executar(string programa, string ambiente)
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "Executar")
                .AddParameter("nomePrograma", programa)
                .AddParameter("ambiente", ambiente);
            Client c = new Client();
            c.SendRequest(rb);
            c.GetResult();
        }

        public void AlterarIntervaloExecucao(string nomePrograma, string ambiente,
             int intervalo, bool executaNoInicio)
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "AlterarIntervaloExecucao")
                .AddParameter("nomePrograma", nomePrograma)
                .AddParameter("ambiente", ambiente)
                .AddParameter("intervalo", intervalo)
                .AddParameter("executaNoInicio", executaNoInicio);
            Client cliente = new Client();
            cliente.SendRequest(rb);
            cliente.GetResult();
        }

        public List<ProgramaServidor> ListarProgramas()
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "ListarProgramasBanco");
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult op = client.GetResult(typeof(List<ProgramaServidor>));
            return (List<ProgramaServidor>)op.Entity;
        }

        public void Registrar(string nome, string ambiente, string parametros)
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "Registrar")
                .AddParameter("nome", nome)
                .AddParameter("ambiente", ambiente)
                .AddParameter("parametros", parametros);
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult op = client.GetResult();
            if (op.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(op.Message);
        }

        public List<string> ProgramasServidor()
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "ListarProgramasDiretorio");
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult op = client.GetResult(typeof(string[]));
            if (op.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(op.Message);

            string[] programas = (string[])op.Entity;
            return programas.ToList();
        }

        public List<string> ListarParametrosPrograma(string programa)
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "ListarParametros")
                .AddParameter("programa", programa);
            Client client = new Client();
            client.SendRequest(rb);

            OperationResult op = client.GetResult(typeof(string[]));
            if (op.Status != (int)StatusResult.OPERACAO_OK)
                throw new Exception(op.Message);

            string[] parametros = (string[])op.Entity;
            return parametros.ToList();
        }

        public void Remove(string nomePrograma, string ambiente)
        {
            RequestBody rb = RequestBody.Create("ServerProgramController", "RemoverPrograma")
                .AddParameter("programa", nomePrograma)
                .AddParameter("ambiente", ambiente);
            Client client = new Client();
            client.SendRequest(rb);
            client.ReadResponse();
        }
    }
}
