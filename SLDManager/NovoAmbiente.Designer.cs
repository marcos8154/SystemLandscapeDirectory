namespace SLDManager
{
    partial class NovoAmbiente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NovoAmbiente));
            this.label1 = new System.Windows.Forms.Label();
            this.txNome = new System.Windows.Forms.TextBox();
            this.txServidor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txSenha = new System.Windows.Forms.TextBox();
            this.txBanco = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btSalvar = new System.Windows.Forms.Button();
            this.btTestarConexao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome";
            // 
            // txNome
            // 
            this.txNome.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txNome.Location = new System.Drawing.Point(107, 10);
            this.txNome.Name = "txNome";
            this.txNome.Size = new System.Drawing.Size(188, 20);
            this.txNome.TabIndex = 1;
            // 
            // txServidor
            // 
            this.txServidor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txServidor.Location = new System.Drawing.Point(107, 36);
            this.txServidor.Name = "txServidor";
            this.txServidor.Size = new System.Drawing.Size(188, 20);
            this.txServidor.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Servidor";
            // 
            // txUsuario
            // 
            this.txUsuario.Location = new System.Drawing.Point(107, 62);
            this.txUsuario.Name = "txUsuario";
            this.txUsuario.Size = new System.Drawing.Size(188, 20);
            this.txUsuario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuário";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Senha";
            // 
            // txSenha
            // 
            this.txSenha.Location = new System.Drawing.Point(107, 88);
            this.txSenha.Name = "txSenha";
            this.txSenha.PasswordChar = '●';
            this.txSenha.Size = new System.Drawing.Size(188, 20);
            this.txSenha.TabIndex = 7;
            // 
            // txBanco
            // 
            this.txBanco.Location = new System.Drawing.Point(107, 114);
            this.txBanco.Name = "txBanco";
            this.txBanco.Size = new System.Drawing.Size(188, 20);
            this.txBanco.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Base de dados";
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(219, 176);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 10;
            this.btCancelar.Text = "&Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btSalvar
            // 
            this.btSalvar.Location = new System.Drawing.Point(138, 176);
            this.btSalvar.Name = "btSalvar";
            this.btSalvar.Size = new System.Drawing.Size(75, 23);
            this.btSalvar.TabIndex = 11;
            this.btSalvar.Text = "&Salvar";
            this.btSalvar.UseVisualStyleBackColor = true;
            this.btSalvar.Click += new System.EventHandler(this.btSalvar_Click);
            // 
            // btTestarConexao
            // 
            this.btTestarConexao.Location = new System.Drawing.Point(57, 176);
            this.btTestarConexao.Name = "btTestarConexao";
            this.btTestarConexao.Size = new System.Drawing.Size(75, 23);
            this.btTestarConexao.TabIndex = 12;
            this.btTestarConexao.Text = "&Testar";
            this.btTestarConexao.UseVisualStyleBackColor = true;
            this.btTestarConexao.Click += new System.EventHandler(this.btTestarConexao_Click);
            // 
            // NovoAmbiente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 216);
            this.Controls.Add(this.btTestarConexao);
            this.Controls.Add(this.btSalvar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.txBanco);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txSenha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txUsuario);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txServidor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txNome);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NovoAmbiente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adicionar novo ambiente";
            this.Load += new System.EventHandler(this.NovoAmbiente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txNome;
        private System.Windows.Forms.TextBox txServidor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txSenha;
        private System.Windows.Forms.TextBox txBanco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btTestarConexao;
        private System.Windows.Forms.Button btSalvar;
    }
}