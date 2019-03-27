namespace SQLiteAdminUTF8CI
{
    partial class TableEditData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableEditData));
            this.MyGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MyGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MyGrid
            // 
            this.MyGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MyGrid.Location = new System.Drawing.Point(0, 0);
            this.MyGrid.Name = "MyGrid";
            this.MyGrid.Size = new System.Drawing.Size(910, 333);
            this.MyGrid.TabIndex = 0;
            this.MyGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.liste_CellValueChanged);
            this.MyGrid.UserAddedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.liste_UserAddedRow);
            this.MyGrid.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.liste_UserDeletingRow);
            // 
            // TableEditData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 333);
            this.Controls.Add(this.MyGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "TableEditData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Table Data";
            this.Load += new System.EventHandler(this.F_BilgiDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MyGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MyGrid;
    }
}