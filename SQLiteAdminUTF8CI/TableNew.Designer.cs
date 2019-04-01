namespace SQLiteAdminUTF8CI
{
    partial class TableNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableNew));
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_TableName = new System.Windows.Forms.TextBox();
            this.Dg_FieldList = new System.Windows.Forms.DataGridView();
            this.btn_tabloolustur = new System.Windows.Forms.Button();
            this.FldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FldType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FldDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FldIsNotNull = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FldIsPrimary = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FldCollation = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FldIsUnique = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.FldIsUpdated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.Dg_FieldList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table Name";
            // 
            // Txt_TableName
            // 
            this.Txt_TableName.Location = new System.Drawing.Point(83, 16);
            this.Txt_TableName.Name = "Txt_TableName";
            this.Txt_TableName.Size = new System.Drawing.Size(168, 20);
            this.Txt_TableName.TabIndex = 1;
            // 
            // Dg_FieldList
            // 
            this.Dg_FieldList.AllowUserToResizeColumns = false;
            this.Dg_FieldList.AllowUserToResizeRows = false;
            this.Dg_FieldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dg_FieldList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FldName,
            this.FldType,
            this.FldDefaultValue,
            this.FldIsNotNull,
            this.FldIsPrimary,
            this.FldCollation,
            this.FldIsUnique,
            this.FldIsUpdated});
            this.Dg_FieldList.Location = new System.Drawing.Point(12, 44);
            this.Dg_FieldList.Name = "Dg_FieldList";
            this.Dg_FieldList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.Dg_FieldList.Size = new System.Drawing.Size(771, 285);
            this.Dg_FieldList.TabIndex = 2;
            this.Dg_FieldList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dg_FieldList_CellValueChanged);
            this.Dg_FieldList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.Dg_FieldList_DataError);
            this.Dg_FieldList.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.Dg_FieldList_EditingControlShowing);
            this.Dg_FieldList.NewRowNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.Dg_FieldList_NewRowNeeded);
            this.Dg_FieldList.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Dg_FieldList_KeyUp);
            // 
            // btn_tabloolustur
            // 
            this.btn_tabloolustur.Image = ((System.Drawing.Image)(resources.GetObject("btn_tabloolustur.Image")));
            this.btn_tabloolustur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_tabloolustur.Location = new System.Drawing.Point(659, 12);
            this.btn_tabloolustur.Name = "btn_tabloolustur";
            this.btn_tabloolustur.Size = new System.Drawing.Size(75, 26);
            this.btn_tabloolustur.TabIndex = 5;
            this.btn_tabloolustur.Text = "Create";
            this.btn_tabloolustur.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_tabloolustur.UseVisualStyleBackColor = true;
            this.btn_tabloolustur.Click += new System.EventHandler(this.btn_tabloolustur_Click);
            // 
            // FldName
            // 
            this.FldName.DataPropertyName = "FldName";
            this.FldName.HeaderText = "Name";
            this.FldName.Name = "FldName";
            this.FldName.Width = 200;
            // 
            // FldType
            // 
            this.FldType.DataPropertyName = "FldType";
            this.FldType.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.FldType.HeaderText = "Type";
            this.FldType.Items.AddRange(new object[] {
            "TEXT",
            "NUMERIC",
            "INTEGER",
            "REAL",
            "BLOB"});
            this.FldType.Name = "FldType";
            this.FldType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FldType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // FldDefaultValue
            // 
            this.FldDefaultValue.DataPropertyName = "FldDefaultValue";
            this.FldDefaultValue.HeaderText = "Default";
            this.FldDefaultValue.Name = "FldDefaultValue";
            // 
            // FldIsNotNull
            // 
            this.FldIsNotNull.DataPropertyName = "FldIsNotNull";
            this.FldIsNotNull.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.FldIsNotNull.HeaderText = "Not Null";
            this.FldIsNotNull.Items.AddRange(new object[] {
            "NOT NULL",
            "ALLOW NULL"});
            this.FldIsNotNull.Name = "FldIsNotNull";
            this.FldIsNotNull.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // FldIsPrimary
            // 
            this.FldIsPrimary.DataPropertyName = "FldIsPrimary";
            this.FldIsPrimary.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.FldIsPrimary.HeaderText = "Primary";
            this.FldIsPrimary.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.FldIsPrimary.Name = "FldIsPrimary";
            this.FldIsPrimary.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FldIsPrimary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FldIsPrimary.Width = 60;
            // 
            // FldCollation
            // 
            this.FldCollation.DataPropertyName = "FldCollation";
            this.FldCollation.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.FldCollation.HeaderText = "Collation";
            this.FldCollation.Items.AddRange(new object[] {
            "NONE",
            "UTF8CI"});
            this.FldCollation.Name = "FldCollation";
            this.FldCollation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FldCollation.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FldCollation.Width = 70;
            // 
            // FldIsUnique
            // 
            this.FldIsUnique.DataPropertyName = "FldIsUnique";
            this.FldIsUnique.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.FldIsUnique.HeaderText = "Unique";
            this.FldIsUnique.Items.AddRange(new object[] {
            "YES",
            "NO"});
            this.FldIsUnique.Name = "FldIsUnique";
            this.FldIsUnique.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FldIsUnique.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FldIsUnique.Width = 60;
            // 
            // FldIsUpdated
            // 
            this.FldIsUpdated.DataPropertyName = "FldIsUpdated";
            this.FldIsUpdated.HeaderText = "fldupdated";
            this.FldIsUpdated.Name = "FldIsUpdated";
            this.FldIsUpdated.Visible = false;
            // 
            // TableNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 339);
            this.Controls.Add(this.btn_tabloolustur);
            this.Controls.Add(this.Dg_FieldList);
            this.Controls.Add(this.Txt_TableName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TableNew";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Table";
            this.Load += new System.EventHandler(this.yenitablo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dg_FieldList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_TableName;
        public System.Windows.Forms.DataGridView Dg_FieldList;
        private System.Windows.Forms.Button btn_tabloolustur;
        private System.Windows.Forms.DataGridViewTextBoxColumn FldName;
        private System.Windows.Forms.DataGridViewComboBoxColumn FldType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FldDefaultValue;
        private System.Windows.Forms.DataGridViewComboBoxColumn FldIsNotNull;
        private System.Windows.Forms.DataGridViewComboBoxColumn FldIsPrimary;
        private System.Windows.Forms.DataGridViewComboBoxColumn FldCollation;
        private System.Windows.Forms.DataGridViewComboBoxColumn FldIsUnique;
        private System.Windows.Forms.DataGridViewCheckBoxColumn FldIsUpdated;
    }
}