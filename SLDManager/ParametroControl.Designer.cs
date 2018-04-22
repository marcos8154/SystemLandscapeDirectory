namespace SLDManager
{
    partial class ParametroControl
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

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbNomeParametro = new System.Windows.Forms.Label();
            this.txValor = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbNomeParametro
            // 
            this.lbNomeParametro.AutoSize = true;
            this.lbNomeParametro.Location = new System.Drawing.Point(3, 7);
            this.lbNomeParametro.Name = "lbNomeParametro";
            this.lbNomeParametro.Size = new System.Drawing.Size(35, 13);
            this.lbNomeParametro.TabIndex = 0;
            this.lbNomeParametro.Text = "label1";
            // 
            // txValor
            // 
            this.txValor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txValor.Location = new System.Drawing.Point(105, 4);
            this.txValor.Name = "txValor";
            this.txValor.Size = new System.Drawing.Size(245, 20);
            this.txValor.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(389, 10);
            this.panel1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Image = global::SLDManager.Properties.Resources.if_Help_27853;
            this.button1.Location = new System.Drawing.Point(356, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(26, 24);
            this.button1.TabIndex = 3;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ParametroControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txValor);
            this.Controls.Add(this.lbNomeParametro);
            this.Name = "ParametroControl";
            this.Size = new System.Drawing.Size(385, 29);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbNomeParametro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox txValor;
    }
}
