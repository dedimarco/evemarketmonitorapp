namespace EveMarketMonitorApp.GUIElements
{
    partial class TutorialIndex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorialIndex));
            this.tutorialTreeView = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tutorialTreeView
            // 
            this.tutorialTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tutorialTreeView.HideSelection = false;
            this.tutorialTreeView.Location = new System.Drawing.Point(0, 0);
            this.tutorialTreeView.Name = "tutorialTreeView";
            this.tutorialTreeView.Size = new System.Drawing.Size(278, 330);
            this.tutorialTreeView.TabIndex = 0;
            this.tutorialTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tutorialTreeView_NodeMouseDoubleClick);
            this.tutorialTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tutorialTreeView_AfterSelect);
            // 
            // TutorialIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 330);
            this.Controls.Add(this.tutorialTreeView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TutorialIndex";
            this.Text = "Tutorial Index";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.TutorialIndex_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tutorialTreeView;
    }
}