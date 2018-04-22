using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SLDClient.Model;

namespace SLDClient
{
    public partial class RegistrarSistema : Form
    {
        public RegistrarSistema()
        {
            //    Application.EnableVisualStyles();
            InitializeComponent();

            txNumeroContrato.Text = "8";
            txCnpj.Text = "19.495.039/0001-55";
            txCPU.Text = Util.GetCPUID();
        }

        private void btConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                LicencaController controller = new LicencaController();
                controller.RegistrarSistema(int.Parse(txNumeroContrato.Text),
                    txCnpj.Text, txCPU.Text);

                MessageBox.Show("Registro OK", "SLD Client", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SLD Client", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
