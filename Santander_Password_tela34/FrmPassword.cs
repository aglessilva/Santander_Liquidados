using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santander_Password_tela34
{
    public partial class FrmPassword : Form
    {
        public FrmPassword()
        {
            InitializeComponent();
        }

        FolderBrowserDialog browserDialog = null;

        void Iniciar()
        {
            SetLoading(true);
            List<string> diretorio = null;
            List<string> lst = new List<string>();
            List<string> lstNao34 = new List<string>();
            List<string> arrayLine;
            FileInfo file = null;

            try
            {
                string pagina = string.Empty;
                string line = string.Empty;

                int contador = 0;
                int coutNot34 = 0;

                diretorio = Directory.EnumerateFiles(textBoxOrigem.Text, "*34.pdf", SearchOption.AllDirectories).ToList();

                Invoke((MethodInvoker)delegate
                {
                    lblTotalArquivo.Text = diretorio.Count.ToString();
                });

                diretorio.ForEach(arq => {
                    try
                    {
                        file = new FileInfo(arq);
                        using (PdfReader reader = new PdfReader(arq))
                        {
                            ITextExtractionStrategy its;
                            pagina = string.Empty;
                            its = new LocationTextExtractionStrategy();
                            pagina = PdfTextExtractor.GetTextFromPage(reader, 1, its).Trim();

                            using (StringReader strReader = new StringReader(pagina))
                            {
                                while ((line = strReader.ReadLine()) != null)
                                {
                                    arrayLine = line.Split(' ').ToList();

                                    if (line.Contains("CTFIN"))
                                    {
                                        if (!arrayLine.Any(c => c.Contains("CTFIN/O034A")))
                                        {
                                            coutNot34++;
                                            lst.Add(file.Name);

                                            Invoke((MethodInvoker)delegate
                                            {
                                                lblNao34.Text = coutNot34.ToString();
                                            });
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        lstNao34.Add(file.Name);
                        contador++;
                        Invoke((MethodInvoker)delegate
                        {
                            lblTotalSenha.Text = contador.ToString();
                        });
                    }
                });

                MessageBox.Show("Processo  finalizado!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (lst.Count > 0)
                {
                    using (StreamWriter stream = new StreamWriter($@"{textBoxDestino.Text}\NAO_eh_TELA34.txt"))
                    {
                        lst.ForEach(l => { stream.WriteLine(l); });
                    }

                    Process.Start($@"{textBoxDestino.Text}\NAO_eh_TELA34.txt");
                }

                if (lstNao34.Count > 0)
                {
                    using (StreamWriter stream = new StreamWriter($@"{textBoxDestino.Text}\TELA34_COM_SENHA.txt"))
                    {
                        lstNao34.ForEach(l => { stream.WriteLine(l); });
                    }

                    Process.Start($@"{textBoxDestino.Text}\TELA34_COM_SENHA.txt");
                }
               
            }
            catch (Exception ex)
            {
                new Exception("Erro na leitura\n" + ex.Message);
            }
            SetLoading(false);

        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            Thread threadInput = new Thread(Iniciar);
            threadInput.Start();
           
        }

        private void btnOrigem_Click(object sender, EventArgs e)
        {
            browserDialog = new FolderBrowserDialog();

            browserDialog.Description = "Selecione o Diretório dos Arquivos com Senha";
            browserDialog.ShowNewFolderButton = false;

            if (browserDialog.ShowDialog() == DialogResult.OK)
                textBoxOrigem.Text = browserDialog.SelectedPath;
            else
                textBoxOrigem.Text = string.Empty;

            btnIniciar.Enabled = (!string.IsNullOrWhiteSpace(textBoxOrigem.Text) && !string.IsNullOrWhiteSpace(textBoxDestino.Text));
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            browserDialog = new FolderBrowserDialog();
            browserDialog.Description = "Diretório onde será geraddo o Txt com os arquivos com senha";
            browserDialog.ShowNewFolderButton = false;

            if (browserDialog.ShowDialog() == DialogResult.OK)
                textBoxDestino.Text = browserDialog.SelectedPath;
            else
                textBoxDestino.Text = string.Empty;

            btnIniciar.Enabled = (!string.IsNullOrWhiteSpace(textBoxOrigem.Text) && !string.IsNullOrWhiteSpace(textBoxDestino.Text));
        }


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
                    panelMain.Visible = !panelMain.Visible;
                });


            }
        }
    }
}
