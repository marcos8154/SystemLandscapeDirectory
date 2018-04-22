using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SLDManager
{
    public partial class ParametroControl : UserControl
    {
        public string NomeParametro { get; private set; }
        private string Descricao { get; set; }
        public ParametroControl(string nome, string descricao)
        {
            InitializeComponent();

            NomeParametro = nome;
            Descricao = descricao;
            lbNomeParametro.Text = nome;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Descricao, NomeParametro, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
