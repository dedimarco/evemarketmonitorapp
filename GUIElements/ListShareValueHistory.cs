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
    public partial class ListShareValueHistory : Form
    {
        private PublicCorp _currentCorp = null;
        private PublicCorp _startCorp = null;
        private EMMADataSet.ShareValueHistoryRow _currentValue = null;

        public ListShareValueHistory()
        {
            InitializeComponent();
        }

        public ListShareValueHistory(PublicCorp corp)
        {
            InitializeComponent();
            _startCorp = corp;
        }

        private void DisplayData()
        {
            EMMADataSet.ShareValueHistoryDataTable data = 
                ShareValueHistory.GetValueHistory(_currentCorp.ID);

            DataGridViewCellStyle style = new DataGridViewCellStyle(ShareValueColumn.DefaultCellStyle);
            style.Format = IskAmount.FormatString();
            ShareValueColumn.DefaultCellStyle = style;

            shareValueGrid.AutoGenerateColumns = false;
            DateColumn.DataPropertyName = "DateTime";
            ShareValueColumn.DataPropertyName = "ShareValue";
            shareValueGrid.DataSource = data;

            shareValueGrid.Sort(DateColumn, ListSortDirection.Descending);
        }

        private void ListShareValueHistory_Load(object sender, EventArgs e)
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MaintShareValueHistory newValHist = new MaintShareValueHistory(_currentCorp);
            newValHist.ShowDialog();
            DisplayData();
        }

        private void shareValueGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _currentValue != null)
            {
                ShareValueHistory.DeleteEntry(_currentValue.PublicCorpID, _currentValue.DateTime);
                DisplayData();
            }
        }

        private void shareValueGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (shareValueGrid.Rows[e.RowIndex] != null)
            {
                _currentValue = (EMMADataSet.ShareValueHistoryRow)
                    (((DataRowView)shareValueGrid.Rows[e.RowIndex].DataBoundItem).Row);
            }
            else
            {
                _currentValue = null;
            }
        }

        private void shareValueGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (shareValueGrid.Rows[e.RowIndex] != null)
            {
                MaintShareValueHistory maintValue = new MaintShareValueHistory((EMMADataSet.ShareValueHistoryRow)
                    (((DataRowView)shareValueGrid.Rows[e.RowIndex].DataBoundItem).Row));
                maintValue.ShowDialog();
                DisplayData();
            }
        }


    }
}