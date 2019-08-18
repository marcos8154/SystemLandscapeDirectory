using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InstalaSQL
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            FillVersaoSQL();

            if (Environment.Is64BitOperatingSystem)
                txCaminhoInstalador.Text = @"C:\Program Files (x86)\Doware Sistemas\FrontStore\Server\SQL12_x64.exe";
            else
                txCaminhoInstalador.Text = @"C:\Program Files\Doware Sistemas\FrontStore\Server\SQL12_x86.exe";
        }

        private async void btExecutar_Click(object sender, EventArgs e)
        {
            btExecutar.Enabled = false;
            btExecutar.Text = "AGUARDE...";

            string caminhoInstalador = txCaminhoInstalador.Text;
            string nomeInstancia = txNomeInstancia.Text;
            string senha = txSenha.Text;
            string habilitaTCP = (ckHabilitaTCP.Checked ? "1" : "0");
            string habilitaBrowse = (ckHabilitaBrowser.Checked ? "Automatic" : "Manual");
            string pastaVersao = cbVersaoBanco.SelectedValue.ToString();
            ApagaArquivosLOG();

            await Task.Run(() =>
            {
                try
                {
                    string parametros = $@"/ACTION=install /UpdateEnabled=0 /QS /INSTANCENAME=""{nomeInstancia}"" /BROWSERSVCSTARTUPTYPE={habilitaBrowse} /ERRORREPORTING=1 /INDICATEPROGRESS=1 /IACCEPTSQLSERVERLICENSETERMS=1 /FEATURES=SQL /ADDCURRENTUSERASSQLADMIN=1 /SECURITYMODE=SQL /SAPWD=""{senha}"" /TCPENABLED={habilitaTCP}";
                    var process = System.Diagnostics.Process.Start(caminhoInstalador, parametros);
                    process.WaitForExit();

                    string baseDir = $@"C:\Program Files\Microsoft SQL Server\{pastaVersao}\Setup Bootstrap\Log\";
                    DirectoryInfo info = new DirectoryInfo(baseDir);
                    foreach (DirectoryInfo dir in info.GetDirectories())
                        if (dir.GetFiles().Any(f => f.Name.StartsWith("SystemConfigurationCheck")))
                        {
                            var file = dir.GetFiles().FirstOrDefault(f => f.Name.StartsWith("SystemConfigurationCheck"));
                            Process.Start(file.FullName);
                        }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });

            btExecutar.Enabled = true;
            btExecutar.Text = "EXECUTAR";
        }

        private void FillVersaoSQL()
        {
            List<KeyValuePair<string, string>> versoes = new List<KeyValuePair<string, string>>();
            versoes.Add(new KeyValuePair<string, string>("105", "2008 R2"));
            versoes.Add(new KeyValuePair<string, string>("110", "2012"));
            versoes.Add(new KeyValuePair<string, string>("120", "2014"));
            versoes.Add(new KeyValuePair<string, string>("130", "2016"));
            versoes.Add(new KeyValuePair<string, string>("140", "2017"));

            cbVersaoBanco.DisplayMember = "Value";
            cbVersaoBanco.ValueMember = "Key";
            cbVersaoBanco.DataSource = versoes;
            cbVersaoBanco.SelectedIndex = 1;
            cbVersaoBanco.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void lnkAlterarCaminho_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();

            if (string.IsNullOrEmpty(dialog.FileName))
                return;

            txCaminhoInstalador.Text = dialog.FileName;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Environment.Is64BitOperatingSystem)
                lbVersaoDB.Text = "DEVE SER INSTALADA A VERSÃO x64 DO SQL SERVER";
            else
                lbVersaoDB.Text = "DEVE SER INSTALADA A VERSÃO x86 DO SQL SERVER";

            ApagaArquivosLOG();
        }

        private void ApagaArquivosLOG()
        {
            try
            {
                string pastaVersao = cbVersaoBanco.SelectedValue.ToString();
                if (Directory.Exists($@"C:\Program Files\Microsoft SQL Server\{pastaVersao}\Setup Bootstrap\Log\"))
                    Directory.Delete($@"C:\Program Files\Microsoft SQL Server\{pastaVersao}\Setup Bootstrap\Log\", true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível apagar os arquivos de LOG do SQL Server: " + ex.Message,
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var process = Process.Start(@"AbrePortas.exe");
                process.WaitForExit();
                MessageBox.Show("As portas foram liberadas no Firewall do Windows. \nO Configurador do SQL Server irá abrir em instantes. Defina uma PORTA TCP em \"Configuração de Rede\", e reinicie o serviço do SQL.",
                    "SRVCFG", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Process.Start("SQLSERVERMANAGER11.msc");
            }
            catch { }
        }
    }
}
