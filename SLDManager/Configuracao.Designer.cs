namespace SLDManager
{
    partial class Configuracao
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuracao));
            this.itemLicencaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ambienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btAlterarIntervalo = new System.Windows.Forms.Button();
            this.btModificar = new System.Windows.Forms.Button();
            this.btExecutar = new System.Windows.Forms.Button();
            this.btRemover = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridProgramas = new System.Windows.Forms.DataGridView();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txPesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btIncluirAmbiente = new System.Windows.Forms.Button();
            this.btAlterar = new System.Windows.Forms.Button();
            this.btRemoverAmbiente = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.itemLicencaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambienteBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProgramas)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btAlterarIntervalo);
            this.tabPage3.Controls.Add(this.btModificar);
            this.tabPage3.Controls.Add(this.btExecutar);
            this.tabPage3.Controls.Add(this.btRemover);
            this.tabPage3.Controls.Add(this.button1);
            this.tabPage3.Controls.Add(this.dataGridProgramas);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(731, 406);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Programas do servidor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btAlterarIntervalo
            // 
            this.btAlterarIntervalo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAlterarIntervalo.Image = global::SLDManager.Properties.Resources.if_cairo_clock_23728;
            this.btAlterarIntervalo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btAlterarIntervalo.Location = new System.Drawing.Point(341, 6);
            this.btAlterarIntervalo.Name = "btAlterarIntervalo";
            this.btAlterarIntervalo.Size = new System.Drawing.Size(114, 30);
            this.btAlterarIntervalo.TabIndex = 5;
            this.btAlterarIntervalo.Text = "Alterar intervalo";
            this.btAlterarIntervalo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btAlterarIntervalo.UseVisualStyleBackColor = true;
            this.btAlterarIntervalo.Click += new System.EventHandler(this.btAlterarIntervalo_Click);
            // 
            // btModificar
            // 
            this.btModificar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModificar.Image = global::SLDManager.Properties.Resources.if_stock_modify_layout_21628;
            this.btModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btModificar.Location = new System.Drawing.Point(558, 6);
            this.btModificar.Name = "btModificar";
            this.btModificar.Size = new System.Drawing.Size(88, 30);
            this.btModificar.TabIndex = 4;
            this.btModificar.Text = "Modificar";
            this.btModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btModificar.UseVisualStyleBackColor = true;
            this.btModificar.Click += new System.EventHandler(this.btModificar_Click);
            // 
            // btExecutar
            // 
            this.btExecutar.Image = global::SLDManager.Properties.Resources.if_Play_38826;
            this.btExecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btExecutar.Location = new System.Drawing.Point(6, 6);
            this.btExecutar.Name = "btExecutar";
            this.btExecutar.Size = new System.Drawing.Size(88, 30);
            this.btExecutar.TabIndex = 3;
            this.btExecutar.Text = "Executar";
            this.btExecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btExecutar.UseVisualStyleBackColor = true;
            this.btExecutar.Click += new System.EventHandler(this.btExecutar_Click);
            // 
            // btRemover
            // 
            this.btRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemover.Image = global::SLDManager.Properties.Resources.if_Delete_1493279;
            this.btRemover.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btRemover.Location = new System.Drawing.Point(461, 6);
            this.btRemover.Name = "btRemover";
            this.btRemover.Size = new System.Drawing.Size(91, 30);
            this.btRemover.TabIndex = 2;
            this.btRemover.Text = "Remover";
            this.btRemover.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btRemover.UseVisualStyleBackColor = true;
            this.btRemover.Click += new System.EventHandler(this.btRemover_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = global::SLDManager.Properties.Resources.if_gnome_app_install_23871__1_;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(652, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Incluir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridProgramas
            // 
            this.dataGridProgramas.AllowUserToAddRows = false;
            this.dataGridProgramas.AllowUserToDeleteRows = false;
            this.dataGridProgramas.AllowUserToOrderColumns = true;
            this.dataGridProgramas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridProgramas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProgramas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column11,
            this.Column10,
            this.Column12,
            this.Column13});
            this.dataGridProgramas.Location = new System.Drawing.Point(6, 42);
            this.dataGridProgramas.MultiSelect = false;
            this.dataGridProgramas.Name = "dataGridProgramas";
            this.dataGridProgramas.ReadOnly = true;
            this.dataGridProgramas.RowHeadersVisible = false;
            this.dataGridProgramas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProgramas.Size = new System.Drawing.Size(719, 358);
            this.dataGridProgramas.TabIndex = 0;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column11.DataPropertyName = "Nome";
            this.Column11.HeaderText = "Nome";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "Ambiente";
            this.Column10.HeaderText = "Ambiente";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "ValoresParametros";
            this.Column12.HeaderText = "Parametros";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 200;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "IntervaloExecucao";
            this.Column13.HeaderText = "Intervalo (minutos)";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 150;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txPesquisa);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btIncluirAmbiente);
            this.tabPage1.Controls.Add(this.btAlterar);
            this.tabPage1.Controls.Add(this.btRemoverAmbiente);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(731, 406);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Ambientes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txPesquisa
            // 
            this.txPesquisa.Location = new System.Drawing.Point(61, 12);
            this.txPesquisa.Name = "txPesquisa";
            this.txPesquisa.Size = new System.Drawing.Size(265, 20);
            this.txPesquisa.TabIndex = 6;
            this.txPesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txPesquisa_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Localizar";
            // 
            // btIncluirAmbiente
            // 
            this.btIncluirAmbiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btIncluirAmbiente.Location = new System.Drawing.Point(475, 10);
            this.btIncluirAmbiente.Name = "btIncluirAmbiente";
            this.btIncluirAmbiente.Size = new System.Drawing.Size(76, 23);
            this.btIncluirAmbiente.TabIndex = 3;
            this.btIncluirAmbiente.Text = "&Incluir";
            this.btIncluirAmbiente.UseVisualStyleBackColor = true;
            this.btIncluirAmbiente.Click += new System.EventHandler(this.btIncluirAmbiente_Click);
            // 
            // btAlterar
            // 
            this.btAlterar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAlterar.Location = new System.Drawing.Point(557, 10);
            this.btAlterar.Name = "btAlterar";
            this.btAlterar.Size = new System.Drawing.Size(78, 23);
            this.btAlterar.TabIndex = 2;
            this.btAlterar.Text = "&Alterar";
            this.btAlterar.UseVisualStyleBackColor = true;
            this.btAlterar.Click += new System.EventHandler(this.btAlterar_Click);
            // 
            // btRemoverAmbiente
            // 
            this.btRemoverAmbiente.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRemoverAmbiente.Location = new System.Drawing.Point(641, 10);
            this.btRemoverAmbiente.Name = "btRemoverAmbiente";
            this.btRemoverAmbiente.Size = new System.Drawing.Size(84, 23);
            this.btRemoverAmbiente.TabIndex = 1;
            this.btRemoverAmbiente.Text = "&Excluir";
            this.btRemoverAmbiente.UseVisualStyleBackColor = true;
            this.btRemoverAmbiente.Click += new System.EventHandler(this.btRemoverAmbiente_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column5,
            this.Usuario,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9});
            this.dataGridView1.Location = new System.Drawing.Point(6, 39);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(719, 353);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column4.DataPropertyName = "Nome";
            this.Column4.HeaderText = "Nome";
            this.Column4.MinimumWidth = 150;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Servidor";
            this.Column5.HeaderText = "Servidor";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Senha";
            this.Column6.HeaderText = "Senha";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Base";
            this.Column7.HeaderText = "Base";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Versao";
            this.Column8.HeaderText = "Versao";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 200;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "Online";
            this.Column9.HeaderText = "Online";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(5, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 432);
            this.tabControl1.TabIndex = 0;
            // 
            // Configuracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 438);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar Ambientes para o FrontStore - SLD Manager  - Doware Soluções";
            this.VisibleChanged += new System.EventHandler(this.Configuracao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemLicencaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ambienteBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProgramas)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource ambienteBindingSource;
        private System.Windows.Forms.BindingSource itemLicencaBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn servidorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn senhaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn baseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn versaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn onlineDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuariosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn produtoDescricaoDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btAlterarIntervalo;
        private System.Windows.Forms.Button btModificar;
        private System.Windows.Forms.Button btExecutar;
        private System.Windows.Forms.Button btRemover;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridProgramas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btIncluirAmbiente;
        private System.Windows.Forms.Button btAlterar;
        private System.Windows.Forms.Button btRemoverAmbiente;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.TabControl tabControl1;
    }
}