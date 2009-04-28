namespace EveMarketMonitorApp.GUIElements
{
    partial class ViewInvestments
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewInvestments));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnDeleteCorp = new System.Windows.Forms.Button();
            this.btnNewCorp = new System.Windows.Forms.Button();
            this.btnAutoDiv = new System.Windows.Forms.Button();
            this.btnCorpDetail = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sharesGrid = new System.Windows.Forms.DataGridView();
            this.btnBuySell = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnToggleBanks = new System.Windows.Forms.Button();
            this.chkInvestedOnly = new System.Windows.Forms.CheckBox();
            this.CorpNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountOwnerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sharesGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.tableLayoutPanel1.Controls.Add(this.btnDeleteCorp, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnNewCorp, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAutoDiv, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnCorpDetail, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnBuySell, 6, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 7, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnHistory, 5, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(652, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnDeleteCorp
            // 
            this.btnDeleteCorp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDeleteCorp.Location = new System.Drawing.Point(103, 312);
            this.btnDeleteCorp.Name = "btnDeleteCorp";
            this.btnDeleteCorp.Size = new System.Drawing.Size(86, 34);
            this.btnDeleteCorp.TabIndex = 9;
            this.btnDeleteCorp.Text = "Delete Corp";
            this.btnDeleteCorp.UseVisualStyleBackColor = true;
            this.btnDeleteCorp.Click += new System.EventHandler(this.btnDeleteCorp_Click);
            // 
            // btnNewCorp
            // 
            this.btnNewCorp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewCorp.Location = new System.Drawing.Point(11, 312);
            this.btnNewCorp.Name = "btnNewCorp";
            this.btnNewCorp.Size = new System.Drawing.Size(86, 34);
            this.btnNewCorp.TabIndex = 7;
            this.btnNewCorp.Text = "New Corp";
            this.btnNewCorp.UseVisualStyleBackColor = true;
            this.btnNewCorp.Click += new System.EventHandler(this.btnNewCorp_Click);
            // 
            // btnAutoDiv
            // 
            this.btnAutoDiv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAutoDiv.Location = new System.Drawing.Point(287, 312);
            this.btnAutoDiv.Name = "btnAutoDiv";
            this.btnAutoDiv.Size = new System.Drawing.Size(86, 34);
            this.btnAutoDiv.TabIndex = 6;
            this.btnAutoDiv.Text = "Auto Update Dividends";
            this.btnAutoDiv.UseVisualStyleBackColor = true;
            this.btnAutoDiv.Click += new System.EventHandler(this.btnAutoDiv_Click);
            // 
            // btnCorpDetail
            // 
            this.btnCorpDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnCorpDetail.Location = new System.Drawing.Point(195, 312);
            this.btnCorpDetail.Name = "btnCorpDetail";
            this.btnCorpDetail.Size = new System.Drawing.Size(86, 34);
            this.btnCorpDetail.TabIndex = 5;
            this.btnCorpDetail.Text = "Corp Details";
            this.btnCorpDetail.UseVisualStyleBackColor = true;
            this.btnCorpDetail.Click += new System.EventHandler(this.btnCorpDetail_Click);
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 8);
            this.groupBox1.Controls.Add(this.sharesGrid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Public Corporations";
            // 
            // sharesGrid
            // 
            this.sharesGrid.AllowUserToAddRows = false;
            this.sharesGrid.AllowUserToDeleteRows = false;
            this.sharesGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sharesGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sharesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sharesGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CorpNameColumn,
            this.AccountOwnerColumn,
            this.QuantityColumn,
            this.ValueColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sharesGrid.DefaultCellStyle = dataGridViewCellStyle4;
            this.sharesGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sharesGrid.Location = new System.Drawing.Point(3, 16);
            this.sharesGrid.Name = "sharesGrid";
            this.sharesGrid.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sharesGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.sharesGrid.RowHeadersVisible = false;
            this.sharesGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sharesGrid.Size = new System.Drawing.Size(640, 238);
            this.sharesGrid.TabIndex = 0;
            this.sharesGrid.VirtualMode = true;
            this.sharesGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.sharesGrid_RowEnter);
            this.sharesGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.sharesGrid_CellDoubleClick);
            // 
            // btnBuySell
            // 
            this.btnBuySell.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBuySell.Location = new System.Drawing.Point(471, 312);
            this.btnBuySell.Name = "btnBuySell";
            this.btnBuySell.Size = new System.Drawing.Size(86, 34);
            this.btnBuySell.TabIndex = 2;
            this.btnBuySell.Text = "Buy/Sell Shares";
            this.btnBuySell.UseVisualStyleBackColor = true;
            this.btnBuySell.Click += new System.EventHandler(this.btnBuySell_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(563, 312);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 34);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHistory.Location = new System.Drawing.Point(379, 312);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(86, 34);
            this.btnHistory.TabIndex = 4;
            this.btnHistory.Text = "Transaction History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // groupBox2
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox2, 8);
            this.groupBox2.Controls.Add(this.btnToggleBanks);
            this.groupBox2.Controls.Add(this.chkInvestedOnly);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(646, 40);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // btnToggleBanks
            // 
            this.btnToggleBanks.Location = new System.Drawing.Point(527, 11);
            this.btnToggleBanks.Name = "btnToggleBanks";
            this.btnToggleBanks.Size = new System.Drawing.Size(110, 23);
            this.btnToggleBanks.TabIndex = 1;
            this.btnToggleBanks.Text = "Show Banks";
            this.btnToggleBanks.UseVisualStyleBackColor = true;
            this.btnToggleBanks.Click += new System.EventHandler(this.btnToggleBanks_Click);
            // 
            // chkInvestedOnly
            // 
            this.chkInvestedOnly.AutoSize = true;
            this.chkInvestedOnly.Location = new System.Drawing.Point(9, 15);
            this.chkInvestedOnly.Name = "chkInvestedOnly";
            this.chkInvestedOnly.Size = new System.Drawing.Size(220, 17);
            this.chkInvestedOnly.TabIndex = 0;
            this.chkInvestedOnly.Text = "Only show corps that you are invested in.";
            this.chkInvestedOnly.UseVisualStyleBackColor = true;
            this.chkInvestedOnly.CheckedChanged += new System.EventHandler(this.chkInvestedOnly_CheckedChanged);
            // 
            // CorpNameColumn
            // 
            this.CorpNameColumn.HeaderText = "Corp Name";
            this.CorpNameColumn.Name = "CorpNameColumn";
            this.CorpNameColumn.ReadOnly = true;
            this.CorpNameColumn.Width = 360;
            // 
            // AccountOwnerColumn
            // 
            this.AccountOwnerColumn.HeaderText = "Account Owner";
            this.AccountOwnerColumn.Name = "AccountOwnerColumn";
            this.AccountOwnerColumn.ReadOnly = true;
            this.AccountOwnerColumn.Visible = false;
            // 
            // QuantityColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QuantityColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.QuantityColumn.HeaderText = "Quantity";
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.ReadOnly = true;
            this.QuantityColumn.Width = 80;
            // 
            // ValueColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValueColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValueColumn.HeaderText = "Value";
            this.ValueColumn.Name = "ValueColumn";
            this.ValueColumn.ReadOnly = true;
            this.ValueColumn.Width = 140;
            // 
            // ViewInvestments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 349);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewInvestments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Investments";
            this.Load += new System.EventHandler(this.ViewInvestments_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sharesGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView sharesGrid;
        private System.Windows.Forms.Button btnBuySell;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnCorpDetail;
        private System.Windows.Forms.Button btnAutoDiv;
        private System.Windows.Forms.Button btnNewCorp;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkInvestedOnly;
        private System.Windows.Forms.Button btnToggleBanks;
        private System.Windows.Forms.Button btnDeleteCorp;
        private System.Windows.Forms.DataGridViewTextBoxColumn CorpNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccountOwnerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueColumn;
    }
}