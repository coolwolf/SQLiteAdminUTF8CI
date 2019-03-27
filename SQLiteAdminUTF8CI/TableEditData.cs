using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace SQLiteAdminUTF8CI
{
    public partial class TableEditData : Form
    {
        public string TableName = "";
        bool _filling = false;
        public TableEditData()
        {
            InitializeComponent();
        }
        private void F_BilgiDuzenle_Load(object sender, EventArgs e)
        {
            if (TableName.Length > 0) FillDataGrid();
        }
        private void FillDataGrid()
        {
            _filling = true;
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter("select rowid as ___cwid,* from " + TableName + " order by ___cwid", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                MyGrid.Columns.Clear();
                MyGrid.Rows.Clear();
                MyGrid.Columns.Add("___cwid", "___cwid");
                MyGrid.Columns[0].Visible = false;
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    MyGrid.Columns.Add(dt.Columns[i].ColumnName, dt.Columns[i].ColumnName);
                }
                int _therow = 0;
                foreach(DataRow dr in dt.Rows)
                {
                    MyGrid.Rows.Add();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        MyGrid[i, _therow].Value = dr[i];
                    }
                    _therow++;
                }
            }
            _filling = false;
        }
        private void liste_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_filling) return;
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteCommand emir = new SQLiteCommand("update " + TableName + " set " + MyGrid.Columns[e.ColumnIndex].Name +
                "=@" + MyGrid.Columns[e.ColumnIndex].Name + " where rowid=" + MyGrid[0, e.RowIndex].Value, cnn);
                emir.Parameters.AddWithValue("@" + MyGrid.Columns[e.ColumnIndex].Name, MyGrid[e.ColumnIndex, e.RowIndex].Value);
                cnn.Open();
                try { emir.ExecuteNonQuery(); }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
                cnn.Close();
            }
        }
        private void liste_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteCommand emir = new SQLiteCommand("delete from " + TableName + " where rowid=" + e.Row.Cells[0].Value, cnn);
                cnn.Open();
                emir.ExecuteScalar();
                cnn.Close();
            }
        }
        private void liste_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            _filling = true;
            string _fldlist = "", _prmlist = "";
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteCommand cmd = new SQLiteCommand("", cnn);
                int i = 0;
                for (i = 1; i < e.Row.Cells.Count; i++)
                {
                    _fldlist = _fldlist + e.Row.Cells[i].OwningColumn.Name + ",";
                    _prmlist = _prmlist + "@" + e.Row.Cells[i].OwningColumn.Name + ",";
                    cmd.Parameters.AddWithValue("@" + e.Row.Cells[i].OwningColumn.Name, e.Row.Cells[i].Value);
                }
                cmd.CommandText = "insert into " + TableName + " (" + _fldlist.Substring(0, _fldlist.Length - 1) + ") values (" +
                    _prmlist.Substring(0, _prmlist.Length - 1) + "); SELECT last_insert_rowid();";
                cnn.Open();
                int _rowID = 0;
                try { _rowID = Convert.ToInt32(cmd.ExecuteScalar()); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                cnn.Close();
                MyGrid[0, e.Row.Index - 1].Value = _rowID;
            }
            _filling = false;
        }
    }
}
