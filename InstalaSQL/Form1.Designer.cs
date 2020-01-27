namespace InstalaSQL
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.cbVersaoBanco = new System.Windows.Forms.ComboBox();
            this.lbVersaoDB = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btExecutar = new System.Windows.Forms.Button();
            this.txSenha = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ckHabilitaBrowser = new System.Windows.Forms.CheckBox();
            this.ckHabilitaTCP = new System.Windows.Forms.CheckBox();
            this.txNomeInstancia = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lnkAlterarCaminho = new System.Windows.Forms.LinkLabel();
            this.txCaminhoInstalador = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txChave = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configurador do servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(55, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(297, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Informe abaixo os parametros necessários para instalação do \r\nbanco de dados SQL";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txChave);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.cbVersaoBanco);
            this.panel1.Controls.Add(this.lbVersaoDB);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btExecutar);
            this.panel1.Controls.Add(this.txSenha);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.ckHabilitaBrowser);
            this.panel1.Controls.Add(this.ckHabilitaTCP);
            this.panel1.Controls.Add(this.txNomeInstancia);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lnkAlterarCaminho);
            this.panel1.Controls.Add(this.txCaminhoInstalador);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(1, 64);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(445, 367);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.button1.Location = new System.Drawing.Point(126, 329);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(189, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "ABRIR PORTAS NO FIREWALL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "Versão do SQL";
            // 
            // cbVersaoBanco
            // 
            this.cbVersaoBanco.FormattingEnabled = true;
            this.cbVersaoBanco.Location = new System.Drawing.Point(195, 104);
            this.cbVersaoBanco.Name = "cbVersaoBanco";
            this.cbVersaoBanco.Size = new System.Drawing.Size(225, 21);
            this.cbVersaoBanco.TabIndex = 17;
            // 
            // lbVersaoDB
            // 
            this.lbVersaoDB.AutoSize = true;
            this.lbVersaoDB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbVersaoDB.Location = new System.Drawing.Point(11, 72);
            this.lbVersaoDB.Name = "lbVersaoDB";
            this.lbVersaoDB.Size = new System.Drawing.Size(291, 13);
            this.lbVersaoDB.TabIndex = 16;
            this.lbVersaoDB.Text = "DEVE SER INSTALADA A VERSAO x86 DO SQL SERVER";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.pictureBox1.BackgroundImage = global::InstalaSQL.Properties.Resources._1499955337microsoft_sql_server_logo_png;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(11, 267);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 88);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // btExecutar
            // 
            this.btExecutar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btExecutar.Location = new System.Drawing.Point(328, 329);
            this.btExecutar.Name = "btExecutar";
            this.btExecutar.Size = new System.Drawing.Size(106, 23);
            this.btExecutar.TabIndex = 14;
            this.btExecutar.Text = "EXECUTAR";
            this.btExecutar.UseVisualStyleBackColor = true;
            this.btExecutar.Click += new System.EventHandler(this.btExecutar_Click);
            // 
            // txSenha
            // 
            this.txSenha.Location = new System.Drawing.Point(195, 157);
            this.txSenha.Name = "txSenha";
            this.txSenha.PasswordChar = '●';
            this.txSenha.Size = new System.Drawing.Size(225, 20);
            this.txSenha.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(133, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Senha do banco de dados";
            // 
            // ckHabilitaBrowser
            // 
            this.ckHabilitaBrowser.AutoSize = true;
            this.ckHabilitaBrowser.Checked = true;
            this.ckHabilitaBrowser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckHabilitaBrowser.Location = new System.Drawing.Point(195, 206);
            this.ckHabilitaBrowser.Name = "ckHabilitaBrowser";
            this.ckHabilitaBrowser.Size = new System.Drawing.Size(239, 17);
            this.ckHabilitaBrowser.TabIndex = 6;
            this.ckHabilitaBrowser.Text = "Habilitar o Navegador do SQL (SQL Browser)";
            this.ckHabilitaBrowser.UseVisualStyleBackColor = true;
            // 
            // ckHabilitaTCP
            // 
            this.ckHabilitaTCP.AutoSize = true;
            this.ckHabilitaTCP.Checked = true;
            this.ckHabilitaTCP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckHabilitaTCP.Location = new System.Drawing.Point(195, 183);
            this.ckHabilitaTCP.Name = "ckHabilitaTCP";
            this.ckHabilitaTCP.Size = new System.Drawing.Size(198, 17);
            this.ckHabilitaTCP.TabIndex = 5;
            this.ckHabilitaTCP.Text = "Habilitar TCP/IP no banco de dados";
            this.ckHabilitaTCP.UseVisualStyleBackColor = true;
            // 
            // txNomeInstancia
            // 
            this.txNomeInstancia.Location = new System.Drawing.Point(195, 131);
            this.txNomeInstancia.Name = "txNomeInstancia";
            this.txNomeInstancia.Size = new System.Drawing.Size(225, 20);
            this.txNomeInstancia.TabIndex = 4;
            this.txNomeInstancia.Text = "FrontStore";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nome da Instância";
            // 
            // lnkAlterarCaminho
            // 
            this.lnkAlterarCaminho.AutoSize = true;
            this.lnkAlterarCaminho.Location = new System.Drawing.Point(355, 68);
            this.lnkAlterarCaminho.Name = "lnkAlterarCaminho";
            this.lnkAlterarCaminho.Size = new System.Drawing.Size(80, 13);
            this.lnkAlterarCaminho.TabIndex = 2;
            this.lnkAlterarCaminho.TabStop = true;
            this.lnkAlterarCaminho.Text = "Alterar caminho";
            this.lnkAlterarCaminho.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlterarCaminho_LinkClicked);
            // 
            // txCaminhoInstalador
            // 
            this.txCaminhoInstalador.Location = new System.Drawing.Point(11, 29);
            this.txCaminhoInstalador.Multiline = true;
            this.txCaminhoInstalador.Name = "txCaminhoInstalador";
            this.txCaminhoInstalador.Size = new System.Drawing.Size(424, 36);
            this.txCaminhoInstalador.TabIndex = 1;
            this.txCaminhoInstalador.Text = "C:\\Program Files (x86)\\Doware Sistemas\\FrontStore\\Server\\SQL12_x86.exe\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(150, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Caminho do instalador do SQL";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::InstalaSQL.Properties.Resources.icone;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 43);
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Chave do produto (opcional)";
            // 
            // txChave
            // 
            this.txChave.Location = new System.Drawing.Point(195, 230);
            this.txChave.Name = "txChave";
            this.txChave.Size = new System.Drawing.Size(225, 20);
            this.txChave.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(195, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 39);
            this.label6.TabIndex = 22;
            this.label6.Text = "Caso nenhuma chave seja aplicada,\r\nserá ativado o SQL EXPRESS como\r\npadrão";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 431);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrontStore Server - Configurar Servidor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel lnkAlterarCaminho;
        private System.Windows.Forms.TextBox txCaminhoInstalador;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txNomeInstancia;
        private System.Windows.Forms.CheckBox ckHabilitaBrowser;
        private System.Windows.Forms.CheckBox ckHabilitaTCP;
        private System.Windows.Forms.TextBox txSenha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btExecutar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbVersaoDB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbVersaoBanco;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txChave;
        private System.Windows.Forms.Label label5;
    }
}

