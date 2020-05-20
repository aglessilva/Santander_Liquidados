using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Santander_Duplicado
{
    public partial class frmConsolidar : Form
    {
        public frmConsolidar()
        {
            InitializeComponent();
        }

        int contador = 0, checado = 0;
        Stopwatch stopwatch = new Stopwatch();
        FolderBrowserDialog folderBrowserDialog = null;

        private void btnPonteiro_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Filter = "Ponteiro|*.txt";
                openFile.Title = "Selecione o ponteiro dos contratos";
                DialogResult result =  openFile.ShowDialog();

                if (result == DialogResult.OK)
                    textBoxPonteiro.Text = openFile.FileName;
                else
                    textBoxPonteiro.Text = string.Empty;
            };
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {
            folderBrowserDialog = new FolderBrowserDialog
            {
                Description = "Selecione o dirtório de DESTINO"
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


        void Consolidar()
        {
           
            string msg = "Processo concluido!";
            try
            {
                SetLoading(true);

                KeyValuePair<string, FileInfo> pair;
                FileInfo fileInfo = null;
                List<KeyValuePair<string, FileInfo>> valuePairs = new List<KeyValuePair<string, FileInfo>>();
                List<string> lstPonteiro = new List<string>();
                List<string> lstArquivos = new List<string>();

                Invoke((MethodInvoker)delegate
                {
                    stopwatch.Restart();
                    label3.Text = $"Aguarde, localizando arquivos";
                });

                using (StreamReader streamReader = new StreamReader(textBoxPonteiro.Text, Encoding.Default))
                {
                    while (!streamReader.EndOfStream)
                    {
                        lstPonteiro.Add(streamReader.ReadLine());
                    }
                }

                string[] telas = { "16","18","20","25", "34" };

                string file = string.Empty;

                foreach (string itemTela in telas)
                {
                    Directory.EnumerateFiles(textBoxOrigem.Text, $"*_{itemTela}.pdf", SearchOption.AllDirectories).ToList().ForEach(c =>
                    {
                        fileInfo = new FileInfo(c);
                        file = fileInfo.Name.Split('_')[0].Length <= 14 ? fileInfo.Name.Split('_')[0] : fileInfo.Name.Split('_')[0].Substring(1);
                        pair = new KeyValuePair<string, FileInfo>(file, fileInfo);
                        valuePairs.Add(pair);
                        lstArquivos.Add(pair.Key);
                        file = string.Empty;
                    });

                    if (valuePairs.Count == 0)
                        continue;
                    else
                        if (!Directory.Exists($@"{textBoxDestino.Text}\TELA{itemTela}"))
                            Directory.CreateDirectory($@"{textBoxDestino.Text}\TELA{itemTela}");

                    List<string> removidos = lstArquivos.Except(lstPonteiro).ToList();

                    Invoke((MethodInvoker)delegate
                    {
                        label3.Text = $"Analise Ponteito Vs Arquivos";
                        lblTotalEcontrado.Text = valuePairs.Count.ToString();
                        lblTotalPonteiro.Text = lstPonteiro.Count.ToString();
                    });


                    valuePairs.RemoveAll(r => !removidos.Contains(r.Key));
                    int remover = valuePairs.Count;

                    Invoke((MethodInvoker)delegate
                    {
                        lblTotalFiltrado.Text = remover.ToString();
                        label3.Text = $"Movimentando tela {itemTela}...";
                    });


                    valuePairs.ForEach(dup =>
                    {
                        if (File.Exists($@"{textBoxDestino.Text}\TELA{itemTela}\{dup.Value.Name}"))
                            checado++;
                        else
                        {
                            File.Move(dup.Value.FullName, $@"{textBoxDestino.Text}\TELA{itemTela}\{dup.Value.Name}");
                            contador++;
                        }

                        Invoke((MethodInvoker)delegate
                        {
                            lblchecado.Text = checado.ToString();
                            lblCopiado.Text = contador.ToString();
                            lblTempo.Text = string.Format("Tempo de Execução: {0}:{1}:{2}:{3} ms", stopwatch.Elapsed.Hours, stopwatch.Elapsed.Minutes, stopwatch.Elapsed.Seconds, stopwatch.Elapsed.Milliseconds);
                        });

                    });

                    msg += $"\n\nResultado da Tela {itemTela}\nTotal Checados: {checado} \nTotal Movidos: {contador}\nTotal: {(checado + contador)}\n";

                    contador = 0;
                    checado = 0;
                    fileInfo = null;
                    valuePairs.Clear();
                    removidos.Clear();
                    lstArquivos.Clear();

                    Invoke((MethodInvoker)delegate
                    {
                        lblchecado.Text = string.Empty;
                        lblCopiado.Text = string.Empty;
                        lblTotalEcontrado.Text = string.Empty;
                        lblTotalFiltrado.Text = string.Empty;
                    });

                }

                stopwatch.Stop();
                SetLoading(false);
                lstPonteiro.Clear();

                MessageBox.Show(msg+$"\n\n{lblTempo.Text}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception exD)
            {
                throw new Exception("Erro:" + exD.Message);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            Thread threadInput = new Thread(Consolidar);
            threadInput.Start();
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
