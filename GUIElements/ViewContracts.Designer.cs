namespace EveMarketMonitorApp.GUIElements
{
    partial class ViewContracts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewContracts));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCourierSettings = new System.Windows.Forms.Button();
            this.btnNewContract = new System.Windows.Forms.Button();
            this.btnAutoContractor = new System.Windows.Forms.Button();
            this.contractsGrid = new EveMarketMonitorApp.Common.MultisortDataGridView();
            this.ContractIDColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IssueDateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OwnerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PickupStationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestinationStationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CollateralColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RewardColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpectedProfitColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CompletedColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.FailedColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.ExpiredColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpFilters = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkIngoreOwner = new System.Windows.Forms.CheckBox();
            this.cmbOwner = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblDestStation = new System.Windows.Forms.Label();
            this.lblPickupStation = new System.Windows.Forms.Label();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.cmbPickup = new System.Windows.Forms.ComboBox();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractsGrid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpFilters.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnCourierSettings);
            this.panel1.Controls.Add(this.btnNewContract);
            this.panel1.Controls.Add(this.btnAutoContractor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 421);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1051, 42);
            this.panel1.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(945, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 32);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCourierSettings
            // 
            this.btnCourierSettings.Location = new System.Drawing.Point(221, 6);
            this.btnCourierSettings.Name = "btnCourierSettings";
            this.btnCourierSettings.Size = new System.Drawing.Size(103, 32);
            this.btnCourierSettings.TabIndex = 2;
            this.btnCourierSettings.Text = "Courier Settings";
            this.btnCourierSettings.UseVisualStyleBackColor = true;
            this.btnCourierSettings.Click += new System.EventHandler(this.btnCourierSettings_Click);
            // 
            // btnNewContract
            // 
            this.btnNewContract.Location = new System.Drawing.Point(3, 6);
            this.btnNewContract.Name = "btnNewContract";
            this.btnNewContract.Size = new System.Drawing.Size(103, 32);
            this.btnNewContract.TabIndex = 1;
            this.btnNewContract.Text = "New Contract";
            this.btnNewContract.UseVisualStyleBackColor = true;
            this.btnNewContract.Click += new System.EventHandler(this.btnNewContract_Click);
            // 
            // btnAutoContractor
            // 
            this.btnAutoContractor.Location = new System.Drawing.Point(112, 6);
            this.btnAutoContractor.Name = "btnAutoContractor";
            this.btnAutoContractor.Size = new System.Drawing.Size(103, 32);
            this.btnAutoContractor.TabIndex = 0;
            this.btnAutoContractor.Text = "Auto-contractor";
            this.btnAutoContractor.UseVisualStyleBackColor = true;
            this.btnAutoContractor.Click += new System.EventHandler(this.btnAutoContractor_Click);
            // 
            // contractsGrid
            // 
            this.contractsGrid.AllowUserToAddRows = false;
            this.contractsGrid.AllowUserToDeleteRows = false;
            this.contractsGrid.AllowUserToResizeRows = false;
            this.contractsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contractsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ContractIDColumn,
            this.IssueDateColumn,
            this.OwnerColumn,
            this.PickupStationColumn,
            this.DestinationStationColumn,
            this.StatusColumn,
            this.CollateralColumn,
            this.RewardColumn,
            this.ExpectedProfitColumn,
            this.CompletedColumn,
            this.FailedColumn,
            this.ExpiredColumn});
            this.contractsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contractsGrid.Location = new System.Drawing.Point(3, 113);
            this.contractsGrid.Name = "contractsGrid";
            this.contractsGrid.ReadOnly = true;
            this.contractsGrid.ShowCellToolTips = false;
            this.contractsGrid.Size = new System.Drawing.Size(1051, 302);
            this.contractsGrid.TabIndex = 0;
            this.contractsGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.contractsGrid_KeyDown);
            // 
            // ContractIDColumn
            // 
            this.ContractIDColumn.HeaderText = "ID";
            this.ContractIDColumn.Name = "ContractIDColumn";
            this.ContractIDColumn.ReadOnly = true;
            this.ContractIDColumn.Visible = false;
            // 
            // IssueDateColumn
            // 
            this.IssueDateColumn.HeaderText = "Issue Date";
            this.IssueDateColumn.Name = "IssueDateColumn";
            this.IssueDateColumn.ReadOnly = true;
            // 
            // OwnerColumn
            // 
            this.OwnerColumn.HeaderText = "Owner";
            this.OwnerColumn.Name = "OwnerColumn";
            this.OwnerColumn.ReadOnly = true;
            this.OwnerColumn.Width = 120;
            // 
            // PickupStationColumn
            // 
            this.PickupStationColumn.HeaderText = "Pickup Station";
            this.PickupStationColumn.Name = "PickupStationColumn";
            this.PickupStationColumn.ReadOnly = true;
            this.PickupStationColumn.Width = 180;
            // 
            // DestinationStationColumn
            // 
            this.DestinationStationColumn.HeaderText = "Destination Station";
            this.DestinationStationColumn.Name = "DestinationStationColumn";
            this.DestinationStationColumn.ReadOnly = true;
            this.DestinationStationColumn.Width = 180;
            // 
            // StatusColumn
            // 
            this.StatusColumn.HeaderText = "Status";
            this.StatusColumn.Name = "StatusColumn";
            this.StatusColumn.ReadOnly = true;
            // 
            // CollateralColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CollateralColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.CollateralColumn.HeaderText = "Collateral";
            this.CollateralColumn.Name = "CollateralColumn";
            this.CollateralColumn.ReadOnly = true;
            this.CollateralColumn.Width = 120;
            // 
            // RewardColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.RewardColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.RewardColumn.HeaderText = "Reward";
            this.RewardColumn.Name = "RewardColumn";
            this.RewardColumn.ReadOnly = true;
            this.RewardColumn.Width = 105;
            // 
            // ExpectedProfitColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ExpectedProfitColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.ExpectedProfitColumn.HeaderText = "Expected Profit";
            this.ExpectedProfitColumn.Name = "ExpectedProfitColumn";
            this.ExpectedProfitColumn.ReadOnly = true;
            this.ExpectedProfitColumn.Width = 120;
            // 
            // CompletedColumn
            // 
            this.CompletedColumn.HeaderText = "Set Completed";
            this.CompletedColumn.Name = "CompletedColumn";
            this.CompletedColumn.ReadOnly = true;
            this.CompletedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CompletedColumn.ToolTipText = "Set contract status to completed";
            this.CompletedColumn.Width = 84;
            // 
            // FailedColumn
            // 
            this.FailedColumn.HeaderText = "Set Failed";
            this.FailedColumn.Name = "FailedColumn";
            this.FailedColumn.ReadOnly = true;
            this.FailedColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FailedColumn.ToolTipText = "Set contract status to failed";
            this.FailedColumn.Width = 62;
            // 
            // ExpiredColumn
            // 
            this.ExpiredColumn.HeaderText = "Set Expired";
            this.ExpiredColumn.Name = "ExpiredColumn";
            this.ExpiredColumn.ReadOnly = true;
            this.ExpiredColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ExpiredColumn.ToolTipText = "Set contract status to expired";
            this.ExpiredColumn.Width = 68;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.contractsGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.grpFilters, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1057, 466);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // grpFilters
            // 
            this.grpFilters.Controls.Add(this.label5);
            this.grpFilters.Controls.Add(this.cmbType);
            this.grpFilters.Controls.Add(this.chkIngoreOwner);
            this.grpFilters.Controls.Add(this.cmbOwner);
            this.grpFilters.Controls.Add(this.label4);
            this.grpFilters.Controls.Add(this.cmbStatus);
            this.grpFilters.Controls.Add(this.lblStatus);
            this.grpFilters.Controls.Add(this.lblDestStation);
            this.grpFilters.Controls.Add(this.lblPickupStation);
            this.grpFilters.Controls.Add(this.cmbDestination);
            this.grpFilters.Controls.Add(this.cmbPickup);
            this.grpFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpFilters.Location = new System.Drawing.Point(3, 3);
            this.grpFilters.Name = "grpFilters";
            this.grpFilters.Size = new System.Drawing.Size(1051, 104);
            this.grpFilters.TabIndex = 1;
            this.grpFilters.TabStop = false;
            this.grpFilters.Text = "Filters";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Type";
            // 
            // cmbType
            // 
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(112, 19);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(307, 21);
            this.cmbType.TabIndex = 20;
            // 
            // chkIngoreOwner
            // 
            this.chkIngoreOwner.AutoSize = true;
            this.chkIngoreOwner.Location = new System.Drawing.Point(791, 49);
            this.chkIngoreOwner.Name = "chkIngoreOwner";
            this.chkIngoreOwner.Size = new System.Drawing.Size(78, 17);
            this.chkIngoreOwner.TabIndex = 19;
            this.chkIngoreOwner.Text = "Any Owner";
            this.chkIngoreOwner.UseVisualStyleBackColor = true;
            // 
            // cmbOwner
            // 
            this.cmbOwner.FormattingEnabled = true;
            this.cmbOwner.Location = new System.Drawing.Point(527, 46);
            this.cmbOwner.Name = "cmbOwner";
            this.cmbOwner.Size = new System.Drawing.Size(251, 21);
            this.cmbOwner.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(454, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Owner";
            // 
            // cmbStatus
            // 
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(527, 73);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(251, 21);
            this.cmbStatus.TabIndex = 5;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(454, 76);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status";
            // 
            // lblDestStation
            // 
            this.lblDestStation.AutoSize = true;
            this.lblDestStation.Location = new System.Drawing.Point(9, 76);
            this.lblDestStation.Name = "lblDestStation";
            this.lblDestStation.Size = new System.Drawing.Size(96, 13);
            this.lblDestStation.TabIndex = 3;
            this.lblDestStation.Text = "Destination Station";
            // 
            // lblPickupStation
            // 
            this.lblPickupStation.AutoSize = true;
            this.lblPickupStation.Location = new System.Drawing.Point(9, 49);
            this.lblPickupStation.Name = "lblPickupStation";
            this.lblPickupStation.Size = new System.Drawing.Size(76, 13);
            this.lblPickupStation.TabIndex = 2;
            this.lblPickupStation.Text = "Pickup Station";
            // 
            // cmbDestination
            // 
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(112, 73);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(307, 21);
            this.cmbDestination.TabIndex = 1;
            // 
            // cmbPickup
            // 
            this.cmbPickup.FormattingEnabled = true;
            this.cmbPickup.Location = new System.Drawing.Point(112, 46);
            this.cmbPickup.Name = "cmbPickup";
            this.cmbPickup.Size = new System.Drawing.Size(307, 21);
            this.cmbPickup.TabIndex = 0;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "Set Completed";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.ToolTipText = "Set contract status to completed";
            this.dataGridViewImageColumn1.Width = 84;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "Set Failed";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.ToolTipText = "Set contract status to failed";
            this.dataGridViewImageColumn2.Width = 62;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "Set Expired";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.ToolTipText = "Set contract status to expired";
            this.dataGridViewImageColumn3.Width = 68;
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "cross.gif");
            this.icons.Images.SetKeyName(1, "expired.gif");
            this.icons.Images.SetKeyName(2, "tick.gif");
            // 
            // ViewContracts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 466);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ViewContracts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Contracts";
            this.Load += new System.EventHandler(this.Contracts_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.contractsGrid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpFilters.ResumeLayout(false);
            this.grpFilters.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCourierSettings;
        private System.Windows.Forms.Button btnNewContract;
        private System.Windows.Forms.Button btnAutoContractor;
        private EveMarketMonitorApp.Common.MultisortDataGridView contractsGrid;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpFilters;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblDestStation;
        private System.Windows.Forms.Label lblPickupStation;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.ComboBox cmbPickup;
        private System.Windows.Forms.CheckBox chkIngoreOwner;
        private System.Windows.Forms.ComboBox cmbOwner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.ImageList icons;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContractIDColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn IssueDateColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn OwnerColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PickupStationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestinationStationColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CollateralColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn RewardColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpectedProfitColumn;
        private System.Windows.Forms.DataGridViewImageColumn CompletedColumn;
        private System.Windows.Forms.DataGridViewImageColumn FailedColumn;
        private System.Windows.Forms.DataGridViewImageColumn ExpiredColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbType;
    }
}