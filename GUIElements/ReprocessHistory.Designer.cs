namespace EveMarketMonitorApp.GUIElements
{
    partial class ReprocessHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReprocessHistory));
            this.reprocessJobsGrid = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReverse = new System.Windows.Forms.Button();
            this.JobDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.reprocessJobsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // reprocessJobsGrid
            // 
            this.reprocessJobsGrid.AllowUserToAddRows = false;
            this.reprocessJobsGrid.AllowUserToDeleteRows = false;
            this.reprocessJobsGrid.AllowUserToResizeRows = false;
            this.reprocessJobsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.reprocessJobsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reprocessJobsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JobDateColumn,
            this.OwnerColumn,
            this.StationColumn});
            this.reprocessJobsGrid.Location = new System.Drawing.Point(12, 12);
            this.reprocessJobsGrid.Name = "reprocessJobsGrid";
            this.reprocessJobsGrid.RowHeadersVisible = false;
            this.reprocessJobsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.reprocessJobsGrid.Size = new System.Drawing.Size(694, 339);
            this.reprocessJobsGrid.TabIndex = 0;
            this.reprocessJobsGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.reprocessJobsGrid_RowEnter);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(622, 357);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 30);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReverse
            // 
            this.btnReverse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnReverse.Location = new System.Drawing.Point(12, 357);
            this.btnReverse.Name = "btnReverse";
            this.btnReverse.Size = new System.Drawing.Size(84, 30);
            this.btnReverse.TabIndex = 2;
            this.btnReverse.Text = "Reverse Job";
            this.btnReverse.UseVisualStyleBackColor = true;
            this.btnReverse.Click += new System.EventHandler(this.btnReverse_Click);
            // 
            // JobDateColumn
            // 
            this.JobDateColumn.HeaderText = "Job Date";
            this.JobDateColumn.Name = "JobDateColumn";
            this.JobDateColumn.Width = 120;
            // 
            // OwnerColumn
            // 
            this.OwnerColumn.HeaderText = "Owner";
            this.OwnerColumn.Name = "OwnerColumn";
            this.OwnerColumn.Width = 140;
            // 
            // StationColumn
            // 
            this.StationColumn.HeaderText = "Station";
            this.StationColumn.Name = "StationColumn";
            this.StationColumn.Width = 350;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.Location = new System.Drawing.Point(102, 357);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Job";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // ReprocessHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 399);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReverse);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.reprocessJobsGrid);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReprocessHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Reprocess History";
            this.Load += new System.EventHandler(this.ReprocessHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reprocessJobsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reprocessJobsGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReverse;
        private System.Windows.Forms.DataGridViewTextBoxColumn JobDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationColumn;
        private System.Windows.Forms.Button btnDelete;
    }
}