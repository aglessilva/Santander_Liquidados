using ConversorToByte.BLL;
using ConversorToByte.DTO;
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
using System.Threading.Tasks;
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
            List<FileSafe> lst = fsf.GetFilesSafe(null);
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
                List<FileSafe> fileSaves = fsf.DownloadFile(obj.NameContract);

                saveFile.FileName = obj.NameContract;

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                   string _path = new FileInfo(saveFile.FileName).DirectoryName + @"\" + obj.NameContract;

                    if (Directory.Exists(_path))
                        Directory.Delete(_path, true);

                    Directory.CreateDirectory(_path);

                    for (int i = 0; i < fileSaves.Count; i++)
                    {
                        if (fileSaves[i].FileEncryption != null)
                        {
                            using (BinaryWriter writer = new BinaryWriter(File.Open(_path + @"\" + obj.NameContract + fileSaves[i].NameContract + ".pdf", FileMode.Create)))
                            { writer.Write(fileSaves[i].FileEncryption); }
                        }
                    }
                   
                    if (MessageBox.Show(string.Format("Deseja abrir o diretório onde o contrato ({0}) foi salvo?", obj.NameContract), "Contratos Liquidados", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
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
                AbrirContrato(obj.NameContract, null, chkContratosAtivos.Checked);

            }

            // TELA 18
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 5)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrWhiteSpace(obj.T18))
                    AbrirContrato(obj.NameContract, "18");
            }

            // TELA 20
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 6)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrWhiteSpace(obj.T20))
                    AbrirContrato(obj.NameContract, "20");
            }

            // TELA 125
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewImageColumn && e.RowIndex >= 0 && e.ColumnIndex == 7)
            {
                FileSafe obj = (FileSafe)dataGridViewContract.Rows[e.RowIndex].DataBoundItem;
                if (!string.IsNullOrWhiteSpace(obj.T25))
                    AbrirContrato(obj.NameContract, "25");
            }
        }

        void AbrirContrato(string _idContract, string _tela, bool _isAtivo = false)
        {
            fsf = new FileSafeOperations();
            FileSafe _file = fsf.GetFileSafe(_idContract, _tela, _isAtivo);
            frmpdf _frmPdf = new frmpdf(_file);
            _frmPdf.ShowDialog();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            textBoxContratocpf.Text = string.Empty;
            textBoxContratocpf.Focus();
        }

        private void textBoxContratocpf_TextChanged(object sender, EventArgs e)
        {
            if (!chkContratosAtivos.Checked)
            {
                if (textBoxContratocpf.Text.Length > 3)
                {
                    dataGridViewContract.DataSource = null;
                    List<FileSafe> lst = fsf.GetFilesSafe(_contractCpf: textBoxContratocpf.Text);
                    dataGridViewContract.DataSource = lst.ToList();
                }
                else
                    if (dataGridViewContract.Rows.Count < 50 && textBoxContratocpf.Text.Length < 3)
                {
                    dataGridViewContract.DataSource = null;
                    List<FileSafe> lst = fsf.GetFilesSafe(null);
                    dataGridViewContract.DataSource = lst.ToList();
                }
            }
            else
            {
                if (textBoxContratocpf.Text.Length > 3)
                {
                    dataGridViewContract.DataSource = null;
                    List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text.Trim());
                    dataGridViewContract.DataSource = lst.ToList();
                }
                else
                    if (dataGridViewContract.Rows.Count < 50 && textBoxContratocpf.Text.Length < 3)
                {
                    dataGridViewContract.DataSource = null;
                    List<FileSafe> lst = fsf.GetFilesAll(null);
                    dataGridViewContract.DataSource = lst.ToList();

                }
            }
        }


        private void addUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddUsuariosAD f = new FrmAddUsuariosAD();
            f.ShowDialog();
        }

        private void chkContratosAtivos_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContratosAtivos.Checked)
            {

                string[] col = { "T18", "T20", "T25" };
                int indiceCol = 5;
                foreach (var item in col)
                {

                    DataGridViewImageColumn dataGridViewImageColumnT18 = new DataGridViewImageColumn()
                    {
                        HeaderText = item,
                        Image = ((System.Drawing.Image)(new ComponentResourceManager(typeof(frmListContrato)).GetObject("Vizualizar.Image"))),
                        MinimumWidth = 5,
                        Width = 30,
                        ImageLayout = DataGridViewImageCellLayout.Zoom,
                    };

                    dataGridViewContract.Columns.Insert(indiceCol, dataGridViewImageColumnT18);
                    indiceCol++;
                }

                dataGridViewContract.DataSource = null;
                List<FileSafe> lst = fsf.GetFilesAll(textBoxContratocpf.Text.Length > 3 ? textBoxContratocpf.Text.Trim() : null);
                dataGridViewContract.DataSource = lst.ToList();
            }
            else
            {
                for (int i = 7; i > 4; i--)
                    dataGridViewContract.Columns.RemoveAt(i);

                dataGridViewContract.DataSource = null;
                List<FileSafe> lst = fsf.GetFilesSafe(textBoxContratocpf.Text.Length > 3 ? textBoxContratocpf.Text.Trim() : null);
                dataGridViewContract.DataSource = lst.ToList();
            }
        }

        private void dataGridViewContract_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            if (chkContratosAtivos.Checked)
            {
                var senderGrid = (DataGridView)sender;
                foreach (DataGridViewRow item in senderGrid.Rows)
                {
                    FileSafe obj = (FileSafe)item.DataBoundItem;
                    if (string.IsNullOrEmpty(obj.T25))
                    {
                        if (senderGrid.Columns[7] is DataGridViewImageColumn && item.Index >= 0)
                        {
                            item.Cells[7].Value = Properties.Resources.Childish_Cross_24996;
                        }
                    }

                    if (string.IsNullOrEmpty(obj.T20))
                    {
                        if (senderGrid.Columns[6] is DataGridViewImageColumn && item.Index >= 0)
                        {
                            item.Cells[6].Value = Properties.Resources.Childish_Cross_24996;
                        }
                    }

                    if (string.IsNullOrEmpty(obj.T18))
                    {
                        if (senderGrid.Columns[5] is DataGridViewImageColumn && item.Index >= 0)
                        {
                            item.Cells[5].Value = Properties.Resources.Childish_Cross_24996;
                        }
                    }

                }
            }
        }
    }
}


