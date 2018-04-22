using MobileAppServer.ServerObjects;
using RegistroNET.Models;
using SLD.Controller;
using SLD.Model;
using SLD.RegistroNET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SLD.Tasks
{
    public class AtualizaFaturasTask : AsyncTask<int, string, int>
    {
        private object locker = new object();

        private List<FaturaContrato> GetFaturasServidor(int numeroContrato)
        {
            RequestHelper rh = new RequestHelper();
            rh.AddParameter("numeroContrato", numeroContrato);
            rh.Send("GetFaturasByNumeroContrato");

            if (!rh.HasSuccess)
                return new List<FaturaContrato>();

            return EntityLoader<List<FaturaContrato>>.Load(rh.Result);
        }

        private void AtualizaFaturasBaseLocal()
        {
            List<Licenca> licencas = new LicencaController().GetAllLicencas();
            foreach (Licenca licenca in licencas)
            {
                int contratoId = int.Parse(Compactor.FromCompact(licenca.ContratoId));
                List<FaturaContrato> faturasServidor = GetFaturasServidor(contratoId);

                foreach (FaturaContrato fatura in faturasServidor)
                {
                    FaturaLicenca faturaLicenca = new LicencaController().GetAllFaturas().
                        Where(e => e.Id == fatura.Id)
                        .FirstOrDefault();

                    if (faturaLicenca == null)
                    {
                        /* Fatura existe no servidor online
                         * mas ainda nao foi baixada para
                         * a base SLD local
                         * */

                        FaturaLicenca novaFatura = new FaturaLicenca();
                        novaFatura.Id = fatura.Id;
                        novaFatura.LicencaId = licenca.Id;
                        novaFatura.DataVencimento = Compactor.ToCompact(fatura.DataVencimento.ToString("yyyy-MM-dd"));
                        novaFatura.IdPagamento = Compactor.ToCompact(fatura.IdPagamento.HasValue
                            ? fatura.IdPagamento.ToString()
                            : Guid.Empty.ToString());
                        new LicencaController().SalvarFatura(novaFatura);
                    }
                    else
                    {
                        if (faturaLicenca.Prorrogado &&
                            DateTime.Parse(faturaLicenca.DataVencimento).Date > DateTime.Now.Date)
                            if (faturaLicenca.IdPagamento == Guid.Empty.ToString())
                                continue;

                        faturaLicenca.DataVencimento = fatura.DataVencimento.ToString("yyyy-MM-dd");
                        if (fatura.IdPagamento != null)
                            faturaLicenca.IdPagamento = Compactor.ToCompact(fatura.IdPagamento.Value.ToString());
                        else
                            faturaLicenca.IdPagamento = Compactor.ToCompact(Guid.Empty.ToString());
                        new LicencaController().SalvarFatura(faturaLicenca, true);
                    }
                }

            }
        }

        public override int DoInBackGround(int param)
        {
            try
            {
                lock (locker)
                {
                    UpdateProgress("Executando Task AtualizaFaturasTask...");

                    AtualizaFaturasBaseLocal();

                    List<Licenca> licencas = new LicencaController().GetAllLicencas();

                    foreach (Licenca licenca in licencas)
                    {
                        int contratoId = int.Parse(Compactor.FromCompact(licenca.ContratoId));
                        string cnpj = Compactor.FromCompact(licenca.Cnpj);

                        Produto produto = new RegistrarSistemaTask().BuscarProduto(int.Parse(Compactor.FromCompact(licenca.ProdutoId)));

                        string cpu = (produto.TipoLicenca == (int)TipoLicenca.Servidor ||
                            produto.TipoLicenca == (int)TipoLicenca.Usuario
                            ? Util.GetCPUID()
                            : licenca.CPUID);

                        Contrato contrato = new RegistrarSistemaTask().BuscarContrato(contratoId, cnpj);
                        Servidor servidor = new RegistrarSistemaTask().BuscarServidorContratoCPU(contrato.NumeroContrato.Value, cpu);

                        licenca.CPUID = (servidor == null
                            ? cpu
                            : servidor.CPUID);
                        licenca.MaximoUsuarios = Compactor.ToCompact(contrato.UsuariosLicenciados.ToString());
                        licenca.Situacao = (servidor == null
                            ? "B"
                            : (servidor.Autorizado
                                    ? "A"
                                    : "B"));
                        licenca.Situacao = Compactor.ToCompact(licenca.Situacao);

                        LicencaController lc = new LicencaController();
                        lc.AtualizarLicenca(licenca);
                    }
                }
            }
            catch (Exception ex)
            {
                var foreAtual = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"*** ERRO AO ATUALIZAR A BASE SLD LOCAL ***");
                Console.WriteLine(ex.Message);
                Console.ForegroundColor = foreAtual;
            }

            return 0;
        }

        public override void OnPostExecute(int result)
        {
        }

        public override void OnPreExecute()
        {
        }

        public override void OnProgressUpdate(string progress)
        {
            Console.WriteLine(progress);
        }
    }
}
