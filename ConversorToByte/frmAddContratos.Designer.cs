namespace ConversorToByte
{
    partial class frmAddContratos
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
            this.groupBoxAddContratos = new System.Windows.Forms.GroupBox();
            this.BtnAddContrados = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnOpenDirectory = new System.Windows.Forms.Button();
            this.TextBoxOrigemContrato = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblDescricaoDuplicados = new System.Windows.Forms.Label();
            this.pictureBoxLoad = new System.Windows.Forms.PictureBox();
            this.lblTempo = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTela = new System.Windows.Forms.Label();
            this.lblLidos = new System.Windows.Forms.Label();
            this.lblContrato = new System.Windows.Forms.Label();
            this.lblQtd = new System.Windows.Forms.Label();
            this.lblPorcentagem = new System.Windows.Forms.Label();
            this.progressBarReaderPdf = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerAddContract = new System.ComponentModel.BackgroundWorker();
            this.groupBoxAddContratos.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnlProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxAddContratos
            // 
            this.groupBoxAddContratos.Controls.Add(this.BtnAddContrados);
            this.groupBoxAddContratos.Controls.Add(this.groupBox2);
            this.groupBoxAddContratos.Controls.Add(this.groupBox1);
            this.groupBoxAddContratos.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAddContratos.Name = "groupBoxAddContratos";
            this.groupBoxAddContratos.Size = new System.Drawing.Size(550, 183);
            this.groupBoxAddContratos.TabIndex = 0;
            this.groupBoxAddContratos.TabStop = false;
            this.groupBoxAddContratos.Text = "Adicionar novos contratos na base de dados";
            // 
            // BtnAddContrados
            // 
            this.BtnAddContrados.Enabled = false;
            this.BtnAddContrados.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAddContrados.Image = global::ConversorToByte.Properties.Resources.business_salesreport_salesreport_negocio_2353;
            this.BtnAddContrados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAddContrados.Location = new System.Drawing.Point(198, 136);
            this.BtnAddContrados.Name = "BtnAddContrados";
            this.BtnAddContrados.Size = new System.Drawing.Size(168, 35);
            this.BtnAddContrados.TabIndex = 5;
            this.BtnAddContrados.Text = "Inicializar Carga";
            this.BtnAddContrados.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAddContrados.UseVisualStyleBackColor = true;
            this.BtnAddContrados.Click += new System.EventHandler(this.BtnAddContrados_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnOpenDirectory);
            this.groupBox2.Controls.Add(this.TextBoxOrigemContrato);
            this.groupBox2.Location = new System.Drawing.Point(6, 69);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(538, 61);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Diretório de origem dos contratos";
            // 
            // BtnOpenDirectory
            // 
            this.BtnOpenDirectory.BackgroundImage = global::ConversorToByte.Properties.Resources.open_file_40455;
            this.BtnOpenDirectory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.BtnOpenDirectory.Location = new System.Drawing.Point(503, 25);
            this.BtnOpenDirectory.Name = "BtnOpenDirectory";
            this.BtnOpenDirectory.Size = new System.Drawing.Size(30, 24);
            this.BtnOpenDirectory.TabIndex = 1;
            this.BtnOpenDirectory.UseVisualStyleBackColor = true;
            this.BtnOpenDirectory.Click += new System.EventHandler(this.BtnOpenDirectory_Click);
            // 
            // TextBoxOrigemContrato
            // 
            this.TextBoxOrigemContrato.Enabled = false;
            this.TextBoxOrigemContrato.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextBoxOrigemContrato.Location = new System.Drawing.Point(6, 26);
            this.TextBoxOrigemContrato.Name = "TextBoxOrigemContrato";
            this.TextBoxOrigemContrato.Size = new System.Drawing.Size(496, 22);
            this.TextBoxOrigemContrato.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Location = new System.Drawing.Point(6, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 41);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo de Contrato";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 18);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Liquidados";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(277, 18);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Ativos";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(138, 18);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(79, 17);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Paralisados";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // pnlProgress
            // 
            this.pnlProgress.Controls.Add(this.lblDescricaoDuplicados);
            this.pnlProgress.Controls.Add(this.pictureBoxLoad);
            this.pnlProgress.Controls.Add(this.lblTempo);
            this.pnlProgress.Controls.Add(this.groupBox3);
            this.pnlProgress.Controls.Add(this.lblPorcentagem);
            this.pnlProgress.Controls.Add(this.progressBarReaderPdf);
            this.pnlProgress.Location = new System.Drawing.Point(6, 5);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(565, 199);
            this.pnlProgress.TabIndex = 1;
            this.pnlProgress.UseWaitCursor = true;
            this.pnlProgress.Visible = false;
            // 
            // lblDescricaoDuplicados
            // 
            this.lblDescricaoDuplicados.AutoSize = true;
            this.lblDescricaoDuplicados.ForeColor = System.Drawing.Color.Red;
            this.lblDescricaoDuplicados.Location = new System.Drawing.Point(158, 164);
            this.lblDescricaoDuplicados.Name = "lblDescricaoDuplicados";
            this.lblDescricaoDuplicados.Size = new System.Drawing.Size(249, 13);
            this.lblDescricaoDuplicados.TabIndex = 5;
            this.lblDescricaoDuplicados.Text = "Removendo registros duplicados da base de dados";
            this.lblDescricaoDuplicados.UseWaitCursor = true;
            this.lblDescricaoDuplicados.Visible = false;
            // 
            // pictureBoxLoad
            // 
            this.pictureBoxLoad.Image = global::ConversorToByte.Properties.Resources.ajax_loader;
            this.pictureBoxLoad.Location = new System.Drawing.Point(257, 128);
            this.pictureBoxLoad.Name = "pictureBoxLoad";
            this.pictureBoxLoad.Size = new System.Drawing.Size(36, 34);
            this.pictureBoxLoad.TabIndex = 4;
            this.pictureBoxLoad.TabStop = false;
            this.pictureBoxLoad.UseWaitCursor = true;
            this.pictureBoxLoad.Visible = false;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(18, 105);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(13, 13);
            this.lblTempo.TabIndex = 3;
            this.lblTempo.Text = "0";
            this.lblTempo.UseWaitCursor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTela);
            this.groupBox3.Controls.Add(this.lblLidos);
            this.groupBox3.Controls.Add(this.lblContrato);
            this.groupBox3.Controls.Add(this.lblQtd);
            this.groupBox3.Location = new System.Drawing.Point(12, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 52);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Carga de contratos para base de dados";
            this.groupBox3.UseWaitCursor = true;
            // 
            // lblTela
            // 
            this.lblTela.AutoSize = true;
            this.lblTela.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTela.ForeColor = System.Drawing.Color.Blue;
            this.lblTela.Location = new System.Drawing.Point(464, 29);
            this.lblTela.Name = "lblTela";
            this.lblTela.Size = new System.Drawing.Size(40, 16);
            this.lblTela.TabIndex = 3;
            this.lblTela.Text = "Tela";
            this.lblTela.UseWaitCursor = true;
            // 
            // lblLidos
            // 
            this.lblLidos.AutoSize = true;
            this.lblLidos.ForeColor = System.Drawing.Color.Green;
            this.lblLidos.Location = new System.Drawing.Point(337, 31);
            this.lblLidos.Name = "lblLidos";
            this.lblLidos.Size = new System.Drawing.Size(13, 13);
            this.lblLidos.TabIndex = 2;
            this.lblLidos.Text = "0";
            this.lblLidos.UseWaitCursor = true;
            // 
            // lblContrato
            // 
            this.lblContrato.AutoSize = true;
            this.lblContrato.ForeColor = System.Drawing.Color.Red;
            this.lblContrato.Location = new System.Drawing.Point(162, 31);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(13, 13);
            this.lblContrato.TabIndex = 1;
            this.lblContrato.Text = "0";
            this.lblContrato.UseWaitCursor = true;
            // 
            // lblQtd
            // 
            this.lblQtd.AutoSize = true;
            this.lblQtd.Location = new System.Drawing.Point(6, 31);
            this.lblQtd.Name = "lblQtd";
            this.lblQtd.Size = new System.Drawing.Size(13, 13);
            this.lblQtd.TabIndex = 0;
            this.lblQtd.Text = "0";
            this.lblQtd.UseWaitCursor = true;
            // 
            // lblPorcentagem
            // 
            this.lblPorcentagem.AutoSize = true;
            this.lblPorcentagem.Location = new System.Drawing.Point(265, 101);
            this.lblPorcentagem.Name = "lblPorcentagem";
            this.lblPorcentagem.Size = new System.Drawing.Size(21, 13);
            this.lblPorcentagem.TabIndex = 1;
            this.lblPorcentagem.Text = "0%";
            this.lblPorcentagem.UseWaitCursor = true;
            // 
            // progressBarReaderPdf
            // 
            this.progressBarReaderPdf.Location = new System.Drawing.Point(12, 70);
            this.progressBarReaderPdf.Name = "progressBarReaderPdf";
            this.progressBarReaderPdf.Size = new System.Drawing.Size(544, 26);
            this.progressBarReaderPdf.TabIndex = 0;
            this.progressBarReaderPdf.UseWaitCursor = true;
            // 
            // backgroundWorkerAddContract
            // 
            this.backgroundWorkerAddContract.WorkerReportsProgress = true;
            this.backgroundWorkerAddContract.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerAddContract_DoWork);
            this.backgroundWorkerAddContract.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerAddContract_ProgressChanged);
            this.backgroundWorkerAddContract.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerAddContract_RunWorkerCompleted);
            // 
            // frmAddContratos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 207);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.groupBoxAddContratos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmAddContratos";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Armazenar novos contratos";
            this.Load += new System.EventHandler(this.frmAddContratos_Load);
            this.groupBoxAddContratos.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.pnlProgress.ResumeLayout(false);
            this.pnlProgress.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoad)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAddContratos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnOpenDirectory;
        private System.Windows.Forms.TextBox TextBoxOrigemContrato;
        private System.Windows.Forms.Button BtnAddContrados;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.ProgressBar progressBarReaderPdf;
        private System.ComponentModel.BackgroundWorker backgroundWorkerAddContract;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblQtd;
        private System.Windows.Forms.Label lblPorcentagem;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblLidos;
        private System.Windows.Forms.Label lblContrato;
        private System.Windows.Forms.Label lblDescricaoDuplicados;
        private System.Windows.Forms.PictureBox pictureBoxLoad;
        private System.Windows.Forms.Label lblTela;
    }
}