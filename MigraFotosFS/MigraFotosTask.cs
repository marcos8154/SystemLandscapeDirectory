using MobileAppServerClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigraFotosFS
{
    public class MigraFotosTask : AsyncTask<int, TaskParams, bool>
    {
        public MigraFotosTask(SqlConnection conexaoSQL,
            string servidor, int porta, Form1 view)
        {
            ConexaoSQL = conexaoSQL;
            Servidor = servidor;
            Porta = porta;
            View = view;
        }

        public SqlConnection ConexaoSQL { get; }
        public string Servidor { get; }
        public int Porta { get; }
        public Form1 View { get; }

        private int GetCountProdutosFoto()
        {
            SqlCommand cmd = new SqlCommand(@"select count(*) from Produtos
where Foto != '' or Foto != null", ConexaoSQL);
            int count = (int)cmd.ExecuteScalar();
            return count;
        }

        public override bool DoInBackGround(int param)
        {
            int count = GetCountProdutosFoto();

            SqlCommand cmd = new SqlCommand(@"select Id, Foto from Produtos
where Foto != '' or Foto != null", ConexaoSQL);
            SqlDataReader dr = cmd.ExecuteReader();
            if(dr.HasRows)
            {
                int enviados = 0;
                while(dr.Read())
                {
                    try
                    {
                        int produtoId = dr.GetInt32(0);
                        byte[] fotoArray = (byte[])dr.GetValue(1);
                        string base64Foto = Convert.ToBase64String(fotoArray);

                        UploadFoto(produtoId, base64Foto);
                        enviados += 1;
                        UpdateProgress(TaskParams.Create()
                            .Set("count", count)
                            .Set("enviados", enviados));
                    }
                    catch
                    {

                    }
                }
            }
            return true;
        }

        private void UploadFoto(int produtoId, string base64Foto)
        {
            Client client = new Client();
            RequestBody rb = RequestBody.Create("ImageController", "Upload")
                .AddParameter("produtoId", produtoId)
                .AddParameter("base64Image", base64Foto);

            client.SendRequest(rb);
            client.GetResult();
        }

        public override void OnPostExecute(bool result)
        {
            View.btIniciar.Enabled = true;
            View.progressBar.Visible = false;
            MessageBox.Show("Upload concluido");
        }

        public override void OnPreExecute()
        {
            View.progressBar.Visible = true;
            View.btIniciar.Enabled = false;
        }

        public override void OnProgressUpdate(TaskParams progress)
        {
            int count = progress.GetInt("count");
            int enviados = progress.GetInt("enviados");
            View.SetProgresso(count, enviados);
        }
    }
}
