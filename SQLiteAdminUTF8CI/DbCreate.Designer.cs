namespace SQLiteAdminUTF8CI
{
    partial class DbCreate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DbCreate));
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_FileName = new System.Windows.Forms.TextBox();
            this.btn_kaydet = new System.Windows.Forms.Button();
            this.Txt_DbPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Lv_Folders = new System.Windows.Forms.ListView();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Lv_Drives = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Name";
            // 
            // Txt_FileName
            // 
            this.Txt_FileName.Location = new System.Drawing.Point(333, 254);
            this.Txt_FileName.Name = "Txt_FileName";
            this.Txt_FileName.Size = new System.Drawing.Size(122, 20);
            this.Txt_FileName.TabIndex = 1;
            this.Txt_FileName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txt_dosyaadi_KeyUp);
            // 
            // btn_kaydet
            // 
            this.btn_kaydet.Image = ((System.Drawing.Image)(resources.GetObject("btn_kaydet.Image")));
            this.btn_kaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_kaydet.Location = new System.Drawing.Point(481, 251);
            this.btn_kaydet.Name = "btn_kaydet";
            this.btn_kaydet.Size = new System.Drawing.Size(75, 26);
            this.btn_kaydet.TabIndex = 2;
            this.btn_kaydet.Text = "Create";
            this.btn_kaydet.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_kaydet.UseVisualStyleBackColor = true;
            this.btn_kaydet.Click += new System.EventHandler(this.btn_kaydet_Click);
            // 
            // Txt_DbPassword
            // 
            this.Txt_DbPassword.Location = new System.Drawing.Point(71, 255);
            this.Txt_DbPassword.Name = "Txt_DbPassword";
            this.Txt_DbPassword.PasswordChar = '*';
            this.Txt_DbPassword.Size = new System.Drawing.Size(122, 20);
            this.Txt_DbPassword.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password";
            // 
            // Lv_Folders
            // 
            this.Lv_Folders.LargeImageList = this.ımageList1;
            this.Lv_Folders.Location = new System.Drawing.Point(106, 0);
            this.Lv_Folders.MultiSelect = false;
            this.Lv_Folders.Name = "Lv_Folders";
            this.Lv_Folders.Size = new System.Drawing.Size(460, 235);
            this.Lv_Folders.SmallImageList = this.ımageList1;
            this.Lv_Folders.TabIndex = 6;
            this.Lv_Folders.UseCompatibleStateImageBehavior = false;
            this.Lv_Folders.DoubleClick += new System.EventHandler(this.lv_dizinler_DoubleClick);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "folder-icon.png");
            this.ımageList1.Images.SetKeyName(1, "Hard-drive-icon.png");
            // 
            // Lv_Drives
            // 
            this.Lv_Drives.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.Lv_Drives.LargeImageList = this.ımageList1;
            this.Lv_Drives.Location = new System.Drawing.Point(0, 0);
            this.Lv_Drives.Name = "Lv_Drives";
            this.Lv_Drives.Size = new System.Drawing.Size(105, 235);
            this.Lv_Drives.SmallImageList = this.ımageList1;
            this.Lv_Drives.TabIndex = 7;
            this.Lv_Drives.UseCompatibleStateImageBehavior = false;
            this.Lv_Drives.SelectedIndexChanged += new System.EventHandler(this.lv_suruculer_SelectedIndexChanged);
            // 
            // DbCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 290);
            this.Controls.Add(this.Lv_Drives);
            this.Controls.Add(this.Lv_Folders);
            this.Controls.Add(this.Txt_DbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_kaydet);
            this.Controls.Add(this.Txt_FileName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DbCreate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Database";
            this.Load += new System.EventHandler(this.F_DBOlustur_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_FileName;
        private System.Windows.Forms.Button btn_kaydet;
        private System.Windows.Forms.TextBox Txt_DbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView Lv_Folders;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.ListView Lv_Drives;
    }
}