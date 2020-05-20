using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santander_Ponteiro
{
    public partial class FrmPonteiro : Form
    {
        public FrmPonteiro()
        {
            InitializeComponent();
        }

        FolderBrowserDialog folderBrowserDialog = null;
        List<string> diretorio = null;

        private void SetLoading(bool displayLoader)
        {
            if (displayLoader)
            {
                Invoke((MethodInvoker)delegate
                {
                    panelMain.Visible = !panelMain.Visible;
                    Cursor = Cursors.WaitCursor;
                });
            }
            else
            {
                Invoke((MethodInvoker)delegate
                {
                    Cursor = Cursors.Default;
                    frmProgressBar frmProgress = new frmProgressBar(diretorio, textBoxDestino.Text);
                    frmProgress.ShowDialog();
                    panelMain.Visible = !panelMain.Visible;
                });


            }
        }


        private void DisplayData()
        {
            try
            {
                SetLoading(true);
                   diretorio = Directory.EnumerateFiles(textBoxOrigem.Text, "*16.pdf", SearchOption.AllDirectories).ToList();
                SetLoading(false);
            }
            catch (Exception exeErro)
            {
                throw exeErro;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(DisplayData);
            threadInput.Start();
        }

        private void btnOrigem_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = false,
                Description = "Selecione o dirtório de ORIGEM dos contratos",

            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                textBoxOrigem.Text = folderBrowserDialog.SelectedPath;
            else
                textBoxOrigem.Text = string.Empty;

            btnIniciar.Enabled = !string.IsNullOrWhiteSpace(textBoxDestino.Text) && !string.IsNullOrWhiteSpace(textBoxOrigem.Text);
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Selecione o dirtório onde será gerado o PONTEIRO"
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDestino.Text = folderBrowserDialog.SelectedPath;
            }
            else
            {
                textBoxDestino.Text = string.Empty;
            }

            btnIniciar.Enabled = !string.IsNullOrWhiteSpace(textBoxDestino.Text) && !string.IsNullOrWhiteSpace(textBoxOrigem.Text);
        }
    }
}
