namespace SQLiteAdminUTF8CI
{
    partial class ViewAdd
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
            this.btn_viewolustur = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_viewadi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_tanim = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_viewolustur
            // 
            this.btn_viewolustur.Location = new System.Drawing.Point(550, 9);
            this.btn_viewolustur.Name = "btn_viewolustur";
            this.btn_viewolustur.Size = new System.Drawing.Size(64, 43);
            this.btn_viewolustur.TabIndex = 9;
            this.btn_viewolustur.Text = "Create View";
            this.btn_viewolustur.UseVisualStyleBackColor = true;
            this.btn_viewolustur.Click += new System.EventHandler(this.btn_viewolustur_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Definition";
            // 
            // txt_viewadi
            // 
            this.txt_viewadi.Location = new System.Drawing.Point(83, 6);
            this.txt_viewadi.Name = "txt_viewadi";
            this.txt_viewadi.Size = new System.Drawing.Size(168, 20);
            this.txt_viewadi.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "View Name";
            // 
            // txt_tanim
            // 
            this.txt_tanim.Location = new System.Drawing.Point(12, 58);
            this.txt_tanim.Multiline = true;
            this.txt_tanim.Name = "txt_tanim";
            this.txt_tanim.Size = new System.Drawing.Size(602, 222);
            this.txt_tanim.TabIndex = 10;
            // 
            // viewekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 289);
            this.Controls.Add(this.txt_tanim);
            this.Controls.Add(this.btn_viewolustur);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_viewadi);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "viewekle";
            this.Text = "Add View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_viewolustur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_viewadi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_tanim;
    }
}