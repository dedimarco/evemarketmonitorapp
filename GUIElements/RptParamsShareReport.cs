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
    /// <summary>
    /// Note: To edit this form in the designer, replace ": RptParamsBase" with ": Form".
    /// Make sure to change it back once you've completed and saved your changes though!
    /// </summary>
    public partial class RptParamsShareReport : RptParamsBase
    {
        public RptParamsShareReport()
        {
            InitializeComponent();
            this.Text = "Public Corps Report Params";
        }

        private void RptParamsShareReport_Load(object sender, EventArgs e)
        {
            string[] columns = SharesReport.GetPossibleColumns();
            chkColumns.Items.AddRange(columns);
            for (int i = 0; i < chkColumns.Items.Count; i++)
            {
                chkColumns.SetItemChecked(i, true);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_parameters == null)
            {
                _parameters = new Dictionary<string, object>();
            }

            string[] columnNames = SharesReport.GetPossibleColumns();
            bool[] colsVisible = new bool[columnNames.Length];
            for (int i = 0; i < columnNames.Length; i++)
            {
                colsVisible[i] = chkColumns.CheckedItems.Contains(columnNames[i]);
            }
            _parameters.Add("ColumnsVisible", colsVisible);
            _parameters.Add("ReportGroupID", UserAccount.CurrentGroup.ID);

            _report = new SharesReport();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}