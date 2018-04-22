namespace SLDClient
{
    partial class RegistrarSistema
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrarSistema));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txNumeroContrato = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Panel = new System.Windows.Forms.Panel();
            this.btConfirmar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.txCnpj = new System.Windows.Forms.MaskedTextBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.LbProgress = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txCPU = new System.Windows.Forms.TextBox();
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.label1.Location = new System.Drawing.Point(60, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registrar software";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label2.Location = new System.Drawing.Point(62, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Informe os dados solicitados abaixo para ativar o produto";
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Location = new System.Drawing.Point(65, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 2);
            this.label4.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label5.Location = new System.Drawing.Point(63, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 18);
            this.label5.TabIndex = 8;
            this.label5.Text = "Número do contrato";
            // 
            // txNumeroContrato
            // 
            this.txNumeroContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txNumeroContrato.Location = new System.Drawing.Point(280, 99);
            this.txNumeroContrato.Name = "txNumeroContrato";
            this.txNumeroContrato.Size = new System.Drawing.Size(39, 24);
            this.txNumeroContrato.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(65, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 2);
            this.label3.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label6.Location = new System.Drawing.Point(62, 132);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "CNPJ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(55, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 10);
            this.panel1.TabIndex = 13;
            // 
            // Panel
            // 
            this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Panel.Controls.Add(this.btConfirmar);
            this.Panel.Controls.Add(this.btCancelar);
            this.Panel.Location = new System.Drawing.Point(-1, 274);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(517, 48);
            this.Panel.TabIndex = 14;
            // 
            // btConfirmar
            // 
            this.btConfirmar.Location = new System.Drawing.Point(298, 12);
            this.btConfirmar.Name = "btConfirmar";
            this.btConfirmar.Size = new System.Drawing.Size(75, 23);
            this.btConfirmar.TabIndex = 1;
            this.btConfirmar.Text = "&Confirmar";
            this.btConfirmar.UseVisualStyleBackColor = true;
            this.btConfirmar.Click += new System.EventHandler(this.btConfirmar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(379, 12);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 0;
            this.btCancelar.Text = "Ca&ncelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // txCnpj
            // 
            this.txCnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txCnpj.Location = new System.Drawing.Point(280, 129);
            this.txCnpj.Mask = "00,000,000/0000-00";
            this.txCnpj.Name = "txCnpj";
            this.txCnpj.Size = new System.Drawing.Size(173, 24);
            this.txCnpj.TabIndex = 15;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(2, 259);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(511, 18);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar.TabIndex = 16;
            this.ProgressBar.Visible = false;
            // 
            // LbProgress
            // 
            this.LbProgress.AutoSize = true;
            this.LbProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.LbProgress.Location = new System.Drawing.Point(12, 238);
            this.LbProgress.Name = "LbProgress";
            this.LbProgress.Size = new System.Drawing.Size(142, 18);
            this.LbProgress.TabIndex = 17;
            this.LbProgress.Text = "Número do contrato";
            this.LbProgress.Visible = false;
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(65, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(215, 2);
            this.label7.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label8.Location = new System.Drawing.Point(63, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "Hardware";
            // 
            // txCPU
            // 
            this.txCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.txCPU.Location = new System.Drawing.Point(280, 159);
            this.txCPU.Name = "txCPU";
            this.txCPU.ReadOnly = true;
            this.txCPU.Size = new System.Drawing.Size(173, 24);
            this.txCPU.TabIndex = 21;
            // 
            // RegistrarSistema
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 321);
            this.Controls.Add(this.txCPU);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LbProgress);
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.txCnpj);
            this.Controls.Add(this.Panel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txNumeroContrato);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarSistema";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar produto";
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txNumeroContrato;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btConfirmar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.MaskedTextBox txCnpj;
        public System.Windows.Forms.ProgressBar ProgressBar;
        public System.Windows.Forms.Label LbProgress;
        public System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txCPU;
    }
}