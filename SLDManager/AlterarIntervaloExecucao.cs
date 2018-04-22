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
    public partial class AlterarIntervaloExecucao : Form
    {
        private ProgramaServidor Programa { get; set; }

        public AlterarIntervaloExecucao(ProgramaServidor programa)
        {
            InitializeComponent();

            Programa = programa;
            txIntervalo.Value = programa.IntervaloExecucao;
            ckExecutarNoInicio.Checked = programa.ExecutaNaInicializacao;
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btAplicar_Click(object sender, EventArgs e)
        {
            new ServerProgramController().AlterarIntervaloExecucao(Programa.Nome,
                Programa.Ambiente, (int)txIntervalo.Value, ckExecutarNoInicio.Checked);
            Close();
        }
    }
}
