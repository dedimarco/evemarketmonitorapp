using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.Reporting;
using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class MaintShareValueHistory : Form
    {
        private PublicCorp _startCorp = null;

        public MaintShareValueHistory()
        {
            InitializeComponent();
            txtValue.Tag = 0.0m;
            dtpDate.Value = DateTime.Now;
        }

        public MaintShareValueHistory(PublicCorp corp)
        {
            InitializeComponent();
            _startCorp = corp;
            txtValue.Tag = 0.0m;
            dtpDate.Value = DateTime.Now;
        }

        public MaintShareValueHistory(EMMADataSet.ShareValueHistoryRow historicValue)
        {
            InitializeComponent();
            txtValue.Tag = historicValue.ShareValue;
            dtpDate.Value = historicValue.DateTime;
            if (UserAccount.Settings.UseLocalTimezone)
            {
                dtpDate.Value = dtpDate.Value.AddHours(Globals.HoursOffset);
            }
            _startCorp = PublicCorps.GetCorp(historicValue.PublicCorpID);
            cmbCorp.Enabled = false;
            dtpDate.Enabled = false;
        }

        private void NewDividend_Load(object sender, EventArgs e)
        {
            PublicCorpsList corpData = PublicCorps.GetAll(false);
            corpData.Sort("Name ASC");
            cmbCorp.DisplayMember = "Name";
            cmbCorp.ValueMember = "ID";
            cmbCorp.DataSource = corpData;

            if (_startCorp != null)
            {
                cmbCorp.SelectedValue = _startCorp.ID;
            }
            else 
            {
                cmbCorp.SelectedIndex = 0;
            }

            txtValue.Text = new IskAmount((decimal)txtValue.Tag).ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Store())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool Store()
        {
            bool retVal = true ;

            try
            {
                ShareValueHistory.SetShareValue((int)cmbCorp.SelectedValue, dtpDate.Value.ToUniversalTime(), (decimal)txtValue.Tag);
            }
            catch (Exception ex)
            {
                EMMAException emmaEx = ex as EMMAException;
                if (emmaEx == null)
                {
                    emmaEx = new EMMAException(ExceptionSeverity.Error, "Problem storing share value history data", ex);
                }
                MessageBox.Show("Error storing share value history data: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                retVal = false;
            }

            return retVal;
        }

        private void txtValue_Enter(object sender, EventArgs e)
        {
            txtValue.Text = txtValue.Tag.ToString();
        }

        private void txtValue_Leave(object sender, EventArgs e)
        {
            try
            {
                txtValue.Tag = decimal.Parse(txtValue.Text);
            }
            catch
            {
                txtValue.Tag = 0.0m;
            }
            txtValue.Text = new IskAmount((decimal)txtValue.Tag).ToString();
       }


    }
}