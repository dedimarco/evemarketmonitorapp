using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.Reporting;
using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.AbstractionClasses;

namespace EveMarketMonitorApp.GUIElements
{
    /// <summary>
    /// Note: To edit this form in the designer, replace ": RptParamsBase" with ": Form".
    /// Make sure to change it back once you've completed and saved your changes though!
    /// </summary>
    public partial class RptParamsIncomeStatement : RptParamsBase
    {
        public RptParamsIncomeStatement()
        {
            InitializeComponent();
            _needFinanceParams = true;
        }

        private void IncomeStatementParams_Load(object sender, EventArgs e)
        {
            cmbPeriod.Items.Clear();
            cmbPeriod.Items.AddRange(Enum.GetNames(Type.GetType("EveMarketMonitorApp.Reporting.ReportPeriod")));
            cmbPeriod.SelectedIndex = 0;

            EMMADataSet.JournalRefTypesDataTable refs = JournalRefTypes.GetTypesByJournal(_financeAccessParams);

            chkEntryTypes.DataSource = refs;
            chkEntryTypes.DisplayMember = "RefName";

            for (int i = 0; i < chkEntryTypes.Items.Count; i++)
            {
                //int id = int.Parse((((DataRowView)chkEntryTypes.Items[i])["ID"]).ToString());
                chkEntryTypes.SetItemChecked(i, true);
            }
            
            dtpStartDate.Value = DateTime.Now;
            txtNumColumns.Text = "3";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int totColumns = 3;
            ReportPeriod period = ReportPeriod.Week;
            List<int> excRefTypes = new List<int>();

            try
            {
                totColumns = int.Parse(txtNumColumns.Text, 
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            }
            catch { }

            period = GetSelectedPeriod();

            for (int i = 0; i < chkEntryTypes.Items.Count; i++)
            {
                if (!chkEntryTypes.GetItemChecked(i))
                {
                    int id = int.Parse(((DataRowView)chkEntryTypes.Items[i])["ID"].ToString());
                    excRefTypes.Add(id);
                }
            }

            if (_parameters == null)
            {
                _parameters = new Dictionary<string, object>();
            }

            _parameters.Add("ColumnPeriod", period);
            _parameters.Add("StartDate", dtpStartDate.Value.ToUniversalTime());
            _parameters.Add("TotalColumns", totColumns);
            _parameters.Add("ExcRefTypes", excRefTypes);

            _report = new IncomeStatement();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmbPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportPeriod period = GetSelectedPeriod();

            if (period == ReportPeriod.AllTime)
            {
                dtpStartDate.Enabled = false;
                txtNumColumns.Enabled = false;
            }
            else
            {
                dtpStartDate.Enabled = true;
                txtNumColumns.Enabled = true;
            }
        }

        private ReportPeriod GetSelectedPeriod()
        {
            ReportPeriod period = ReportPeriod.Week;

            try
            {
                period = (ReportPeriod)Enum.Parse(Type.GetType("EveMarketMonitorApp.Reporting.ReportPeriod"),
                    cmbPeriod.Text);
            }
            catch { }

            return period;
        }

                
    }
}

