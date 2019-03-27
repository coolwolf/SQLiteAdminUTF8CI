using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace SQLiteAdminUTF8CI
{
    public partial class MainForm : Form
    {
        string _filetoopen = "";
        public MainForm(string _dosyaADI)
        {
            _filetoopen = _dosyaADI;
            InitializeComponent();
        }
        #region MenuBar
        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^V");
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^C");
        }
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^X");
        }
        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^A");
        }
        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^Y");
        }
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendKeys.Send("^Z");
        }
        private void ShowNewForm(object sender, EventArgs e)
        {
            NewDatabase();
        }
        private void OpenFile(object sender, EventArgs e)
        {
            OpenDatabase();
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Sqlite Files (*.db3)|*.db3";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close application ?", "Closing confirmation", MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question) != DialogResult.Yes) return;
            this.Close();
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        private void newQueryWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QueryScreen frms = new QueryScreen();
            frms.MdiParent = this;
            frms.Show();
        }
        private void addTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableWindow("");
        }
        private void NewDatabase()
        {
            DbCreate frmdo = new DbCreate();
            frmdo.ShowDialog(this);
            Global.SqlStr = frmdo.GetSelectedConnectionString();
            if (Global.SqlStr == "") return;
            ShowDbStructure();
        }
        private void OpenDatabase()
        {
            DbOpen frmdba = new DbOpen();
            frmdba.ShowDialog(this);
            Global.SqlStr = frmdba.GetSelectedConnectionString();
            if (Global.SqlStr == "") return;
            ShowDbStructure();
        }
        private void TableWindow(string Table)
        {
            TableNew frmyt = new TableNew();
            frmyt.TableName = Table;
            frmyt.MdiParent = this;
            frmyt.Show();
        }
        #endregion
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (_filetoopen.Length > 0) DirectFileOpen("");
        }
        public void ShowDbStructure()
        {
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter("select name,type from sqlite_master where type not in ('table','view') order by name", cnn);
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                FileInfo fi = new FileInfo(Global.SqlDbFile);
                Tv_DbStructure.Nodes.Clear();
                Tv_DbStructure.Nodes.Add(fi.Name, fi.Name);
                Tv_DbStructure.Nodes[fi.Name].Nodes.Add("sys", "System Objects (" + dt.Rows.Count + ")");
                foreach(DataRow dr in dt.Rows)
                {
                    Tv_DbStructure.Nodes[fi.Name].Nodes["sys"].Nodes.Add("sys" + dr["name"].ToString(),
                        dr["name"].ToString() + " (" + dr["type"].ToString() + ")");
                }
                //////////////////////////////////////////////////////////////////////////////////////
                da.SelectCommand.CommandText = "select name from sqlite_master where type='table' and name not like 'sqlite_%' order by name";
                dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Tv_DbStructure.Nodes[fi.Name].Nodes.Add("tbl", "Tables (" + dt.Rows.Count + ")");
                foreach (DataRow dr in dt.Rows)
                {
                    Tv_DbStructure.Nodes[fi.Name].Nodes["tbl"].Nodes.Add(dr["name"].ToString(), dr["name"].ToString());
                    ShowDbObject(dr["name"].ToString(), Tv_DbStructure.Nodes[fi.Name].Nodes["tbl"].Nodes[dr["name"].ToString()]);
                }
                //////////////////////////////////////////////////////////////////////////////////////////
                da.SelectCommand.CommandText = "select name from sqlite_master where type='view'";
                dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                Tv_DbStructure.Nodes[fi.Name].Nodes.Add("vw", "Views (" + dt.Rows.Count + ")");
                foreach (DataRow dr in dt.Rows)
                {
                    Tv_DbStructure.Nodes[fi.Name].Nodes["vw"].Nodes.Add(dr["name"].ToString(), dr["name"].ToString());
                    ShowDbObject(dr["name"].ToString(), Tv_DbStructure.Nodes[fi.Name].Nodes["vw"].Nodes[dr["name"].ToString()]);
                }
            }
            Tv_DbStructure.Nodes[0].Expand();
            Tv_DbStructure.Nodes[0].Nodes[0].Expand();
            Tv_DbStructure.Nodes[0].Nodes[1].Expand();
            Tv_DbStructure.Nodes[0].Nodes[2].Expand();
        }
        private void ShowDbObject(string _tabloADI,TreeNode nodum)
        {
            using (SQLiteConnection cnn1 = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter("pragma table_info (" + _tabloADI + ")", cnn1);
                DataTable dt = new DataTable();
                try { da.Fill(dt); }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                string _null = "", _pk = "", _default = ""; ;
                foreach(DataRow dr in dt.Rows)
                {
                    if (dr[3].ToString() == "0") _null = ", null"; else _null = ", not null";
                    if (dr[5].ToString() == "1") _pk = ", primary"; else _pk = "";
                    if (dr[4].ToString().Length > 0) _default = ", " + dr[4].ToString(); else _default = "";
                    nodum.Nodes.Add(_tabloADI + "_" + dr[0],
                        dr[1].ToString() + ", " + dr[2].ToString() + _default + _null + _pk);
                }
                nodum.Text = nodum.Text + "(" + dt.Rows.Count + ")";
            }
        }
        #region Sağ tuş ve üst toolbar
        private void cmstbl_newtable_Click(object sender, EventArgs e)
        {
            TableNew frmyt = new TableNew();
            frmyt.MdiParent = this;
            frmyt.Show();
        }
        private void cmstbl_droptable_Click(object sender, EventArgs e)
        {
            string Soru = "Delete Table ?";
            if (MessageBox.Show(Soru, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Error) != DialogResult.Yes) return;
            SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr);
            SQLiteCommand emir = new SQLiteCommand("DROP TABLE IF EXISTS [" + Tv_DbStructure.SelectedNode.Name + "];", cnn);
            cnn.Open();
            emir.ExecuteNonQuery();
            cnn.Close();
            ShowDbStructure();
        }
        private void renameTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBoxResult _sonuc = InputBox.Show("Please enter new name for table", "Table Rename", 
                Tv_DbStructure.SelectedNode.Text);
            if(_sonuc.ReturnCode!=DialogResult.OK) return;
            SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr);
            cnn.Open();
            SQLiteCommand emir = new SQLiteCommand("ALTER TABLE " + Tv_DbStructure.SelectedNode.Text + " RENAME TO " +
                _sonuc.Text, cnn);
            cnn.Close();
            ShowDbStructure();
        }
        private void cmstbl_altertable_Click(object sender, EventArgs e)
        {
            if (Tv_DbStructure.SelectedNode == null)
            {
                MessageBox.Show("No objects selected");
                return;
            }
            if (Tv_DbStructure.SelectedNode.Parent.Name=="tbl")
                TableWindow(Tv_DbStructure.SelectedNode.Name);
        }
        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDbStructure();
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewDatabase();
        }
        private void tsb_tabloekle_Click(object sender, EventArgs e)
        {
            TableWindow("");
        }
        private void tsb_dbac_Click(object sender, EventArgs e)
        {
            OpenDatabase();
        }
        #endregion
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (Tv_DbStructure.SelectedNode == null) return;
            if (Tv_DbStructure.SelectedNode.Name == Tv_DbStructure.Nodes[0].Name)
            {
                //Eğer veritabanı adına sağ tuş yapılırsa......
                return;
            }
            //////////////////////////////////////
            if (Tv_DbStructure.SelectedNode.Parent.Name == "tbl")
            {
                foreach (ToolStripMenuItem mi in contextMenuStrip1.Items)
                    {
                        if (mi.Name.StartsWith("cmstbl")) mi.Visible = true; else mi.Visible = false;
                    }
            }
            else if (Tv_DbStructure.SelectedNode.Parent.Name == "vw")
            {
                foreach (ToolStripMenuItem mi in contextMenuStrip1.Items)
                {
                    if (mi.Name.StartsWith("cmsvw")) mi.Visible = true; else mi.Visible = false;
                }
            }
            ///////////////////////////////////
            if (Tv_DbStructure.SelectedNode.Name == "tbl")
            {
                foreach (ToolStripMenuItem mi in contextMenuStrip1.Items)
                {
                    if (mi.Name.StartsWith("cmstbl")) mi.Visible = true; else mi.Visible = false;
                }
            }else if (Tv_DbStructure.SelectedNode.Name == "vw")
            {
                foreach (ToolStripMenuItem mi in contextMenuStrip1.Items)
                {
                    if (mi.Name.StartsWith("cmsvw")) mi.Visible = true; else mi.Visible = false;
                }
            }
            /////////////////////////////////////////////////
            if (Tv_DbStructure.SelectedNode.Parent.Name == "tbl" || Tv_DbStructure.SelectedNode.Parent.Name == "vw")
            {
                contextMenuStrip1.Items["csm_select"].Visible = true;
                contextMenuStrip1.Items["cmstbl_editdata"].Visible = true;
            }
            else
            {
                contextMenuStrip1.Items["csm_select"].Visible = false;
                contextMenuStrip1.Items["cmstbl_editdata"].Visible = false;
            }
        }
        private void csm_select_Click(object sender, EventArgs e)
        {
            if (Tv_DbStructure.SelectedNode == null) return;
            QueryScreen frms = new QueryScreen();
            frms.TableName = Tv_DbStructure.SelectedNode.Name;
            frms.MdiParent = this;
            frms.Show();
        }
        private void cmstbl_editdata_Click(object sender, EventArgs e)
        {
            if (Tv_DbStructure.SelectedNode == null)
            {
                MessageBox.Show("No objects selected");
                return;
            }
            if (Tv_DbStructure.SelectedNode.Parent == null)
            {
                MessageBox.Show("No Table selected...");
                return;
            }
            if (Tv_DbStructure.SelectedNode.Parent.Name == "tbl")
            {
                TableEditData frmbd = new TableEditData();
                frmbd.TableName = Tv_DbStructure.SelectedNode.Name;
                frmbd.MdiParent = this;
                frmbd.Show();
            }
        }
        private void DirectFileOpen(string _pwd)
        {
            string _append = "";
            if (_pwd.Length > 0) _append = "Password=" + _pwd+ ";";
            Global.SqlDbFile = _filetoopen;
            string _conSTR = "Data Source=" + Global.SqlDbFile + ";Version=3;" + _append;
            using (SQLiteConnection cnn = new SQLiteConnection(_conSTR))
            {
                Global.SqlStr = _conSTR;
                try
                {
                    SQLiteCommand emir = new SQLiteCommand("select name from sqlite_master limit 1", cnn);
                    cnn.Open();
                    string _thename = emir.ExecuteScalar().ToString();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    if (ex.Message.Contains("encrypted"))
                    {
                        InputBoxResult _sifwe = InputBox.Show("If database uses password please enter :", "Database Password", true);
                        if (_sifwe.ReturnCode == DialogResult.OK) DirectFileOpen(_sifwe.Text);
                        return;
                    }
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            ShowDbStructure();
        }
        private void cmsvw_alterview_Click(object sender, EventArgs e)
        {
            //birşey seçilmemişse ve view değilse dön
            if (Tv_DbStructure.SelectedNode == null) return;
            if (Tv_DbStructure.SelectedNode.Parent.Name != "vw") return;
            //view oluşturma komutunu al
            SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr);
            cnn.Open();
            SQLiteCommand emir = new SQLiteCommand("select sql from sqlite_master where name='" + Tv_DbStructure.SelectedNode.Name + "'", cnn);
            string _createscript = "";
            try { _createscript = emir.ExecuteScalar().ToString(); }
            catch { }
            cnn.Close();
            //viewekle iceriği alındı
            QueryScreen frms = new QueryScreen();
            frms.fastColoredTextBox1.Text = "DROP VIEW IF EXISTS " + Tv_DbStructure.SelectedNode.Name + ";" + Environment.NewLine +
                _createscript;
            frms.MdiParent = this;
            frms.Show();
        }
        private void cmsvw_newview_Click(object sender, EventArgs e)
        {
            //birşey seçilmemişse ve view değilse dön
            if (Tv_DbStructure.SelectedNode == null) return;
            if (Tv_DbStructure.SelectedNode.Parent.Name != "vw") return;
            QueryScreen frms = new QueryScreen();
            frms.fastColoredTextBox1.Text = "CREATE VIEW myview1 AS " + Environment.NewLine;
            frms.MdiParent = this;
            frms.Show();
        }
        private void cmsvw_dropview_Click(object sender, EventArgs e)
        {
            //birşey seçilmemişse ve view değilse dön
            if (Tv_DbStructure.SelectedNode == null) return;
            if (Tv_DbStructure.SelectedNode.Parent.Name != "vw") return;
            if (MessageBox.Show("Do you want to remove view completely ?", "Deleting confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteCommand emir = new SQLiteCommand("DROP VIEW IF EXISTS " + Tv_DbStructure.SelectedNode.Name + ";", cnn);
                cnn.Open();
                emir.ExecuteNonQuery();
                cnn.Close();
            }
            ShowDbStructure();
        }
        private void tv_dbici_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }
        private void tv_dbici_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                _filetoopen = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
                DirectFileOpen("");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void tv_dbici_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (!e.Node.IsSelected) Tv_DbStructure.SelectedNode = e.Node;
        }
    }
}
