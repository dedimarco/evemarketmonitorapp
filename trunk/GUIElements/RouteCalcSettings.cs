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
    public partial class RouteCalcSettings : Form
    {
        private int _highSecCost = 0;
        private int _lowSecCost = 0;
        private int _nullSecCost = 0;

        public RouteCalcSettings()
        {
            InitializeComponent();
            _highSecCost = UserAccount.CurrentGroup.Settings.RouteHighSecWeight;
            _lowSecCost = UserAccount.CurrentGroup.Settings.RouteLowSecWeight;
            _nullSecCost = UserAccount.CurrentGroup.Settings.RouteNullSecWeight;
            this.DialogResult = DialogResult.Cancel;
        }

        private void RouteCalcSettings_Load(object sender, EventArgs e)
        {
            txtHighSecCost.Text = _highSecCost.ToString();
            txtLowSec.Text = _lowSecCost.ToString();
            txtNullSec.Text = _nullSecCost.ToString();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (Verify())
            {
                UserAccount.CurrentGroup.Settings.RouteHighSecWeight = _highSecCost;
                UserAccount.CurrentGroup.Settings.RouteLowSecWeight = _lowSecCost;
                UserAccount.CurrentGroup.Settings.RouteNullSecWeight = _nullSecCost;
                this.Close();
            }
            else
            {
                MessageBox.Show("Costs must be greater than zero and less than or equal to 100.\r\nThey must also be whole numbers.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Verify()
        {
            bool retVal = true;
            try
            {
                _highSecCost = int.Parse(txtHighSecCost.Text);
            }
            catch
            {
                _highSecCost = 1;
                retVal = false;
            }
            try
            {
                _lowSecCost = int.Parse(txtLowSec.Text);
            }
            catch
            {
                _lowSecCost = 1;
                retVal = false;
            }
            try
            {
                _nullSecCost = int.Parse(txtNullSec.Text);
            }
            catch
            {
                _nullSecCost = 1;
                retVal = false;
            }

            if (_highSecCost < 1) { _highSecCost = 1; retVal = false; }
            if (_lowSecCost < 1) { _lowSecCost = 1; retVal = false; }
            if (_nullSecCost < 1) { _nullSecCost = 1; retVal = false; }
            if (_highSecCost > 100) { _highSecCost = 100; retVal = false; }
            if (_lowSecCost > 100) { _lowSecCost = 100; retVal = false; }
            if (_nullSecCost > 100) { _nullSecCost = 100; retVal = false; }

            txtHighSecCost.Text = _highSecCost.ToString();
            txtLowSec.Text = _lowSecCost.ToString();
            txtNullSec.Text = _nullSecCost.ToString();


            return retVal;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}