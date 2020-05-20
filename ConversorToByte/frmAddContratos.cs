using ConversorToByte.BLL;
using ConversorToByte.DALL;
using ConversorToByte.DTO;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ConversorToByte
{
    public partial class frmAddContratos : Form
    {
        public frmAddContratos()
        {
            InitializeComponent();
        }
        List<long> listContracts = new List<long>();
        List<long> listContractsTable = new List<long>();

        Thread _thread = null;
        Stopwatch stopwatch = new Stopwatch();
        List<UploadFileContract> uploadFileContracts = null;
        List<string> arrayLine = new List<string>();
        int contador = 0, totalArquivos = 0, sequencia = 0, countPercent = 0;
        string tmp = string.Empty, pagina = string.Empty, _personDocument = string.Empty, _tela = string.Empty, _numberContract = string.Empty;
        FileInfo fileInfo = null;
        bool isDateContract = false, isNotTela = false;

        DataTable table = null;
        DataRow dataRow = null;

        Conn conn = null;
        FileSafeOperations fsf;

        private void frmAddContratos_Load(object sender, EventArgs e)
        {
            

            uploadFileContracts = new List<UploadFileContract>()
            {
                //new UploadFileContract(){ TypeContract = 'P', Tela = 16, TableName = "FileSafe16", Contracts = { } },
                //new UploadFileContract(){ TypeContract = 'P', Tela = 16, TableName = "FileSafeTeste", Contracts = { } },
                //new UploadFileContract(){ TypeContract = 'P', Tela = 18, TableName = "FileSafeTeste18", Contracts = { } },
                //new UploadFileContract(){ TypeContract = 'P', Tela = 20, TableName = "FileSafeTeste20", Contracts = { } },
                //new UploadFileContract(){ TypeContract = 'P', Tela = 25, TableName = "FileSafeTeste25", Contracts = { } },
                //new UploadFileContract(){ TypeContract = 'P', Tela = 34, TableName = "FileSafeTeste34", Contracts = { } },

                new UploadFileContract(){ TypeContract = 'P', Tela = 16, TableName = "FileSafe16", Contracts = { } },
                new UploadFileContract(){ TypeContract = 'P', Tela = 18, TableName = "FileSafe18", Contracts = { } },
                new UploadFileContract(){ TypeContract = 'P', Tela = 20, TableName = "FileSafe20", Contracts = { } },
                new UploadFileContract(){ TypeContract = 'P', Tela = 25, TableName = "FileSafe25", Contracts = { } },
                new UploadFileContract(){ TypeContract = 'P', Tela = 34, TableName = "FileSafe34", Contracts = { } },
            };

            conn = new Conn();
        }

        private void BtnOpenDirectory_Click(object sender, EventArgs e)
        {
            listContracts.Clear();
            fsf = new FileSafeOperations();
            listContracts = fsf.GetNumberContract(16);

            RadioButton radioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(chk => chk.Checked);
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = $"Selecione o diretório dos contratos {radioButton.Text}";
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                TextBoxOrigemContrato.Text = folderBrowserDialog.SelectedPath;
                BtnAddContrados.Enabled = true;

                uploadFileContracts.ForEach(f => { f.TypeContract = Convert.ToChar(radioButton.Text.Substring(0, 1));  f.Contracts = Directory.EnumerateFiles(TextBoxOrigemContrato.Text, $"*_{f.Tela}.pdf", SearchOption.AllDirectories); });
            }
            else
            {
                TextBoxOrigemContrato.Text = string.Empty;
                BtnAddContrados.Enabled = false;
                uploadFileContracts.ForEach(f => { f.TypeContract = 'P'; f.Contracts = null; });
            }
        }

        private void backgroundWorkerAddContract_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            try
            {
                lblDescricaoDuplicados.Visible = !lblDescricaoDuplicados.Visible;
                pictureBoxLoad.Visible = !pictureBoxLoad.Visible;

                FileSafeOperations fileSafeOperations = new FileSafeOperations();
                fileSafeOperations.RemoveDuplicateRegister();

                progressBarReaderPdf.Value = 0;
                progressBarReaderPdf.Maximum = 0;
                lblLidos.Text = "0";
                lblPorcentagem.Text = "0%";
                lblQtd.Text = "0";
                lblTempo.Text = "0";
                lblTela.Text = "Tela";
                pnlProgress.Visible = !pnlProgress.Visible;

                stopwatch.Stop();

                MessageBox.Show($"Carga concluída com sucesso\n{tmp}.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exCompleted)
            {
                throw exCompleted;
            }
        }

        private void BtnAddContrados_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBoxLoad.Visible = false;
                lblDescricaoDuplicados.Visible = false;
                pnlProgress.Visible = true;
                stopwatch.Restart();
                totalArquivos = uploadFileContracts[0].Contracts.Count();
                progressBarReaderPdf.Value = 0;
                lblContrato.Text = "0";
                lblLidos.Text = "0";
                lblPorcentagem.Text = "0%";
                lblTempo.Text = "0";

                backgroundWorkerAddContract.RunWorkerAsync();

            }
            catch (Exception exErro)
            {
                MessageBox.Show(exErro.Message);
            }
        }

        private static DataTable CriaTabela()
        {
            var table = new DataTable();
            table.Columns.Add("TypeContract", typeof(char));
            table.Columns.Add("NumberContract", typeof(string));
            table.Columns.Add("EncryptedFile", typeof(byte[]));

            return table;
        }

        DataTable CriaTabelaPdf()
        {
            var table = new DataTable();
            table.Columns.Add("TypeContract", typeof(string));
            table.Columns.Add("PersonName", typeof(string));
            table.Columns.Add("PersonDocument", typeof(string));
            table.Columns.Add("NumberContract", typeof(string));
            table.Columns.Add("DateContract", typeof(DateTime));
            table.Columns.Add("DateInclude", typeof(DateTime));
            table.Columns.Add("EncryptedFile", typeof(byte[]));

            return table;
        }


        void RemoveDuplicate()
        {
            List<long> newList = listContracts.Intersect(listContractsTable).ToList();
            List<long> lstExcep = listContractsTable.Except(listContracts).ToList();

            if (lstExcep.Count > 0)
                listContracts.AddRange(lstExcep);

            newList.ForEach(c => {
                table.Select($"NumberContract={c}").ToList().ForEach(d => d.Delete());
            });

        }

        private void backgroundWorkerAddContract_DoWork(object sender, DoWorkEventArgs e)
        {
            conn = new Conn();
            FileInfo _contract = null;
            try
            {
                foreach (var item in uploadFileContracts)
                {
                    try
                    {
                        // ################### INSERE NA BASE DE DADOS CONTRATOS DO TIPO TELA 16 ###################
                        if (item.Tela.Equals(16))
                        {
                            _tela = $"TELA {item.Tela}";
                            FileCompress fileCompress = null;
                            table = CriaTabelaPdf();

                            item.Contracts.ToList().ForEach(w =>
                            {
                                fileCompress = new FileCompress();
                                try
                                {
                                    isDateContract = false;
                                    _contract = new FileInfo(w);
                                    countPercent++;

                                    using (PdfReader reader = new PdfReader(w))
                                    {
                                        ITextExtractionStrategy its;
                                        pagina = _personDocument = string.Empty;

                                        for (int i = 1; i <= 1; i++)
                                        {
                                            its = new LocationTextExtractionStrategy();
                                            pagina = PdfTextExtractor.GetTextFromPage(reader, i, its).Trim();

                                            using (StringReader strReader = new StringReader(pagina))
                                            {
                                                string line = string.Empty;

                                                while ((line = strReader.ReadLine()) != null)
                                                {
                                                    arrayLine = line.Split(' ').ToList();

                                                    if (arrayLine.Any(ctn => ctn.Trim().Contains("CTFIN")))
                                                    {
                                                        if (!arrayLine.Any(ctn => ctn.Trim().Equals("CTFIN/O016A")))
                                                        {
                                                            isNotTela = true;
                                                            break;
                                                        }
                                                        
                                                    }

                                                    if (!isDateContract)
                                                    {
                                                        if (!arrayLine.Any(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"))) continue;

                                                        sequencia = arrayLine.ToList().FindIndex(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"));

                                                        fileCompress.PersonName = string.Join(" ", arrayLine.Take((sequencia - 1)).ToArray());
                                                        fileCompress.NumberContract = _contract.Name.Split('_')[0];

                                                        _personDocument = arrayLine.FirstOrDefault(c => Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\-\d{2}$)") || Regex.IsMatch(c, @"(^\d{3}.\d{3}.\d{3}\/\d{4}\-\d{2}$)"));
                                                        fileCompress.PersonDocument = Regex.Replace(_personDocument, "[^0-9$]", string.Empty);
                                                        isDateContract = true;
                                                        continue;
                                                    }
                                                    else
                                                    {
                                                        if (!arrayLine.Any(c => Regex.IsMatch(c, @"(^\d{2}/\d{2}/\d{4}$)"))) continue;

                                                        fileCompress.DateContract = Convert.ToDateTime(arrayLine.Find(c => Regex.IsMatch(c, @"(^\d{2}/\d{2}/\d{4}$)")));
                                                        fileCompress.TypeContract = item.TypeContract.ToString();
                                                        fileCompress.EncryptedFile = File.ReadAllBytes(_contract.FullName);
                                                    }
                                                    break;
                                                }
                                            }


                                            if (isNotTela) break;
                                            if (!string.IsNullOrWhiteSpace(_personDocument)) break;
                                        }

                                        if (!isNotTela)
                                        {
                                            dataRow = table.NewRow();

                                            dataRow["TypeContract"] = fileCompress.TypeContract.Trim();
                                            dataRow["PersonName"] = fileCompress.PersonName.Length > 100 ? fileCompress.PersonName.Substring(0, 100) : fileCompress.PersonName;
                                            dataRow["PersonDocument"] = fileCompress.PersonDocument;
                                            dataRow["NumberContract"] = fileCompress.NumberContract;
                                            dataRow["DateContract"] = fileCompress.DateContract;
                                            dataRow["DateInclude"] = DateTime.Now;
                                            dataRow["EncryptedFile"] = fileCompress.EncryptedFile;

                                            if (!table.AsEnumerable().Any(r => ((string)r["NumberContract"]) == fileCompress.NumberContract))
                                            {
                                                listContractsTable.Add(Convert.ToInt64(fileCompress.NumberContract));
                                                table.Rows.Add(dataRow);
                                            }
                                        }
                                    }

                                    contador++;
                                    backgroundWorkerAddContract.ReportProgress(countPercent, _contract);
                                    _contract = null;

                                    if (contador == 5000)
                                    {
                                        RemoveDuplicate();

                                        contador = 0;
                                        var tab = new
                                        {
                                            item1 = table,
                                            item2 = item.TableName,
                                        };

                                        if (table.Rows.Count > 0)
                                        {
                                            _thread = new Thread(new ParameterizedThreadStart(conn.FileStores));
                                            _thread.Start(tab);

                                            if (_thread.ThreadState == System.Threading.ThreadState.Running)
                                                _thread.Join();
                                        }
                                        table.Rows.Clear();
                                        listContractsTable.Clear();
                                    }

                                }
                                catch (iTextSharp.text.exceptions.InvalidPdfException exload)
                                {
                                    Console.Clear();
                                    Console.WriteLine(exload.Message + w);
                                }

                                catch (PdfException exload)
                                {
                                    Console.Clear();
                                    Console.WriteLine(exload.Message + w);
                                }

                            });


                            if (contador > 0)
                            {
                                RemoveDuplicate();

                                var tab = new
                                {
                                    item1 = table,
                                    item2 = item.TableName,
                                };

                                if (table.Rows.Count > 0)
                                    conn.FileStores(tab);

                                contador = 0;
                                table = null;
                                listContractsTable.Clear();
                            }
                        }
                        else
                        {
                          // ################### INSERE NA BASE DE DADOS CONTRATOS DO TIPO TELA (18,20,25 e 34) ###################
                            table = CriaTabela();
                            Thread.Sleep(500);
                            listContractsTable.Clear();
                            totalArquivos = item.Contracts.Count();
                            backgroundWorkerAddContract.ReportProgress(0);
                            _tela = $"TELA {item.Tela}";
                            int _typeTela = Convert.ToInt32(Regex.Replace(_tela, "[^0-9$]", string.Empty));
                            countPercent = 0;
                            listContracts.Clear();
                            listContracts = fsf.GetNumberContract(_typeTela);

                            item.Contracts.ToList().ForEach(w =>
                            {
                                try
                                {
                                    _contract = new FileInfo(w);
                                    dataRow = table.NewRow();
                                    countPercent++;

                                    using (PdfReader reader = new PdfReader(w))
                                    {
                                        ITextExtractionStrategy its;
                                        pagina = _personDocument = string.Empty;

                                        for (int i = 1; i <= 1; i++)
                                        {
                                            its = new LocationTextExtractionStrategy();
                                            pagina = PdfTextExtractor.GetTextFromPage(reader, i, its).Trim();

                                            using (StringReader strReader = new StringReader(pagina))
                                            {
                                                string line = string.Empty;

                                                while ((line = strReader.ReadLine()) != null)
                                                {
                                                    arrayLine = line.Split(' ').ToList();

                                                    if (arrayLine.Any(ctn => ctn.Trim().Contains("CTFIN")))
                                                    {
                                                        if (!arrayLine.Any(ctn => ctn.Trim().Equals($"CTFIN/O0{_typeTela}A")))
                                                        {
                                                            isNotTela = true;
                                                            break;
                                                        }
                                                        else break;
                                                    }
                                                }
                                            }

                                            if (isNotTela)
                                                break;
                                        }
                                    }

                                    if (isNotTela)
                                    {
                                        isNotTela = false;
                                        return;
                                    }

                                    _numberContract = _contract.Name.Split('_')[0];
                                    dataRow["TypeContract"] = item.TypeContract;
                                    dataRow["NumberContract"] = _contract.Name.Split('_')[0];
                                    dataRow["EncryptedFile"] = File.ReadAllBytes(_contract.FullName);

                                    if (!table.AsEnumerable().Any(r => ((string)r["NumberContract"]) == _numberContract))
                                    {
                                        table.Rows.Add(dataRow);
                                        listContractsTable.Add(Convert.ToInt64(_contract.Name.Split('_')[0]));
                                    }
                                    contador++;

                                    backgroundWorkerAddContract.ReportProgress(countPercent, _contract);
                                    _contract = null;

                                    if (contador == 5000)
                                    {
                                        RemoveDuplicate();

                                        contador = 0;
                                        var tab = new
                                        {
                                            item1 = table,
                                            item2 = item.TableName,
                                        };

                                        if (table.Rows.Count > 0)
                                        {
                                            _thread = new Thread(new ParameterizedThreadStart(conn.FileStores));
                                            _thread.Start(tab);

                                            if (_thread.ThreadState == System.Threading.ThreadState.Running)
                                                _thread.Join();
                                        }

                                        table.Rows.Clear();
                                        listContractsTable.Clear();
                                        arrayLine.Clear();
                                    }

                                }
                                catch (Exception exload)
                                {

                                    string err = exload.Message;
                                    Console.WriteLine(err + "-----> " + _contract.FullName);
                                }
                            });


                            if (contador > 0)
                            {
                                RemoveDuplicate();

                                var tab = new
                                {
                                    item1 = table,
                                    item2 = item.TableName,
                                };

                                if (table.Rows.Count > 0)
                                    conn.FileStores(tab);

                                contador = 0;
                                table = null;
                                listContractsTable.Clear();
                                arrayLine.Clear();
                            }
                        }

                    }
                    catch (Exception exLoop)
                    {
                        string err = exLoop.Message;
                        Console.WriteLine(err + "-----> " + _contract.FullName);
                    }

                }
            }
            catch (Exception exErroWork)
            {
                string err = exErroWork.Message;
                Console.WriteLine(err + "-----> " + _contract.FullName);
            }
        }

        private void backgroundWorkerAddContract_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                progressBarReaderPdf.Maximum = totalArquivos;
                lblLidos.Text = string.Format("Contratos lidos: {0}", e.ProgressPercentage.ToString());
                lblTela.Text = _tela;

                fileInfo = (FileInfo)e.UserState;

                if (progressBarReaderPdf.Value <= progressBarReaderPdf.Maximum)
                    progressBarReaderPdf.Value = e.ProgressPercentage;

                if (fileInfo != null)
                {
                    tmp = string.Format("Tempo de Execução: {0}:{1}:{2}:{3} ms", stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
                    lblQtd.Text = string.Format("Total de Arquivos: {0}", totalArquivos);
                    lblPorcentagem.Text = string.Format("{0:P2}", (double)e.ProgressPercentage / (double)(progressBarReaderPdf.Maximum));
                    lblTempo.Text = tmp;
                    lblContrato.Text = string.Format("Contrato: {0}", fileInfo.Name.Split('_')[0]);
                }
            }
            catch (Exception exProgress)
            {
                MessageBox.Show(exProgress.Message);
            }
        }
    }
}
