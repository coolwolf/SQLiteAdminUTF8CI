using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SQLite;

namespace SQLiteAdminUTF8CI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SQLiteFunction.RegisterFunction(typeof(SQLiteCaseInsensitiveCollation));
            string _dosya = "";
            try { _dosya = args[0]; }
            catch { }
            Application.Run(new MainForm(_dosya));
        }
    }
}
