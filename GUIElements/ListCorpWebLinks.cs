using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.DatabaseClasses;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class ListCorpWebLinks : Form
    {
        private PublicCorp _selectedCorp = null;
        private PublicCorp _startCorp = null;
        private WebLink _selectedLink = null;

        public ListCorpWebLinks(PublicCorp _corpData)
        {
            InitializeComponent();
            _startCorp = _corpData;
        }

        private void ListCorpWebLinks_Load(object sender, EventArgs e)
        {
            _selectedCorp = _startCorp;
            DisplayData();

            PublicCorpsList corpData = PublicCorps.GetAll();
            corpData.Sort("Name ASC");
            cmbCorpShown.DisplayMember = "Name";
            cmbCorpShown.ValueMember = "ID";
            cmbCorpShown.DataSource = corpData;

            if (_startCorp !=null)
            {
                cmbCorpShown.SelectedValue = _startCorp.ID;
            }
        }

        private void DisplayData()
        {
            WebLinkList data = WebLinks.GetWebLinks(_selectedCorp.ID);

            webLinkGrid.AutoGenerateColumns = false;
            webLinkGrid.DataSource = data;
            LinkIDColumn.DataPropertyName = "ID";
            DescriptionColumn.DataPropertyName = "Description";
            LinkColumn.DataPropertyName = "Link";
        }

        private void cmbCorpShown_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCorp = (PublicCorp)cmbCorpShown.SelectedItem;
            DisplayData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            MaintWebLink newlink = new MaintWebLink(_selectedCorp);
            newlink.ShowDialog();
            DisplayData();
        }


        private void webLinkGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(webLinkGrid.Rows[e.RowIndex] != null) 
            {
                _selectedLink = (WebLink)webLinkGrid.Rows[e.RowIndex].DataBoundItem;
            }
        }

        private void webLinkGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (webLinkGrid.Columns[e.ColumnIndex] != null &&
                webLinkGrid.Rows[e.RowIndex] != null)
            {
                if (webLinkGrid.Columns[e.ColumnIndex].Name.Equals("LinkColumn"))
                {
                    System.Diagnostics.Process.Start(webLinkGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                }
            }
        }

        private void webLinkGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && _selectedLink != null)
            {
                WebLinks.DeleteLink(_selectedLink.ID);
                DisplayData();
            }
        }

        private void webLinkGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (webLinkGrid.Rows[e.RowIndex] != null)
            {
                MaintWebLink maintLink = new MaintWebLink((WebLink)webLinkGrid.Rows[e.RowIndex].DataBoundItem);
                maintLink.ShowDialog();
                DisplayData();
            }
        }

    }
}