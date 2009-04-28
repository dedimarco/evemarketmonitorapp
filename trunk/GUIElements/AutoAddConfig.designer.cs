namespace EveMarketMonitorApp.GUIElements
{
    partial class AutoAddConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoAddConfig));
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lblpart1 = new System.Windows.Forms.Label();
            this.txtMinRequired = new System.Windows.Forms.TextBox();
            this.lblPart2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAddBasedOn = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(156, 145);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 29);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(250, 145);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 29);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(6, 19);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(314, 32);
            this.textBox3.TabIndex = 7;
            this.textBox3.Text = "Here you can configure how the \'auto add\' button on the \'traded items\' screen wil" +
                "l function.";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblpart1
            // 
            this.lblpart1.AutoSize = true;
            this.lblpart1.Location = new System.Drawing.Point(9, 107);
            this.lblpart1.Name = "lblpart1";
            this.lblpart1.Size = new System.Drawing.Size(138, 13);
            this.lblpart1.TabIndex = 4;
            this.lblpart1.Text = "Only add items with at least ";
            // 
            // txtMinRequired
            // 
            this.txtMinRequired.Location = new System.Drawing.Point(153, 104);
            this.txtMinRequired.Name = "txtMinRequired";
            this.txtMinRequired.Size = new System.Drawing.Size(45, 20);
            this.txtMinRequired.TabIndex = 5;
            this.txtMinRequired.TextChanged += new System.EventHandler(this.txtMinRequired_TextChanged);
            // 
            // lblPart2
            // 
            this.lblPart2.AutoSize = true;
            this.lblPart2.Location = new System.Drawing.Point(204, 107);
            this.lblPart2.Name = "lblPart2";
            this.lblPart2.Size = new System.Drawing.Size(134, 13);
            this.lblPart2.TabIndex = 7;
            this.lblPart2.Text = "buy and x sell transactions.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Add items based upon";
            // 
            // cmbAddBasedOn
            // 
            this.cmbAddBasedOn.FormattingEnabled = true;
            this.cmbAddBasedOn.Items.AddRange(new object[] {
            "Sales",
            "Transactions"});
            this.cmbAddBasedOn.Location = new System.Drawing.Point(127, 77);
            this.cmbAddBasedOn.Name = "cmbAddBasedOn";
            this.cmbAddBasedOn.Size = new System.Drawing.Size(211, 21);
            this.cmbAddBasedOn.TabIndex = 6;
            this.cmbAddBasedOn.SelectedIndexChanged += new System.EventHandler(this.cmbAddBasedOn_SelectedIndexChanged);
            // 
            // AutoAddConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 186);
            this.Controls.Add(this.lblPart2);
            this.Controls.Add(this.cmbAddBasedOn);
            this.Controls.Add(this.txtMinRequired);
            this.Controls.Add(this.lblpart1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoAddConfig";
            this.Text = "Auto Add Config";
            this.Load += new System.EventHandler(this.AutoAddConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lblpart1;
        private System.Windows.Forms.TextBox txtMinRequired;
        private System.Windows.Forms.Label lblPart2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbAddBasedOn;
    }
}