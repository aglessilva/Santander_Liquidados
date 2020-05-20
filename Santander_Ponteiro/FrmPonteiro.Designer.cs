namespace Santander_Ponteiro
{
    partial class FrmPonteiro
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label2.Size = new System.Drawing.Size(186, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Diretorio de DESTINO do PONTEIRO";
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Santander_Ponteiro.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(265, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(180, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(208, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Aguarde...Localizando arquivos";
            // 
            // FrmPonteiro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 110);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPonteiro";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ponteiro de contratos Paralisados";
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
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}

