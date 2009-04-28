namespace EveMarketMonitorApp.GUIElements
{
    partial class ViewJournal
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewJournal));
            this.journalDataGridView = new EveMarketMonitorApp.Common.MultisortDataGridView();
            this.IDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerIsSenderColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerID1Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner1CorpColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner1WalletColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerID2Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner2CorpColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Owner2WalletColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArgIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArgNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalanceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReasonColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCellDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCellTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIgnoreWallet = new System.Windows.Forms.CheckBox();
            this.chkIngoreOwner = new System.Windows.Forms.CheckBox();
            this.lblWallet = new System.Windows.Forms.Label();
            this.cmbWallet = new System.Windows.Forms.ComboBox();
            this.cmbOwner = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCSV = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.journalDataGridView)).BeginInit();
            this.GridContextMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // journalDataGridView
            // 
            this.journalDataGridView.AllowUserToAddRows = false;
            this.journalDataGridView.AllowUserToDeleteRows = false;
            this.journalDataGridView.AllowUserToResizeRows = false;
            this.journalDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDColumn,
            this.DateColumn,
            this.TypeColumn,
            this.OwnerIsSenderColumn,
            this.Owner1Column,
            this.OwnerID1Column,
            this.Owner1CorpColumn,
            this.Owner1WalletColumn,
            this.Owner2Column,
            this.OwnerID2Column,
            this.Owner2CorpColumn,
            this.Owner2WalletColumn,
            this.ArgIDColumn,
            this.ArgNameColumn,
            this.AmountColumn,
            this.BalanceColumn,
            this.ReasonColumn});
            this.journalDataGridView.ContextMenuStrip = this.GridContextMenu;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.journalDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.journalDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.journalDataGridView.Location = new System.Drawing.Point(3, 111);
            this.journalDataGridView.Name = "journalDataGridView";
            this.journalDataGridView.ReadOnly = true;
            this.journalDataGridView.Size = new System.Drawing.Size(1064, 282);
            this.journalDataGridView.TabIndex = 1;
            this.journalDataGridView.VirtualMode = true;
            this.journalDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.journalDataGridView_MouseDown);
            this.journalDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.journalDataGridView_CellFormatting);
            // 
            // IDColumn
            // 
            this.IDColumn.HeaderText = "ID";
            this.IDColumn.Name = "IDColumn";
            this.IDColumn.ReadOnly = true;
            this.IDColumn.Visible = false;
            // 
            // DateColumn
            // 
            this.DateColumn.HeaderText = "Date & Time";
            this.DateColumn.Name = "DateColumn";
            this.DateColumn.ReadOnly = true;
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.Width = 170;
            // 
            // OwnerIsSenderColumn
            // 
            this.OwnerIsSenderColumn.HeaderText = "Owner Is Sender";
            this.OwnerIsSenderColumn.Name = "OwnerIsSenderColumn";
            this.OwnerIsSenderColumn.ReadOnly = true;
            this.OwnerIsSenderColumn.Visible = false;
            // 
            // Owner1Column
            // 
            this.Owner1Column.HeaderText = "Owner 1";
            this.Owner1Column.Name = "Owner1Column";
            this.Owner1Column.ReadOnly = true;
            this.Owner1Column.Width = 120;
            // 
            // OwnerID1Column
            // 
            this.OwnerID1Column.HeaderText = "Owner ID 1";
            this.OwnerID1Column.Name = "OwnerID1Column";
            this.OwnerID1Column.ReadOnly = true;
            this.OwnerID1Column.Visible = false;
            // 
            // Owner1CorpColumn
            // 
            this.Owner1CorpColumn.HeaderText = "Owner 1 Corp";
            this.Owner1CorpColumn.Name = "Owner1CorpColumn";
            this.Owner1CorpColumn.ReadOnly = true;
            this.Owner1CorpColumn.Width = 150;
            // 
            // Owner1WalletColumn
            // 
            this.Owner1WalletColumn.HeaderText = "Owner 1 Wallet";
            this.Owner1WalletColumn.Name = "Owner1WalletColumn";
            this.Owner1WalletColumn.ReadOnly = true;
            this.Owner1WalletColumn.Width = 150;
            // 
            // Owner2Column
            // 
            this.Owner2Column.HeaderText = "Owner 2";
            this.Owner2Column.Name = "Owner2Column";
            this.Owner2Column.ReadOnly = true;
            this.Owner2Column.Width = 120;
            // 
            // OwnerID2Column
            // 
            this.OwnerID2Column.HeaderText = "Owner ID 2";
            this.OwnerID2Column.Name = "OwnerID2Column";
            this.OwnerID2Column.ReadOnly = true;
            this.OwnerID2Column.Visible = false;
            // 
            // Owner2CorpColumn
            // 
            this.Owner2CorpColumn.HeaderText = "Owner 2 Corp";
            this.Owner2CorpColumn.Name = "Owner2CorpColumn";
            this.Owner2CorpColumn.ReadOnly = true;
            this.Owner2CorpColumn.Width = 150;
            // 
            // Owner2WalletColumn
            // 
            this.Owner2WalletColumn.HeaderText = "Owner 2 Wallet";
            this.Owner2WalletColumn.Name = "Owner2WalletColumn";
            this.Owner2WalletColumn.ReadOnly = true;
            this.Owner2WalletColumn.Width = 150;
            // 
            // ArgIDColumn
            // 
            this.ArgIDColumn.HeaderText = "Arg ID";
            this.ArgIDColumn.Name = "ArgIDColumn";
            this.ArgIDColumn.ReadOnly = true;
            this.ArgIDColumn.Width = 120;
            // 
            // ArgNameColumn
            // 
            this.ArgNameColumn.HeaderText = "Arg Name";
            this.ArgNameColumn.Name = "ArgNameColumn";
            this.ArgNameColumn.ReadOnly = true;
            this.ArgNameColumn.Width = 120;
            // 
            // AmountColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.AmountColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.AmountColumn.HeaderText = "Amount";
            this.AmountColumn.Name = "AmountColumn";
            this.AmountColumn.ReadOnly = true;
            this.AmountColumn.Width = 130;
            // 
            // BalanceColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BalanceColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.BalanceColumn.HeaderText = "Balance";
            this.BalanceColumn.Name = "BalanceColumn";
            this.BalanceColumn.ReadOnly = true;
            this.BalanceColumn.Width = 140;
            // 
            // ReasonColumn
            // 
            this.ReasonColumn.HeaderText = "Reason";
            this.ReasonColumn.Name = "ReasonColumn";
            this.ReasonColumn.ReadOnly = true;
            this.ReasonColumn.Width = 300;
            // 
            // GridContextMenu
            // 
            this.GridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyCellDataToolStripMenuItem,
            this.copyRowDataToolStripMenuItem,
            this.copyCellTextToolStripMenuItem,
            this.copyRowTextToolStripMenuItem});
            this.GridContextMenu.Name = "GridContextMenu";
            this.GridContextMenu.Size = new System.Drawing.Size(161, 92);
            // 
            // copyCellDataToolStripMenuItem
            // 
            this.copyCellDataToolStripMenuItem.Name = "copyCellDataToolStripMenuItem";
            this.copyCellDataToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyCellDataToolStripMenuItem.Text = "Copy Cell Data";
            this.copyCellDataToolStripMenuItem.Click += new System.EventHandler(this.copyCellDataToolStripMenuItem_Click);
            // 
            // copyRowDataToolStripMenuItem
            // 
            this.copyRowDataToolStripMenuItem.Name = "copyRowDataToolStripMenuItem";
            this.copyRowDataToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyRowDataToolStripMenuItem.Text = "Copy Row Data";
            this.copyRowDataToolStripMenuItem.Click += new System.EventHandler(this.copyRowDataToolStripMenuItem_Click);
            // 
            // copyCellTextToolStripMenuItem
            // 
            this.copyCellTextToolStripMenuItem.Name = "copyCellTextToolStripMenuItem";
            this.copyCellTextToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyCellTextToolStripMenuItem.Text = "Copy Cell Text";
            this.copyCellTextToolStripMenuItem.Click += new System.EventHandler(this.copyCellTextToolStripMenuItem_Click);
            // 
            // copyRowTextToolStripMenuItem
            // 
            this.copyRowTextToolStripMenuItem.Name = "copyRowTextToolStripMenuItem";
            this.copyRowTextToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyRowTextToolStripMenuItem.Text = "Copy Row Text";
            this.copyRowTextToolStripMenuItem.Click += new System.EventHandler(this.copyRowTextToolStripMenuItem_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.journalDataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1070, 430);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.chkIgnoreWallet);
            this.groupBox1.Controls.Add(this.chkIngoreOwner);
            this.groupBox1.Controls.Add(this.lblWallet);
            this.groupBox1.Controls.Add(this.cmbWallet);
            this.groupBox1.Controls.Add(this.cmbOwner);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1064, 102);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MMM-yyyy HH:mm:ss";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(316, 19);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(171, 20);
            this.dtpEndDate.TabIndex = 21;
            this.dtpEndDate.DropDown += new System.EventHandler(this.dtpEndDate_DropDown);
            this.dtpEndDate.CloseUp += new System.EventHandler(this.dtpEndDate_CloseUp);
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MMM-yyyy HH:mm:ss";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(113, 19);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(171, 20);
            this.dtpStartDate.TabIndex = 20;
            this.dtpStartDate.DropDown += new System.EventHandler(this.dtpStartDate_DropDown);
            this.dtpStartDate.CloseUp += new System.EventHandler(this.dtpStartDate_CloseUp);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(290, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Date range";
            // 
            // chkIgnoreWallet
            // 
            this.chkIgnoreWallet.AutoSize = true;
            this.chkIgnoreWallet.Location = new System.Drawing.Point(960, 74);
            this.chkIgnoreWallet.Name = "chkIgnoreWallet";
            this.chkIgnoreWallet.Size = new System.Drawing.Size(77, 17);
            this.chkIgnoreWallet.TabIndex = 17;
            this.chkIgnoreWallet.Text = "Any Wallet";
            this.chkIgnoreWallet.UseVisualStyleBackColor = true;
            // 
            // chkIngoreOwner
            // 
            this.chkIngoreOwner.AutoSize = true;
            this.chkIngoreOwner.Location = new System.Drawing.Point(960, 47);
            this.chkIngoreOwner.Name = "chkIngoreOwner";
            this.chkIngoreOwner.Size = new System.Drawing.Size(78, 17);
            this.chkIngoreOwner.TabIndex = 16;
            this.chkIngoreOwner.Text = "Any Owner";
            this.chkIngoreOwner.UseVisualStyleBackColor = true;
            // 
            // lblWallet
            // 
            this.lblWallet.AutoSize = true;
            this.lblWallet.Location = new System.Drawing.Point(521, 74);
            this.lblWallet.Name = "lblWallet";
            this.lblWallet.Size = new System.Drawing.Size(37, 13);
            this.lblWallet.TabIndex = 15;
            this.lblWallet.Text = "Wallet";
            // 
            // cmbWallet
            // 
            this.cmbWallet.FormattingEnabled = true;
            this.cmbWallet.Location = new System.Drawing.Point(598, 71);
            this.cmbWallet.Name = "cmbWallet";
            this.cmbWallet.Size = new System.Drawing.Size(344, 21);
            this.cmbWallet.TabIndex = 14;
            // 
            // cmbOwner
            // 
            this.cmbOwner.FormattingEnabled = true;
            this.cmbOwner.Location = new System.Drawing.Point(598, 45);
            this.cmbOwner.Name = "cmbOwner";
            this.cmbOwner.Size = new System.Drawing.Size(344, 21);
            this.cmbOwner.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(520, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Owner";
            // 
            // cmbType
            // 
            this.cmbType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(113, 45);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(374, 21);
            this.cmbType.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(113, 72);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(374, 20);
            this.txtName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Entries involving";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Entry types";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 399);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1064, 28);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(971, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 29);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCSV
            // 
            this.btnCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCSV.Location = new System.Drawing.Point(0, 0);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(93, 29);
            this.btnCSV.TabIndex = 2;
            this.btnCSV.Text = "Export to CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // ViewJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1070, 430);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewJournal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Journal";
            this.Load += new System.EventHandler(this.ViewJournal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.journalDataGridView)).EndInit();
            this.GridContextMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EveMarketMonitorApp.Common.MultisortDataGridView journalDataGridView;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox chkIgnoreWallet;
        private System.Windows.Forms.CheckBox chkIngoreOwner;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.ComboBox cmbWallet;
        private System.Windows.Forms.ComboBox cmbOwner;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerIsSenderColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerID1Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner1CorpColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner1WalletColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerID2Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner2CorpColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Owner2WalletColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArgIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArgNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AmountColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalanceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReasonColumn;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip GridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyCellDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRowDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCellTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRowTextToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.Button btnClose;

    }
}