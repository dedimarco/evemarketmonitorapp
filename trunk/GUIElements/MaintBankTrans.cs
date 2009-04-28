using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.Reporting;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class MaintBankTrans : Form
    {
        private PublicCorp _corpData;
        BankTransactionType _defaultType = BankTransactionType.Deposit;
        BankTransaction _transactionData = null;

        public MaintBankTrans(PublicCorp corpData, BankTransactionType defaultType)
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            _corpData = corpData;
            _defaultType = defaultType;
            _transactionData = new BankTransaction(corpData.BankAccountID, defaultType);
        }

        private void MaintBankTrans_Load(object sender, EventArgs e)
        {
            dtpDate.Value = DateTime.Now;
            lblBankName.Text = _corpData.Name;
            cmbType.DisplayMember = "Description";
            cmbType.ValueMember = "TypeID";
            cmbType.DataSource = BankTransactionTypes.GetAll();
            cmbType.SelectedValue = (short)_defaultType;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_transactionData.Type == BankTransactionType.Withdrawl &&
                _transactionData.Change > 0)
            {
                _transactionData.Change *= -1;
            }
            _transactionData.Date = dtpDate.Value.ToUniversalTime();
            _transactionData.Type = (BankTransactionType)cmbType.SelectedValue;

            BankAccounts.StoreBankTransaction(_transactionData);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txtAmount_Enter(object sender, EventArgs e)
        {
            txtAmount.Text = _transactionData.Change.ToString();
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            try
            {
                _transactionData.Change = decimal.Parse(txtAmount.Text);
            }
            catch
            {
                _transactionData.Change = 0;
            }
            txtAmount.Text = new IskAmount(_transactionData.Change).ToString();
        }

        public DateTime TransactionDate
        {
            get { return _transactionData.Date; }
        }
    }
}