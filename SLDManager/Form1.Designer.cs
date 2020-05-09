namespace SLDManager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btOK = new System.Windows.Forms.Button();
            this.cbAmbientes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.btSetOnline = new System.Windows.Forms.Button();
            this.btSetOffline = new System.Windows.Forms.Button();
            this.lbStatusAmbiente = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(213, 203);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(75, 23);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "OK";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbAmbientes
            // 
            this.cbAmbientes.FormattingEnabled = true;
            this.cbAmbientes.Location = new System.Drawing.Point(81, 38);
            this.cbAmbientes.Name = "cbAmbientes";
            this.cbAmbientes.Size = new System.Drawing.Size(205, 21);
            this.cbAmbientes.TabIndex = 3;
            this.cbAmbientes.TextChanged += new System.EventHandler(this.cbAmbientes_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Ambiente";
            // 
            // txServidor
            // 
            this.txServidor.Location = new System.Drawing.Point(81, 12);
            this.txServidor.Name = "txServidor";
            this.txServidor.Size = new System.Drawing.Size(205, 20);
            this.txServidor.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Servidor";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(81, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "&Configurar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Doware Curae - SLD Manager";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(-3, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(302, 1);
            this.label3.TabIndex = 9;
            // 
            // btSetOnline
            // 
            this.btSetOnline.BackgroundImage = global::SLDManager.Properties.Resources.if_music_play_pause_control_go_arrow_blue_1872769;
            this.btSetOnline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetOnline.Location = new System.Drawing.Point(120, 65);
            this.btSetOnline.Name = "btSetOnline";
            this.btSetOnline.Size = new System.Drawing.Size(33, 31);
            this.btSetOnline.TabIndex = 10;
            this.btSetOnline.UseVisualStyleBackColor = true;
            this.btSetOnline.Click += new System.EventHandler(this.btSetOnline_Click);
            // 
            // btSetOffline
            // 
            this.btSetOffline.BackgroundImage = global::SLDManager.Properties.Resources.if_music_square_stop_play_pause_blue_1872776;
            this.btSetOffline.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btSetOffline.Location = new System.Drawing.Point(81, 65);
            this.btSetOffline.Name = "btSetOffline";
            this.btSetOffline.Size = new System.Drawing.Size(33, 31);
            this.btSetOffline.TabIndex = 8;
            this.btSetOffline.UseVisualStyleBackColor = true;
            this.btSetOffline.Click += new System.EventHandler(this.btSetOffline_Click);
            // 
            // lbStatusAmbiente
            // 
            this.lbStatusAmbiente.AutoSize = true;
            this.lbStatusAmbiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.lbStatusAmbiente.Location = new System.Drawing.Point(159, 74);
            this.lbStatusAmbiente.Name = "lbStatusAmbiente";
            this.lbStatusAmbiente.Size = new System.Drawing.Size(50, 18);
            this.lbStatusAmbiente.TabIndex = 11;
            this.lbStatusAmbiente.Text = "Offline";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(11, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "SLD Manager - v1.2.20";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(11, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "powered by Doware Soluções";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(298, 234);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbStatusAmbiente);
            this.Controls.Add(this.btSetOnline);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btSetOffline);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txServidor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbAmbientes);
            this.Controls.Add(this.btOK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doware - SLD Manager";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btOK;
        private System.Windows.Forms.ComboBox cbAmbientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Button btSetOffline;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSetOnline;
        private System.Windows.Forms.Label lbStatusAmbiente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

