using MobileAppServer.ServerObjects;
using RegistroNET.Models;
using SLD.Model;
using SLD.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SLD.Controller
{
    public class LicencaController : IController
    {
        public int RegistrarLicenca(Licenca licenca)
        {
            string sql = @"INSERT INTO Licenca (ContratoId, ClienteId, CPUID, OS, ProdutoId, ProdutoDescricao, MaximoUsuarios, ModeloLicenca, Cnpj, Situacao) 
                values (@ContratoId, @ClienteId, @CPUID, @OS, @ProdutoId, @ProdutoDescricao,
@MaximoUsuarios, @ModeloLicenca, @Cnpj, @Situacao)";

            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ContratoId", licenca.ContratoId);
            cmd.Parameters.AddWithValue("@ClienteId", licenca.ClienteId);
            cmd.Parameters.AddWithValue("@CPUID", licenca.CPUID);
            cmd.Parameters.AddWithValue("@OS", licenca.OS);
            cmd.Parameters.AddWithValue("@ProdutoId", licenca.ProdutoId);
            cmd.Parameters.AddWithValue("@ProdutoDescricao", licenca.ProdutoDescricao);
            cmd.Parameters.AddWithValue("@MaximoUsuarios", licenca.MaximoUsuarios);
            cmd.Parameters.AddWithValue("@ModeloLicenca", licenca.ModeloLicenca);
            cmd.Parameters.AddWithValue("@Cnpj", licenca.Cnpj);
            cmd.Parameters.AddWithValue("@Situacao", licenca.Situacao);
            cmd.ExecuteNonQuery();

            cmd = new SqlCommand("SELECT MAX(Id) FROM Licenca", conn);
            int id = int.Parse(cmd.ExecuteScalar().ToString());

            conn.Close();

            return id;
        }

        public List<Licenca> GetAllLicencas()
        {
            string sql = "select * from Licenca";
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            conn.Close();

            List<Licenca> result = new List<Licenca>();

            foreach (DataRow row in dt.Rows)
            {
                Licenca lic = new Licenca();
                lic.ContratoId = row["ContratoId"].ToString();
                lic.ClienteId = row["ClienteId"].ToString();
                lic.CPUID = row["CPUID"].ToString();
                lic.OS = row["OS"].ToString();
                lic.ProdutoId = row["ProdutoId"].ToString();
                lic.Id = int.Parse(row["Id"].ToString());
                lic.ProdutoDescricao = row["ProdutoDescricao"].ToString();
                lic.MaximoUsuarios = row["MaximoUsuarios"].ToString();
                lic.ModeloLicenca = int.Parse(row["ModeloLicenca"].ToString());
                lic.Cnpj = row["Cnpj"].ToString();
                lic.Situacao = row["Situacao"].ToString();

                result.Add(lic);
            }

            return result;
        }

        public void AtualizarLicenca(Licenca licenca)
        {
            string sql = "update licenca set MaximoUsuarios = @maxUsr, CPUID = @CPU, Situacao = @sit where id = @id";
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", licenca.Id);
            cmd.Parameters.AddWithValue("@maxUsr", licenca.MaximoUsuarios);
            cmd.Parameters.AddWithValue("@sit", licenca.Situacao);
            cmd.Parameters.AddWithValue("@CPU", licenca.CPUID);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public bool LicencaRegistrada(int contratoId)
        {
            string str = Compactor.ToCompact(contratoId.ToString());
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT Count(*) FROM Licenca WHERE ContratoId = @ContratoId", conn);
            cmd.Parameters.AddWithValue("@ContratoId", str);
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();

            return (count > 0);
        }

        public void SalvarFatura(FaturaLicenca fatura, bool update = false)
        {
            string sql = (update
                ? "UPDATE FaturaLicenca SET IdPagamento = @IdPagamento WHERE Id = @Id"
                : @"INSERT INTO FaturaLicenca(Id, LicencaId, DataVencimento, IdPagamento) 
values (@Id, @LicencaId, @DataVencimento, @IdPagamento)");

            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Id", fatura.Id);
            cmd.Parameters.AddWithValue("@IdPagamento", fatura.IdPagamento);

            if (!update)
            {
                cmd.Parameters.AddWithValue("@LicencaId", fatura.LicencaId);
                cmd.Parameters.AddWithValue("@DataVencimento", fatura.DataVencimento);
            }

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public ActionResult Registrado()
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from Licenca", conn);
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            conn.Close();

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", count > 1));
        }

        public ActionResult RegistrarSistema(int contratoId, string cnpj, string CPUID)
        {
            RegistrarSistemaTask task = new RegistrarSistemaTask();
            TaskResult result = task.DoInBackGround(TaskParams.Create()
                   .Set("contratoId", contratoId)
                   .Set("cnpj", cnpj)
                   .Set("CPUID", CPUID));

            return (result.GetInt("Status") == 1
                ? ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Solicitação enviada ao servidor de estrutura", true))
                : ActionResult.Json(new OperationResult(StatusResult.FALHA_VALIDACAO, result.GetString("Msg"), false)));
        }

        public ActionResult ListarLicencas()
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Licenca", conn);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            conn.Close();

            List<Licenca> licencas = new List<Licenca>();
            foreach (DataRow row in dt.Rows)
            {
                licencas.Add(new Licenca()
                {
                    ContratoId = Compactor.FromCompact(row["ContratoId"].ToString()),
                    ClienteId = Compactor.FromCompact(row["ClienteId"].ToString()),
                    CPUID = row["CPUID"].ToString(),
                    OS = row["OS"].ToString(),
                    ProdutoId = Compactor.FromCompact(row["ProdutoId"].ToString()),
                    Id = int.Parse(row["Id"].ToString()),
                    ProdutoDescricao = row["ProdutoDescricao"].ToString(),
                    MaximoUsuarios = Compactor.FromCompact(row["MaximoUsuarios"].ToString()),
                    ModeloLicenca = int.Parse(row["ModeloLicenca"].ToString()),
                    Cnpj = Compactor.FromCompact(row["Cnpj"].ToString()),
                    Situacao = Compactor.FromCompact(row["Situacao"].ToString())
                });
            }

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", licencas));
        }

        private List<FaturaLicenca> GetFaturas(int licencaId)
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT * FROM FaturaLicenca WHERE LicencaId = @LicencaId", conn);
            cmd.Parameters.AddWithValue("@LicencaId", licencaId);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            dr.Close();
            conn.Close();

            List<FaturaLicenca> faturas = new List<FaturaLicenca>();
            foreach (DataRow row in dt.Rows)
            {
                faturas.Add(new FaturaLicenca()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    LicencaId = int.Parse(row["LicencaId"].ToString()),
                    DataVencimento = Compactor.FromCompact(row["DataVencimento"].ToString()),
                    IdPagamento = Compactor.FromCompact(row["IdPagamento"].ToString()),
                    Prorrogado = bool.Parse(row["Prorrogado"].ToString())
                });
            }

            return faturas;
        }

        public List<FaturaLicenca> GetAllFaturas()
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("select * from FaturaLicenca", conn);
            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            conn.Close();

            List<FaturaLicenca> result = new List<FaturaLicenca>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new FaturaLicenca()
                {
                    Id = int.Parse(row["Id"].ToString()),
                    LicencaId = int.Parse(row["LicencaId"].ToString()),
                    DataVencimento = Compactor.FromCompact(row["DataVencimento"].ToString()),
                    IdPagamento = Compactor.FromCompact(row["IdPagamento"].ToString()),
                    Prorrogado = bool.Parse(row["Prorrogado"].ToString())
                });
            }

            return result;
        }

        public ActionResult ListarFaturas(int licencaId)
        {
            List<FaturaLicenca> faturas = GetFaturas(licencaId);
            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", faturas));
        }

        private Licenca Find(string produtoId, string CPUID)
        {
            if (string.IsNullOrEmpty(CPUID))
                CPUID = Util.GetCPUID();

            SqlConnection conn = ConnectionManager.GetConnection();
            string sql = "SELECT TOP(1) * FROM Licenca WHERE ProdutoId = @ProdutoId AND CPUID = @CPU";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@ProdutoId", produtoId);
            cmd.Parameters.AddWithValue("@CPU", CPUID);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            dr.Close();
            conn.Close();

            if (dt.Rows.Count == 0)
                return null;

            DataRow row = dt.Rows[0];

            Licenca lic = new Licenca();
            lic.ContratoId = row["ContratoId"].ToString();
            lic.ClienteId = row["ClienteId"].ToString();
            lic.CPUID = row["CPUID"].ToString();
            lic.OS = row["OS"].ToString();
            lic.ProdutoId = row["ProdutoId"].ToString();
            lic.Id = int.Parse(row["Id"].ToString());
            lic.ProdutoDescricao = row["ProdutoDescricao"].ToString();
            lic.MaximoUsuarios = row["MaximoUsuarios"].ToString();
            lic.ModeloLicenca = int.Parse(row["ModeloLicenca"].ToString());
            lic.Cnpj = row["Cnpj"].ToString();
            lic.Situacao = row["Situacao"].ToString();

            return lic;
        }

        public ActionResult GetLicenca(int produtoId, string CPUID, string cnpj)
        {
            string key = $"LIC-{produtoId}-{CPUID}-{cnpj}";
            Cache<Licenca> cached = CacheRepository<Licenca>.Get(key);
            if (cached != null)
                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", cached.Value));

            string pId = Compactor.ToCompact(produtoId.ToString());
            cnpj = Compactor.ToCompact(cnpj);
            if (string.IsNullOrEmpty(CPUID))
                CPUID = Util.GetCPUID();

            string sql = $@"select top(1) * from Licenca where produtoId = '{pId}' and 
CPUID = '{CPUID}' and cnpj = '{cnpj}'";

            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            SqlDataReader dr = cmd.ExecuteReader();

            Licenca lic = null;

            if (dr.HasRows)
            {
                dr.Read();

                lic = new Licenca();
                lic.ContratoId = Compactor.FromCompact(dr.GetString(0));
                lic.ClienteId = Compactor.FromCompact(dr.GetString(1));
                lic.CPUID = dr.GetString(2);
                lic.OS = dr.GetString(3);
                lic.ProdutoId = Compactor.FromCompact(dr.GetString(4));
                lic.Id = dr.GetInt32(5);
                lic.ProdutoDescricao = dr.GetString(6);
                lic.MaximoUsuarios = Compactor.FromCompact(dr.GetString(7));
                lic.ModeloLicenca = dr.GetInt32(8);
                lic.Cnpj = Compactor.FromCompact(dr.GetString(9));
                lic.Situacao = Compactor.FromCompact(dr.GetString(10));
            }

            dr.Close();
            conn.Close();

            if (lic != null)
                CacheRepository<Licenca>.Set(key, lic, 60);

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", lic));
        }

        public ActionResult ValidaLicenca(int produtoId, int usuarios, string CPUID,
            string cnpj)
        {
            Licenca licenca = Find(Compactor.ToCompact(produtoId.ToString()), CPUID);
            if (licenca == null)
                return ActionResult.Json(new OperationResult(StatusResult.NAO_ENCONTRADO, "-20:Licença não encontrada", null));

            try
            {
                if (licenca.ModeloLicenca == (int)TipoLicenca.Usuario)
                    ValidaLicencaUsuario(licenca, usuarios, cnpj);

                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "1:Licença ok", null));
            }
            catch (Exception ex)
            {
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_VALIDACAO, ex.Message, null));
            }
        }

        private void ValidaLicencaUsuario(Licenca licenca, int usuarios, string cnpjEnviado)
        {
            if (Compactor.FromCompact(licenca.Situacao).Equals("B"))
                throw new Exception("-20:O uso deste produto não está autorizado para o servidor atual devido a um bloqueio de hardware (HARDLOCK). \nAcione o suporte Doware.");

            if (usuarios > int.Parse(Compactor.FromCompact(licenca.MaximoUsuarios)))
                throw new Exception("-10:O número de usuários ativos excede o limite máximo permitido. \nAcione o suporte Doware.");

            string cnpjBanco = Compactor.FromCompact(licenca.Cnpj);
            if (cnpjBanco != cnpjEnviado)
                throw new Exception("-65:Este produto não está licenciado para este CNPJ. \nAcione o suporte Doware.");

            List<FaturaLicenca> faturas = GetFaturas(licenca.Id);
            List<FaturaLicenca> faturasVencidas = faturas.Where(f =>
                        DateTime.Parse(f.DataVencimento).Date <= DateTime.Now.Date &&
                        Guid.Parse(f.IdPagamento) == Guid.Empty)
                        .ToList();

            if (faturasVencidas.Count > 0)
            {
                if (faturasVencidas.Any(f =>
                     (DateTime.Now - DateTime.Parse(f.DataVencimento)).Days >= 1))
                {
                    FaturaLicenca fatVencida = faturasVencidas.FirstOrDefault(f => (DateTime.Now - DateTime.Parse(f.DataVencimento)).Days >= 1);
                    DateTime dataVenc = Convert.ToDateTime(fatVencida.DataVencimento);
                    int diasPassados = (DateTime.Now - dataVenc.Date).Days;
                    if (diasPassados > 15)
                        throw new Exception("-30:Licença do produto expirada");

                    if (fatVencida.Prorrogado)
                        throw new Exception("-30:Licença do produto expirada");
                    else
                        throw new Exception("-35:Licença do produto expirada");
                }
            }
            else
            {
                FaturaLicenca ultimaPaga = faturas.Where(e => e.IdPagamento != Guid.Empty.ToString()).LastOrDefault();
                if (ultimaPaga == null)
                    return;

                DateTime proximaData = DateTime.Parse(ultimaPaga.DataVencimento).AddMonths(1);

                FaturaLicenca proximaFatura = faturas.Where(e => e.IdPagamento == Guid.Empty.ToString() &&
                    DateTime.Parse(e.DataVencimento) <= proximaData.Date).FirstOrDefault();
                if (proximaFatura == null)
                    return;


                bool fimContrato = (faturas.Where(e => DateTime.Parse(e.DataVencimento).Date.AddMonths(1) > proximaData).Count() == 0);
                if (fimContrato)
                    throw new Exception("-35:O contrato do produto chegou ao fim. Entre em contato com o setor financeiro da Doware para realizar a renovação do contrato");
                
                int diasParaVencer = (DateTime.Parse(proximaFatura.DataVencimento).Date - DateTime.Now.Date).Days;
                if (diasParaVencer <= 5)
                    throw new Exception($"-40:Faltam {diasParaVencer} dias para a licença do produto expirar");
            }
        }

        public ActionResult ProrrogarFatura(int produtoId, string CPUID,
            string dataFatura)
        {
            Licenca lic = Find(Compactor.ToCompact(produtoId.ToString()), CPUID);
            FaturaLicenca fatura = GetFaturas(lic.Id)
                .Where(f => f.IdPagamento == Guid.Empty.ToString() &&
                        Convert.ToDateTime(f.DataVencimento).Date <= Convert.ToDateTime(dataFatura).Date)
                .FirstOrDefault();

            if (fatura == null)
                return ActionResult.Json(new OperationResult(StatusResult.NAO_ENCONTRADO, "Fatura não encontrada", null));

            if (fatura.Prorrogado)
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_VALIDACAO, "Esta fatura já foi prorrogada", null));

            fatura.DataVencimento = Convert.ToDateTime(fatura.DataVencimento).AddDays(15).ToString("yyyy-MM-dd");
            AtualizarFatura(fatura);

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Fatura atualizada", null));
        }

        private void AtualizarFatura(FaturaLicenca fatura)
        {
            string sql = @"UPDATE FaturaLicenca SET DataVencimento = @DataVencimento, Prorrogado = 1 
WHERE FaturaLicenca.Id = @Id";
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@DataVencimento", Compactor.ToCompact(fatura.DataVencimento));
            cmd.Parameters.AddWithValue("@Id", fatura.Id);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
