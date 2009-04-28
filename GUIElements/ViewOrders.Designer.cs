namespace EveMarketMonitorApp.GUIElements
{
    partial class ViewOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewOrders));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtStation = new System.Windows.Forms.TextBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStateFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkIngoreOwner = new System.Windows.Forms.CheckBox();
            this.cmbOwner = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ordersGrid = new EveMarketMonitorApp.Common.MultisortDataGridView();
            this.GridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyCellDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCellTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyRowTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCSV = new System.Windows.Forms.Button();
            this.btnUnacknowledgedOrders = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DateIssuedColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SystemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalUnitsColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RemainingValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EscrowColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RangeColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DurationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGrid)).BeginInit();
            this.GridContextMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ordersGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1026, 429);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtStation);
            this.groupBox1.Controls.Add(this.cmbType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbStateFilter);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkIngoreOwner);
            this.groupBox1.Controls.Add(this.cmbOwner);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 74);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // txtStation
            // 
            this.txtStation.Location = new System.Drawing.Point(88, 19);
            this.txtStation.Name = "txtStation";
            this.txtStation.Size = new System.Drawing.Size(344, 20);
            this.txtStation.TabIndex = 23;
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "Any",
            "Buy",
            "Sell"});
            this.cmbType.Location = new System.Drawing.Point(88, 46);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(344, 21);
            this.cmbType.TabIndex = 22;
            this.cmbType.Text = "Any";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Station";
            // 
            // cmbStateFilter
            // 
            this.cmbStateFilter.FormattingEnabled = true;
            this.cmbStateFilter.Location = new System.Drawing.Point(571, 46);
            this.cmbStateFilter.Name = "cmbStateFilter";
            this.cmbStateFilter.Size = new System.Drawing.Size(344, 21);
            this.cmbStateFilter.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(493, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Order State";
            // 
            // chkIngoreOwner
            // 
            this.chkIngoreOwner.AutoSize = true;
            this.chkIngoreOwner.Location = new System.Drawing.Point(933, 22);
            this.chkIngoreOwner.Name = "chkIngoreOwner";
            this.chkIngoreOwner.Size = new System.Drawing.Size(78, 17);
            this.chkIngoreOwner.TabIndex = 16;
            this.chkIngoreOwner.Text = "Any Owner";
            this.chkIngoreOwner.UseVisualStyleBackColor = true;
            // 
            // cmbOwner
            // 
            this.cmbOwner.FormattingEnabled = true;
            this.cmbOwner.Location = new System.Drawing.Point(571, 19);
            this.cmbOwner.Name = "cmbOwner";
            this.cmbOwner.Size = new System.Drawing.Size(344, 21);
            this.cmbOwner.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(493, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Owner";
            // 
            // ordersGrid
            // 
            this.ordersGrid.AllowUserToAddRows = false;
            this.ordersGrid.AllowUserToDeleteRows = false;
            this.ordersGrid.AllowUserToResizeRows = false;
            this.ordersGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateIssuedColumn,
            this.OwnerColumn,
            this.ItemColumn,
            this.PriceColumn,
            this.StationColumn,
            this.SystemColumn,
            this.RegionColumn,
            this.TypeColumn,
            this.TotalUnitsColumn,
            this.QuantityColumn,
            this.TotalValueColumn,
            this.RemainingValueColumn,
            this.EscrowColumn,
            this.StateColumn,
            this.RangeColumn,
            this.DurationColumn});
            this.ordersGrid.ContextMenuStrip = this.GridContextMenu;
            this.ordersGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ordersGrid.Location = new System.Drawing.Point(3, 83);
            this.ordersGrid.Name = "ordersGrid";
            this.ordersGrid.ReadOnly = true;
            this.ordersGrid.Size = new System.Drawing.Size(1020, 301);
            this.ordersGrid.TabIndex = 1;
            this.ordersGrid.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ordersGrid_MouseDown);
            this.ordersGrid.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.ordersGrid_CellFormatting);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCSV);
            this.panel1.Controls.Add(this.btnUnacknowledgedOrders);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 390);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1020, 36);
            this.panel1.TabIndex = 2;
            // 
            // btnCSV
            // 
            this.btnCSV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCSV.Location = new System.Drawing.Point(110, 1);
            this.btnCSV.Name = "btnCSV";
            this.btnCSV.Size = new System.Drawing.Size(101, 35);
            this.btnCSV.TabIndex = 2;
            this.btnCSV.Text = "Export to CSV";
            this.btnCSV.UseVisualStyleBackColor = true;
            this.btnCSV.Click += new System.EventHandler(this.btnCSV_Click);
            // 
            // btnUnacknowledgedOrders
            // 
            this.btnUnacknowledgedOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUnacknowledgedOrders.Location = new System.Drawing.Point(3, 1);
            this.btnUnacknowledgedOrders.Name = "btnUnacknowledgedOrders";
            this.btnUnacknowledgedOrders.Size = new System.Drawing.Size(101, 35);
            this.btnUnacknowledgedOrders.TabIndex = 1;
            this.btnUnacknowledgedOrders.Text = "Unacknowledged Orders";
            this.btnUnacknowledgedOrders.UseVisualStyleBackColor = true;
            this.btnUnacknowledgedOrders.Click += new System.EventHandler(this.btnUnacknowledgedOrders_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(919, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 35);
            this.btnClose.TabIndex = 0;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // DateIssuedColumn
            // 
            this.DateIssuedColumn.HeaderText = "Date";
            this.DateIssuedColumn.Name = "DateIssuedColumn";
            this.DateIssuedColumn.ReadOnly = true;
            this.DateIssuedColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // OwnerColumn
            // 
            this.OwnerColumn.HeaderText = "Owner";
            this.OwnerColumn.Name = "OwnerColumn";
            this.OwnerColumn.ReadOnly = true;
            this.OwnerColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.OwnerColumn.Width = 140;
            // 
            // ItemColumn
            // 
            this.ItemColumn.HeaderText = "Item";
            this.ItemColumn.Name = "ItemColumn";
            this.ItemColumn.ReadOnly = true;
            this.ItemColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.ItemColumn.Width = 200;
            // 
            // PriceColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PriceColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.PriceColumn.HeaderText = "Price";
            this.PriceColumn.Name = "PriceColumn";
            this.PriceColumn.ReadOnly = true;
            this.PriceColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.PriceColumn.Width = 140;
            // 
            // StationColumn
            // 
            this.StationColumn.HeaderText = "Station";
            this.StationColumn.Name = "StationColumn";
            this.StationColumn.ReadOnly = true;
            this.StationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.StationColumn.Width = 200;
            // 
            // SystemColumn
            // 
            this.SystemColumn.HeaderText = "System";
            this.SystemColumn.Name = "SystemColumn";
            this.SystemColumn.ReadOnly = true;
            this.SystemColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // RegionColumn
            // 
            this.RegionColumn.HeaderText = "Region";
            this.RegionColumn.Name = "RegionColumn";
            this.RegionColumn.ReadOnly = true;
            this.RegionColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // TypeColumn
            // 
            this.TypeColumn.HeaderText = "Type";
            this.TypeColumn.Name = "TypeColumn";
            this.TypeColumn.ReadOnly = true;
            this.TypeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TypeColumn.Width = 80;
            // 
            // TotalUnitsColumn
            // 
            this.TotalUnitsColumn.HeaderText = "Total Units";
            this.TotalUnitsColumn.Name = "TotalUnitsColumn";
            this.TotalUnitsColumn.ReadOnly = true;
            this.TotalUnitsColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TotalUnitsColumn.Width = 90;
            // 
            // QuantityColumn
            // 
            this.QuantityColumn.HeaderText = "Remaining Units";
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.ReadOnly = true;
            this.QuantityColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.QuantityColumn.Width = 110;
            // 
            // TotalValueColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.TotalValueColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.TotalValueColumn.HeaderText = "Total Value";
            this.TotalValueColumn.Name = "TotalValueColumn";
            this.TotalValueColumn.ReadOnly = true;
            this.TotalValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.TotalValueColumn.Width = 140;
            // 
            // RemainingValueColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RemainingValueColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.RemainingValueColumn.HeaderText = "Remaining Value";
            this.RemainingValueColumn.Name = "RemainingValueColumn";
            this.RemainingValueColumn.ReadOnly = true;
            this.RemainingValueColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.RemainingValueColumn.Width = 140;
            // 
            // EscrowColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EscrowColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.EscrowColumn.HeaderText = "Escrow";
            this.EscrowColumn.Name = "EscrowColumn";
            this.EscrowColumn.ReadOnly = true;
            this.EscrowColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.EscrowColumn.Width = 140;
            // 
            // StateColumn
            // 
            this.StateColumn.HeaderText = "State";
            this.StateColumn.Name = "StateColumn";
            this.StateColumn.ReadOnly = true;
            this.StateColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.StateColumn.Width = 90;
            // 
            // RangeColumn
            // 
            this.RangeColumn.HeaderText = "Range";
            this.RangeColumn.Name = "RangeColumn";
            this.RangeColumn.ReadOnly = true;
            this.RangeColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.RangeColumn.Width = 80;
            // 
            // DurationColumn
            // 
            this.DurationColumn.HeaderText = "Duration";
            this.DurationColumn.Name = "DurationColumn";
            this.DurationColumn.ReadOnly = true;
            this.DurationColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ViewOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 429);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewOrders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.ViewOrders_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGrid)).EndInit();
            this.GridContextMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIngoreOwner;
        private System.Windows.Forms.ComboBox cmbOwner;
        private System.Windows.Forms.Label label3;
        private EveMarketMonitorApp.Common.MultisortDataGridView ordersGrid;
        private System.Windows.Forms.ComboBox cmbStateFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStation;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnUnacknowledgedOrders;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip GridContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyCellDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRowDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCellTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyRowTextToolStripMenuItem;
        private System.Windows.Forms.Button btnCSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateIssuedColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SystemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalUnitsColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RemainingValueColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn EscrowColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RangeColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DurationColumn;
    }
}