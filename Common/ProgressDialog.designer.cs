namespace EveMarketMonitorApp.Common
{
    partial class ProgressDialog
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
            this.prgProgress = new System.Windows.Forms.ProgressBar();
            this.lstStatusHistory = new System.Windows.Forms.ListBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblSection = new System.Windows.Forms.TextBox();
            this.lblSectionStatus = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // prgProgress
            // 
            this.prgProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.prgProgress.Location = new System.Drawing.Point(12, 90);
            this.prgProgress.Name = "prgProgress";
            this.prgProgress.Size = new System.Drawing.Size(466, 23);
            this.prgProgress.TabIndex = 2;
            // 
            // lstStatusHistory
            // 
            this.lstStatusHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstStatusHistory.FormattingEnabled = true;
            this.lstStatusHistory.Location = new System.Drawing.Point(12, 119);
            this.lstStatusHistory.Name = "lstStatusHistory";
            this.lstStatusHistory.Size = new System.Drawing.Size(466, 160);
            this.lstStatusHistory.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOk.Location = new System.Drawing.Point(201, 287);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(88, 29);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Visible = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblSection
            // 
            this.lblSection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSection.BackColor = System.Drawing.SystemColors.Control;
            this.lblSection.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblSection.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSection.Location = new System.Drawing.Point(12, 12);
            this.lblSection.Name = "lblSection";
            this.lblSection.ReadOnly = true;
            this.lblSection.Size = new System.Drawing.Size(466, 13);
            this.lblSection.TabIndex = 3;
            this.lblSection.Text = "Section";
            this.lblSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSectionStatus
            // 
            this.lblSectionStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSectionStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lblSectionStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lblSectionStatus.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblSectionStatus.Location = new System.Drawing.Point(12, 38);
            this.lblSectionStatus.Multiline = true;
            this.lblSectionStatus.Name = "lblSectionStatus";
            this.lblSectionStatus.ReadOnly = true;
            this.lblSectionStatus.Size = new System.Drawing.Size(466, 46);
            this.lblSectionStatus.TabIndex = 4;
            this.lblSectionStatus.Text = "Section Status";
            this.lblSectionStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            // 
            // ProgressDialog
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 327);
            this.Controls.Add(this.lblSectionStatus);
            this.Controls.Add(this.lblSection);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lstStatusHistory);
            this.Controls.Add(this.prgProgress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ProgressDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ProgressDialog";
            this.Load += new System.EventHandler(this.ProgressDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar prgProgress;
        private System.Windows.Forms.ListBox lstStatusHistory;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox lblSection;
        private System.Windows.Forms.TextBox lblSectionStatus;
        private System.Windows.Forms.Timer timer1;
    }
}