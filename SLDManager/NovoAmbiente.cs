using SLDClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLDClient.Model;

namespace SLDManager
{
    public partial class NovoAmbiente : Form
    {
        public NovoAmbiente()
        {
            InitializeComponent();
        }

        private void NovoAmbiente_Load(object sender, EventArgs e)
        {

        }

        private void btTestarConexao_Click(object sender, EventArgs e)
        {
            try
            {
                AmbienteController controller = new AmbienteController();
                controller.ValidarConexao(txServidor.Text,
                    txUsuario.Text,
                    txSenha.Text,
                    txBanco.Text);

                MessageBox.Show("Conexão OK!", "SLD Environment Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SLD Environment Test", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                AmbienteController controller = new AmbienteController();
                controller.CriarAmbiente(txNome.Text,
                    txServidor.Text,
                    txUsuario.Text,
                    txSenha.Text,
                    txBanco.Text);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SLD", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void Fill(Ambiente ambiente)
        {
            Text = "Alterar ambiente";
            txNome.Enabled = false;
            txNome.Text = ambiente.Nome;
            txServidor.Text = ambiente.Servidor;
            txUsuario.Text = ambiente.Usuario;
            txSenha.Text = ambiente.Senha;
            txBanco.Text = ambiente.Base;
        }
    }
}
