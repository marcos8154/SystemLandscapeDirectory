using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SLDClient
{
    public partial class Registrar : Form
    {
        public Registrar()
        {
    //        Application.EnableVisualStyles();
            InitializeComponent();
        }

        private void Registrar_Load(object sender, EventArgs e)
        {

        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void btProximo_Click(object sender, EventArgs e)
        {
            try
            {
                AmbienteController controller = new AmbienteController();
                controller.RegistrarServidor(txServidor.Text, txUsuario.Text, txSenha.Text);
                MessageBox.Show("Servidor registrado", "SLD Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SLD Client", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
