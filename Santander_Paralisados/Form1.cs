using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Santander_Paralisados
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string roozipFilesPdf = $@"{Directory.GetCurrentDirectory()}\ParalizadosPdf";

        FolderBrowserDialog folderBrowserDialog = null;
        List<string> ponteiro, contratos  = null;
        ContratosPdf listContratosValidos = null;
        string rotulo = string.Empty;

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
                Description = "Selecione o dirtório de DESTINO dos contratos"
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

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(roozipFilesPdf))
                Directory.CreateDirectory(roozipFilesPdf);
            else
            {
                string[] _files = Directory.GetFiles(roozipFilesPdf);

                foreach (string itemFile in _files)
                {
                    File.Delete(itemFile);
                }
            }

          //  textBoxDestino.Text = @"C:\paralisados";
          //  textBoxOrigem.Text = @"C:\@TombamentoV1_01\TOMBAMENTOS\TOMBAMENTO2019-12-20";
           
            Thread threadInput = new Thread(DisplayData);
            threadInput.Start();
        }


        public static List<string> GetPonteiroExcel()
        {
            List<string> ponteiro = new List<string>();

            string con =
   $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Directory.GetCurrentDirectory()}\Excel\Contratos_Tombados.xlsx;" +
   @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select CONTRATOMONTREAL from [Tombamento$] ", connection);
                using (OleDbDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!string.IsNullOrEmpty(dr["CONTRATOMONTREAL"].ToString()))
                            ponteiro.Add(dr["CONTRATOMONTREAL"].ToString().Trim().Substring(1));
                    }
                }
            }

            return ponteiro;
        }


        private void SetLoading(bool displayLoader, int act = 0)
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
                    if (act == 0)
                    {
                        Cursor = Cursors.Default;
                        FrmProgress frm = new FrmProgress(listContratosValidos.Tela16, new List<string>() { textBoxOrigem.Text, roozipFilesPdf });
                        frm.ShowDialog();
                        panelMain.Visible = !panelMain.Visible;
                    }

                    if (act == 1)
                    {
                        Cursor = Cursors.Default;
                        panelMain.Visible = !panelMain.Visible;
                    }
                });
                
               
            }
        }

        private void DisplayData()
        {
            string[] telas = { "16", "18", "20", "25" };
            string _numeroContrato = string.Empty;
            contratos = new List<string>();
            FileInfo fileInfo = null;
            listContratosValidos = new ContratosPdf();
            try
            {
                SetLoading(true);

                Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Validando Ponteiro VS Arquivos..."; });
                ponteiro = new List<string>();
                ponteiro = GetPonteiroExcel();

                IEnumerable<string> arquivos = null;
                foreach (string itemTela in telas)
                {
                    arquivos = Directory.EnumerateFiles(textBoxOrigem.Text, $"*_{itemTela}.pdf", System.IO.SearchOption.AllDirectories);

                    if (arquivos.Count() == 0)
                        continue;

                    foreach (string item in arquivos)
                    {
                        fileInfo = new FileInfo(item);
                        _numeroContrato = fileInfo.Name.Split('_')[0].Trim();

                        if (itemTela.Equals("16"))
                        {
                            listContratosValidos.Tela16.Add(new KeyValuePair<string, string>(_numeroContrato, item));
                            contratos.Add(_numeroContrato);
                            continue;
                        }
                        if (itemTela.Equals("18"))
                        {
                            listContratosValidos.Tela18.Add(new KeyValuePair<string, string>(_numeroContrato, item));
                            continue;
                        }
                        if (itemTela.Equals("20"))
                        {
                            listContratosValidos.Tela20.Add(new KeyValuePair<string, string>(_numeroContrato, item));
                            continue;
                        }
                        if (itemTela.Equals("25"))
                        {
                            listContratosValidos.Tela25.Add(new KeyValuePair<string, string>(_numeroContrato, item));
                            continue;
                        }
                        if (itemTela.Equals("34"))
                        {
                            listContratosValidos.Tela34.Add(new KeyValuePair<string, string>(_numeroContrato, item));
                            continue;
                        }
                        _numeroContrato = string.Empty;
                        fileInfo = null;
                    }
                }

                fileInfo = null;
                ponteiro = ponteiro.Intersect(contratos).ToList();
                contratos = contratos.Except(ponteiro).ToList();

                contratos.ForEach(c =>
                {
                    listContratosValidos.Tela16.RemoveAll(r => r.Key.Equals(c));
                    listContratosValidos.Tela18.RemoveAll(r => r.Key.Equals(c));
                    listContratosValidos.Tela20.RemoveAll(r => r.Key.Equals(c));
                    listContratosValidos.Tela25.RemoveAll(r => r.Key.Equals(c));
                    listContratosValidos.Tela34.RemoveAll(r => r.Key.Equals(c));
                });


                SetLoading(false);
                ZiparContratos();

               
                System.Diagnostics.Process.Start("explorer.exe", textBoxDestino.Text);
                Application.Exit();
                MessageBox.Show("Processo Finalizado com sucesso", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exLoad)
            {
                MessageBox.Show($"Erro ao carregar contratos\n{exLoad.Message}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ZiparContratos()
        {
            try
            {
                SetLoading(true, 1);

                listContratosValidos.Tela16.Clear();
               // listContratosValidos.Tela25.Clear();
               // listContratosValidos.Tela18.Clear();
                CriaPastas();

                FileInfo fileInfo = null;
                Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Copiando arquivos Tela 16"; });
                   
                foreach (KeyValuePair<string,string> item in listContratosValidos.Tela16)
                {
                    fileInfo = new FileInfo(item.Value);
                    File.Copy(item.Value, $@"{roozipFilesPdf}\Tela16\{fileInfo.Name}", true);
                }

                Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Copiando arquivos Tela 18"; });
                foreach (KeyValuePair<string, string> item in listContratosValidos.Tela18)
                {
                    fileInfo = new FileInfo(item.Value);
                    File.Copy(item.Value, $@"{roozipFilesPdf}\Tela18\{fileInfo.Name}", true);
                }

                Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Copiando arquivos Tela 20"; });
                foreach (KeyValuePair<string, string> item in listContratosValidos.Tela20)
                {
                    fileInfo = new FileInfo(item.Value);
                    File.Copy(item.Value, $@"{roozipFilesPdf}\Tela20\{fileInfo.Name}",true);
                }

                Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Copiando arquivos Tela 25"; });
                foreach (KeyValuePair<string, string> item in listContratosValidos.Tela25)
                {
                    fileInfo = new FileInfo(item.Value);
                    File.Copy(item.Value, $@"{roozipFilesPdf}\Tela25\{fileInfo.Name}", true);
                }

                Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Copiando arquivos Tela 34"; });
                foreach (KeyValuePair<string, string> item in listContratosValidos.Tela34)
                {
                    fileInfo = new FileInfo(item.Value);
                    File.Copy(item.Value, $@"{roozipFilesPdf}\Tela34\{fileInfo.Name}", true);
                }


                if (listContratosValidos.Tela16.Count > 0)
                {
                    Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Compactando Tela 16, Aguarde"; });
                    ZipFile.CreateFromDirectory($@"{roozipFilesPdf}\Tela16\", $@"{roozipFilesPdf}\Tela16.zip");
                    Directory.Delete($@"{roozipFilesPdf}\Tela16\", true);
                }

                if (listContratosValidos.Tela18.Count > 0)
                {
                    Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Compactando Tela 18, Aguarde"; });
                    ZipFile.CreateFromDirectory($@"{roozipFilesPdf}\Tela18\", $@"{roozipFilesPdf}\Tela18.zip");
                    Directory.Delete($@"{roozipFilesPdf}\Tela18\", true);
                }

                if (listContratosValidos.Tela20.Count > 0)
                {
                    Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Compactando Tela 20, Aguarde"; });
                    ZipFile.CreateFromDirectory($@"{roozipFilesPdf}\Tela20\", $@"{roozipFilesPdf}\Tela20.zip");
                    Directory.Delete($@"{roozipFilesPdf}\Tela20\", true);
                }

                if (listContratosValidos.Tela25.Count > 0)
                {
                    Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Compactando Tela 25, Aguarde"; });
                    ZipFile.CreateFromDirectory($@"{roozipFilesPdf}\Tela25\", $@"{roozipFilesPdf}\Tela25.zip");
                    Directory.Delete($@"{roozipFilesPdf}\Tela25\", true);
                }

                if (listContratosValidos.Tela34.Count > 0)
                {
                    Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Compactando Tela 34, Aguarde"; });
                    ZipFile.CreateFromDirectory($@"{roozipFilesPdf}\Tela34\", $@"{roozipFilesPdf}\Tela34.zip");
                    Directory.Delete($@"{roozipFilesPdf}\Tela34\", true);
                }


                Invoke((MethodInvoker)delegate { lblSetLoad.Text = "Iniciar transferencia de destino."; });

                if (File.Exists($@"{textBoxDestino.Text}\CONTRAOS_PARALISADOS.xlsx"))
                    File.Delete($@"{textBoxDestino.Text}\CONTRAOS_PARALISADOS.xlsx");

                File.Move($@"{roozipFilesPdf}\CONTRAOS_PARALISADOS.xlsx", $@"{textBoxDestino.Text}\CONTRAOS_PARALISADOS.xlsx");
                

                Invoke((MethodInvoker)delegate { Hide(); });
                FileSystem.MoveDirectory(roozipFilesPdf,  textBoxDestino.Text, UIOption.AllDialogs, UICancelOption.DoNothing);
                Invoke((MethodInvoker)delegate { Show(); });

                if (Directory.Exists(roozipFilesPdf))
                    Directory.Delete(roozipFilesPdf, true);

                SetLoading(false, 1);
            }
            catch (Exception exComp)
            {
                SetLoading(false, 1);
                throw new Exception("ao tentar copiar ou compactar arquivos.\n" + exComp.Message, exComp.InnerException);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

           if( WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Minimized;
           else
                WindowState = FormWindowState.Normal;

            //  FileSystem.MoveFile(@"C:\Users\x194262\Desktop\teste", @"\\bsbrsp1010\apps\MI\AglesTeste", UIOption.AllDialogs, UICancelOption.DoNothing);

        }

        void CriaPastas()
        {
            if (Directory.Exists($@"{roozipFilesPdf}\Tela16"))
                Directory.Delete($@"{roozipFilesPdf}\Tela16\", true);

            if (Directory.Exists($@"{roozipFilesPdf}\Tela18"))
                Directory.Delete($@"{roozipFilesPdf}\Tela18\", true);

            if (Directory.Exists($@"{roozipFilesPdf}\Tela20"))
                Directory.Delete($@"{roozipFilesPdf}\Tela20\", true);

            if (Directory.Exists($@"{roozipFilesPdf}\Tela25"))
                Directory.Delete($@"{roozipFilesPdf}\Tela25\", true);

            if (Directory.Exists($@"{roozipFilesPdf}\Tela34"))
                Directory.Delete($@"{roozipFilesPdf}\Tela34\", true);

            if (listContratosValidos.Tela16.Count > 0)
                Directory.CreateDirectory($@"{roozipFilesPdf}\Tela16\");

            if (listContratosValidos.Tela18.Count > 0)
                Directory.CreateDirectory($@"{roozipFilesPdf}\Tela18\");

            if (listContratosValidos.Tela20.Count > 0)
                Directory.CreateDirectory($@"{roozipFilesPdf}\Tela20\");

            if (listContratosValidos.Tela25.Count > 0)
                Directory.CreateDirectory($@"{roozipFilesPdf}\Tela25\");

            if (listContratosValidos.Tela34.Count > 0)
                Directory.CreateDirectory($@"{roozipFilesPdf}\Tela34\");

        }


        //private void RemoveDuplicado(IEnumerable<string> _arquivos)
        //{
        //    try
        //    {
        //        List<string> listDuplicados = _arquivos.GroupBy(s => s).SelectMany(d => d.Skip(1)).ToList();
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


    }



}


