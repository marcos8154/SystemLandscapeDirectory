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
    public partial class Configuracao : Form
    {
        public Configuracao()
        {
            InitializeComponent();
            dataGridProgramas.AutoGenerateColumns = false;
            dataGridProgramas.DataSource = new ServerProgramController().ListarProgramas();
        }
        
        private void BuscarAmbientes()
        {
            try
            {
                AmbienteController controller = new AmbienteController();
                List<Ambiente> list = controller.ListarAmbientes(txPesquisa.Text);
                list.ForEach(a => a.Senha = "****");
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void btIncluirAmbiente_Click(object sender, EventArgs e)
        {
            NovoAmbiente novo = new NovoAmbiente();
            novo.ShowDialog();

            BuscarAmbientes();
        }

        private void Configuracao_Load(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                BuscarAmbientes();
            }
        }

        private void txPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = e.SuppressKeyPress = true;
                BuscarAmbientes();
            }
        }

        private void btAlterar_Click(object sender, EventArgs e)
        {
            var currentRow = dataGridView1.CurrentRow;
            AmbienteController controller = new AmbienteController();
            Ambiente ambiente = controller.GetAmbiente(currentRow.Cells[0].Value.ToString());
            if (ambiente == null)
                return;

            NovoAmbiente cadastro = new NovoAmbiente();
            cadastro.Fill(ambiente);
            cadastro.ShowDialog();

            BuscarAmbientes();
        }

        private void btRemoverAmbiente_Click(object sender, EventArgs e)
        {
            var currentRow = dataGridView1.CurrentRow;
            DialogResult res = MessageBox.Show($@"Confirmar a remoção do ambiente '{currentRow.Cells[0].Value.ToString()}' no servidor?
Sistemas ou módulos conectados a ele irão parar de funcionar!
Tenha certeza do que está fazendo!", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            try
            {
                AmbienteController controller = new AmbienteController();
                controller.RemoverAmbiente(currentRow.Cells[0].Value.ToString());
                BuscarAmbientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SLD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            IncluirProgramaSLD i = new IncluirProgramaSLD();
            i.ShowDialog();

            dataGridProgramas.DataSource = new ServerProgramController().ListarProgramas();
        }

        private void btRemover_Click(object sender, EventArgs e)
        {
            if (dataGridProgramas.CurrentRow == null)
                return;

            ProgramaServidor p = (dataGridProgramas.DataSource as List<ProgramaServidor>)[dataGridProgramas.CurrentRow.Index];
            if (p == null)
                return;

            DialogResult res = MessageBox.Show($"Confirmar a remoção do programa '{p.Nome}' do ambiente '{p.Ambiente}'? \nEsta ação não poderá ser revertida!",
                "Remover programa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
                return;

            ServerProgramController controller = new ServerProgramController();
            controller.Remove(p.Nome, p.Ambiente);
            dataGridProgramas.DataSource = new ServerProgramController().ListarProgramas();
        }

        private void btModificar_Click(object sender, EventArgs e)
        {
            if (dataGridProgramas.CurrentRow == null)
                return;

            ProgramaServidor p = (dataGridProgramas.DataSource as List<ProgramaServidor>)[dataGridProgramas.CurrentRow.Index];
            if (p == null)
                return;

            IncluirProgramaSLD i = new IncluirProgramaSLD();
            i.FillForm(p);
            i.ShowDialog();

            dataGridProgramas.DataSource = new ServerProgramController().ListarProgramas();
        }

        private void btAlterarIntervalo_Click(object sender, EventArgs e)
        {
            if (dataGridProgramas.CurrentRow == null)
                return;

            ProgramaServidor p = (dataGridProgramas.DataSource as List<ProgramaServidor>)[dataGridProgramas.CurrentRow.Index];
            if (p == null)
                return;

            AlterarIntervaloExecucao alterarIntervalo = new AlterarIntervaloExecucao(p);
            alterarIntervalo.ShowDialog(); dataGridProgramas.DataSource = new ServerProgramController().ListarProgramas();
        }

        private void btExecutar_Click(object sender, EventArgs e)
        {
            if (dataGridProgramas.CurrentRow == null)
                return;

            ProgramaServidor p = (dataGridProgramas.DataSource as List<ProgramaServidor>)[dataGridProgramas.CurrentRow.Index];
            if (p == null)
                return;

            new ServerProgramController().Executar(p.Nome, p.Ambiente);
            MessageBox.Show("A solicitação foi enviada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
