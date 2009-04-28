namespace EveMarketMonitorApp.GUIElements
{
    partial class ManageReportGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageReportGroups));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reportGroupsGrid = new System.Windows.Forms.DataGridView();
            this.GroupNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupTypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserAccessLevelColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblNoGroups = new System.Windows.Forms.Label();
            this.chkShowPublic = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.reportGroupsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(524, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(518, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // reportGroupsGrid
            // 
            this.reportGroupsGrid.AllowUserToAddRows = false;
            this.reportGroupsGrid.AllowUserToDeleteRows = false;
            this.reportGroupsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reportGroupsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.reportGroupsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reportGroupsGrid.ColumnHeadersVisible = false;
            this.reportGroupsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupNameColumn,
            this.GroupTypeColumn,
            this.UserAccessLevelColumn,
            this.GroupIDColumn});
            this.reportGroupsGrid.Location = new System.Drawing.Point(12, 113);
            this.reportGroupsGrid.MultiSelect = false;
            this.reportGroupsGrid.Name = "reportGroupsGrid";
            this.reportGroupsGrid.ReadOnly = true;
            this.reportGroupsGrid.RowHeadersVisible = false;
            this.reportGroupsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reportGroupsGrid.Size = new System.Drawing.Size(524, 248);
            this.reportGroupsGrid.TabIndex = 1;
            this.reportGroupsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.reportGroupsGrid_CellDoubleClick);
            // 
            // GroupNameColumn
            // 
            this.GroupNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.GroupNameColumn.HeaderText = "Group Name";
            this.GroupNameColumn.Name = "GroupNameColumn";
            this.GroupNameColumn.ReadOnly = true;
            // 
            // GroupTypeColumn
            // 
            this.GroupTypeColumn.HeaderText = "Type";
            this.GroupTypeColumn.Name = "GroupTypeColumn";
            this.GroupTypeColumn.ReadOnly = true;
            // 
            // UserAccessLevelColumn
            // 
            this.UserAccessLevelColumn.HeaderText = "Access Level";
            this.UserAccessLevelColumn.Name = "UserAccessLevelColumn";
            this.UserAccessLevelColumn.ReadOnly = true;
            // 
            // GroupIDColumn
            // 
            this.GroupIDColumn.HeaderText = "ID";
            this.GroupIDColumn.Name = "GroupIDColumn";
            this.GroupIDColumn.ReadOnly = true;
            this.GroupIDColumn.Visible = false;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(352, 367);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(89, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(447, 367);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnNew.Location = new System.Drawing.Point(12, 367);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(89, 30);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "New Group";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(107, 367);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(89, 30);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Delete Group";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblNoGroups
            // 
            this.lblNoGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoGroups.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.lblNoGroups.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoGroups.Location = new System.Drawing.Point(18, 128);
            this.lblNoGroups.Name = "lblNoGroups";
            this.lblNoGroups.Size = new System.Drawing.Size(515, 71);
            this.lblNoGroups.TabIndex = 6;
            this.lblNoGroups.Text = "You currently have no report groups setup, click \'New Group\' to add one.";
            this.lblNoGroups.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkShowPublic
            // 
            this.chkShowPublic.AutoSize = true;
            this.chkShowPublic.Location = new System.Drawing.Point(18, 90);
            this.chkShowPublic.Name = "chkShowPublic";
            this.chkShowPublic.Size = new System.Drawing.Size(149, 17);
            this.chkShowPublic.TabIndex = 7;
            this.chkShowPublic.Text = "Show public report groups";
            this.chkShowPublic.UseVisualStyleBackColor = true;
            this.chkShowPublic.CheckedChanged += new System.EventHandler(this.chkShowPublic_CheckedChanged);
            // 
            // ManageReportGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 409);
            this.Controls.Add(this.chkShowPublic);
            this.Controls.Add(this.lblNoGroups);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.reportGroupsGrid);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageReportGroups";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Report Groups";
            this.Load += new System.EventHandler(this.ManageReportGroups_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.reportGroupsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView reportGroupsGrid;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblNoGroups;
        private System.Windows.Forms.CheckBox chkShowPublic;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupTypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserAccessLevelColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupIDColumn;
    }
}