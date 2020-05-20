namespace Santander_Paralisados
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
            this.textBoxOrigem = new System.Windows.Forms.TextBox();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.btnOrigem = new System.Windows.Forms.Button();
            this.btnDestino = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblSetLoad = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxOrigem
            // 
            this.textBoxOrigem.Enabled = false;
            this.textBoxOrigem.Location = new System.Drawing.Point(14, 20);
            this.textBoxOrigem.Name = "textBoxOrigem";
            this.textBoxOrigem.Size = new System.Drawing.Size(504, 20);
            this.textBoxOrigem.TabIndex = 0;
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Enabled = false;
            this.textBoxDestino.Location = new System.Drawing.Point(14, 60);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(504, 20);
            this.textBoxDestino.TabIndex = 1;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diretorio de ORIGEM dos contratos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Diretorio de DESTINO dos contratos";
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
            // panelMain
            // 
            this.panelMain.Controls.Add(this.button1);
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
            this.panelMain.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(442, 84);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Santander_Paralisados.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(270, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(34, 33);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // lblSetLoad
            // 
            this.lblSetLoad.AutoSize = true;
            this.lblSetLoad.Location = new System.Drawing.Point(212, 67);
            this.lblSetLoad.Name = "lblSetLoad";
            this.lblSetLoad.Size = new System.Drawing.Size(158, 13);
            this.lblSetLoad.TabIndex = 9;
            this.lblSetLoad.Text = "Validando ponteiro Vs Contratos";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 112);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblSetLoad);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxOrigem;
        private System.Windows.Forms.TextBox textBoxDestino;
        private System.Windows.Forms.Button btnOrigem;
        private System.Windows.Forms.Button btnDestino;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblSetLoad;
        private System.Windows.Forms.Button button1;
    }
}

