using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SQLite;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace SQLiteAdminUTF8CI
{
    class Global
    {
        public static string SqlDbFile = "";
        public static string SqlStr = "";
        public static string[] FieldTypes = new string[] { "TEXT", "NUMERIC", "INTEGER", "REAL", "BLOB" };
        public static string[] CollationTypes = new string[] { "NONE", "UTF8CI" };
    }
    [SQLiteFunction(FuncType = FunctionType.Collation, Name = "UTF8CI")]
    public class SQLiteCaseInsensitiveCollation : SQLiteFunction
    {
        private static readonly CultureInfo _cultureInfo = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.Encoding);
        public override int Compare(string x, string y)
        {
            return string.Compare(x, y, _cultureInfo, CompareOptions.IgnoreCase);
        }
    }
    #region InputBOX
    public class InputBox
    {
        #region Private Windows Contols and Constructor
        // Create a new instance of the form.
        private static Form frmInputDialog;
        private static Label lblPrompt;
        private static Button btnOK;
        private static Button btnCancel;
        private static TextBox txtInput;
        public InputBox()
        {
        }
        #endregion
        #region Private Variables
        private static string _formCaption = string.Empty;
        private static string _formPrompt = string.Empty;
        private static InputBoxResult _outputResponse = new InputBoxResult();
        private static string _defaultValue = string.Empty;
        private static bool _password = false;
        private static int _xPos = -1;
        private static int _yPos = -1;
        #endregion
        #region Windows Form code
        private static void InitializeComponent()
        {
            // Create a new instance of the form.
            frmInputDialog = new Form();
            lblPrompt = new Label();
            btnOK = new Button();
            btnCancel = new Button();
            txtInput = new TextBox();
            frmInputDialog.SuspendLayout();
            // 
            // lblPrompt
            // 
            lblPrompt.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right)));
            lblPrompt.BackColor = SystemColors.Control;
            lblPrompt.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((Byte)(0)));
            lblPrompt.Location = new Point(12, 9);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(302, 82);
            lblPrompt.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.DialogResult = DialogResult.OK;
            btnOK.FlatStyle = FlatStyle.Popup;
            btnOK.Location = new Point(326, 8);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(64, 24);
            btnOK.TabIndex = 1;
            btnOK.Text = "&OK";
            btnOK.Click += new EventHandler(btnOK_Click);
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatStyle = FlatStyle.Popup;
            btnCancel.Location = new Point(326, 40);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 24);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "&Cancel";
            btnCancel.Click += new EventHandler(btnCancel_Click);
            // 
            // txtInput
            // 
            if(_password) txtInput.PasswordChar = '*';
            txtInput.Location = new Point(8, 100);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(379, 20);
            txtInput.TabIndex = 0;
            txtInput.Text = "";
            txtInput.KeyUp += new System.Windows.Forms.KeyEventHandler(txtInput_KeyUp);
            // 
            // InputBoxDialog
            // 
            frmInputDialog.AutoScaleBaseSize = new Size(5, 13);
            frmInputDialog.ClientSize = new Size(398, 128);
            frmInputDialog.Controls.Add(txtInput);
            frmInputDialog.Controls.Add(btnCancel);
            frmInputDialog.Controls.Add(btnOK);
            frmInputDialog.Controls.Add(lblPrompt);
            frmInputDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            frmInputDialog.MaximizeBox = false;
            frmInputDialog.MinimizeBox = false;
            frmInputDialog.Name = "InputBoxDialog";
            frmInputDialog.ResumeLayout(false);
        }

        #endregion

        #region Private function, InputBox Form move and change size

        static private void LoadForm()
        {
            OutputResponse.ReturnCode = DialogResult.Ignore;
            OutputResponse.Text = string.Empty;

            txtInput.Text = _defaultValue;
            lblPrompt.Text = _formPrompt;
            frmInputDialog.Text = _formCaption;

            // Retrieve the working rectangle from the Screen class
            // using the PrimaryScreen and the WorkingArea properties.
            System.Drawing.Rectangle workingRectangle = Screen.PrimaryScreen.WorkingArea;

            if ((_xPos >= 0 && _xPos < workingRectangle.Width - 100) && (_yPos >= 0 && _yPos < workingRectangle.Height - 100))
            {
                frmInputDialog.StartPosition = FormStartPosition.Manual;
                frmInputDialog.Location = new System.Drawing.Point(_xPos, _yPos);
            }
            else
                frmInputDialog.StartPosition = FormStartPosition.CenterScreen;


            string PrompText = lblPrompt.Text;

            int n = 0;
            int Index = 0;
            while (PrompText.IndexOf("\n", Index) > -1)
            {
                Index = PrompText.IndexOf("\n", Index) + 1;
                n++;
            }

            if (n == 0)
                n = 1;

            System.Drawing.Point Txt = txtInput.Location;
            Txt.Y = Txt.Y + (n * 4);
            txtInput.Location = Txt;
            System.Drawing.Size form = frmInputDialog.Size;
            form.Height = form.Height + (n * 4);
            frmInputDialog.Size = form;

            txtInput.SelectionStart = 0;
            txtInput.SelectionLength = txtInput.Text.Length;
            txtInput.Focus();
        }

        #endregion

        #region Button control click event

        static private void btnOK_Click(object sender, System.EventArgs e)
        {
            OutputResponse.ReturnCode = DialogResult.OK;
            OutputResponse.Text = txtInput.Text;
            frmInputDialog.Dispose();
        }

        static private void txtInput_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                OutputResponse.ReturnCode = DialogResult.OK;
                OutputResponse.Text = txtInput.Text;
                frmInputDialog.Dispose();
            }
        }

        static private void btnCancel_Click(object sender, System.EventArgs e)
        {
            OutputResponse.ReturnCode = DialogResult.Cancel;
            OutputResponse.Text = string.Empty; //Clean output response
            frmInputDialog.Dispose();
        }

        #endregion

        #region Public Static Show functions

        static public InputBoxResult Show(string Prompt)
        {
            InitializeComponent();
            FormPrompt = Prompt;

            // Display the form as a modal dialog box.
            LoadForm();
            frmInputDialog.ShowDialog();
            return OutputResponse;
        }

        static public InputBoxResult Show(string Prompt, string Title)
        {
            InitializeComponent();

            FormCaption = Title;
            FormPrompt = Prompt;

            // Display the form as a modal dialog box.
            LoadForm();
            frmInputDialog.ShowDialog();
            return OutputResponse;
        }

        static public InputBoxResult Show(string Prompt, string Title,bool IsPassword)
        {
            InitializeComponent();

            FormCaption = Title;
            FormPrompt = Prompt;
            _password = IsPassword;
            // Display the form as a modal dialog box.
            LoadForm();
            frmInputDialog.ShowDialog();
            return OutputResponse;
        }

        static public InputBoxResult Show(string Prompt, string Title, string Default)
        {
            InitializeComponent();

            FormCaption = Title;
            FormPrompt = Prompt;
            DefaultValue = Default;

            // Display the form as a modal dialog box.
            LoadForm();
            frmInputDialog.ShowDialog();
            return OutputResponse;
        }

        static public InputBoxResult Show(string Prompt, string Title, string Default, int XPos, int YPos)
        {
            InitializeComponent();
            FormCaption = Title;
            FormPrompt = Prompt;
            DefaultValue = Default;
            XPosition = XPos;
            YPosition = YPos;

            // Display the form as a modal dialog box.
            LoadForm();
            frmInputDialog.ShowDialog();
            return OutputResponse;
        }

        #endregion

        #region Private Properties

        static private string FormCaption
        {
            set
            {
                _formCaption = value;
            }
        } // property FormCaption

        static private string FormPrompt
        {
            set
            {
                _formPrompt = value;
            }
        } // property FormPrompt

        static private InputBoxResult OutputResponse
        {
            get
            {
                return _outputResponse;
            }
            set
            {
                _outputResponse = value;
            }
        } // property InputResponse

        static private string DefaultValue
        {
            set
            {
                _defaultValue = value;
            }
        } // property DefaultValue

        static private int XPosition
        {
            set
            {
                if (value >= 0)
                    _xPos = value;
            }
        } // property XPos

        static private int YPosition
        {
            set
            {
                if (value >= 0)
                    _yPos = value;
            }
        } // property YPos

        #endregion
    }
    /// <summary>
    /// Class used to store the result of an InputBox.Show message.
    /// </summary>
    public class InputBoxResult
    {
        public DialogResult ReturnCode;
        public string Text;
    }
    #endregion
    class FXS
    {
        public static string PrepareFieldString(Models.TableField MyField)
        {
            string _colll = "", _defDEGER = "", _unik = "", _nullmu = "", _primm = "", _deflt = "", _typ = "TEXT";
            if (MyField.FldType != null) _typ = MyField.FldType;
            if (MyField.FldCollation != "NONE" && _typ == "TEXT") _colll = " COLLATE UTF8CI ";
            if (MyField.FldIsNotNull == "NOT NULL") _nullmu = " NOT NULL "; //"ALLOW NULL" : "NOT NULL";
            if (MyField.FldIsUnique == "YES") _unik = " UNIQUE ";
            if (MyField.FldDefaultValue != null) _deflt = MyField.FldDefaultValue;
            if (_deflt.Length > 0 && _typ == "TEXT") _defDEGER = " DEFAULT '" + _deflt + "'";
            else if (_deflt.Length > 0 && _typ == "INTEGER") _defDEGER = " DEFAULT " + _deflt;
            else if (_deflt.Length > 0 && _typ == "NUMERIC") _defDEGER = " DEFAULT " + _deflt;
            if (MyField.FldIsPrimary == "YES") _primm = " PRIMARY KEY"; ////YES, NO
            return "[" + MyField.FldName + "] " + _typ + _defDEGER + _nullmu + _unik + _primm + _colll;
        }
        public static string IsFieldUnique(string Table,string Field)
        {
            string result = "NO";
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter("select sql from sqlite_master where tbl_name='" + Table +
                    "' and type='table'", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0) return result;
                string _tablecreatescript = dt.Rows[0][0].ToString(),_fieldname="";
                _tablecreatescript = _tablecreatescript.Substring(_tablecreatescript.IndexOf("(") + 1);
                _tablecreatescript = _tablecreatescript.Substring(0, _tablecreatescript.IndexOf(")"));
                string[] TableFields = _tablecreatescript.Split(',');
                foreach (string thefield in TableFields)
                {
                    _fieldname = thefield.Substring(0, thefield.IndexOf(' '));
                    _fieldname = _fieldname.Replace("[", "");
                    _fieldname = _fieldname.Replace("]", "");
                    _fieldname = _fieldname.Replace("'", "");
                    if (_fieldname == Field && thefield.ToUpper().IndexOf("UNIQUE") > 0)
                    {
                        result = "YES";
                        break;
                    }
                }
            }
            return result;
        }
        public static string GetFieldCollation(string Table, string Field)
        {
            string result = "NONE";
            using (SQLiteConnection cnn = new SQLiteConnection(Global.SqlStr))
            {
                SQLiteDataAdapter da = new SQLiteDataAdapter("select sql from sqlite_master where tbl_name='" + Table +
                    "' and type='table'", cnn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 0) return result;
                string _tablecreatescript = dt.Rows[0][0].ToString(), _fieldname="";
                _tablecreatescript = _tablecreatescript.Substring(_tablecreatescript.IndexOf("(") + 1);
                _tablecreatescript = _tablecreatescript.Substring(0, _tablecreatescript.IndexOf(")"));
                string[] _fields = _tablecreatescript.Split(',');
                foreach (string _field in _fields)
                {
                    _fieldname = _field.Substring(0, _field.IndexOf(' '));
                    _fieldname = _fieldname.Replace("[", "");
                    _fieldname = _fieldname.Replace("]", "");
                    _fieldname = _fieldname.Replace("'", "");
                    if (_fieldname == Field)
                    {
                        if (_field.ToUpper().IndexOf("COLLATE") > 0)
                        {
                            string _clt = _field.Substring(_field.ToUpper().IndexOf("COLLATE") + 7);
                            _clt = _clt.TrimStart();
                            result = _clt.Substring(0, _clt.IndexOf(" "));
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
}
