using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLiteAdminUTF8CI
{
    public partial class QueryScreen : Form
    {
        public string TableName = "";
        SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr);
        DataTable dt = new DataTable("");
        public QueryScreen()
        {
            InitializeComponent();
        }
        private void executeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExecuteQuery();
        }
        private void FillTheGrid(string QueryString)
        {
            SQLiteDataAdapter da = new SQLiteDataAdapter(QueryString, cnn);
            DataTable dt=new DataTable();
            try
            {
                da.Fill(dt);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            dataGridView1.DataSource = dt;
            dataGridView1.AutoResizeColumns();
        }
        private void ExecuteCommand(string CommandString)
        {
            try
            {
                SQLiteCommand emir = new SQLiteCommand(CommandString, cnn);
                cnn.Open();
                int _sonuc = emir.ExecuteNonQuery();
                cnn.Close();
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Columns.Add();
                dt.Rows.Add(_sonuc + " records affected.");
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                dt.Columns.Clear();
                dt.Rows.Clear();
                dt.Columns.Add();
                dt.Rows.Add(ex.Message);
                dataGridView1.DataSource = dt;
                cnn.Close();
            }
        }
        private void F_Sorgu_Load(object sender, EventArgs e)
        {
            if (TableName.Length > 0)
            {
                fastColoredTextBox1.Text = "select * from " + TableName + " limit 1000";
                ExecuteQuery();
            }
        }
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(fastColoredTextBox1.SelectedText);
        }
        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fastColoredTextBox1.InsertText(Clipboard.GetText());
        }
        private void copyContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(dataGridView1.GetClipboardContent());
        }
        private void ExecuteQuery()
        {
            string _query = "";
            foreach (string _row in fastColoredTextBox1.Lines)
            {
                if (!_row.TrimStart().StartsWith("--")) _query = _query + _row;
            }
            if (_query.TrimStart().ToLower().StartsWith("select") || _query.TrimStart().ToLower().StartsWith("pragma"))
            {
                FillTheGrid(_query);
            }
            else
            {
                ExecuteCommand(_query);
            }
        }
    }
}
