namespace SLDManager
{
    partial class AlterarIntervaloExecucao
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
            this.txIntervalo = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ckExecutarNoInicio = new System.Windows.Forms.CheckBox();
            this.btCancelar = new System.Windows.Forms.Button();
            this.btAplicar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txIntervalo)).BeginInit();
            this.SuspendLayout();
            // 
            // txIntervalo
            // 
            this.txIntervalo.Location = new System.Drawing.Point(131, 41);
            this.txIntervalo.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.txIntervalo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txIntervalo.Name = "txIntervalo";
            this.txIntervalo.Size = new System.Drawing.Size(61, 20);
            this.txIntervalo.TabIndex = 0;
            this.txIntervalo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Intervalo de execução";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(198, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Minutos";
            // 
            // ckExecutarNoInicio
            // 
            this.ckExecutarNoInicio.AutoSize = true;
            this.ckExecutarNoInicio.Location = new System.Drawing.Point(131, 68);
            this.ckExecutarNoInicio.Name = "ckExecutarNoInicio";
            this.ckExecutarNoInicio.Size = new System.Drawing.Size(198, 17);
            this.ckExecutarNoInicio.TabIndex = 3;
            this.ckExecutarNoInicio.Text = "Executar na inicialização do servidor";
            this.ckExecutarNoInicio.UseVisualStyleBackColor = true;
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(201, 158);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(75, 23);
            this.btCancelar.TabIndex = 4;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // btAplicar
            // 
            this.btAplicar.Location = new System.Drawing.Point(120, 158);
            this.btAplicar.Name = "btAplicar";
            this.btAplicar.Size = new System.Drawing.Size(75, 23);
            this.btAplicar.TabIndex = 5;
            this.btAplicar.Text = "Aplicar";
            this.btAplicar.UseVisualStyleBackColor = true;
            this.btAplicar.Click += new System.EventHandler(this.btAplicar_Click);
            // 
            // AlterarIntervaloExecucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(339, 225);
            this.Controls.Add(this.btAplicar);
            this.Controls.Add(this.btCancelar);
            this.Controls.Add(this.ckExecutarNoInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txIntervalo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlterarIntervaloExecucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alterar intervalo de execução do programa";
            ((System.ComponentModel.ISupportInitialize)(this.txIntervalo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txIntervalo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ckExecutarNoInicio;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Button btAplicar;
    }
}