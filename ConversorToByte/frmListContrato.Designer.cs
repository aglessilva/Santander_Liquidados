namespace ConversorToByte
{
    partial class frmListContrato
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListContrato));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBoxDataFim = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDataIni = new System.Windows.Forms.MaskedTextBox();
            this.radioAtivos = new System.Windows.Forms.RadioButton();
            this.radioTypeContract = new System.Windows.Forms.RadioButton();
            this.radioLiquidados = new System.Windows.Forms.RadioButton();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.textBoxContratocpf = new System.Windows.Forms.TextBox();
            this.dataGridViewContract = new System.Windows.Forms.DataGridView();
            this.PersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Download = new System.Windows.Forms.DataGridViewImageColumn();
            this.T16 = new System.Windows.Forms.DataGridViewImageColumn();
            this.T18 = new System.Windows.Forms.DataGridViewImageColumn();
            this.T20 = new System.Windows.Forms.DataGridViewImageColumn();
            this.T25 = new System.Windows.Forms.DataGridViewImageColumn();
            this.T34 = new System.Windows.Forms.DataGridViewImageColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addContratosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContract)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Title = "Contratos Liquidados";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBoxDataFim);
            this.groupBox1.Controls.Add(this.maskedTextBoxDataIni);
            this.groupBox1.Controls.Add(this.radioAtivos);
            this.groupBox1.Controls.Add(this.radioTypeContract);
            this.groupBox1.Controls.Add(this.radioLiquidados);
            this.groupBox1.Controls.Add(this.btnLimpar);
            this.groupBox1.Controls.Add(this.textBoxContratocpf);
            this.groupBox1.Location = new System.Drawing.Point(2, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 69);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro por Contrato | NOME | CPF | CNPJ";
            // 
            // maskedTextBoxDataFim
            // 
            this.maskedTextBoxDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxDataFim.Location = new System.Drawing.Point(449, 20);
            this.maskedTextBoxDataFim.Mask = "00/00/0000";
            this.maskedTextBoxDataFim.Name = "maskedTextBoxDataFim";
            this.maskedTextBoxDataFim.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBoxDataFim.TabIndex = 2;
            this.maskedTextBoxDataFim.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxDataFim.TextChanged += new System.EventHandler(this.maskedTextBoxDataFim_TextChanged);
            // 
            // maskedTextBoxDataIni
            // 
            this.maskedTextBoxDataIni.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxDataIni.Location = new System.Drawing.Point(366, 20);
            this.maskedTextBoxDataIni.Mask = "00/00/0000";
            this.maskedTextBoxDataIni.Name = "maskedTextBoxDataIni";
            this.maskedTextBoxDataIni.Size = new System.Drawing.Size(81, 22);
            this.maskedTextBoxDataIni.TabIndex = 1;
            this.maskedTextBoxDataIni.ValidatingType = typeof(System.DateTime);
            this.maskedTextBoxDataIni.TextChanged += new System.EventHandler(this.maskedTextBoxDataIni_TextChanged);
            // 
            // radioAtivos
            // 
            this.radioAtivos.AutoSize = true;
            this.radioAtivos.Location = new System.Drawing.Point(190, 49);
            this.radioAtivos.Name = "radioAtivos";
            this.radioAtivos.Size = new System.Drawing.Size(54, 17);
            this.radioAtivos.TabIndex = 6;
            this.radioAtivos.Text = "Ativos";
            this.radioAtivos.UseVisualStyleBackColor = true;
            this.radioAtivos.Click += new System.EventHandler(this.radioAtivos_Click);
            // 
            // radioTypeContract
            // 
            this.radioTypeContract.AutoSize = true;
            this.radioTypeContract.Checked = true;
            this.radioTypeContract.Location = new System.Drawing.Point(94, 49);
            this.radioTypeContract.Name = "radioTypeContract";
            this.radioTypeContract.Size = new System.Drawing.Size(79, 17);
            this.radioTypeContract.TabIndex = 5;
            this.radioTypeContract.TabStop = true;
            this.radioTypeContract.Text = "Paralisados";
            this.radioTypeContract.UseVisualStyleBackColor = true;
            this.radioTypeContract.Click += new System.EventHandler(this.radioTypeContract_Click);
            // 
            // radioLiquidados
            // 
            this.radioLiquidados.AutoSize = true;
            this.radioLiquidados.Location = new System.Drawing.Point(3, 49);
            this.radioLiquidados.Name = "radioLiquidados";
            this.radioLiquidados.Size = new System.Drawing.Size(76, 17);
            this.radioLiquidados.TabIndex = 4;
            this.radioLiquidados.Text = "Liquidados";
            this.radioLiquidados.UseVisualStyleBackColor = true;
            this.radioLiquidados.Click += new System.EventHandler(this.radioLiquidados_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackgroundImage = global::ConversorToByte.Properties.Resources.clear_filters_48_45590__1_;
            this.btnLimpar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnLimpar.Location = new System.Drawing.Point(534, 20);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(29, 22);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // textBoxContratocpf
            // 
            this.textBoxContratocpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxContratocpf.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.textBoxContratocpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxContratocpf.Location = new System.Drawing.Point(4, 20);
            this.textBoxContratocpf.MaxLength = 20;
            this.textBoxContratocpf.Name = "textBoxContratocpf";
            this.textBoxContratocpf.Size = new System.Drawing.Size(360, 22);
            this.textBoxContratocpf.TabIndex = 0;
            this.textBoxContratocpf.TextChanged += new System.EventHandler(this.textBoxContratocpf_TextChanged);
            // 
            // dataGridViewContract
            // 
            this.dataGridViewContract.AllowUserToAddRows = false;
            this.dataGridViewContract.AllowUserToDeleteRows = false;
            this.dataGridViewContract.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dataGridViewContract.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewContract.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewContract.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContract.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonName,
            this.NameContract,
            this.PersonDocument,
            this.Download,
            this.T16,
            this.T18,
            this.T20,
            this.T25,
            this.T34});
            this.dataGridViewContract.Location = new System.Drawing.Point(2, 109);
            this.dataGridViewContract.MultiSelect = false;
            this.dataGridViewContract.Name = "dataGridViewContract";
            this.dataGridViewContract.ReadOnly = true;
            this.dataGridViewContract.RowHeadersVisible = false;
            this.dataGridViewContract.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContract.Size = new System.Drawing.Size(570, 398);
            this.dataGridViewContract.TabIndex = 3;
            this.dataGridViewContract.TabStop = false;
            this.dataGridViewContract.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewContract_CellContentClick);
            this.dataGridViewContract.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dataGridViewContract_RowsAdded);
            // 
            // PersonName
            // 
            this.PersonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.PersonName.DataPropertyName = "PersonName";
            this.PersonName.HeaderText = "Nome";
            this.PersonName.Name = "PersonName";
            this.PersonName.ReadOnly = true;
            this.PersonName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PersonName.ToolTipText = "Nome do Cliente";
            // 
            // NameContract
            // 
            this.NameContract.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NameContract.DataPropertyName = "T16";
            this.NameContract.FillWeight = 27.02702F;
            this.NameContract.HeaderText = "Contrato";
            this.NameContract.Name = "NameContract";
            this.NameContract.ReadOnly = true;
            this.NameContract.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NameContract.ToolTipText = "Numero do contrato";
            // 
            // PersonDocument
            // 
            this.PersonDocument.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PersonDocument.DataPropertyName = "PersonDocument";
            this.PersonDocument.FillWeight = 172.973F;
            this.PersonDocument.HeaderText = "Documento";
            this.PersonDocument.Name = "PersonDocument";
            this.PersonDocument.ReadOnly = true;
            this.PersonDocument.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Download
            // 
            this.Download.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Download.Description = "Baixar Arquivo";
            this.Download.HeaderText = "";
            this.Download.Image = global::ConversorToByte.Properties.Resources.ic_cloud_download_128_28299;
            this.Download.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Download.Name = "Download";
            this.Download.ReadOnly = true;
            this.Download.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Download.ToolTipText = "Baixar Arquivo compactado";
            this.Download.Width = 30;
            // 
            // T16
            // 
            this.T16.HeaderText = "T16";
            this.T16.Image = ((System.Drawing.Image)(resources.GetObject("T16.Image")));
            this.T16.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.T16.Name = "T16";
            this.T16.ReadOnly = true;
            this.T16.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.T16.ToolTipText = "Vizualizar Arquivo 16";
            this.T16.Width = 30;
            // 
            // T18
            // 
            this.T18.HeaderText = "T18";
            this.T18.Image = global::ConversorToByte.Properties.Resources.search_locate_find_6278;
            this.T18.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.T18.Name = "T18";
            this.T18.ReadOnly = true;
            this.T18.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.T18.ToolTipText = "Vizualizar Arquivo 18";
            this.T18.Width = 30;
            // 
            // T20
            // 
            this.T20.HeaderText = "T20";
            this.T20.Image = global::ConversorToByte.Properties.Resources.search_locate_find_6278;
            this.T20.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.T20.Name = "T20";
            this.T20.ReadOnly = true;
            this.T20.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.T20.ToolTipText = "Vizualizar Arquivo 20";
            this.T20.Width = 30;
            // 
            // T25
            // 
            this.T25.HeaderText = "T25";
            this.T25.Image = global::ConversorToByte.Properties.Resources.search_locate_find_6278;
            this.T25.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.T25.Name = "T25";
            this.T25.ReadOnly = true;
            this.T25.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.T25.ToolTipText = "Vizualizar Arquivo 25";
            this.T25.Width = 30;
            // 
            // T34
            // 
            this.T34.HeaderText = "T34";
            this.T34.Image = global::ConversorToByte.Properties.Resources.search_locate_find_6278;
            this.T34.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.T34.Name = "T34";
            this.T34.ReadOnly = true;
            this.T34.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.T34.ToolTipText = "Vizualizar Arquivo 34";
            this.T34.Width = 30;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addUsuarioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(574, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addUsuarioToolStripMenuItem
            // 
            this.addUsuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addContratosToolStripMenuItem,
            this.addUsuariosToolStripMenuItem});
            this.addUsuarioToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addUsuarioToolStripMenuItem.Name = "addUsuarioToolStripMenuItem";
            this.addUsuarioToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.addUsuarioToolStripMenuItem.Text = "Menu";
            // 
            // addContratosToolStripMenuItem
            // 
            this.addContratosToolStripMenuItem.Image = global::ConversorToByte.Properties.Resources.business_salesreport_salesreport_negocio_2353;
            this.addContratosToolStripMenuItem.Name = "addContratosToolStripMenuItem";
            this.addContratosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addContratosToolStripMenuItem.Text = "Carga de Contratos";
            this.addContratosToolStripMenuItem.Click += new System.EventHandler(this.addContratosToolStripMenuItem_Click);
            // 
            // addUsuariosToolStripMenuItem
            // 
            this.addUsuariosToolStripMenuItem.Image = global::ConversorToByte.Properties.Resources.business_application_addmale_useradd_insert_add_user_client_2312;
            this.addUsuariosToolStripMenuItem.Name = "addUsuariosToolStripMenuItem";
            this.addUsuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addUsuariosToolStripMenuItem.Text = "Add Usuarios";
            this.addUsuariosToolStripMenuItem.Click += new System.EventHandler(this.addUsuariosToolStripMenuItem_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::ConversorToByte.Properties.Resources.ic_cloud_download_128_28299;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.ToolTipText = "Baixar Arquivo compactado";
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "";
            this.dataGridViewImageColumn2.Image = ((System.Drawing.Image)(resources.GetObject("dataGridViewImageColumn2.Image")));
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.ToolTipText = "Vizualizar Arquivo";
            this.dataGridViewImageColumn2.Width = 30;
            // 
            // frmListContrato
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 509);
            this.Controls.Add(this.dataGridViewContract);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmListContrato";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Lista de Contratos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContract)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.TextBox textBoxContratocpf;
        private System.Windows.Forms.DataGridView dataGridViewContract;
        private System.Windows.Forms.ToolStripMenuItem addUsuarioToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.RadioButton radioTypeContract;
        private System.Windows.Forms.RadioButton radioLiquidados;
        private System.Windows.Forms.RadioButton radioAtivos;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameContract;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonDocument;
        private System.Windows.Forms.DataGridViewImageColumn Download;
        private System.Windows.Forms.DataGridViewImageColumn T16;
        private System.Windows.Forms.DataGridViewImageColumn T18;
        private System.Windows.Forms.DataGridViewImageColumn T20;
        private System.Windows.Forms.DataGridViewImageColumn T25;
        private System.Windows.Forms.DataGridViewImageColumn T34;
        private System.Windows.Forms.ToolStripMenuItem addContratosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addUsuariosToolStripMenuItem;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataFim;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDataIni;
    }
}

