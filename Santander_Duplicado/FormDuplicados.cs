using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Santander_Duplicado
{
    public partial class FormDuplicados : Form
    {
        public FormDuplicados()
        {
            InitializeComponent();
        }

        int contador = 0 , checado = 0;

        FolderBrowserDialog folderBrowserDialog = null;

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

        private void btnIniciar_Click(object sender, EventArgs e)
        {

            Thread threadInput = new Thread(RemoverDuplicado);
            threadInput.Start();
          
        }



        private void RemoverDuplicado()
        {
            string msg = "Processo concluido!";
           
            try
            {
                SetLoading(true);

                if (!Directory.Exists($@"{textBoxDestino.Text}\TELA16"))
                    Directory.CreateDirectory($@"{textBoxDestino.Text}\TELA16");

                if (!Directory.Exists($@"{textBoxDestino.Text}\TELA34"))
                    Directory.CreateDirectory($@"{textBoxDestino.Text}\TELA34");
               

                KeyValuePair<string, FileInfo> pair;
                FileInfo fileInfo = null;
                List<KeyValuePair<string, FileInfo>> valuePairs = new List<KeyValuePair<string, FileInfo>>();

                string[] telas = { "16", "34" };

                foreach (string itemTela in telas)
                {
                    Invoke((MethodInvoker)delegate
                    {
                        label3.Text = $"Movendo arquivos da Tela {itemTela}";
                    });
                    Directory.EnumerateFiles(textBoxOrigem.Text, $"*{itemTela}.pdf", SearchOption.AllDirectories).ToList().ForEach(c =>
                    {
                        fileInfo = new FileInfo(c);
                        pair = new KeyValuePair<string, FileInfo>(fileInfo.Name.Split('.')[0], fileInfo);
                        valuePairs.Add(pair);
                    });

                    if (valuePairs.Count == 0) continue;

                    var duplicado = valuePairs.GroupBy(g => g.Key).ToDictionary(x => x.Key, x => x.ToList()).ToList();

                    Invoke((MethodInvoker)delegate
                    {
                        lblTotalEcontrado.Text = valuePairs.Count.ToString();
                        lblTotalFiltrado.Text = duplicado.Count.ToString();
                    });


                    valuePairs.Clear();
                    duplicado.ForEach(dup =>
                    {
                        if (File.Exists($@"{textBoxDestino.Text}\TELA{itemTela}\{dup.Value.ElementAt(0).Value.Name}"))
                            checado++;
                        else
                        {
                            File.Move(dup.Value.ElementAt(0).Value.FullName, $@"{textBoxDestino.Text}\TELA{itemTela}\{dup.Value.ElementAt(0).Value.Name}");
                            contador++;
                        }

                        Invoke((MethodInvoker)delegate
                        {
                            lblchecado.Text = checado.ToString();
                            lblCopiado.Text = contador.ToString();
                        });

                    });

                    msg += $"\n\nResultado da Tela {itemTela}\n\nTotal Checados: {checado} \nTotal Movidos: {contador}\nTotal: {(checado + contador)}\n\n";

                    contador = 0;
                    checado = 0;
                    fileInfo = null;
                    valuePairs.Clear();
                    duplicado.Clear();

                    Invoke((MethodInvoker)delegate
                    {
                        lblchecado.Text = string.Empty;
                        lblCopiado.Text = string.Empty;
                        lblTotalEcontrado.Text = string.Empty;
                        lblTotalFiltrado.Text = string.Empty;
                    });
                   
                }
                Invoke((MethodInvoker)delegate
                {
                    label3.Text = " Aguarde o final do processo...";
                });

                SetLoading(false);


                MessageBox.Show(msg, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exeCopy)
            {
                throw new Exception("Erro no processo para Mover arquivos: " + exeCopy.Message);
            }
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
