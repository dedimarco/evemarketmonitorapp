namespace EveMarketMonitorApp.GUIElements
{
    partial class ListShareTransactions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListShareTransactions));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkShowAll = new System.Windows.Forms.CheckBox();
            this.cmbCorp = new System.Windows.Forms.ComboBox();
            this.lblCorpShown = new System.Windows.Forms.Label();
            this.shareTransGridView = new System.Windows.Forms.DataGridView();
            this.TransIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CorpColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shareTransGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.shareTransGridView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(698, 330);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(609, 299);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 28);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 3);
            this.groupBox1.Controls.Add(this.chkShowAll);
            this.groupBox1.Controls.Add(this.cmbCorp);
            this.groupBox1.Controls.Add(this.lblCorpShown);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(692, 68);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Transaction Filter";
            // 
            // chkShowAll
            // 
            this.chkShowAll.AutoSize = true;
            this.chkShowAll.Location = new System.Drawing.Point(9, 19);
            this.chkShowAll.Name = "chkShowAll";
            this.chkShowAll.Size = new System.Drawing.Size(155, 17);
            this.chkShowAll.TabIndex = 2;
            this.chkShowAll.Text = "Show all share transactions";
            this.chkShowAll.UseVisualStyleBackColor = true;
            this.chkShowAll.CheckedChanged += new System.EventHandler(this.chkShowAll_CheckedChanged);
            // 
            // cmbCorp
            // 
            this.cmbCorp.FormattingEnabled = true;
            this.cmbCorp.Location = new System.Drawing.Point(61, 42);
            this.cmbCorp.Name = "cmbCorp";
            this.cmbCorp.Size = new System.Drawing.Size(438, 21);
            this.cmbCorp.TabIndex = 1;
            this.cmbCorp.SelectedIndexChanged += new System.EventHandler(this.cmbCorp_SelectedIndexChanged);
            // 
            // lblCorpShown
            // 
            this.lblCorpShown.AutoSize = true;
            this.lblCorpShown.Location = new System.Drawing.Point(6, 45);
            this.lblCorpShown.Name = "lblCorpShown";
            this.lblCorpShown.Size = new System.Drawing.Size(29, 13);
            this.lblCorpShown.TabIndex = 0;
            this.lblCorpShown.Text = "Corp";
            // 
            // shareTransGridView
            // 
            this.shareTransGridView.AllowUserToAddRows = false;
            this.shareTransGridView.AllowUserToDeleteRows = false;
            this.shareTransGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.shareTransGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransIDColumn,
            this.DateColumn,
            this.CorpColumn,
            this.PriceValueColumn,
            this.AmountColumn,
            this.TypeColumn});
            this.tableLayoutPanel1.SetColumnSpan(this.shareTransGridView, 3);
            this.shareTransGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shareTransGridView.Location = new System.Drawing.Point(3, 77);
            this.shareTransGridView.Name = "shareTransGridView";
            this.shareTransGridView.ReadOnly = true;
            this.shareTransGridView.RowHeadersVisible = false;
            this.shareTransGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.shareTransGridView.Size = new System.Drawing.Size(692, 216);
            this.shareTransGridView.TabIndex = 0;
            this.shareTransGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.shareTransGridView_KeyDown);
            this.shareTransGridView.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.shareTransGridView_RowEnter);
            // 
            // TransIDColumn
            // 
            this.TransIDColumn.HeaderText = "Trans ID";
            this.TransIDColumn.Name = "TransIDColumn";
            this.TransIDColumn.ReadOnly = true;
            this.TransIDColumn.Visible = false;
            // 
            // DateColumn
            // 
            this.DateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateColumn.HeaderText = "Date";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            this.DateColumn.Width = 55;
            // 
            // CorpColumn
            // 
            this.CorpColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CorpColumn.HeaderText = "Corp";
            this.CorpColumn.Name = "CorpColumn";
            this.CorpColumn.ReadOnly = true;
            this.CorpColumn.Width = 54;
            // 
            // PriceValueColumn
            // 
            this.PriceValueColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PriceValueColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.PriceValueColumn.HeaderText = "Price";
            this.PriceValueColumn.Name = "PriceValueColumn";
            this.PriceValueColumn.ReadOnly = true;
            this.PriceValueColumn.Width = 56;
            // 
            // AmountColumn
            // 
            this.AmountColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AmountColumn.HeaderText = "Amount";
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.ReadOnly = true;
            this.AmountColumn.Width = 68;
            // 
            // TypeColumn
            // 
            this.TypeColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Width = 56;
            // 
            // ListShareTransactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 330);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListShareTransactions";
            this.Text = "Share Transactions";
            this.Load += new System.EventHandler(this.ListShareTransactions_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shareTransGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView shareTransGridView;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbCorp;
        private System.Windows.Forms.Label lblCorpShown;
        private System.Windows.Forms.CheckBox chkShowAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorpColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
    }
}