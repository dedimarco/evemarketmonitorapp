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
    public partial class MaintDividend : Form
    {
        Dividend _dividend = null;
        PublicCorp _startCorp = null;

        public MaintDividend()
        {
            InitializeComponent();
            _dividend = new Dividend(0);
        }

        public MaintDividend(PublicCorp corp)
        {
            InitializeComponent();
            _startCorp = corp;
            _dividend = new Dividend((corp == null ? 0 : corp.ID));
        }

        public MaintDividend(Dividend dividend)
        {
            InitializeComponent();
            _dividend = dividend;
            cmbCorp.Enabled = false;
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
            if (_dividend.CorpID == 0)
            {
                _dividend.CorpID = (int)cmbCorp.SelectedValue;
            }

            if (!cmbCorp.Enabled)
            {
                cmbCorp.SelectedValue = _dividend.CorpID;
                dtpDate.Value = _dividend.Date;
                txtPayout.Text = new IskAmount(_dividend.PayoutPerShare).ToString();
            }
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
                _dividend.Date = dtpDate.Value;
                _dividend.CorpID = (int)cmbCorp.SelectedValue;
                Dividends.StoreDividend(_dividend);
            }
            catch (Exception ex)
            {
                EMMAException emmaEx = ex as EMMAException;
                if (emmaEx == null)
                {
                    emmaEx = new EMMAException(ExceptionSeverity.Error, "Problem storing dividend data", ex);
                }
                MessageBox.Show("Error storing dividend data: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error); 
                retVal = false;
            }

            return retVal;
        }

        private void txtPayout_Enter(object sender, EventArgs e)
        {
            txtPayout.Text = _dividend.PayoutPerShare.ToString();
        }

        private void txtPayout_Leave(object sender, EventArgs e)
        {
            try
            {
                _dividend.PayoutPerShare = decimal.Parse(txtPayout.Text);
            }
            catch
            {
                _dividend.PayoutPerShare = 0;
            }
            txtPayout.Text = new IskAmount(_dividend.PayoutPerShare).ToString();
       }


    }
}