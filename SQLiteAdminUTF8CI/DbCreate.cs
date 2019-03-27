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
    public partial class DbCreate : Form
    {
        string _conSTR = "";
        public DbCreate()
        {
            InitializeComponent();
        }
        private void F_DBOlustur_Load(object sender, EventArgs e)
        {
            ListDrives();
            string _mydesktop=Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Lv_Folders.Items.Add(_mydesktop.Substring(0, _mydesktop.LastIndexOf("\\")), "..", 0);
            Lv_Folders.Items[0].SubItems.Add(_mydesktop);
            string[] _folders = Directory.GetDirectories(_mydesktop);
            foreach (string _folder in _folders)
            {
                Lv_Folders.Items.Add(_folder, _folder.Substring(_folder.LastIndexOf("\\")+1), 0);
            }
        }
        public string GetSelectedConnectionString()
        {
            return _conSTR;
        }
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            CreateDatabase();
        }
        private void lv_dizinler_DoubleClick(object sender, EventArgs e)
        {
            if (Lv_Folders.SelectedItems[0].Focused == true) ListFolders(Lv_Folders.SelectedItems[0].Name);
        }
        private void ListDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    Lv_Drives.Items.Add(drive.Name,drive.VolumeLabel,1);
                }
            }
        }
        private void lv_suruculer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lv_Drives.SelectedItems.Count>0 && Lv_Drives.SelectedItems[0].Focused == true)
                ListFolders(Lv_Drives.SelectedItems[0].Name);
        }
        private void ListFolders(string ParentFolder)
        {
            string _repl = "";
            Lv_Folders.Items.Clear();
            if (ParentFolder.IndexOf("\\") > 0)
                Lv_Folders.Items.Add(ParentFolder.Substring(0, ParentFolder.LastIndexOf("\\")), "..", 0);
            else _repl = ParentFolder.Substring(0, ParentFolder.IndexOf(":") + 1);
            Lv_Folders.Items[0].SubItems.Add(ParentFolder);
            string[] _folders = Directory.GetDirectories(ParentFolder);
            foreach (string _folder in _folders)
            {
                if (_repl.Length > 0)
                    Lv_Folders.Items.Add(_folder.Replace(_repl, _repl + "\\"),
                        _folder.Replace(_repl, ""), 0);
                else Lv_Folders.Items.Add(_folder, _folder.Substring(_folder.LastIndexOf("\\") + 1), 0);
            }
        }
        private void txt_dosyaadi_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) CreateDatabase();
        }
        private void CreateDatabase()
        {
            if (Txt_FileName.Text.Length < 1)
            {
                MessageBox.Show("File name is required.");
                return;
            }
            string _append = "", _filename = Txt_FileName.Text;
            try 
            {
                string[] du = _filename.Split('.');
                if (du[1] == "") _filename = _filename + ".db3";
            }
            catch { _filename = _filename + ".db3"; }
            _filename = _filename.Replace("..",".");
            if (Txt_DbPassword.Text.Length > 0) _append = "Password=" + Txt_DbPassword.Text + ";";
            Global.SqlDbFile = Lv_Folders.Items[0].SubItems[1].Text + "\\" + _filename;
            _conSTR = "Data Source=" + Global.SqlDbFile + ";Version=3;" + _append;
            SQLiteConnection cnn = new SQLiteConnection(_conSTR);
            try
            {
                cnn.Open();
                cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }
    }
}
