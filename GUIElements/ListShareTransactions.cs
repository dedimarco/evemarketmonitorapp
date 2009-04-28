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
    public partial class ListShareTransactions : Form
    {
        int _currentTrans = 0;
        int _reportGroup = 0;
        private PublicCorp _startCorp = null;

        public ListShareTransactions()
        {
            InitializeComponent();
        }
        
        public ListShareTransactions(PublicCorp corpData)
        {
            _startCorp = corpData;
            InitializeComponent();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            bool enable = !chkShowAll.Checked;
            cmbCorp.Enabled = enable;
            lblCorpShown.Enabled = enable;
            DisplayData(true);
        }

        private void ListShareTransactions_Load(object sender, EventArgs e)
        {
            PublicCorpsList corps = PublicCorps.GetAll(false);
            corps.Sort("Name ASC");
            cmbCorp.DisplayMember = "Name";
            cmbCorp.ValueMember = "ID";
            cmbCorp.DataSource = corps;
            if (_startCorp != null)
            {
                cmbCorp.SelectedValue = _startCorp.ID;
            }

            _reportGroup = UserAccount.CurrentGroup.ID;

            DisplayData(true);
        }

        private void DisplayData(bool sort)
        {
            ShareTransactionList shareTrans = ShareTransactions.GetTransactions(_reportGroup, 
                (chkShowAll.Checked ? 0 : (int)cmbCorp.SelectedValue));

            DataGridViewCellStyle style = new DataGridViewCellStyle(PriceValueColumn.DefaultCellStyle);
            style.Format = IskAmount.FormatString();
            PriceValueColumn.DefaultCellStyle = style;

            shareTransGridView.AutoGenerateColumns = false;
            TransIDColumn.DataPropertyName = "ID";
            DateColumn.DataPropertyName = "TransactionDate";
            CorpColumn.DataPropertyName = "CorpName";
            PriceValueColumn.DataPropertyName = "PricePerShare";
            AmountColumn.DataPropertyName = "Quantity";
            TypeColumn.DataPropertyName = "Type";
            shareTransGridView.DataSource = shareTrans;

            if (sort)
            {
                shareTransGridView.Sort(shareTransGridView.Columns["DateColumn"], ListSortDirection.Descending);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void shareTransGridView_KeyDown(object sender, KeyEventArgs e)
        {        
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedTrans();
            }
        }

        private void DeleteSelectedTrans()
        {
            try
            {
                ShareTransactions.DeleteTrans(_currentTrans);
                DisplayData(true);
            }
            catch (EMMADataException emmaDataEx)
            {
                MessageBox.Show(emmaDataEx.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void shareTransGridView_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            _currentTrans = ((ShareTransaction)shareTransGridView.Rows[e.RowIndex].DataBoundItem).ID;
        }

        private void cmbCorp_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayData(true);
        }


    }
}