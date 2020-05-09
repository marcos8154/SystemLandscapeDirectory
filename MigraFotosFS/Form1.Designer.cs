namespace MigraFotosFS
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txServidorSQL = new System.Windows.Forms.TextBox();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txBanco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txSenha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btIniciar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txServidorImg = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txPorta = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(396, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Migrar fotos de produtos do FrontStore para o \r\nservidor de imagens\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Servidor MSSQL";
            // 
            // txServidorSQL
            // 
            this.txServidorSQL.Location = new System.Drawing.Point(126, 96);
            this.txServidorSQL.Name = "txServidorSQL";
            this.txServidorSQL.Size = new System.Drawing.Size(174, 20);
            this.txServidorSQL.TabIndex = 1;
            // 
            // txUsuario
            // 
            this.txUsuario.Location = new System.Drawing.Point(126, 122);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.Size = new System.Drawing.Size(65, 20);
            this.txUsuario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Usuário";
            // 
            // txBanco
            // 
            this.txBanco.Location = new System.Drawing.Point(126, 174);
            this.txBanco.Name = "txBanco";
            this.txBanco.Size = new System.Drawing.Size(174, 20);
            this.txBanco.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Base de dados";
            // 
            // txSenha
            // 
            this.txSenha.Location = new System.Drawing.Point(126, 148);
            this.txSenha.Name = "txSenha";
            this.txSenha.PasswordChar = '*';
            this.txSenha.Size = new System.Drawing.Size(174, 20);
            this.txSenha.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(73, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Senha";
            // 
            // btIniciar
            // 
            this.btIniciar.Location = new System.Drawing.Point(126, 301);
            this.btIniciar.Name = "btIniciar";
            this.btIniciar.Size = new System.Drawing.Size(115, 23);
            this.btIniciar.TabIndex = 7;
            this.btIniciar.Text = "Iniciar Migração";
            this.btIniciar.UseVisualStyleBackColor = true;
            this.btIniciar.Click += new System.EventHandler(this.btIniciar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(16, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fonte dos dados";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label7.Location = new System.Drawing.Point(16, 218);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Destino dos dados";
            // 
            // txServidorImg
            // 
            this.txServidorImg.Location = new System.Drawing.Point(126, 234);
            this.txServidorImg.Name = "txServidorImg";
            this.txServidorImg.Size = new System.Drawing.Size(174, 20);
            this.txServidorImg.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 238);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Servidor de imagens";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(79, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Porta";
            // 
            // txPorta
            // 
            this.txPorta.Location = new System.Drawing.Point(126, 260);
            this.txPorta.Name = "txPorta";
            this.txPorta.Size = new System.Drawing.Size(65, 20);
            this.txPorta.TabIndex = 6;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 339);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(411, 23);
            this.progressBar.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(435, 374);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txPorta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txServidorImg);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btIniciar);
            this.Controls.Add(this.txSenha);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txBanco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txServidorSQL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Migrar imagens do FrontStore";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txServidorSQL;
        private System.Windows.Forms.TextBox txUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txBanco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txSenha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txServidorImg;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txPorta;
        public System.Windows.Forms.Button btIniciar;
        public System.Windows.Forms.ProgressBar progressBar;
    }
}

