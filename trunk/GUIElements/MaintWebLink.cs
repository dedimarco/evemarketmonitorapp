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
    public partial class MaintWebLink : Form
    {
        WebLink _link = null;
        PublicCorp _selectedCorp = null;
        PublicCorp _startCorp = null;

        public MaintWebLink(PublicCorp corp)
        {
            InitializeComponent();
            _startCorp = corp;
            _link = new WebLink(corp.ID);
        }

        public MaintWebLink(WebLink link)
        {
            InitializeComponent();
            _link = link;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _link.Link = txtURL.Text;
            _link.Description = txtDescription.Text;
            _link.CorpID = _selectedCorp.ID;
            WebLinks.StoreLink(_link);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MaintWebLink_Load(object sender, EventArgs e)
        {
            PublicCorpsList corpData = PublicCorps.GetAll();
            corpData.Sort("Name ASC");
            cmbCorp.DisplayMember = "Name";
            cmbCorp.ValueMember = "ID";
            cmbCorp.DataSource = corpData;

            if (_startCorp != null)
            {
                cmbCorp.SelectedValue = _startCorp.ID;
            }
        }

        private void cmbCorp_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedCorp = (PublicCorp)cmbCorp.SelectedItem;
        }
    }
}