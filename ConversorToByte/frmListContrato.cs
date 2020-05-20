using ConversorToByte.BLL;
using ConversorToByte.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ConversorToByte
{
    public partial class frmListContrato : Form
    {
        FileSafeOperations fsf;

        public frmListContrato()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Height = (Screen.PrimaryScreen.Bounds.Height - 30);

            fsf = new FileSafeOperations();
            Users obj = fsf.CheckUser(Environment.UserName);

            dataGridViewContract.Enabled = (obj.IsAtivo || obj.IsGestorApp);

            ValidaPermissao(obj);
            BindGrid();
        }

        void BindGrid()
        {
            List<FileSafe> lst = fsf.GetFilesAll(null, 'P');
            dataGridViewContract.AutoGenerateColumns = false;
            dataGridViewContract.DataSource = lst.ToList();
        }

        private void ValidaPermissao(Users obj)
        {
            SessionUser.IsGestorApp = obj.IsGestorApp;
            SessionUser.UserLogin = Environment.UserName;
            menuStrip1.Visible = obj.IsGestorApp;
        }



        private void DataGridViewContract_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex < 3)
                return;

            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 3)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Contrato|*.pdf";

                fsf = new FileSafeOperations();
                List<FileSafe> fileSaves = fsf.DownloadFile(obj.T16);

                if (fileSaves.Count == 0)
                    return;

                saveFile.FileName = obj.T16;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string _path = new FileInfo(saveFile.FileName).DirectoryName + @"\" + obj.T16;

                    if (Directory.Exists(_path))
                        Directory.Delete(_path, true);

                    Directory.CreateDirectory(_path);

                    foreach (FileSafe fileSafe in fileSaves)
                    {
                        if (fileSafe.EncryptedFile != null)
                        {
                            using (BinaryWriter writer = new BinaryWriter(File.Open(_path + @"\" + obj.T16 + fileSafe.PersonName + ".pdf", FileMode.Create)))
                            { writer.Write(fileSafe.EncryptedFile); }
                        }
                    }

                    if (MessageBox.Show(string.Format("Deseja abrir o diretório onde o contrato ({0}) foi salvo?", obj.T16), "Contratos Liquidados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        Process.Start("explorer.exe", _path);
                        Cursor.Current = Cursors.Default;
                    }
                }
            }

            // TELA 16
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 4)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                AbrirContrato(obj.T16, "16");
            }

            // TELA 18
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrWhiteSpace(obj.T18))
                    AbrirContrato(obj.T16, "18");
            }

            // TELA 20
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrWhiteSpace(obj.T20))
                    AbrirContrato(obj.T16, "20");
            }

            // TELA 25
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrWhiteSpace(obj.T25))
                    AbrirContrato(obj.T16, "25");
            }
        }

        void AbrirContrato(string _Contract, string _tela)
        {
            fsf = new FileSafeOperations();
            FileSafe _file = fsf.GetFileSafe(_Contract, _tela);

            _file.T16 = _Contract;
            frmpdf _frmPdf = new frmpdf(_file);
            _frmPdf.ShowDialog();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            radioTypeContract.Checked = true;
            maskedTextBoxDataIni.Text = string.Empty;
            maskedTextBoxDataFim.Text = string.Empty;
            textBoxContratocpf.Text = string.Empty;
            textBoxContratocpf.Focus();
            BindGrid();
        }

        private void textBoxContratocpf_TextChanged(object sender, EventArgs e)
        {
            if (textBoxContratocpf.Text.Length >= 4)
            {
                RadioButton radioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(chk => chk.Checked);
                dataGridViewContract.DataSource = null;
                List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text, Convert.ToChar(radioButton.Text.ToUpper().Substring(0, 1)), RetonaData());
                dataGridViewContract.DataSource = lst.ToList();
            }
            else
            {
                if (dataGridViewContract.Rows.Count != 100)
                {
                    RadioButton radioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(chk => chk.Checked);
                    dataGridViewContract.DataSource = null;
                    List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text, Convert.ToChar(radioButton.Text.ToUpper().Substring(0, 1)), RetonaData());
                    dataGridViewContract.DataSource = lst.ToList();
                }
            }

        }

        private void dataGridViewContract_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;
                foreach (DataGridViewRow item in senderGrid.Rows)
                {
                    FileSafe obj = (FileSafe)item.DataBoundItem;

                    if (string.IsNullOrEmpty(obj.T18))
                    {
                        if (senderGrid.Columns[5] is DataGridViewImageColumn && item.Index >= 0)
                        {
                            item.Cells[5].Value = Properties.Resources.Childish_Cross_24996;
                        }
                    }

                    if (string.IsNullOrEmpty(obj.T20))
                    {
                        if (senderGrid.Columns[6] is DataGridViewImageColumn && item.Index >= 0)
                        {
                            item.Cells[6].Value = Properties.Resources.Childish_Cross_24996;
                        }
                    }

                    if (string.IsNullOrEmpty(obj.T25))
                    {
                        if (senderGrid.Columns[7] is DataGridViewImageColumn && item.Index >= 0)
                        {
                            item.Cells[7].Value = Properties.Resources.Childish_Cross_24996;
                        }
                    }

                    if (string.IsNullOrEmpty(obj.T34))
                    {
                        if (senderGrid.Columns[8] is DataGridViewImageColumn && item.Index >= 0)
                        {
                            item.Cells[8].Value = Properties.Resources.Childish_Cross_24996;
                        }
                    }
                }
            }
            catch (Exception exAddRow)
            {
                string _err = exAddRow.Message;
            }
        }


        void GetTypeContract(string _parametro, char _typeContract, DateTime[] _dataParam =  null)
        {
            dataGridViewContract.DataSource = null;
            List<FileSafe> lst = fsf.GetFilesAll(_parametro, _typeContract, _dataParam);
            dataGridViewContract.DataSource = lst.ToList();
        }

        DateTime[] RetonaData()
        {
            DateTime[] dataParam = new DateTime[2];
            dataParam[0] = maskedTextBoxDataIni.Text.Trim().Length == 10 ? Convert.ToDateTime(maskedTextBoxDataIni.Text.Trim()) : (DateTime.Now.AddDays(-20000).Date);
            dataParam[1] = maskedTextBoxDataFim.Text.Length == 10 ? Convert.ToDateTime(maskedTextBoxDataFim.Text) : DateTime.Now.Date;
            return dataParam;
        }

        private void radioAtivos_Click(object sender, EventArgs e)
        {
            string _paramentro = string.IsNullOrWhiteSpace(textBoxContratocpf.Text) ? null : textBoxContratocpf.Text;
            GetTypeContract(_paramentro , Convert.ToChar(radioAtivos.Text.ToUpper().Substring(0, 1)),RetonaData());
        }

        private void radioTypeContract_Click(object sender, EventArgs e)
        {
            string _paramentro = string.IsNullOrWhiteSpace(textBoxContratocpf.Text) ? null : textBoxContratocpf.Text;
            GetTypeContract(_paramentro, Convert.ToChar(radioTypeContract.Text.ToUpper().Substring(0, 1)), RetonaData());
        }

        private void radioLiquidados_Click(object sender, EventArgs e)
        {
            string _paramentro = string.IsNullOrWhiteSpace(textBoxContratocpf.Text) ? null : textBoxContratocpf.Text;
            GetTypeContract(_paramentro, Convert.ToChar(radioLiquidados.Text.ToUpper().Substring(0, 1)), RetonaData());
        }

        private void addUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddUsuariosAD f = new FrmAddUsuariosAD();
            f.ShowDialog();
        }

        private void addContratosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddContratos frm = new frmAddContratos();
            frm.ShowDialog();
        }

        private void maskedTextBoxDataIni_TextChanged(object sender, EventArgs e)
        {
            if (maskedTextBoxDataIni.Text.Length == 10)
            {
                DateTime[] _dataInicial = RetonaData();
                if (!DateTime.TryParse(_dataInicial[0].ToShortDateString(), out _dataInicial[0]))
                {
                    MessageBox.Show($"Data {maskedTextBoxDataIni.Text.Trim()} de inicio inválida! ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                RadioButton radioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(chk => chk.Checked);
                dataGridViewContract.DataSource = null;
                List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text, Convert.ToChar(radioButton.Text.ToUpper().Substring(0, 1)), RetonaData());
                dataGridViewContract.DataSource = lst.ToList();
                maskedTextBoxDataFim.Focus();
                return;
            }

            if (Regex.Replace(maskedTextBoxDataIni.Text, @"[^0-9$]", "").Length == 0 && !string.IsNullOrWhiteSpace(textBoxContratocpf.Text) )
            {
                RadioButton radioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(chk => chk.Checked);
                dataGridViewContract.DataSource = null;
                List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text, Convert.ToChar(radioButton.Text.ToUpper().Substring(0, 1)), RetonaData());
                dataGridViewContract.DataSource = lst.ToList();
            }
        }

        private void maskedTextBoxDataFim_TextChanged(object sender, EventArgs e)
        {

            if (maskedTextBoxDataFim.Text.Length == 10)
            {
                DateTime[] _dataInicial = RetonaData();
                if (!DateTime.TryParse(_dataInicial[1].ToShortDateString(), out _dataInicial[1]))
                {
                    MessageBox.Show($"Data {maskedTextBoxDataFim.Text.Trim()} Final inválida! ", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                RadioButton radioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(chk => chk.Checked);
                dataGridViewContract.DataSource = null;
                List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text, Convert.ToChar(radioButton.Text.ToUpper().Substring(0, 1)), RetonaData());
                dataGridViewContract.DataSource = lst.ToList();
            }

            if (Regex.Replace(maskedTextBoxDataFim.Text, @"[^0-9$]", "").Length == 0 && !string.IsNullOrWhiteSpace(textBoxContratocpf.Text))
            {
                RadioButton radioButton = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(chk => chk.Checked);
                dataGridViewContract.DataSource = null;
                List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text, Convert.ToChar(radioButton.Text.ToUpper().Substring(0, 1)), RetonaData());
                dataGridViewContract.DataSource = lst.ToList();
            }

        }
    }
}


