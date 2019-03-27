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
    public partial class ViewAdd : Form
    {
        SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr);
        public ViewAdd()
        {
            InitializeComponent();
        }
        private void btn_viewolustur_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
                SQLiteCommand emir = new SQLiteCommand("DROP VIEW IF EXISTS \"main\".\"" + txt_viewadi.Text + "\"; " +
                    "CREATE  VIEW \"main\".\"" + txt_viewadi.Text + "\" AS " + txt_tanim.Text, cnn);
                emir.ExecuteNonQuery();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
