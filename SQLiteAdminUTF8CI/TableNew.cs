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
    public partial class TableNew : Form
    {
        public string TableName = "";
        SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr);
        BindingList<Models.TableField> _fieldlist = new BindingList<Models.TableField>();
        BindingList<Models.TableField> _origfieldlist = new BindingList<Models.TableField>();
        public TableNew()
        {
            InitializeComponent();
        }
        private void yenitablo_Load(object sender, EventArgs e)
        {
            if (TableName == "")
            {
                AddEmptyField(true);
                Dg_FieldList.DataSource = _fieldlist;
                this.Text = "Add Table";
                btn_tabloolustur.Text = "Create";
                Dg_FieldList.Columns[5].ReadOnly = false;
                Dg_FieldList.Columns[5].DefaultCellStyle.BackColor = Color.White;
                Dg_FieldList.Columns[6].ReadOnly = false;
                Dg_FieldList.Columns[6].DefaultCellStyle.BackColor = Color.White;
            }
            else
            {
                ShowFieldsInTable();
                this.Text = "Edit Table";
                btn_tabloolustur.Text = "Update";
                Dg_FieldList.Columns[5].ReadOnly = true;
                Dg_FieldList.Columns[5].DefaultCellStyle.BackColor = Color.Gray;
                Dg_FieldList.Columns[6].ReadOnly = true;
                Dg_FieldList.Columns[6].DefaultCellStyle.BackColor = Color.Gray;
            }
        }
        public void ShowFieldsInTable()
        {
            Txt_TableName.Text = TableName;
            SQLiteDataAdapter da = new SQLiteDataAdapter("pragma table_info (" + TableName + ")", cnn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            _fieldlist.Clear();
            foreach(DataRow dr in dt.Rows)
            {
                Models.TableField _fld = new Models.TableField();
                _fld.FldName = dr[1].ToString();
                _fld.FldType = dr[2].ToString() == "INT" ? "INTEGER" : dr[2].ToString();
                _fld.FldIsNotNull = Convert.ToInt16(dr[3]) == 0 ? "ALLOW NULL" : "NOT NULL";
                _fld.FldDefaultValue = dr[4].ToString();
                _fld.FldIsPrimary = Convert.ToInt16(dr[5])==0?"NO":"YES"; ////YES, NO
                _fld.FldIsUpdated = false;
                _fld.FldIsUnique = FXS.IsFieldUnique(TableName, _fld.FldName);
                _fld.FldCollation = FXS.GetFieldCollation(TableName, _fld.FldName);
                _fieldlist.Add(_fld);
                _origfieldlist.Add(_fld);
            }
            Dg_FieldList.DataSource = _fieldlist;
            for (int i = 0; i < Dg_FieldList.Rows.Count; i++)
            {
                Dg_FieldList.Rows[i].ReadOnly = true;
                foreach (DataGridViewCell cell in Dg_FieldList.Rows[i].Cells)
                {
                    cell.ReadOnly = true;
                }
            }
        }
        private void btn_tabloolustur_Click(object sender, EventArgs e)
        {
            if (TableName != "") EditTheTable();
            else CreateTheTable();
        }
        private void EditTheTable()
        {
            cnn.Open();
            SQLiteCommand emir = new SQLiteCommand("", cnn);
            //SİLİNEN SÜTUN VAR MI
            bool _hasdele = false;
            bool _haschange = false;
            foreach (Models.TableField fld in _origfieldlist)
            {
                if (!_fieldlist.Contains(fld)) _hasdele = true;
                if (fld.FldIsUpdated) _haschange = true;
            }
            if (_hasdele || _haschange)
            {
                string _columnlist = "", _appendcolumn = "";
                foreach (Models.TableField fld in _fieldlist)
                {
                    _columnlist = _columnlist + "," + fld.FldName;
                    _appendcolumn = _appendcolumn + "," + FXS.PrepareFieldString(fld);
                }
                _columnlist = _columnlist.Substring(1);
                _appendcolumn = _appendcolumn.Substring(1);
                emir.CommandText = "BEGIN TRANSACTION;" +
                            "CREATE TEMPORARY TABLE t1_backup(" + _columnlist + ");" +
                            "INSERT INTO t1_backup SELECT " + _columnlist + " FROM " + TableName + ";" +
                            "DROP TABLE " + TableName + ";" +
                            "CREATE TABLE " + TableName + " (" + _appendcolumn + ");" +
                            "INSERT INTO " + TableName + " SELECT " + _columnlist + " FROM t1_backup;" +
                            "DROP TABLE t1_backup;" +
                            "COMMIT;";
                try
                {
                    emir.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            //YENİ EKLENEN SÜTUN VAR MI
            foreach (Models.TableField fld in _fieldlist)
            {
                if (_origfieldlist.Contains(fld)) continue;
                try
                {
                    emir.CommandText = "ALTER TABLE " + TableName + " ADD COLUMN " + FXS.PrepareFieldString(fld);
                    emir.ExecuteNonQuery();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            cnn.Close();
            this.Close();
        }
        private void CreateTheTable()
        {
            string _tblCODE = "CREATE TABLE [" + Txt_TableName.Text + "] (";
            foreach (Models.TableField fld in _fieldlist)
            {
                _tblCODE = _tblCODE + FXS.PrepareFieldString(fld) + ",";
            }
            _tblCODE = _tblCODE.Remove(_tblCODE.Length-1) + ");";
            try
            {
                SQLiteCommand emir = new SQLiteCommand(_tblCODE, cnn);
                cnn.Open();
                emir.ExecuteNonQuery();
                MainForm frmp = (MainForm)Application.OpenForms["MainForm"];
                frmp.ShowDbStructure();
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void AddEmptyField(bool _pk)
        {
            Models.TableField _fld = new Models.TableField();
            if (_pk) _fld.FldCollation = "NONE"; else _fld.FldCollation = "UTF8CI";
            _fld.FldDefaultValue = "";
            if (_pk) _fld.FldName = "Id"; else _fld.FldName = "";
            _fld.FldIsNotNull = "ALLOW NULL"; ////"ALLOW NULL" : "NOT NULL";
            if (_pk) _fld.FldIsPrimary = "YES"; else _fld.FldIsPrimary = "NO";//YES, NO
            if (_pk) _fld.FldType = "INTEGER"; else _fld.FldType = "TEXT";
            _fld.FldIsUnique = "NO";
            _fld.FldIsUpdated = false;
            _fieldlist.Add(_fld);
        }
        private void Dg_FieldList_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (Dg_FieldList.CurrentCell.ColumnIndex == 1)
            {
                var source = new AutoCompleteStringCollection();
                source.AddRange(Global.FieldTypes);
                TextBox _fieldtype = e.Control as TextBox;
                if (_fieldtype != null)
                {
                    _fieldtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    _fieldtype.AutoCompleteCustomSource = source;
                    _fieldtype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
            else if (Dg_FieldList.CurrentCell.ColumnIndex == 5)
            {
                var source = new AutoCompleteStringCollection();
                source.AddRange(Global.CollationTypes);
                TextBox _fieldtype = e.Control as TextBox;
                if (_fieldtype != null)
                {
                    _fieldtype.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    _fieldtype.AutoCompleteCustomSource = source;
                    _fieldtype.AutoCompleteSource = AutoCompleteSource.CustomSource;
                }
            }
        }
        private void Dg_FieldList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
        private void Dg_FieldList_NewRowNeeded(object sender, DataGridViewRowEventArgs e)
        {
            AddEmptyField(false);
        }
        private void ShowFieldType(object sender, EventArgs e)
        {
            ToolStripItem _sitm = (ToolStripItem)sender;
            ContextMenuStrip _mstp = (ContextMenuStrip)_sitm.GetCurrentParent();
            int _rowIND = Convert.ToInt32(_mstp.Name.Replace("sagtus_", ""));
            Dg_FieldList[1, _rowIND].Value = _sitm.Text;
        }
        private void ShowColumnType(object sender, EventArgs e)
        {
            ToolStripItem _sitm = (ToolStripItem)sender;
            ContextMenuStrip _mstp = (ContextMenuStrip)_sitm.GetCurrentParent();
            int _rowIND = Convert.ToInt32(_mstp.Name.Replace("sagtus_", ""));
            Dg_FieldList[5, _rowIND].Value = _sitm.Text;
        }
        private void Dg_FieldList_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                try
                {
                    _fieldlist.RemoveAt(Dg_FieldList.CurrentRow.Index);
                    Dg_FieldList.Refresh();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Dg_FieldList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            Dg_FieldList["FldIsUpdated", e.RowIndex].Value=true;
        }
    }
}
