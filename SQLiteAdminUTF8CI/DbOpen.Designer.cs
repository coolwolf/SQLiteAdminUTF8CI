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
            this.Btn_OpenDb = new System.Windows.Forms.Button();
            this.Lv_Drives = new System.Windows.Forms.ListView();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Lv_Folders = new System.Windows.Forms.ListView();
            this.Txt_FolderPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Txt_Password
            // 
            this.Txt_Password.Location = new System.Drawing.Point(177, 277);
            this.Txt_Password.Name = "Txt_Password";
            this.Txt_Password.PasswordChar = '*';
            this.Txt_Password.Size = new System.Drawing.Size(192, 20);
            this.Txt_Password.TabIndex = 4;
            this.Txt_Password.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_Password_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password";
            // 
            // Btn_OpenDb
            // 
            this.Btn_OpenDb.Image = ((System.Drawing.Image)(resources.GetObject("Btn_OpenDb.Image")));
            this.Btn_OpenDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Btn_OpenDb.Location = new System.Drawing.Point(493, 277);
            this.Btn_OpenDb.Name = "Btn_OpenDb";
            this.Btn_OpenDb.Size = new System.Drawing.Size(68, 26);
            this.Btn_OpenDb.TabIndex = 5;
            this.Btn_OpenDb.Text = "&Open";
            this.Btn_OpenDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Btn_OpenDb.UseVisualStyleBackColor = true;
            this.Btn_OpenDb.Click += new System.EventHandler(this.Btn_OpenDb_Click);
            // 
            // Lv_Drives
            // 
            this.Lv_Drives.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Lv_Drives.HideSelection = false;
            this.Lv_Drives.LargeImageList = this.ımageList1;
            this.Lv_Drives.Location = new System.Drawing.Point(1, 36);
            this.Lv_Drives.Name = "Lv_Drives";
            this.Lv_Drives.Size = new System.Drawing.Size(105, 235);
            this.Lv_Drives.SmallImageList = this.ımageList1;
            this.Lv_Drives.TabIndex = 9;
            this.Lv_Drives.UseCompatibleStateImageBehavior = false;
            this.Lv_Drives.SelectedIndexChanged += new System.EventHandler(this.Lv_Drives_SelectedIndexChanged);
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
            this.Lv_Folders.HideSelection = false;
            this.Lv_Folders.LargeImageList = this.ımageList1;
            this.Lv_Folders.Location = new System.Drawing.Point(108, 36);
            this.Lv_Folders.MultiSelect = false;
            this.Lv_Folders.Name = "Lv_Folders";
            this.Lv_Folders.Size = new System.Drawing.Size(460, 235);
            this.Lv_Folders.SmallImageList = this.ımageList1;
            this.Lv_Folders.TabIndex = 8;
            this.Lv_Folders.UseCompatibleStateImageBehavior = false;
            this.Lv_Folders.DoubleClick += new System.EventHandler(this.Lv_Folders_DoubleClick);
            // 
            // Txt_FolderPath
            // 
            this.Txt_FolderPath.Location = new System.Drawing.Point(108, 12);
            this.Txt_FolderPath.Name = "Txt_FolderPath";
            this.Txt_FolderPath.Size = new System.Drawing.Size(460, 20);
            this.Txt_FolderPath.TabIndex = 10;
            this.Txt_FolderPath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_FolderPath_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Path";
            // 
            // DbOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 310);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_FolderPath);
            this.Controls.Add(this.Lv_Drives);
            this.Controls.Add(this.Lv_Folders);
            this.Controls.Add(this.Btn_OpenDb);
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
        private System.Windows.Forms.Button Btn_OpenDb;
        private System.Windows.Forms.ListView Lv_Drives;
        private System.Windows.Forms.ListView Lv_Folders;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.TextBox Txt_FolderPath;
        private System.Windows.Forms.Label label1;
    }
}