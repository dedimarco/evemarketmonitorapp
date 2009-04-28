namespace EveMarketMonitorApp.GUIElements
{
    partial class ListCorpWebLinks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListCorpWebLinks));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.webLinkGrid = new System.Windows.Forms.DataGridView();
            this.DescriptionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LinkColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.cmbCorpShown = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.webLinkGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnNew, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbCorpShown, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(753, 306);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(664, 275);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNew.Location = new System.Drawing.Point(572, 275);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 28);
            this.btnNew.TabIndex = 3;
            this.btnNew.Text = "New Link";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Show links for:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.webLinkGrid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(747, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Links";
            // 
            // webLinkGrid
            // 
            this.webLinkGrid.AllowUserToAddRows = false;
            this.webLinkGrid.AllowUserToDeleteRows = false;
            this.webLinkGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.webLinkGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DescriptionColumn,
            this.LinkIDColumn,
            this.LinkColumn});
            this.webLinkGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webLinkGrid.Location = new System.Drawing.Point(3, 16);
            this.webLinkGrid.Name = "webLinkGrid";
            this.webLinkGrid.ReadOnly = true;
            this.webLinkGrid.RowHeadersVisible = false;
            this.webLinkGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.webLinkGrid.Size = new System.Drawing.Size(741, 219);
            this.webLinkGrid.TabIndex = 1;
            this.webLinkGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.webLinkGrid_KeyDown);
            this.webLinkGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.webLinkGrid_RowEnter);
            this.webLinkGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.webLinkGrid_CellDoubleClick);
            this.webLinkGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.webLinkGrid_CellContentClick);
            // 
            // DescriptionColumn
            // 
            this.DescriptionColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DescriptionColumn.HeaderText = "Description";
            this.DescriptionColumn.Name = "DescriptionColumn";
            this.DescriptionColumn.ReadOnly = true;
            this.DescriptionColumn.Width = 85;
            // 
            // LinkIDColumn
            // 
            this.LinkIDColumn.HeaderText = "Link ID";
            this.LinkIDColumn.Name = "LinkIDColumn";
            this.LinkIDColumn.ReadOnly = true;
            this.LinkIDColumn.Visible = false;
            // 
            // LinkColumn
            // 
            this.LinkColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.LinkColumn.HeaderText = "Link";
            this.LinkColumn.Name = "LinkColumn";
            this.LinkColumn.ReadOnly = true;
            this.LinkColumn.Width = 33;
            // 
            // cmbCorpShown
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbCorpShown, 3);
            this.cmbCorpShown.FormattingEnabled = true;
            this.cmbCorpShown.Location = new System.Drawing.Point(103, 3);
            this.cmbCorpShown.Name = "cmbCorpShown";
            this.cmbCorpShown.Size = new System.Drawing.Size(358, 21);
            this.cmbCorpShown.TabIndex = 5;
            this.cmbCorpShown.SelectedIndexChanged += new System.EventHandler(this.cmbCorpShown_SelectedIndexChanged);
            // 
            // ListCorpWebLinks
            // 
            this.ClientSize = new System.Drawing.Size(753, 306);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListCorpWebLinks";
            this.Text = "Corporation Web Links";
            this.Load += new System.EventHandler(this.ListCorpWebLinks_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.webLinkGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView webLinkGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCorpShown;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LinkIDColumn;
        private System.Windows.Forms.DataGridViewLinkColumn LinkColumn;
    }
}