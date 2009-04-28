namespace EveMarketMonitorApp.GUIElements
{
    partial class CourierCalc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CourierCalc));
            this.cmbPickup = new System.Windows.Forms.ComboBox();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.lblPickup = new System.Windows.Forms.Label();
            this.lblDropoff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCollateral = new System.Windows.Forms.Label();
            this.lblJumps = new System.Windows.Forms.Label();
            this.txtReward = new System.Windows.Forms.TextBox();
            this.txtJumps = new System.Windows.Forms.TextBox();
            this.txtCollateral = new System.Windows.Forms.TextBox();
            this.lblReward = new System.Windows.Forms.Label();
            this.chkLowSec = new System.Windows.Forms.CheckBox();
            this.lblLowSec = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCreateContract = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.lblGrossProfit = new System.Windows.Forms.Label();
            this.lblProfit = new System.Windows.Forms.Label();
            this.lblProfitPerc = new System.Windows.Forms.Label();
            this.btnExclude = new System.Windows.Forms.Button();
            this.contractItemsGrid = new System.Windows.Forms.DataGridView();
            this.ItemColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuyPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SellPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VolPercentageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProfitPercentageColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblVolume = new System.Windows.Forms.Label();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.btnApplyPrice = new System.Windows.Forms.Button();
            this.lblSellPrice = new System.Windows.Forms.Label();
            this.lblBuyPrice = new System.Windows.Forms.Label();
            this.txtSellPrice = new System.Windows.Forms.TextBox();
            this.txtBuyPrice = new System.Windows.Forms.TextBox();
            this.cmbBuySell = new System.Windows.Forms.ComboBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.chkAutoCalcItemPrice = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.contractItemsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPickup
            // 
            this.cmbPickup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPickup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbPickup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbPickup.FormattingEnabled = true;
            this.cmbPickup.Location = new System.Drawing.Point(82, 12);
            this.cmbPickup.Name = "cmbPickup";
            this.cmbPickup.Size = new System.Drawing.Size(610, 21);
            this.cmbPickup.TabIndex = 0;
            // 
            // cmbDestination
            // 
            this.cmbDestination.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbDestination.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDestination.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Location = new System.Drawing.Point(82, 39);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(610, 21);
            this.cmbDestination.TabIndex = 1;
            // 
            // lblPickup
            // 
            this.lblPickup.AutoSize = true;
            this.lblPickup.Location = new System.Drawing.Point(12, 15);
            this.lblPickup.Name = "lblPickup";
            this.lblPickup.Size = new System.Drawing.Size(43, 13);
            this.lblPickup.TabIndex = 2;
            this.lblPickup.Text = "Pickup:";
            // 
            // lblDropoff
            // 
            this.lblDropoff.AutoSize = true;
            this.lblDropoff.Location = new System.Drawing.Point(12, 42);
            this.lblDropoff.Name = "lblDropoff";
            this.lblDropoff.Size = new System.Drawing.Size(48, 13);
            this.lblDropoff.TabIndex = 3;
            this.lblDropoff.Text = "Drop off:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Item:";
            // 
            // lblCollateral
            // 
            this.lblCollateral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCollateral.AutoSize = true;
            this.lblCollateral.Location = new System.Drawing.Point(12, 531);
            this.lblCollateral.Name = "lblCollateral";
            this.lblCollateral.Size = new System.Drawing.Size(53, 13);
            this.lblCollateral.TabIndex = 7;
            this.lblCollateral.Text = "Collateral:";
            // 
            // lblJumps
            // 
            this.lblJumps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblJumps.AutoSize = true;
            this.lblJumps.Location = new System.Drawing.Point(12, 430);
            this.lblJumps.Name = "lblJumps";
            this.lblJumps.Size = new System.Drawing.Size(40, 13);
            this.lblJumps.TabIndex = 8;
            this.lblJumps.Text = "Jumps:";
            // 
            // txtReward
            // 
            this.txtReward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReward.Location = new System.Drawing.Point(82, 502);
            this.txtReward.Name = "txtReward";
            this.txtReward.Size = new System.Drawing.Size(171, 20);
            this.txtReward.TabIndex = 15;
            this.txtReward.Leave += new System.EventHandler(this.txtReward_Leave);
            this.txtReward.Enter += new System.EventHandler(this.txtReward_Enter);
            // 
            // txtJumps
            // 
            this.txtJumps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtJumps.Location = new System.Drawing.Point(82, 427);
            this.txtJumps.Name = "txtJumps";
            this.txtJumps.Size = new System.Drawing.Size(100, 20);
            this.txtJumps.TabIndex = 12;
            // 
            // txtCollateral
            // 
            this.txtCollateral.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCollateral.Location = new System.Drawing.Point(82, 528);
            this.txtCollateral.Name = "txtCollateral";
            this.txtCollateral.Size = new System.Drawing.Size(171, 20);
            this.txtCollateral.TabIndex = 16;
            this.txtCollateral.Leave += new System.EventHandler(this.txtCollateral_Leave);
            this.txtCollateral.Enter += new System.EventHandler(this.txtCollateral_Enter);
            // 
            // lblReward
            // 
            this.lblReward.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblReward.AutoSize = true;
            this.lblReward.Location = new System.Drawing.Point(12, 505);
            this.lblReward.Name = "lblReward";
            this.lblReward.Size = new System.Drawing.Size(47, 13);
            this.lblReward.TabIndex = 13;
            this.lblReward.Text = "Reward:";
            // 
            // chkLowSec
            // 
            this.chkLowSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLowSec.AutoSize = true;
            this.chkLowSec.Location = new System.Drawing.Point(82, 453);
            this.chkLowSec.Name = "chkLowSec";
            this.chkLowSec.Size = new System.Drawing.Size(15, 14);
            this.chkLowSec.TabIndex = 13;
            this.chkLowSec.UseVisualStyleBackColor = true;
            // 
            // lblLowSec
            // 
            this.lblLowSec.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLowSec.AutoSize = true;
            this.lblLowSec.Location = new System.Drawing.Point(12, 456);
            this.lblLowSec.Name = "lblLowSec";
            this.lblLowSec.Size = new System.Drawing.Size(50, 13);
            this.lblLowSec.TabIndex = 16;
            this.lblLowSec.Text = "Low-sec:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(603, 513);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 36);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtQuantity
            // 
            this.txtQuantity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuantity.Location = new System.Drawing.Point(604, 88);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(88, 20);
            this.txtQuantity.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(601, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "Quantity:";
            // 
            // btnAddItem
            // 
            this.btnAddItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddItem.Location = new System.Drawing.Point(636, 114);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(56, 20);
            this.btnAddItem.TabIndex = 8;
            this.btnAddItem.Text = "Add";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(650, 401);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(42, 20);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCreateContract
            // 
            this.btnCreateContract.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateContract.Location = new System.Drawing.Point(510, 513);
            this.btnCreateContract.Name = "btnCreateContract";
            this.btnCreateContract.Size = new System.Drawing.Size(88, 36);
            this.btnCreateContract.TabIndex = 17;
            this.btnCreateContract.Text = "Create";
            this.btnCreateContract.UseVisualStyleBackColor = true;
            this.btnCreateContract.Click += new System.EventHandler(this.btnCreateContract_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAuto.Location = new System.Drawing.Point(603, 401);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(41, 20);
            this.btnAuto.TabIndex = 29;
            this.btnAuto.Text = "Auto";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // lblGrossProfit
            // 
            this.lblGrossProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGrossProfit.AutoSize = true;
            this.lblGrossProfit.Location = new System.Drawing.Point(12, 479);
            this.lblGrossProfit.Name = "lblGrossProfit";
            this.lblGrossProfit.Size = new System.Drawing.Size(63, 13);
            this.lblGrossProfit.TabIndex = 32;
            this.lblGrossProfit.Text = "Gross profit:";
            // 
            // lblProfit
            // 
            this.lblProfit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProfit.AutoSize = true;
            this.lblProfit.Location = new System.Drawing.Point(79, 479);
            this.lblProfit.Name = "lblProfit";
            this.lblProfit.Size = new System.Drawing.Size(41, 13);
            this.lblProfit.TabIndex = 14;
            this.lblProfit.Text = "lblProfit";
            // 
            // lblProfitPerc
            // 
            this.lblProfitPerc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblProfitPerc.AutoSize = true;
            this.lblProfitPerc.Location = new System.Drawing.Point(259, 505);
            this.lblProfitPerc.Name = "lblProfitPerc";
            this.lblProfitPerc.Size = new System.Drawing.Size(63, 13);
            this.lblProfitPerc.TabIndex = 34;
            this.lblProfitPerc.Text = "lblProfitPerc";
            // 
            // btnExclude
            // 
            this.btnExclude.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExclude.Enabled = false;
            this.btnExclude.Location = new System.Drawing.Point(474, 401);
            this.btnExclude.Name = "btnExclude";
            this.btnExclude.Size = new System.Drawing.Size(123, 20);
            this.btnExclude.TabIndex = 35;
            this.btnExclude.Text = "Permenantly Exclude";
            this.btnExclude.UseVisualStyleBackColor = true;
            this.btnExclude.Click += new System.EventHandler(this.cmdExclude_Click);
            // 
            // contractItemsGrid
            // 
            this.contractItemsGrid.AllowUserToAddRows = false;
            this.contractItemsGrid.AllowUserToDeleteRows = false;
            this.contractItemsGrid.AllowUserToResizeRows = false;
            this.contractItemsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.contractItemsGrid.BackgroundColor = System.Drawing.Color.White;
            this.contractItemsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.contractItemsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.contractItemsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.contractItemsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.contractItemsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ItemColumn,
            this.QuantityColumn,
            this.BuyPriceColumn,
            this.SellPriceColumn,
            this.VolPercentageColumn,
            this.ProfitPercentageColumn});
            this.contractItemsGrid.EnableHeadersVisualStyles = false;
            this.contractItemsGrid.GridColor = System.Drawing.Color.DarkGray;
            this.contractItemsGrid.Location = new System.Drawing.Point(15, 166);
            this.contractItemsGrid.Name = "contractItemsGrid";
            this.contractItemsGrid.ReadOnly = true;
            this.contractItemsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.contractItemsGrid.RowHeadersVisible = false;
            this.contractItemsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.contractItemsGrid.RowTemplate.Height = 16;
            this.contractItemsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.contractItemsGrid.Size = new System.Drawing.Size(677, 229);
            this.contractItemsGrid.TabIndex = 6;
            // 
            // ItemColumn
            // 
            this.ItemColumn.HeaderText = "Item";
            this.ItemColumn.Name = "ItemColumn";
            this.ItemColumn.ReadOnly = true;
            this.ItemColumn.Width = 180;
            // 
            // QuantityColumn
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.QuantityColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.QuantityColumn.HeaderText = "Quantity";
            this.QuantityColumn.Name = "QuantityColumn";
            this.QuantityColumn.ReadOnly = true;
            this.QuantityColumn.Width = 60;
            // 
            // BuyPriceColumn
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.BuyPriceColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.BuyPriceColumn.HeaderText = "Buy Price";
            this.BuyPriceColumn.Name = "BuyPriceColumn";
            this.BuyPriceColumn.ReadOnly = true;
            this.BuyPriceColumn.Width = 140;
            // 
            // SellPriceColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.SellPriceColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.SellPriceColumn.HeaderText = "Sell Price";
            this.SellPriceColumn.Name = "SellPriceColumn";
            this.SellPriceColumn.ReadOnly = true;
            this.SellPriceColumn.Width = 140;
            // 
            // VolPercentageColumn
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.VolPercentageColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.VolPercentageColumn.HeaderText = "Vol %";
            this.VolPercentageColumn.Name = "VolPercentageColumn";
            this.VolPercentageColumn.ReadOnly = true;
            this.VolPercentageColumn.Width = 68;
            // 
            // ProfitPercentageColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ProfitPercentageColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.ProfitPercentageColumn.HeaderText = "Profit %";
            this.ProfitPercentageColumn.Name = "ProfitPercentageColumn";
            this.ProfitPercentageColumn.ReadOnly = true;
            this.ProfitPercentageColumn.Width = 68;
            // 
            // lblVolume
            // 
            this.lblVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVolume.AutoSize = true;
            this.lblVolume.Location = new System.Drawing.Point(12, 404);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(45, 13);
            this.lblVolume.TabIndex = 44;
            this.lblVolume.Text = "Volume:";
            // 
            // txtVolume
            // 
            this.txtVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtVolume.Location = new System.Drawing.Point(82, 401);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(171, 20);
            this.txtVolume.TabIndex = 10;
            // 
            // btnApplyPrice
            // 
            this.btnApplyPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApplyPrice.Location = new System.Drawing.Point(636, 140);
            this.btnApplyPrice.Name = "btnApplyPrice";
            this.btnApplyPrice.Size = new System.Drawing.Size(56, 20);
            this.btnApplyPrice.TabIndex = 9;
            this.btnApplyPrice.Text = "Apply";
            this.btnApplyPrice.UseVisualStyleBackColor = true;
            this.btnApplyPrice.Click += new System.EventHandler(this.btnApplyPrice_Click);
            // 
            // lblSellPrice
            // 
            this.lblSellPrice.AutoSize = true;
            this.lblSellPrice.Location = new System.Drawing.Point(12, 143);
            this.lblSellPrice.Name = "lblSellPrice";
            this.lblSellPrice.Size = new System.Drawing.Size(54, 13);
            this.lblSellPrice.TabIndex = 43;
            this.lblSellPrice.Text = "Sell Price:";
            // 
            // lblBuyPrice
            // 
            this.lblBuyPrice.AutoSize = true;
            this.lblBuyPrice.Location = new System.Drawing.Point(12, 117);
            this.lblBuyPrice.Name = "lblBuyPrice";
            this.lblBuyPrice.Size = new System.Drawing.Size(54, 13);
            this.lblBuyPrice.TabIndex = 42;
            this.lblBuyPrice.Text = "Buy price:";
            // 
            // txtSellPrice
            // 
            this.txtSellPrice.Location = new System.Drawing.Point(82, 140);
            this.txtSellPrice.Name = "txtSellPrice";
            this.txtSellPrice.Size = new System.Drawing.Size(171, 20);
            this.txtSellPrice.TabIndex = 6;
            // 
            // txtBuyPrice
            // 
            this.txtBuyPrice.Location = new System.Drawing.Point(82, 114);
            this.txtBuyPrice.Name = "txtBuyPrice";
            this.txtBuyPrice.Size = new System.Drawing.Size(171, 20);
            this.txtBuyPrice.TabIndex = 5;
            // 
            // cmbBuySell
            // 
            this.cmbBuySell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbBuySell.FormattingEnabled = true;
            this.cmbBuySell.Items.AddRange(new object[] {
            "Buying",
            "Selling"});
            this.cmbBuySell.Location = new System.Drawing.Point(168, 401);
            this.cmbBuySell.Name = "cmbBuySell";
            this.cmbBuySell.Size = new System.Drawing.Size(171, 21);
            this.cmbBuySell.TabIndex = 11;
            this.cmbBuySell.SelectedIndexChanged += new System.EventHandler(this.cmbBuySell_SelectedIndexChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy HH:mm:ss";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(82, 40);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(171, 20);
            this.dtpDate.TabIndex = 2;
            // 
            // txtItem
            // 
            this.txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItem.Location = new System.Drawing.Point(12, 88);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(586, 20);
            this.txtItem.TabIndex = 3;
            // 
            // chkAutoCalcItemPrice
            // 
            this.chkAutoCalcItemPrice.AutoSize = true;
            this.chkAutoCalcItemPrice.Location = new System.Drawing.Point(320, 142);
            this.chkAutoCalcItemPrice.Name = "chkAutoCalcItemPrice";
            this.chkAutoCalcItemPrice.Size = new System.Drawing.Size(278, 17);
            this.chkAutoCalcItemPrice.TabIndex = 7;
            this.chkAutoCalcItemPrice.Text = "Calc item price from est. item value and contract price";
            this.chkAutoCalcItemPrice.UseVisualStyleBackColor = true;
            this.chkAutoCalcItemPrice.CheckedChanged += new System.EventHandler(this.chkAutoCalcItemPrice_CheckedChanged);
            // 
            // CourierCalc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 561);
            this.Controls.Add(this.chkAutoCalcItemPrice);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.cmbBuySell);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.btnApplyPrice);
            this.Controls.Add(this.lblSellPrice);
            this.Controls.Add(this.lblBuyPrice);
            this.Controls.Add(this.txtSellPrice);
            this.Controls.Add(this.txtBuyPrice);
            this.Controls.Add(this.contractItemsGrid);
            this.Controls.Add(this.btnExclude);
            this.Controls.Add(this.lblProfitPerc);
            this.Controls.Add(this.lblProfit);
            this.Controls.Add(this.lblGrossProfit);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnCreateContract);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblLowSec);
            this.Controls.Add(this.chkLowSec);
            this.Controls.Add(this.lblReward);
            this.Controls.Add(this.txtCollateral);
            this.Controls.Add(this.txtJumps);
            this.Controls.Add(this.txtReward);
            this.Controls.Add(this.lblJumps);
            this.Controls.Add(this.lblCollateral);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblDropoff);
            this.Controls.Add(this.lblPickup);
            this.Controls.Add(this.cmbDestination);
            this.Controls.Add(this.cmbPickup);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CourierCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Courier Calculator";
            this.Load += new System.EventHandler(this.CourierCalc_Load);
            ((System.ComponentModel.ISupportInitialize)(this.contractItemsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPickup;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label lblPickup;
        private System.Windows.Forms.Label lblDropoff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCollateral;
        private System.Windows.Forms.Label lblJumps;
        private System.Windows.Forms.TextBox txtReward;
        private System.Windows.Forms.TextBox txtJumps;
        private System.Windows.Forms.TextBox txtCollateral;
        private System.Windows.Forms.Label lblReward;
        private System.Windows.Forms.CheckBox chkLowSec;
        private System.Windows.Forms.Label lblLowSec;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCreateContract;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Label lblGrossProfit;
        private System.Windows.Forms.Label lblProfit;
        private System.Windows.Forms.Label lblProfitPerc;
        private System.Windows.Forms.Button btnExclude;
        private System.Windows.Forms.DataGridView contractItemsGrid;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.TextBox txtVolume;
        private System.Windows.Forms.Button btnApplyPrice;
        private System.Windows.Forms.Label lblSellPrice;
        private System.Windows.Forms.Label lblBuyPrice;
        private System.Windows.Forms.TextBox txtSellPrice;
        private System.Windows.Forms.TextBox txtBuyPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuyPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SellPriceColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn VolPercentageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProfitPercentageColumn;
        private System.Windows.Forms.ComboBox cmbBuySell;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.CheckBox chkAutoCalcItemPrice;
    }
}