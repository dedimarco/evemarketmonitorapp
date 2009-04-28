using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.Reporting;
using EveMarketMonitorApp.DatabaseClasses;

namespace EveMarketMonitorApp.GUIElements
{
    public abstract class RptParamsBase : Form
    {
        protected Dictionary<string, object> _parameters;
        protected IReport _report;
        protected bool _needFinanceParams;
        protected bool _needAssetParams;
        protected List<FinanceAccessParams> _financeAccessParams;
        protected List<AssetAccessParams> _assetAccessParams;

        public RptParamsBase()
        {
            InitializeComponent();
        }

        public Dictionary<string, object> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public IReport Report
        {
            get { return _report; }
        }

        public bool NeedFinanceParams
        {
            get { return _needFinanceParams; }
        }

        public bool NeedAssetParams
        {
            get { return _needAssetParams; }
        }

        public List<FinanceAccessParams> FinanceParams
        {
            get { return _financeAccessParams; }
            set { _financeAccessParams = value; }
        }

        public List<AssetAccessParams> AssetParams
        {
            get { return _assetAccessParams; }
            set { _assetAccessParams = value; }
        }

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RptParamsBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 231);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "RptParamsBase";
            this.Text = "Report Parameters Form";
            this.ResumeLayout(false);

        }


    }
}