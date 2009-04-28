using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class NewRptGroup : Form
    {
        public NewRptGroup()
        {
            InitializeComponent();
            chkPublic.Visible = false;
            chkPublic.Checked = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public string SelectedName
        {
            get { return txtName.Text; }
            set { txtName.Text = value; }
        }

        public bool PublicAccess
        {
            get { return chkPublic.Checked; }
            set { chkPublic.Checked = value; }
        }

    }
}