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
    public partial class AutoAddConfig : Form
    {
        public AutoAddConfig()
        {
            InitializeComponent();
            label1.Visible = false;
            cmbAddBasedOn.Visible = false;
        }

        private void AutoAddConfig_Load(object sender, EventArgs e)
        {
            cmbAddBasedOn.Text = UserAccount.CurrentGroup.Settings.AutoAddItemsBy;
            txtMinRequired.Text = UserAccount.CurrentGroup.Settings.AutoAddMin.ToString();
            RefreshText();
        }
        
        private void cmbAddBasedOn_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshText();
        }

        private void txtMinRequired_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int.Parse(txtMinRequired.Text);
            }
            catch
            {
                txtMinRequired.Text = "";
            }

            RefreshText();
        }

        private void SaveSettings()
        {
            UserAccount.CurrentGroup.Settings.AutoAddItemsBy = cmbAddBasedOn.Text;
            UserAccount.CurrentGroup.Settings.AutoAddMin = int.Parse(txtMinRequired.Text);
            UserAccount.CurrentGroup.StoreSettings();
        }

        private void RefreshText()
        {
            if (cmbAddBasedOn.Text.Equals("Transactions"))
            {
                //lblPart2.Text = "buy and " + (txtMinRequired.Text.Equals("") ? "x" : txtMinRequired.Text) + " sell transactions.";
                lblPart2.Text = "units bought or sold.";
            }
            else if (cmbAddBasedOn.Text.Equals("Sales"))
            {
                lblPart2.Text = " sales.";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            SaveSettings();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }


    }
}