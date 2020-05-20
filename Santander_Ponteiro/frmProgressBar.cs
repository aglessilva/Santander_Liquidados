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
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Santander_Ponteiro
{
    public partial class frmProgressBar : Form
    {
        List<string> listPonteiro = new List<string>();
        List<string> diretorio = null;
        string diretorioDestino = string.Empty;
        Stopwatch stopwatch = new Stopwatch();
        int totalArquivo = 0;
        string PathFileCompany = string.Empty, pathDestino = string.Empty;

        public frmProgressBar(List<string> _diretorio, string _diretorioDestino)
        {
            InitializeComponent();
            diretorioDestino = _diretorioDestino;
            diretorio = _diretorio;
        }

       

        private void frmProgressBar_Shown(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists($@"{diretorioDestino}\PONTEIRO_PARALISADO.txt"))
                    File.Delete($@"{diretorioDestino}\PONTEIRO_PARALISADO.txt");

                totalArquivo = diretorio.Count; 
                progressBarParalizados.Minimum = 0;
                progressBarParalizados.Maximum = totalArquivo;

                stopwatch.Restart();
                backgroundWorkerPonteiro.RunWorkerAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void backgroundWorkerPonteiro_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                lbllidos.Text = string.Format("Contratos lidos: {0}", e.ProgressPercentage.ToString());

                if (progressBarParalizados.Value < progressBarParalizados.Maximum)
                    progressBarParalizados.Value = e.ProgressPercentage;

                lblTotal.Text = $"Total de Contratos: {totalArquivo} - Pendente: {(totalArquivo - e.ProgressPercentage)}";
                lblporcentagem.Text = string.Format("{0:P2}", (double)e.ProgressPercentage / (double)(progressBarParalizados.Maximum));
                lblTempo.Text = string.Format("Tempo de Execução: {0}:{1}:{2}:{3} ms", stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);

            }
            catch (Exception exEprogre)
            {
                throw exEprogre;
            }
        }

        private void backgroundWorkerPonteiro_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter($@"{diretorioDestino}\PONTEIRO_PARALISADO.txt"))
                {
                    listPonteiro.ForEach(m => {
                        streamWriter.WriteLine(m);
                    });
                };

                MessageBox.Show("Ponteiro concluído", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            catch (Exception exClose)
            {
                throw exClose;
            }
        }

        void ErrorCTFIN(string f)
        {
            FileInfo fileInfo = new FileInfo(f);

            using (StreamWriter streamWriter = new StreamWriter($@"{diretorioDestino}\CONTRATO_ERRO.txt",true))
            {
                streamWriter.WriteLine($"Arquivo: {fileInfo.Name}\nDiretorio: {fileInfo.FullName}\n=======================================================================================");
               
            };
        }

        private void backgroundWorkerPonteiro_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
              
                int contador = 0, sequencia = 0;
                string pagina, line, _numberContrato;
                List<string> arrayLine = new List<string>();
                // FileInfo fileInfo = null;
                bool cin16;

                diretorio.ForEach(w =>
                {
                    _numberContrato = string.Empty;

                    try
                    {
                        using (PdfReader reader = new PdfReader(w))
                        {
                            cin16 = false;
                            ITextExtractionStrategy its;
                            pagina = string.Empty;
                            sequencia = 0;

                            for (int i = 1; i <= reader.NumberOfPages; i++)
                            {
                                its = new LocationTextExtractionStrategy();
                                pagina = PdfTextExtractor.GetTextFromPage(reader, i, its).Trim();

                                using (StringReader strReader = new StringReader(pagina))
                                {
                                    line = string.Empty;

                                    while ((line = strReader.ReadLine()) != null)
                                    {
                                        arrayLine = line.Split(' ').ToList();

                                        if (i == 1)
                                        {
                                            if (line.Contains("CTFIN"))
                                            {
                                                if (!arrayLine.Any(c => c.Contains("CTFIN/O016A")))
                                                {
                                                    cin16 = true;
                                                    break;
                                                }
                                            }
                                        }

                                        if (!arrayLine.Any(t => t.Equals("10-BANCO") || t.Equals("PARALISADO"))) continue;

                                        if (arrayLine.Any(t => t.Equals("10-BANCO")))
                                        {
                                            _numberContrato = arrayLine.FirstOrDefault(c => Regex.IsMatch(c.Trim(), @"(^\d{4}$)")).Substring(2);
                                            _numberContrato += arrayLine.FirstOrDefault(c => Regex.IsMatch(c.Trim(), @"(^\d{4}.\d{5}.\d{3}\-\d{1}$)"));//0142.23001.452 - 3
                                            _numberContrato = Regex.Replace(_numberContrato, @"[^0-9$]", "").Trim();

                                        }

                                        sequencia++;

                                        if (sequencia == 2)
                                        {
                                            sequencia = 0;
                                            // fileInfo = new FileInfo(w);
                                            // _numberContrato = Regex.Replace(fileInfo.Name.Split('.')[0], @"[^0-9$]", "").PadLeft(15, '0'); 
                                            listPonteiro.Add(_numberContrato.Substring(0, 15));

                                            break;
                                        }

                                        i = reader.NumberOfPages > 1 ? (reader.NumberOfPages - 1) : i;
                                        if (i > 1) break;

                                    }

                                    if (cin16)
                                    {
                                        ErrorCTFIN(w);
                                        cin16 = false;
                                        break;
                                    }
                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        FileInfo fileInfo = new FileInfo(w);

                        using (StreamWriter streamWriter = new StreamWriter($@"{diretorioDestino}\CONTRATO_ERRO.txt", true))
                        {
                            streamWriter.WriteLine($"Arquivo: {fileInfo.Name}\nDiretorio: {fileInfo.FullName}");
                            streamWriter.WriteLine($"ERRO: {ex.Message}\n=======================================================================================");
                        };
                    }

                    contador++;
                    backgroundWorkerPonteiro.ReportProgress(contador);
                });
            }
            catch (Exception exP)
            {
                throw new Exception("Erro: "+ exP.Message );
            }
        }
    }
}
