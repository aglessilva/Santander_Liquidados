namespace Santander_Duplicado
{
    partial class FormDuplicados
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDestino = new System.Windows.Forms.Button();
            this.btnOrigem = new System.Windows.Forms.Button();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.textBoxOrigem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblchecado = new System.Windows.Forms.Label();
            this.lblCopiado = new System.Windows.Forms.Label();
            this.lblTotalEcontrado = new System.Windows.Forms.Label();
            this.lblTotalFiltrado = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
            this.panelMain.TabIndex = 9;
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
            this.label2.Size = new System.Drawing.Size(288, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Diretorio onde serão criadas as pastas \"Tela16\" e \"Tela34\"";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Aguarde o final do processo...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Checados:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Movidos:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Total Encontrado:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Total Filtrado:";
            // 
            // lblchecado
            // 
            this.lblchecado.AutoSize = true;
            this.lblchecado.Location = new System.Drawing.Point(71, 56);
            this.lblchecado.Name = "lblchecado";
            this.lblchecado.Size = new System.Drawing.Size(13, 13);
            this.lblchecado.TabIndex = 16;
            this.lblchecado.Text = "0";
            // 
            // lblCopiado
            // 
            this.lblCopiado.AutoSize = true;
            this.lblCopiado.Location = new System.Drawing.Point(71, 83);
            this.lblCopiado.Name = "lblCopiado";
            this.lblCopiado.Size = new System.Drawing.Size(13, 13);
            this.lblCopiado.TabIndex = 17;
            this.lblCopiado.Text = "0";
            // 
            // lblTotalEcontrado
            // 
            this.lblTotalEcontrado.AutoSize = true;
            this.lblTotalEcontrado.Location = new System.Drawing.Point(110, 9);
            this.lblTotalEcontrado.Name = "lblTotalEcontrado";
            this.lblTotalEcontrado.Size = new System.Drawing.Size(13, 13);
            this.lblTotalEcontrado.TabIndex = 18;
            this.lblTotalEcontrado.Text = "0";
            // 
            // lblTotalFiltrado
            // 
            this.lblTotalFiltrado.AutoSize = true;
            this.lblTotalFiltrado.Location = new System.Drawing.Point(91, 32);
            this.lblTotalFiltrado.Name = "lblTotalFiltrado";
            this.lblTotalFiltrado.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiltrado.TabIndex = 19;
            this.lblTotalFiltrado.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Santander_Duplicado.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(272, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // FormDuplicados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 112);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblTotalFiltrado);
            this.Controls.Add(this.lblTotalEcontrado);
            this.Controls.Add(this.lblCopiado);
            this.Controls.Add(this.lblchecado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDuplicados";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mover Contratos Único das tela 16 e 34";
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblchecado;
        private System.Windows.Forms.Label lblCopiado;
        private System.Windows.Forms.Label lblTotalEcontrado;
        private System.Windows.Forms.Label lblTotalFiltrado;
    }
}