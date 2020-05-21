namespace Santander_Password_tela34
{
    partial class FrmPassword
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDestino = new System.Windows.Forms.Button();
            this.btnOrigem = new System.Windows.Forms.Button();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.textBoxOrigem = new System.Windows.Forms.TextBox();
            this.lblSetLoad = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalArquivo = new System.Windows.Forms.Label();
            this.lblTotalSenha = new System.Windows.Forms.Label();
            this.lblNao34 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.btnIniciar);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btnDestino);
            this.panelMain.Controls.Add(this.btnOrigem);
            this.panelMain.Controls.Add(this.textBoxDestino);
            this.panelMain.Controls.Add(this.textBoxOrigem);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(560, 111);
            this.panelMain.TabIndex = 8;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Enabled = false;
            this.btnIniciar.Location = new System.Drawing.Point(230, 82);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(107, 27);
            this.btnIniciar.TabIndex = 6;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Diretorio de DESTINO do Arquivo Gerado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diretorio de ORIGEM dos contratos";
            // 
            // btnDestino
            // 
            this.btnDestino.Location = new System.Drawing.Point(518, 59);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(31, 22);
            this.btnDestino.TabIndex = 3;
            this.btnDestino.Text = "...";
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // btnOrigem
            // 
            this.btnOrigem.Location = new System.Drawing.Point(518, 19);
            this.btnOrigem.Name = "btnOrigem";
            this.btnOrigem.Size = new System.Drawing.Size(31, 22);
            this.btnOrigem.TabIndex = 2;
            this.btnOrigem.Text = "...";
            this.btnOrigem.UseVisualStyleBackColor = true;
            this.btnOrigem.Click += new System.EventHandler(this.btnOrigem_Click);
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Enabled = false;
            this.textBoxDestino.Location = new System.Drawing.Point(14, 60);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(504, 20);
            this.textBoxDestino.TabIndex = 1;
            // 
            // textBoxOrigem
            // 
            this.textBoxOrigem.Enabled = false;
            this.textBoxOrigem.Location = new System.Drawing.Point(14, 20);
            this.textBoxOrigem.Name = "textBoxOrigem";
            this.textBoxOrigem.Size = new System.Drawing.Size(504, 20);
            this.textBoxOrigem.TabIndex = 0;
            // 
            // lblSetLoad
            // 
            this.lblSetLoad.AutoSize = true;
            this.lblSetLoad.Location = new System.Drawing.Point(224, 68);
            this.lblSetLoad.Name = "lblSetLoad";
            this.lblSetLoad.Size = new System.Drawing.Size(111, 13);
            this.lblSetLoad.TabIndex = 11;
            this.lblSetLoad.Text = "Analisando arquivos...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Santander_Password_tela34.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(260, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Total com Senha:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Total de Arquivos:";
            // 
            // lblTotalArquivo
            // 
            this.lblTotalArquivo.AutoSize = true;
            this.lblTotalArquivo.Location = new System.Drawing.Point(112, 31);
            this.lblTotalArquivo.Name = "lblTotalArquivo";
            this.lblTotalArquivo.Size = new System.Drawing.Size(13, 13);
            this.lblTotalArquivo.TabIndex = 14;
            this.lblTotalArquivo.Text = "0";
            // 
            // lblTotalSenha
            // 
            this.lblTotalSenha.AutoSize = true;
            this.lblTotalSenha.Location = new System.Drawing.Point(112, 70);
            this.lblTotalSenha.Name = "lblTotalSenha";
            this.lblTotalSenha.Size = new System.Drawing.Size(13, 13);
            this.lblTotalSenha.TabIndex = 15;
            this.lblTotalSenha.Text = "0";
            // 
            // lblNao34
            // 
            this.lblNao34.AutoSize = true;
            this.lblNao34.Location = new System.Drawing.Point(112, 51);
            this.lblNao34.Name = "lblNao34";
            this.lblNao34.Size = new System.Drawing.Size(13, 13);
            this.lblNao34.TabIndex = 17;
            this.lblNao34.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total não Tela34:";
            // 
            // FrmPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 112);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblNao34);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblTotalSenha);
            this.Controls.Add(this.lblTotalArquivo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSetLoad);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Verificar se arquivo tem senha  e se é Tela 34";
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.Button btnOrigem;
        private System.Windows.Forms.TextBox textBoxDestino;
        private System.Windows.Forms.TextBox textBoxOrigem;
        private System.Windows.Forms.Label lblSetLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotalArquivo;
        private System.Windows.Forms.Label lblTotalSenha;
        private System.Windows.Forms.Label lblNao34;
        private System.Windows.Forms.Label label6;
    }
}

