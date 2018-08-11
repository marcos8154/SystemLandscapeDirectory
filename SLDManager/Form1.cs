using SLDClient;
using SLDClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLDManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            try
            {
                if (!ServidorAtivado())
                {
                    Registrar r = new Registrar();
                    r.ShowDialog();

                    if (!ServidorAtivado())
                        Environment.Exit(1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
   
            }

            txServidor.Text = Environment.MachineName;
            ListarAmbientes();
        }

        private bool ServidorAtivado()
        {
            AmbienteController controller = new AmbienteController();
            return controller.ServidorRegistrado();
        }

        private void ListarAmbientes()
        {
            try
            {
                Client client = new Client();
                AmbienteController controller = new AmbienteController();
                List<Ambiente> ambientes = controller.ListarAmbientes("");
                cbAmbientes.DataSource = ambientes;
                cbAmbientes.DisplayMember = "Nome";
                cbAmbientes.ValueMember = "Nome";

                if (ambientes.Count > 0)
                    ShowStatus(ambientes[0].Nome);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Configuracao conf = new Configuracao();
            conf.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(1000, "Doware FrontStore - SLD Manager", "Clique para restaurar", ToolTipIcon.Info);
                this.Hide();
                this.ShowInTaskbar = false;
            }
            else
            {
                this.ShowInTaskbar = true;
                notifyIcon.Visible = false;
            }
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
            this.TopMost = true;
            this.TopMost = false;
        }

        private void ShowStatus(string ambiente)
        {
            try
            {
                AmbienteController controller = new AmbienteController();
                bool online = controller.AmbienteOnline(ambiente);

                if (online)
                {
                    btSetOffline.Enabled = true;
                    btSetOnline.Enabled = false;
                    lbStatusAmbiente.Text = "Online";
                }
                else
                {
                    btSetOffline.Enabled = false;
                    btSetOnline.Enabled = true;
                    lbStatusAmbiente.Text = "Offline";
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void cbAmbientes_TextChanged(object sender, EventArgs e)
        {
            ShowStatus(cbAmbientes.Text);
        }

        private void btSetOffline_Click(object sender, EventArgs e)
        {
            try
            {
                AmbienteController controller = new AmbienteController();
                controller.SetStatus(cbAmbientes.Text, false);
                ShowStatus(cbAmbientes.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSetOnline_Click(object sender, EventArgs e)
        {
            try
            {
                AmbienteController controller = new AmbienteController();
                controller.SetStatus(cbAmbientes.Text, true);
                ShowStatus(cbAmbientes.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
