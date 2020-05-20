namespace Santander_Ponteiro
{
    partial class frmProgressBar
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lbllidos = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblporcentagem = new System.Windows.Forms.Label();
            this.progressBarParalizados = new System.Windows.Forms.ProgressBar();
            this.backgroundWorkerPonteiro = new System.ComponentModel.BackgroundWorker();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblTempo);
            this.panel2.Controls.Add(this.lbllidos);
            this.panel2.Controls.Add(this.lblTotal);
            this.panel2.Controls.Add(this.lblporcentagem);
            this.panel2.Controls.Add(this.progressBarParalizados);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(535, 77);
            this.panel2.TabIndex = 2;
            this.panel2.UseWaitCursor = true;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(17, 55);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(10, 13);
            this.lblTempo.TabIndex = 5;
            this.lblTempo.Text = "-";
            this.lblTempo.UseWaitCursor = true;
            // 
            // lbllidos
            // 
            this.lbllidos.AutoSize = true;
            this.lbllidos.Location = new System.Drawing.Point(258, 10);
            this.lbllidos.Name = "lbllidos";
            this.lbllidos.Size = new System.Drawing.Size(10, 13);
            this.lbllidos.TabIndex = 3;
            this.lbllidos.Text = "-";
            this.lbllidos.UseWaitCursor = true;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(17, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "-";
            this.lblTotal.UseWaitCursor = true;
            // 
            // lblporcentagem
            // 
            this.lblporcentagem.AutoSize = true;
            this.lblporcentagem.Location = new System.Drawing.Point(256, 55);
            this.lblporcentagem.Name = "lblporcentagem";
            this.lblporcentagem.Size = new System.Drawing.Size(21, 13);
            this.lblporcentagem.TabIndex = 1;
            this.lblporcentagem.Text = "0%";
            this.lblporcentagem.UseWaitCursor = true;
            // 
            // progressBarParalizados
            // 
            this.progressBarParalizados.Location = new System.Drawing.Point(6, 26);
            this.progressBarParalizados.Name = "progressBarParalizados";
            this.progressBarParalizados.Size = new System.Drawing.Size(521, 23);
            this.progressBarParalizados.TabIndex = 0;
            this.progressBarParalizados.UseWaitCursor = true;
            // 
            // backgroundWorkerPonteiro
            // 
            this.backgroundWorkerPonteiro.WorkerReportsProgress = true;
            this.backgroundWorkerPonteiro.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerPonteiro_DoWork);
            this.backgroundWorkerPonteiro.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerPonteiro_ProgressChanged);
            this.backgroundWorkerPonteiro.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerPonteiro_RunWorkerCompleted);
            // 
            // frmProgressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 77);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmProgressBar";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProgressBar";
            this.UseWaitCursor = true;
            this.Shown += new System.EventHandler(this.frmProgressBar_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lbllidos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblporcentagem;
        private System.Windows.Forms.ProgressBar progressBarParalizados;
        private System.ComponentModel.BackgroundWorker backgroundWorkerPonteiro;
    }
}