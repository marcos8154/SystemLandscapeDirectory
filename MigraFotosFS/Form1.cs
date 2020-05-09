using MobileAppServerClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MigraFotosFS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private SqlConnection ConectarSQL()
        {
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.DataSource = txServidorSQL.Text;
            sb.UserID = txUsuario.Text;
            sb.Password = txSenha.Text;
            sb.InitialCatalog = txBanco.Text;

            SqlConnection conn = new SqlConnection(sb.ConnectionString);
            conn.Open();
            return conn;
        }

        private void btIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                Client.Configure(txServidorImg.Text, int.Parse(txPorta.Text),
                    10000000);

                var conn = ConectarSQL();
                MigraFotosTask task = new MigraFotosTask(conn,
                    txServidorImg.Text, int.Parse(txPorta.Text), this);
                task.Execute(1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        internal void SetProgresso(int count, int enviados)
        {
            progressBar.Maximum = count;
            progressBar.Value = enviados;
        }
    }
}
