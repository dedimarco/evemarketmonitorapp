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
    public partial class MaintPublicCorp : Form
    {
        PublicCorp _corpData;
        decimal _oldShareVal;
        bool _displayMessage = true;
        decimal _oldInterestRate = 0.0m;

        /// <summary>
        /// Constructor to use if creating a new public corp.
        /// </summary>
        public MaintPublicCorp()
        {
            InitializeComponent();
            _corpData = new PublicCorp();
            _oldShareVal = decimal.MinValue;
        }

        /// <summary>
        /// Constructor to use if modifying an existing corp.
        /// </summary>
        /// <param name="corpID"></param>
        public MaintPublicCorp(PublicCorp corpData)
        {
            InitializeComponent();
            _corpData = corpData;
            _oldShareVal = _corpData.ShareValue;
        }

        private void MaintPublicCorp_Load(object sender, EventArgs e)
        {
            cmbPayoutPeriod.DataSource = CorpPayoutPeriods.GetAll();
            cmbPayoutPeriod.ValueMember = "ID";
            cmbPayoutPeriod.DisplayMember = "Description";

            cmbRiskRating.DataSource = RiskRatings.GetAll();
            cmbRiskRating.ValueMember = "ID";
            cmbRiskRating.DisplayMember = "Description";

            if(_corpData != null && _corpData.Bank)
            {
                _oldInterestRate = _corpData.ExpectedPayout;
            }

            DisplayData();
        }

        private void DisplayData()
        {
            if (_corpData != null)
            {
                txtName.Text = _corpData.Name;
                txtDescription.Text = _corpData.Description;
                txtTicker.Text = _corpData.Ticker;
                dtpNavDate.Value = _corpData.NAVDate;
                txtCEO.Text = _corpData.CEO;
                _displayMessage = false;
                chkBank.Checked = _corpData.Bank;
                _displayMessage = true;
                SetFieldsEnabled();
                DisplayNAV();
                DisplayPayout();
                DisplayShareVal();
                cmbPayoutPeriod.SelectedValue = (short)_corpData.PayoutPeriod;
                cmbRiskRating.SelectedValue = (short)_corpData.CorpRiskRating;
            }
            else
            {
                cmbPayoutPeriod.SelectedValue = CorpPayoutPeriod.Unspecified;
                cmbRiskRating.SelectedValue = RiskRating.NotRated;
            }
        }

        private void DisplayNAV()
        {
            if (!_corpData.Bank)
            {
                txtNav.Text = new IskAmount(_corpData.NAV).ToString();
            }
        }
        private void DisplayPayout()
        {
            if (_corpData.Bank)
            {
                txtPayout.Text = _corpData.ExpectedPayout.ToString() + " %";
            }
            else
            {
                txtPayout.Text = new IskAmount(_corpData.ExpectedPayout).ToString();
            }
        }
        private void DisplayShareVal()
        {
            if (!_corpData.Bank)
            {
                txtShareValue.Text = new IskAmount(_corpData.ShareValue).ToString();
            }
        }

        private void txtNav_Enter(object sender, EventArgs e)
        {
            txtNav.Text = _corpData.NAV.ToString();
        }

        private void txtNav_Leave(object sender, EventArgs e)
        {
            try
            {
                _corpData.NAV = decimal.Parse(txtNav.Text);
            }
            catch
            {
                _corpData.NAV = 0;
            }
            finally
            {
                DisplayNAV();
            }
        }

        private void txtShareValue_Enter(object sender, EventArgs e)
        {
            txtShareValue.Text = _corpData.ShareValue.ToString();
        }

        private void txtShareValue_Leave(object sender, EventArgs e)
        {
            try
            {
                _corpData.ShareValue = decimal.Parse(txtShareValue.Text);
            }
            catch
            {
                _corpData.ShareValue = 0;
            }
            finally
            {
                DisplayShareVal();
            }
        }

        private void txtPayout_Enter(object sender, EventArgs e)
        {
            txtPayout.Text = _corpData.ExpectedPayout.ToString();
        }

        private void txtPayout_Leave(object sender, EventArgs e)
        {
            try
            {
                _corpData.ExpectedPayout = decimal.Parse(txtPayout.Text);
            }
            catch
            {
                _corpData.ExpectedPayout = 0;
            }
            finally
            {
                DisplayPayout();
            }
        }
        
        private bool StoreData()
        {
            bool retVal = true;

            try
            {
                _corpData.Name = txtName.Text;
                _corpData.Description = txtDescription.Text;
                _corpData.Ticker = txtTicker.Text;
                _corpData.NAVDate = dtpNavDate.Value.ToUniversalTime();
                _corpData.CEO = txtCEO.Text;
                _corpData.Bank = chkBank.Checked;
                _corpData.PayoutPeriod = (CorpPayoutPeriod)cmbPayoutPeriod.SelectedValue;
                _corpData.CorpRiskRating = (RiskRating)cmbRiskRating.SelectedValue;

                PublicCorps.StoreCorp(_corpData);

                if (_corpData.ShareValue != _oldShareVal)
                {
                    ShareValueHistory.SetShareValue(_corpData.ID, DateTime.UtcNow, _corpData.ShareValue);
                }
                if (_corpData.Bank && _corpData.ExpectedPayout != _oldInterestRate)
                {
                    if (MessageBox.Show("The interest rate has been changed.\r\nDo you wish to recalculate all " +
                        "historical interest payments using the new rate?", "Question",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        BankAccounts.ClearAllInterestPayments(_corpData.ID);
                    }
                }
            }
            catch (Exception ex)
            {
                EMMAException emmaex = ex as EMMAException;
                if(emmaex == null)
                {
                    emmaex = new EMMAException(ExceptionSeverity.Error, "Problem storing public corp data", ex);
                }
                MessageBox.Show("Error storing corp data: " + ex.Message, "Error", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                retVal = false;
            }

            return retVal;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (StoreData())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public PublicCorp CorpData
        {
            get { return _corpData; }
        }

        private void btnDividends_Click(object sender, EventArgs e)
        {
            ListDividend divList = new ListDividend(_corpData);
            divList.ShowDialog();
        }

        private void btnWebLinks_Click(object sender, EventArgs e)
        {
            ListCorpWebLinks linksList = new ListCorpWebLinks(_corpData);
            linksList.ShowDialog();
        }

        private void btnShareValueHistory_Click(object sender, EventArgs e)
        {
            ListShareValueHistory valueHistory = new ListShareValueHistory(_corpData);
            valueHistory.ShowDialog();
        }

        private void chkBank_CheckedChanged(object sender, EventArgs e)
        {
            _corpData.Bank = chkBank.Checked;
            if (_displayMessage)
            {
                if (chkBank.Checked)
                {
                    MessageBox.Show("This option should only be enabled for schemes that provide compounded " +
                        "returns .\r\nFor example, an EBank savings account should use this option because it pays " +
                        "a certain percentage per day on whatever is in your account.\r\nHowever, an EBank " +
                        "bond should not use this option because it pays monthly, non-compounded interest.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTicker.Text = "";
                    txtNav.Text = "";
                    txtShareValue.Text = "";
                    _corpData.ExpectedPayout = 0;
                    DisplayPayout();
                }
                else
                {
                    txtTicker.Text = _corpData.Ticker;
                    DisplayNAV();
                    DisplayShareVal();
                    _corpData.ExpectedPayout = 0;
                    DisplayPayout();
                }
                SetFieldsEnabled();
            }
        }

        private void SetFieldsEnabled()
        {
            if (_corpData.Bank)
            {
                txtTicker.Enabled = false;
                txtNav.Enabled = false;
                dtpNavDate.Enabled = false;
                txtShareValue.Enabled = false;
                lblPayout.Text = "Interest rate per period";
                lblPeriod.Text = "How often is interest paid";
                btnDividends.Visible = false;
                btnShareValueHistory.Visible = false;
            }
            else
            {
                txtTicker.Enabled = true;
                txtNav.Enabled = true;
                dtpNavDate.Enabled = true;
                txtShareValue.Enabled = true;
                lblPayout.Text = "Est payout per share";
                lblPeriod.Text = "How often are payouts made";
                btnDividends.Visible = true;
                btnShareValueHistory.Visible = true;
            }
            
        }

        

    }

}