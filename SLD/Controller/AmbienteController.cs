using MobileAppServer.ServerObjects;
using Newtonsoft.Json;
using SLD.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace SLD.Controller
{
    public class AmbienteController : IController
    {
   
        public ActionResult ServidorRegistrado()
        {
            try
            {
                SqlConnection conn = ConnectionManager.GetConnection();
                conn.Close();
                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Servidor registrado", null));
            }
            catch (Exception ex)
            {
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_VALIDACAO, ex.Message, null));
            }
        }

        private SqlConnection GetConnection(string servidor, string usuario, string senha)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = servidor;
            sb.UserID = usuario;
            sb.Password = senha;

            SqlConnection conn = new SqlConnection(sb.ConnectionString);

            conn.Open();
            return conn;
        }

        private bool BancoExiste(string servidor, string usuario, string senha)
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = servidor;
            sb.UserID = usuario;
            sb.Password = senha;
            sb.InitialCatalog = "SLD";

            SqlConnection conn = new SqlConnection(sb.ConnectionString);

            try
            {
                conn.Open();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public ActionResult RegistrarServidor(string servidor,
            string usuario, string senha)
        {
            try
            {
                string sqlCreate = @"
USE SLD

CREATE TABLE [dbo].[Ambiente](
	[Nome] [varchar](100) NOT NULL,
	[Servidor] [varchar](500) NOT NULL,
	[Usuario] [varchar](500) NOT NULL,
	[Senha] [varchar](500) NOT NULL,
	[Base] [varchar](500) NOT NULL,
	[Versao] [varchar](1000) NOT NULL,
	[Online] [bit] NOT NULL DEFAULT ((1)),
PRIMARY KEY CLUSTERED 
(
	[Nome] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

create table ProgramaServidor
(
	Id int identity(1,1) not null,
	Ambiente varchar(100) not null,
	Nome varchar(100) unique not null,
	Parametros varchar(3000) not null,
	ValoresParametros varchar(500) not null,
	IntervaloExecucao int not null default 5,
    ExecutaNaInicializacao bit not null default 0,

	primary key(Id)
)

CREATE TABLE [dbo].[FaturaLicenca](
	[Id] [int] NOT NULL,
	[LicencaId] [int] NOT NULL,
	[DataVencimento] [varchar](100) NOT NULL,
	[IdPagamento] [varchar](100) NULL,
	[Prorrogado] [bit] NOT NULL DEFAULT ((0)),
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

CREATE TABLE [dbo].[Licenca](
	[ContratoId] [varchar](100) NOT NULL,
	[ClienteId] [varchar](100) NOT NULL,
	[CPUID] [varchar](100) NOT NULL,
	[OS] [varchar](100) NOT NULL,
	[ProdutoId] [varchar](100) NOT NULL,
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ProdutoDescricao] [varchar](100) NOT NULL DEFAULT (''),
	[MaximoUsuarios] [varchar](100) NULL,
	[ModeloLicenca] [int] NOT NULL DEFAULT ((0)),
    [Cnpj] [varchar](100) NOT NULL,
    [Situacao] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
";

                string conf = $@"{servidor}
{usuario}
{senha}";

                if (BancoExiste(servidor, usuario, senha))
                {
                    File.WriteAllText(@".\Files\SLD.Conf", conf);
                    return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Servidor do SLD foi registrado", null));
                }

                SqlConnection conn = GetConnection(servidor, usuario, senha);
                SqlCommand cmd = new SqlCommand("CREATE DATABASE SLD", conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                conn = GetConnection(servidor, usuario, senha);
                cmd = new SqlCommand(sqlCreate, conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                File.WriteAllText(@".\Files\SLD.Conf", conf);
                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Servidor do SLD foi registrado", null));
            }
            catch (Exception ex)
            {
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_INTERNA, ex.Message, null));
            }
        }

        public ActionResult CriarAmbiente(string nome,
            string servidor, string usuario, string senha,
            string banco)
        {
            bool ambienteExiste = AmbienteExiste(nome);

            string sql = (ambienteExiste
               ? "update Ambiente set Servidor = @Servidor, Usuario = @Usuario, Senha = @Senha, Base = @Base, Versao = @Versao where Nome = @Nome"
               : @"insert into Ambiente (Nome, Servidor, Usuario, Senha, Base, Versao, Online)
values (@Nome, @Servidor, @Usuario, @Senha, @Base, @Versao, 1)");

            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Servidor", Compactor.ToCompact(servidor));
            cmd.Parameters.AddWithValue("@Usuario", Compactor.ToCompact(usuario));
            cmd.Parameters.AddWithValue("@Senha", Compactor.ToCompact(senha));
            cmd.Parameters.AddWithValue("@Base", Compactor.ToCompact(banco));
            cmd.Parameters.AddWithValue("@Versao", GetVersaoServidor());
            cmd.ExecuteNonQuery();
            conn.Close();

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Ambiente criado com sucesso", new Ambiente()));
        }

        private bool AmbienteExiste(string nome)
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("select count(*) from Ambiente where Nome = @nome", conn);
            cmd.Parameters.AddWithValue("@nome", nome);
            int count = int.Parse(cmd.ExecuteScalar().ToString());
            return (count > 0);
        }

        public ActionResult ListarAmbientes(string nome)
        {
            SqlConnection conn = null;
            try
            {
                List<Ambiente> list = new List<Ambiente>();
                conn = ConnectionManager.GetConnection();
                SqlCommand cmd = new SqlCommand("select ambiente.* from ambiente where Nome like @nome", conn);
                cmd.Parameters.AddWithValue("@nome", $"%{nome}%");
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(new Ambiente()
                        {
                            Nome = dr.GetString(0),
                            Servidor = Compactor.FromCompact(dr.GetString(1)),
                            Usuario = Compactor.FromCompact(dr.GetString(2)),
                            Senha = Compactor.FromCompact(dr.GetString(3)),
                            Base = Compactor.FromCompact(dr.GetString(4)),
                            Versao = dr.GetString(5),
                            Online = dr.GetBoolean(6)
                        });
                    }
                }
                dr.Close();
                conn.Close();

                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", list));
            }
            catch (Exception ex)
            {
                if (conn != null)
                    conn.Close();

                return ActionResult.Json(new OperationResult(StatusResult.FALHA_INTERNA, ex.Message, null));
            }
        }

        public ActionResult RemoverAmbiente(string nome)
        {
            try
            {
                SqlConnection conn = ConnectionManager.GetConnection();
                SqlCommand cmd = new SqlCommand("delete from Ambiente where Nome = @nome", conn);
                cmd.Parameters.AddWithValue("@nome", nome);
                cmd.ExecuteNonQuery();
                conn.Close();

                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Ambiente removido do servidor", null));
            }
            catch (Exception ex)
            {
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_INTERNA,
                    $"Ocorreu um problema ao excluir o ambiente: \n{ex.Message}", null));
            }
        }

        public string GetVersaoServidor()
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("select @@Version", conn);
            string version = cmd.ExecuteScalar().ToString();
            conn.Close();
            return version;
        }

        public ActionResult SetStatus(string ambiente, bool online)
        {
            string sql = "update Ambiente set Online = @online where Nome = @nome";
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@online", online);
            cmd.Parameters.AddWithValue("@nome", ambiente);
            cmd.ExecuteNonQuery();
            conn.Close();

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "Status do ambiente alterado.", null));
        }

        public ActionResult GetStatus(string ambiente)
        {
            SqlConnection conn = ConnectionManager.GetConnection();
            SqlCommand cmd = new SqlCommand("SELECT Online FROM Ambiente WHERE Nome = @Nome", conn);
            cmd.Parameters.AddWithValue("@Nome", ambiente);
            SqlDataReader dr = cmd.ExecuteReader();

            bool online = false;
            if (dr.HasRows)
            {
                dr.Read();
                online = Convert.ToBoolean(dr.GetBoolean(0));
            }

            dr.Close();
            conn.Close();

            return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK, "", online));
        }

        public ActionResult ValidarConexao(string servidor, string usuario, string senha,
            string banco)
        {
            try
            {
                SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
                sb.DataSource = servidor;
                sb.UserID = usuario;
                sb.Password = senha;
                sb.InitialCatalog = banco;

                SqlConnection conn = new SqlConnection(sb.ConnectionString);
                conn.Open();
                conn.Close();

                return ActionResult.Json(new OperationResult(StatusResult.OPERACAO_OK,
                    "Conexão OK!", null));
            }
            catch (Exception ex)
            {
                return ActionResult.Json(new OperationResult(StatusResult.FALHA_VALIDACAO,
                    ex.Message, null));
            }
        }

        public Tuple<bool, string> TestarConexao(string servidor, string usuario, string senha,
            string banco)
        {
            ActionResult result = ValidarConexao(servidor, usuario, senha, banco);
            OperationResult op = (OperationResult)JsonConvert.DeserializeObject(result.Content.ToString(), typeof(OperationResult));
            return (op.Status == (int)StatusResult.OPERACAO_OK
                ? new Tuple<bool, string>(true, "Conexao OK")
                : new Tuple<bool, string>(false, op.Message));
        }
    }
}
