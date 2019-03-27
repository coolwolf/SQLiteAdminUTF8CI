namespace SQLiteAdminUTF8CI
{
    partial class DbOpen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbOpen));
            this.Txt_Password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_dbac = new System.Windows.Forms.Button();
            this.Lv_Drives = new System.Windows.Forms.ListView();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Lv_Folders = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(107, 247);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(192, 20);
            this.Txt_Password.TabIndex = 4;
            this.Txt_Password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_parola_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // btn_dbac
            // 
            this.btn_dbac.Image = ((System.Drawing.Image)(resources.GetObject("btn_dbac.Image")));
            this.btn_dbac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_dbac.Location = new System.Drawing.Point(499, 243);
            this.btn_dbac.Name = "btn_dbac";
            this.btn_dbac.Size = new System.Drawing.Size(68, 26);
            this.btn_dbac.TabIndex = 5;
            this.btn_dbac.Text = "&Open";
            this.btn_dbac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_dbac.UseVisualStyleBackColor = true;
            this.btn_dbac.Click += new System.EventHandler(this.btn_dbac_Click);
            // 
            // Lv_Drives
            // 
            this.Lv_Drives.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Lv_Drives.LargeImageList = this.ımageList1;
            this.Lv_Drives.Location = new System.Drawing.Point(0, 0);
            this.Lv_Drives.Name = "Lv_Drives";
            this.Lv_Drives.Size = new System.Drawing.Size(105, 235);
            this.Lv_Drives.SmallImageList = this.ımageList1;
            this.Lv_Drives.TabIndex = 9;
            this.Lv_Drives.UseCompatibleStateImageBehavior = false;
            this.Lv_Drives.SelectedIndexChanged += new System.EventHandler(this.lv_suruculer_SelectedIndexChanged);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "folder-icon.png");
            this.ımageList1.Images.SetKeyName(1, "Hard-drive-icon.png");
            this.ımageList1.Images.SetKeyName(2, "file-icon.png");
            // 
            // Lv_Folders
            // 
            this.Lv_Folders.LargeImageList = this.ımageList1;
            this.Lv_Folders.Location = new System.Drawing.Point(107, 0);
            this.Lv_Folders.MultiSelect = false;
            this.Lv_Folders.Name = "Lv_Folders";
            this.Lv_Folders.Size = new System.Drawing.Size(460, 235);
            this.Lv_Folders.SmallImageList = this.ımageList1;
            this.Lv_Folders.TabIndex = 8;
            this.Lv_Folders.UseCompatibleStateImageBehavior = false;
            this.Lv_Folders.DoubleClick += new System.EventHandler(this.lv_dizinler_DoubleClick);
            // 
            // DbOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 285);
            this.Controls.Add(this.Lv_Drives);
            this.Controls.Add(this.Lv_Folders);
            this.Controls.Add(this.btn_dbac);
            this.Controls.Add(this.Txt_Password);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DbOpen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Open Database File";
            this.Load += new System.EventHandler(this.F_DBAc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Txt_Password;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_dbac;
        private System.Windows.Forms.ListView Lv_Drives;
        private System.Windows.Forms.ListView Lv_Folders;
        private System.Windows.Forms.ImageList ımageList1;


    }
}