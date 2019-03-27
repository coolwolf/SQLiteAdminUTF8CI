using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SQLite;

namespace SQLiteAdminUTF8CI
{
    public partial class DbOpen : Form
    {
        string _conSTR = "";
        public DbOpen()
        {
            InitializeComponent();
        }
        private void btn_dbac_Click(object sender, EventArgs e)
        {
            OpenSelectedDb();
        }
        public string GetSelectedConnectionString()
        {
            return _conSTR;
        }
        private void F_DBAc_Load(object sender, EventArgs e)
        {
            ListDrives();
            if (Properties.Settings.Default.LastFolder.Length < 1)
                Properties.Settings.Default.LastFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ListFiles(Properties.Settings.Default.LastFolder);
        }
        private void ListDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Lv_Drives.Items.Add(drive.Name, drive.VolumeLabel, 1);
                }
            }
        }
        private void lv_dizinler_DoubleClick(object sender, EventArgs e)
        {
            if (Lv_Folders.SelectedItems[0].Focused == true)
            {
                if (Lv_Folders.SelectedItems[0].ImageIndex == 0)
                {
                    Properties.Settings.Default.LastFolder = Lv_Folders.SelectedItems[0].Name;
                    Properties.Settings.Default.Save();
                    ListFiles(Lv_Folders.SelectedItems[0].Name);
                }
                else if (Lv_Folders.SelectedItems[0].ImageIndex == 2)
                    OpenSelectedDb();
            }
        }
        private void ListFiles(string ParentFolder)
        {
            string _repl = "";
            Lv_Folders.Items.Clear();
            if (ParentFolder.IndexOf("\\") > 0)
                Lv_Folders.Items.Add(ParentFolder.Substring(0, ParentFolder.LastIndexOf("\\")), "..", 0);
            else _repl = ParentFolder.Substring(0, ParentFolder.IndexOf(":") + 1);
            Lv_Folders.Items[0].SubItems.Add(ParentFolder);
            string[] _folders = Directory.GetDirectories(ParentFolder);
            string[] _files = Directory.GetFiles(ParentFolder);
            foreach (string _folder in _folders)
            {
                if (_repl.Length > 0)
                    Lv_Folders.Items.Add(_folder.Replace(_repl, _repl + "\\"),
                        _folder.Replace(_repl, ""), 0);
                else Lv_Folders.Items.Add(_folder, _folder.Substring(_folder.LastIndexOf("\\") + 1), 0);
            }
            foreach (string _file in _files)
            {
                FileInfo fi = new FileInfo(_file);
                Lv_Folders.Items.Add(_file, fi.Name, 2);
            }
        }
        private void lv_suruculer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lv_Drives.SelectedItems.Count > 0 && Lv_Drives.SelectedItems[0].Focused == true)
                ListFiles(Lv_Drives.SelectedItems[0].Name);
        }
        private void OpenSelectedDb()
        {
            string _append = "",_result="";
            if (Txt_Password.Text.Length > 0) _append = "Password=" + Txt_Password.Text + ";";
            Global.SqlDbFile = Lv_Folders.SelectedItems[0].Name;
            _conSTR = "Data Source=" + Global.SqlDbFile + ";Version=3;" + _append;
            using (SQLiteConnection cnn = new SQLiteConnection(_conSTR))
            {
                try
                {
                    SQLiteCommand emir = new SQLiteCommand("select name from sqlite_master limit 1", cnn);
                    cnn.Open();
                    _result = emir.ExecuteScalar().ToString();
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            this.Close();
        }
        private void txt_parola_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) OpenSelectedDb();
        }
    }
}
