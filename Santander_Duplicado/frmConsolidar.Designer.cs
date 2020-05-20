namespace Santander_Duplicado
{
    partial class frmConsolidar
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
            this.label6 = new System.Windows.Forms.Label();
            this.btnPonteiro = new System.Windows.Forms.Button();
            this.textBoxPonteiro = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDestino = new System.Windows.Forms.Button();
            this.btnOrigem = new System.Windows.Forms.Button();
            this.textBoxDestino = new System.Windows.Forms.TextBox();
            this.textBoxOrigem = new System.Windows.Forms.TextBox();
            this.lblTotalFiltrado = new System.Windows.Forms.Label();
            this.lblTotalEcontrado = new System.Windows.Forms.Label();
            this.lblCopiado = new System.Windows.Forms.Label();
            this.lblchecado = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl06 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTotalPonteiro = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.label6);
            this.panelMain.Controls.Add(this.btnPonteiro);
            this.panelMain.Controls.Add(this.textBoxPonteiro);
            this.panelMain.Controls.Add(this.btnIniciar);
            this.panelMain.Controls.Add(this.label2);
            this.panelMain.Controls.Add(this.label1);
            this.panelMain.Controls.Add(this.btnDestino);
            this.panelMain.Controls.Add(this.btnOrigem);
            this.panelMain.Controls.Add(this.textBoxDestino);
            this.panelMain.Controls.Add(this.textBoxOrigem);
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(563, 160);
            this.panelMain.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 6);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "SELECIONE O PONTEIRO";
            // 
            // btnPonteiro
            // 
            this.btnPonteiro.Location = new System.Drawing.Point(518, 21);
            this.btnPonteiro.Name = "btnPonteiro";
            this.btnPonteiro.Size = new System.Drawing.Size(31, 22);
            this.btnPonteiro.TabIndex = 0;
            this.btnPonteiro.Text = "...";
            this.btnPonteiro.UseVisualStyleBackColor = true;
            this.btnPonteiro.Click += new System.EventHandler(this.btnPonteiro_Click);
            // 
            // textBoxPonteiro
            // 
            this.textBoxPonteiro.Enabled = false;
            this.textBoxPonteiro.Location = new System.Drawing.Point(14, 22);
            this.textBoxPonteiro.Name = "textBoxPonteiro";
            this.textBoxPonteiro.Size = new System.Drawing.Size(504, 20);
            this.textBoxPonteiro.TabIndex = 7;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Enabled = false;
            this.btnIniciar.Location = new System.Drawing.Point(230, 126);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(107, 27);
            this.btnIniciar.TabIndex = 3;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Diretorio de DESTINO onde os arquivos serão movidos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Diretorio de ORIGEM dos contratos";
            // 
            // btnDestino
            // 
            this.btnDestino.Location = new System.Drawing.Point(518, 103);
            this.btnDestino.Name = "btnDestino";
            this.btnDestino.Size = new System.Drawing.Size(31, 22);
            this.btnDestino.TabIndex = 2;
            this.btnDestino.Text = "...";
            this.btnDestino.UseVisualStyleBackColor = true;
            this.btnDestino.Click += new System.EventHandler(this.btnDestino_Click);
            // 
            // btnOrigem
            // 
            this.btnOrigem.Location = new System.Drawing.Point(518, 63);
            this.btnOrigem.Name = "btnOrigem";
            this.btnOrigem.Size = new System.Drawing.Size(31, 22);
            this.btnOrigem.TabIndex = 1;
            this.btnOrigem.Text = "...";
            this.btnOrigem.UseVisualStyleBackColor = true;
            this.btnOrigem.Click += new System.EventHandler(this.btnOrigem_Click);
            // 
            // textBoxDestino
            // 
            this.textBoxDestino.Enabled = false;
            this.textBoxDestino.Location = new System.Drawing.Point(14, 104);
            this.textBoxDestino.Name = "textBoxDestino";
            this.textBoxDestino.Size = new System.Drawing.Size(504, 20);
            this.textBoxDestino.TabIndex = 1;
            // 
            // textBoxOrigem
            // 
            this.textBoxOrigem.Enabled = false;
            this.textBoxOrigem.Location = new System.Drawing.Point(14, 64);
            this.textBoxOrigem.Name = "textBoxOrigem";
            this.textBoxOrigem.Size = new System.Drawing.Size(504, 20);
            this.textBoxOrigem.TabIndex = 0;
            // 
            // lblTotalFiltrado
            // 
            this.lblTotalFiltrado.AutoSize = true;
            this.lblTotalFiltrado.Location = new System.Drawing.Point(91, 54);
            this.lblTotalFiltrado.Name = "lblTotalFiltrado";
            this.lblTotalFiltrado.Size = new System.Drawing.Size(13, 13);
            this.lblTotalFiltrado.TabIndex = 29;
            this.lblTotalFiltrado.Text = "0";
            // 
            // lblTotalEcontrado
            // 
            this.lblTotalEcontrado.AutoSize = true;
            this.lblTotalEcontrado.Location = new System.Drawing.Point(110, 30);
            this.lblTotalEcontrado.Name = "lblTotalEcontrado";
            this.lblTotalEcontrado.Size = new System.Drawing.Size(13, 13);
            this.lblTotalEcontrado.TabIndex = 28;
            this.lblTotalEcontrado.Text = "0";
            // 
            // lblCopiado
            // 
            this.lblCopiado.AutoSize = true;
            this.lblCopiado.Location = new System.Drawing.Point(71, 104);
            this.lblCopiado.Name = "lblCopiado";
            this.lblCopiado.Size = new System.Drawing.Size(13, 13);
            this.lblCopiado.TabIndex = 27;
            this.lblCopiado.Text = "0";
            // 
            // lblchecado
            // 
            this.lblchecado.AutoSize = true;
            this.lblchecado.Location = new System.Drawing.Point(71, 77);
            this.lblchecado.Name = "lblchecado";
            this.lblchecado.Size = new System.Drawing.Size(13, 13);
            this.lblchecado.TabIndex = 26;
            this.lblchecado.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Total Remover:";
            // 
            // lbl06
            // 
            this.lbl06.AutoSize = true;
            this.lbl06.Location = new System.Drawing.Point(12, 30);
            this.lbl06.Name = "lbl06";
            this.lbl06.Size = new System.Drawing.Size(92, 13);
            this.lbl06.TabIndex = 24;
            this.lbl06.Text = "Total Encontrado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Movidos:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "Checados:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(222, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Aguarde o final do processo...";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Santander_Duplicado.Properties.Resources.ajax_loader;
            this.pictureBox1.Location = new System.Drawing.Point(272, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 31);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // lblTotalPonteiro
            // 
            this.lblTotalPonteiro.AutoSize = true;
            this.lblTotalPonteiro.Location = new System.Drawing.Point(91, 9);
            this.lblTotalPonteiro.Name = "lblTotalPonteiro";
            this.lblTotalPonteiro.Size = new System.Drawing.Size(13, 13);
            this.lblTotalPonteiro.TabIndex = 31;
            this.lblTotalPonteiro.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Total Ponteiro:";
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(12, 138);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(13, 13);
            this.lblTempo.TabIndex = 32;
            this.lblTempo.Text = "0";
            // 
            // frmConsolidar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 160);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.lblTotalPonteiro);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblTotalFiltrado);
            this.Controls.Add(this.lblTotalEcontrado);
            this.Controls.Add(this.lblCopiado);
            this.Controls.Add(this.lblchecado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lbl06);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmConsolidar";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mover Contratos";
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
        private System.Windows.Forms.Label lblTotalFiltrado;
        private System.Windows.Forms.Label lblTotalEcontrado;
        private System.Windows.Forms.Label lblCopiado;
        private System.Windows.Forms.Label lblchecado;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl06;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPonteiro;
        private System.Windows.Forms.TextBox textBoxPonteiro;
        private System.Windows.Forms.Label lblTotalPonteiro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblTempo;
    }
}