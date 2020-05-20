using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Santander_Paralisados
{
    public partial class FrmProgress : Form
    {
        List<KeyValuePair<string, string>> ponteiro = null;
        Thread _thread = null;
        Stopwatch stopwatch = new Stopwatch();
        int totalArquivo = 0;
        string PathFileCompany = string.Empty, pathDestino = string.Empty;
        DataTable table = null;

        public FrmProgress(List<KeyValuePair<string, string>> _ponteiro, List<string> _diretorios)
        {
            InitializeComponent();
            PathFileCompany = _diretorios[0];
            pathDestino = _diretorios[1];
            ponteiro = _ponteiro;
        }


        public void GetTableExcel(object parametro)
        {
            DataTable dataTable = (DataTable)parametro.GetType().GetProperty("item1").GetValue(parametro, null);

            string con =
    $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pathDestino}\CONTRAOS_PARALISADOS.xlsx;" +
    @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = null;

                foreach (DataRow item in dataTable.Rows)
                {
                    command = new OleDbCommand($"INSERT INTO [Planilha1$] (CONTRATO, NOME, DOCUMENTO, DATACONTRATO) VALUES ('{item[2].ToString()}', '{item[0].ToString()}', '{item[1].ToString()}', '{item[3].ToString()}')", connection);
                    command.ExecuteNonQuery();
                }

                command.Dispose();
                command = null;
            }

        }

        private static DataTable CriaTabelaPdf()
        {
            var table = new DataTable();
            table.Columns.Add("PersonName", typeof(string));
            table.Columns.Add("PersonDocument", typeof(string));
            table.Columns.Add("NumberContract", typeof(string));
            table.Columns.Add("DateContract", typeof(DateTime));

            return table;
        }

        private void FrmProgress_Load(object sender, EventArgs e)
        {

            if(File.Exists($@"{pathDestino}\CONTRAOS_PARALISADOS.xlsx"))
            {
                File.Delete($@"{pathDestino}\CONTRAOS_PARALISADOS.xlsx");
                File.Copy($@"{Directory.GetCurrentDirectory()}\Excel\CONTRAOS_PARALISADOS.xlsx", $@"{pathDestino}\CONTRAOS_PARALISADOS.xlsx");
            }
            else
                File.Copy($@"{Directory.GetCurrentDirectory()}\Excel\CONTRAOS_PARALISADOS.xlsx", $@"{pathDestino}\CONTRAOS_PARALISADOS.xlsx");

        }

        private void FrmProgress_Shown(object sender, EventArgs e)
        {
            totalArquivo = ponteiro.Count; 
            progressBarParalizados.Minimum = 0;
            progressBarParalizados.Maximum = totalArquivo;

            stopwatch.Restart();
            backgroundWorkerProgress.RunWorkerAsync();
        }

        private void backgroundWorkerProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            DataRow dataRow = null;
          
            try
            {
                table = CriaTabelaPdf();

                string newNameContract = string.Empty;
                int contador = 0, sequencia = 0;
                string pagina, _personDocument;
                bool isDateContract;
                List<string> arrayLine = new List<string>();
               
                FileCompress fileCompress = null;

                ponteiro.ForEach(w =>
                {

                    fileCompress = new FileCompress();
                    try
                    {
                        isDateContract = false;
                        FileInfo _contract = new FileInfo(w.Value);
                        using (PdfReader reader = new PdfReader(w.Value))
                        {
                            ITextExtractionStrategy its;
                            pagina = _personDocument = string.Empty;

                            for (int i = 1; i <= reader.NumberOfPages; i++)
                            {
                                its = new LocationTextExtractionStrategy();
                                pagina = PdfTextExtractor.GetTextFromPage(reader, i, its).Trim();

                                using (StringReader strReader = new StringReader(pagina))
                                {
                                    string line = string.Empty;

                                    while ((line = strReader.ReadLine()) != null)
                                    {
                                        arrayLine = line.Split(' ').ToList();

                                        if (!isDateContract)
                                        {
                                            if (!arrayLine.Any(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"))) continue;

                                            sequencia = arrayLine.ToList().FindIndex(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"));

                                            fileCompress.PersonName = string.Join(" ", arrayLine.Take((sequencia - 1)).ToArray());
                                            fileCompress.NumberContract = _contract.Name.Split('_')[0].PadLeft(15,'0');

                                            _personDocument = arrayLine.FirstOrDefault(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"));
                                            fileCompress.PersonDocument = Regex.Replace(_personDocument, "[^0-9$]", string.Empty);
                                            isDateContract = true;
                                            continue;
                                        }
                                        else
                                        {
                                            if (!arrayLine.Any(c => Regex.IsMatch(c, @"(^\d{2}/\d{2}/\d{4}$)"))) continue;

                                            fileCompress.DateContract = Convert.ToDateTime(arrayLine.Find(c => Regex.IsMatch(c, @"(^\d{2}/\d{2}/\d{4}$)")));
                                            fileCompress.EncryptedFile = File.ReadAllBytes(_contract.FullName);
                                        }
                                        break;
                                    }
                                }

                                if (!string.IsNullOrWhiteSpace(_personDocument))
                                    break;
                            }


                            if (fileCompress.PersonName != null)
                            {
                                dataRow = table.NewRow();

                                dataRow["PersonName"] = fileCompress.PersonName.Length > 100 ? fileCompress.PersonName.Substring(0, 100) : fileCompress.PersonName;
                                dataRow["PersonDocument"] = fileCompress.PersonDocument;
                                dataRow["NumberContract"] = fileCompress.NumberContract;
                                dataRow["DateContract"] = fileCompress.DateContract;

                                table.Rows.Add(dataRow);
                            }

                        }
                        contador++;
                        _contract = null;

                        backgroundWorkerProgress.ReportProgress(contador);

                        if (table.Rows.Count == 1000)
                        {
                            var tab = new
                            {
                                item1 = table,
                            };

                            if (_thread != null)
                                if (_thread.ThreadState == System.Threading.ThreadState.Running)
                                    _thread.Join();

                            _thread = new Thread(new ParameterizedThreadStart(GetTableExcel));
                            _thread.Start(tab);

                            table = CriaTabelaPdf();
                        }

                    }

                    catch (Exception ex)
                    {
                        string err = ex.Message;
                    }

                });


                if (table.Rows.Count > 0)
                {
                    var tab = new
                    {
                        item1 = table,
                    };
                    GetTableExcel(tab);
                }

            }
            catch (Exception ex)
            {
                string err = ex.Message;
            }

            
        }

        private void backgroundWorkerProgress_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            lbllidos.Text = string.Format("Contratos lidos: {0}", e.ProgressPercentage.ToString());

            if (progressBarParalizados.Value < progressBarParalizados.Maximum)
                progressBarParalizados.Value = e.ProgressPercentage;
           
            lblTotal.Text =$"Total de Contratos: {totalArquivo} - Pendente: {(totalArquivo - e.ProgressPercentage)}";
            lblporcentagem.Text = string.Format("{0:P2}", (double)e.ProgressPercentage / (double)(progressBarParalizados.Maximum));
            lblTempo.Text = string.Format("Tempo de Execução: {0}:{1}:{2}:{3} ms", stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
            
        }

        private void backgroundWorkerProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

           
           // MessageBox.Show("Processo concluido!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }
    }
}
