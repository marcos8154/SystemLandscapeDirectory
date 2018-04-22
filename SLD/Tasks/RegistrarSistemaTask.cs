using MobileAppServer.ServerObjects;
using RegistroNET.Models;
using SLD.Controller;
using SLD.Model;
using SLD.RegistroNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SLD.Tasks
{
    public class RegistrarSistemaTask : AsyncTask<TaskParams, string, TaskResult>
    {
        public Contrato BuscarContrato(int id, string cnpj)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("numeroContrato", id);
            rh.AddParameter("cnpj", cnpj);
            rh.Send("SystemFind");

            return EntityLoader<Contrato>.Load(rh.Result);
        }

        public Produto BuscarProduto(int id)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("produtoId", id);
            rh.Send("FindProduto");

            return EntityLoader<Produto>.Load(rh.Result);
        }

        public Servidor BuscarServidor(int numeroContrato)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("numeroContrato", numeroContrato);
            rh.Send("FindServidor");

            Servidor registrado = EntityLoader<Servidor>.Load(rh.Result);
            return registrado;
        }

        public Servidor BuscarServidorContratoCPU(int numeroContrato,
            string cpuId)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("numeroContrato", numeroContrato);
            rh.AddParameter("CPUID", cpuId);
            rh.Send("FindServidorContratoCPU");

            Servidor registrado = EntityLoader<Servidor>.Load(rh.Result);
            return registrado;
        }

        private bool RegistrarServidor(int contratoId)
        {
            string sql = new AmbienteController().GetVersaoServidor();
            sql = sql.Split('\n')[0];

            RequestHelper rh = new RequestHelper();
            rh.AddParameter("servidor.CPUID", Util.GetCPUID());
            rh.AddParameter("servidor.Nome", Environment.MachineName);
            rh.AddParameter("servidor.OS", Util.FriendlyName());
            rh.AddParameter("servidor.Memoria", "0GB");
            rh.AddParameter("servidor.Autorizado", true);
            rh.AddParameter("servidor.ContratoId", contratoId);
            rh.AddParameter("servidor.SqlServer", sql);
            rh.Send("RegistrarServidor");
            rh.isHandled = true;
            bool result = rh.HasSuccess;

            if (!result)
                throw new Exception(rh.Result.Message);

            return result;
        }

        private bool ExisteSlotVazioNovoServidor(int numeroContrato)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("numeroContrato", numeroContrato);
            rh.Send("ExisteSlotVazioServidorContrato");
            rh.isHandled = true;

            if (!rh.HasSuccess)
                return false;

            bool result = Convert.ToBoolean(rh.Result.Entity);
            if (!result)
                throw new Exception(rh.Result.Message);
            return result;
        }

        public override TaskResult DoInBackGround(TaskParams param)
        {
            try
            {
                int numeroContrato = param.GetInt("contratoId");
                string cnpj = param.GetString("cnpj");
                string CPU = param.GetString("CPUID");

                Contrato contrato = BuscarContrato(numeroContrato, cnpj);
                if (contrato == null)
                    throw new Exception("Contrato não encontrado");

                Produto produto = BuscarProduto(contrato.ProdutoId);
                if (produto == null)
                    throw new Exception("O procedimento de ativação do produto falhou: produto não encontrado. \n Acione o suporte Doware");

                if (produto.TipoLicenca == (int)TipoLicenca.Servidor ||
                    produto.TipoLicenca == (int)TipoLicenca.Usuario)
                    CPU = Util.GetCPUID();
                else
                {
                    if (string.IsNullOrEmpty(CPU))
                        throw new Exception("O número de série da CPU não foi informado");
                }

                Servidor servidor = BuscarServidorContratoCPU(numeroContrato, CPU);
                if (servidor == null)
                {
                    if (!RegistrarServidor(contrato.Id))
                        throw new Exception("O procedimento de ativação do produto falhou: erro ao registrar o servidor. \nAcione o suporte Doware");
                    servidor = BuscarServidorContratoCPU(numeroContrato, CPU);
                }
                else
                {
                    if (!servidor.CPUID.Equals(CPU))
                    {
                        if (ExisteSlotVazioNovoServidor(numeroContrato))
                        {
                            if (!RegistrarServidor(contrato.Id))
                                throw new Exception("O procedimento de ativação do produto falhou: erro ao registrar o servidor. \nAcione o suporte Doware");
                            servidor = BuscarServidorContratoCPU(numeroContrato, CPU);
                        }
                        else
                            throw new Exception("O procedimento de ativação foi interrompido: este servidor não está autorizado para uso do produto. \nAcione o suporte Doware");
                    }
                }

                Cliente cliente = BuscarCliente(contrato.ClienteId);
                if (cliente == null)
                    throw new Exception("Cliente não encontrado");

                LicencaController controller = new LicencaController();
                if (controller.LicencaRegistrada(contrato.NumeroContrato.Value))
                    throw new Exception("Esta licença já está registrada");

                FaixaPreco faixaPreco = BuscarFaixaPreco(contrato.FaixaPrecoId);
                if (faixaPreco == null)
                    throw new Exception("O procedimento de ativação foi interrompido: faixa de preço não encontrada. \nAcione o suporte Doware");

                Licenca licenca = new Licenca();
                licenca.ContratoId = Compactor.ToCompact(contrato.NumeroContrato.ToString());
                licenca.ClienteId = Compactor.ToCompact(contrato.ClienteId.ToString());
                licenca.ProdutoId = Compactor.ToCompact(contrato.ProdutoId.ToString());
                licenca.OS = Environment.OSVersion.VersionString;
                licenca.CPUID = CPU;
                licenca.ProdutoDescricao = produto.Nome;
                licenca.MaximoUsuarios = Compactor.ToCompact(contrato.UsuariosLicenciados.ToString());
                licenca.ModeloLicenca = produto.TipoLicenca;
                licenca.Cnpj = Compactor.ToCompact(cliente.CnpjCpf);
                licenca.Situacao = (servidor.Autorizado
                    ? "A"
                    : "B");
                licenca.Situacao = Compactor.ToCompact(licenca.Situacao);

                int licencaId = controller.RegistrarLicenca(licenca);

                Thread.Sleep(3000);
                List<FaturaContrato> faturas = BuscarFaturasContrato(contrato.Id);

                faturas.ForEach(f =>
                {
                    FaturaLicenca fat = new FaturaLicenca();
                    fat.Id = f.Id;
                    fat.LicencaId = licencaId;
                    fat.DataVencimento = Compactor.ToCompact(f.DataVencimento.ToString("yyyy-MM-dd"));
                    fat.IdPagamento = (f.IdPagamento == null ? Compactor.ToCompact(Guid.Empty.ToString()) : Compactor.ToCompact(f.IdPagamento.Value.ToString()));

                    controller.SalvarFatura(fat);
                });

                TaskResult result = new TaskResult();
                result.SetValue("Msg", "Registro concluído com sucesso!");
                result.SetValue("Status", 1);

                return result;
            }
            catch (Exception ex)
            {
                TaskResult result = new TaskResult();
                result.SetValue("Msg", ex.Message);
                result.SetValue("Status", 0);

                return result;
            }
        }

        private Cliente BuscarCliente(int clienteId)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("clienteId", clienteId);
            rh.Send("FindCliente");

            return EntityLoader<Cliente>.Load(rh.Result);
        }

        private FaixaPreco BuscarFaixaPreco(int faixaPrecoId)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("faixaPrecoId", faixaPrecoId);
            rh.Send("FindFaixaPreco");

            return EntityLoader<FaixaPreco>.Load(rh.Result);
        }

        private List<FaturaContrato> BuscarFaturasContrato(int contratoId)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("contratoId", contratoId);
            rh.Send("GetFaturas");

            List<FaturaContrato> faturas = EntityLoader<List<FaturaContrato>>.Load(rh.Result);
            return faturas;
        }

        public override void OnPostExecute(TaskResult result)
        {
        }

        public override void OnPreExecute()
        {
        }

        public override void OnProgressUpdate(string progress)
        {
        }
    }
}
