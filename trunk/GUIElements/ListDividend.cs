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
    public partial class ListDividend : Form
    {
        private PublicCorp _currentCorp = null;
        private PublicCorp _startCorp = null;
        private Dividend _currentDiv = null;

        public ListDividend()
        {
            InitializeComponent();
            chkShowAll.Checked = true;
        }

        public ListDividend(PublicCorp corp)
        {
            InitializeComponent();
            chkShowAll.Checked = false;
            _startCorp = corp;
        }

        private void DisplayData()
        {
            DividendList data = Dividends.GetDividends(
                ((chkShowAll.Checked || _currentCorp == null) ? 0 : _currentCorp.ID));

            DataGridViewCellStyle style = new DataGridViewCellStyle(PayoutValueColumn.DefaultCellStyle);
            style.Format = IskAmount.FormatString();
            PayoutValueColumn.DefaultCellStyle = style;

            dividendGrid.AutoGenerateColumns = false;
            DivIDColumn.DataPropertyName = "ID";
            DateColumn.DataPropertyName = "Date";
            CorpNameColumn.DataPropertyName = "CorpName";
            PayoutValueColumn.DataPropertyName = "PayoutPerShare";
            dividendGrid.DataSource = data;

            dividendGrid.Sort(DateColumn, ListSortDirection.Descending);
        }

        private void DividendMaint_Load(object sender, EventArgs e)
        {
            _currentCorp = _startCorp;
            DisplayData();

            PublicCorpsList corpData = PublicCorps.GetAll(false);
            corpData.Sort("Name ASC");
            cmbSelectedCorp.DisplayMember = "Name";
            cmbSelectedCorp.ValueMember = "ID";
            cmbSelectedCorp.DataSource = corpData;

            if (_startCorp != null)
            {
                cmbSelectedCorp.SelectedValue = _startCorp.ID;
            }
        }

        private void cmbSelectedCorp_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCorp = (PublicCorp)cmbSelectedCorp.SelectedItem;
            DisplayData();
        }

        private void chkShowAll_CheckedChanged(object sender, EventArgs e)
        {
            cmbSelectedCorp.Enabled = !chkShowAll.Checked;
            DisplayData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MaintDividend newdiv = new MaintDividend(_currentCorp);
            newdiv.ShowDialog();
            DisplayData();
        }

        private void dividendGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _currentDiv != null)
            {
                Dividends.DeleteDividend(_currentDiv.ID);
                DisplayData();
            }
        }

        private void dividendGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dividendGrid.Rows[e.RowIndex] != null)
            {
                _currentDiv = (Dividend)dividendGrid.Rows[e.RowIndex].DataBoundItem;
            }
            else
            {
                _currentDiv = null;
            }
        }

        private void dividendGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dividendGrid.Rows[e.RowIndex] != null)
            {
                MaintDividend maintDiv = new MaintDividend((Dividend)dividendGrid.Rows[e.RowIndex].DataBoundItem);
                maintDiv.ShowDialog();
                DisplayData();
            }
        }


    }
}