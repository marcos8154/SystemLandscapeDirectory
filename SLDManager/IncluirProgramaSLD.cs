using SLDClient;
using SLDClient.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SLDManager
{
    public partial class IncluirProgramaSLD : Form
    {
        public IncluirProgramaSLD()
        {
            InitializeComponent();

            cbAmbiente.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPrograma.DropDownStyle = ComboBoxStyle.DropDownList;
            List<string> list = new ServerProgramController().ProgramasServidor();
            cbPrograma.DataSource = list;
            if (list.Count > 0)
                cbPrograma.SelectedIndex = 0;

            List<Ambiente> ambientes = new AmbienteController().ListarAmbientes("");
            ambientes.ForEach(a => cbAmbiente.Items.Add(a.Nome));
            if (ambientes.Count > 0)
                cbAmbiente.SelectedIndex = 0;
        }

        private void cbPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                panel.Controls.Clear();
                List<string> parametros = new ServerProgramController().ListarParametrosPrograma(cbPrograma.Text);
                parametros.ForEach(p =>
                {
                    if (!string.IsNullOrEmpty(p))
                        panel.Controls.Add(new ParametroControl(p.Split(':')[0], p.Split(':')[1]));
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                ServerProgramController controller = new ServerProgramController();

                if (ModoEdicao)
                    controller.Remove(ProgramaOriginal.Nome, ProgramaOriginal.Ambiente);

                string param = string.Empty;
                foreach (var item in panel.Controls)
                    param += $"{(item as ParametroControl).NomeParametro}={(item as ParametroControl).txValor.Text};";


                controller.Registrar(cbPrograma.Text, cbAmbiente.Text, param);

                if (ModoEdicao)
                    MessageBox.Show("O programa foi modificado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("O programa foi registrado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private ProgramaServidor ProgramaOriginal = null;

        private bool ModoEdicao { get; set; }
        public void FillForm(ProgramaServidor p)
        {
            ProgramaOriginal = p;
            ModoEdicao = true;

            cbPrograma.SelectedItem = p.Nome;
            cbAmbiente.SelectedItem = p.Ambiente;

            string[] parametros = p.ValoresParametros.Split(';');
            foreach (string par in parametros)
            {
                foreach (var item in panel.Controls)
                {
                    var parametroUi = (item as ParametroControl);
                    if (parametroUi.NomeParametro.Equals(par.Split('=')[0]))
                        parametroUi.txValor.Text = par.Split('=')[1];
                }
            }
        }
    }
}
