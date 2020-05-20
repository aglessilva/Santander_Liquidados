namespace Santander_Paralisados
{
    partial class FrmProgress
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
            this.backgroundWorkerProgress = new System.ComponentModel.BackgroundWorker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.progressBarParalizados = new System.Windows.Forms.ProgressBar();
            this.lblporcentagem = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lbllidos = new System.Windows.Forms.Label();
            this.lblTempo = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerProgress
            // 
            this.backgroundWorkerProgress.WorkerReportsProgress = true;
            this.backgroundWorkerProgress.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerProgress_DoWork);
            this.backgroundWorkerProgress.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerProgress_ProgressChanged);
            this.backgroundWorkerProgress.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerProgress_RunWorkerCompleted);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblTempo);
            this.panel1.Controls.Add(this.lbllidos);
            this.panel1.Controls.Add(this.lblTotal);
            this.panel1.Controls.Add(this.lblporcentagem);
            this.panel1.Controls.Add(this.progressBarParalizados);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 74);
            this.panel1.TabIndex = 0;
            // 
            // progressBarParalizados
            // 
            this.progressBarParalizados.Location = new System.Drawing.Point(9, 26);
            this.progressBarParalizados.Name = "progressBarParalizados";
            this.progressBarParalizados.Size = new System.Drawing.Size(533, 23);
            this.progressBarParalizados.TabIndex = 0;
            // 
            // lblporcentagem
            // 
            this.lblporcentagem.AutoSize = true;
            this.lblporcentagem.Location = new System.Drawing.Point(264, 55);
            this.lblporcentagem.Name = "lblporcentagem";
            this.lblporcentagem.Size = new System.Drawing.Size(21, 13);
            this.lblporcentagem.TabIndex = 1;
            this.lblporcentagem.Text = "0%";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(17, 10);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(10, 13);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "-";
            // 
            // lbllidos
            // 
            this.lbllidos.AutoSize = true;
            this.lbllidos.Location = new System.Drawing.Point(264, 10);
            this.lbllidos.Name = "lbllidos";
            this.lbllidos.Size = new System.Drawing.Size(10, 13);
            this.lbllidos.TabIndex = 3;
            this.lbllidos.Text = "-";
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Location = new System.Drawing.Point(17, 55);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(10, 13);
            this.lblTempo.TabIndex = 5;
            this.lblTempo.Text = "-";
            // 
            // FrmProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 74);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProgress";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProgress";
            this.Load += new System.EventHandler(this.FrmProgress_Load);
            this.Shown += new System.EventHandler(this.FrmProgress_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorkerProgress;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lbllidos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblporcentagem;
        private System.Windows.Forms.ProgressBar progressBarParalizados;
    }
}