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
    public partial class OrderNotificationSettings : Form
    {
        ReportGroupSettings settings;

        public OrderNotificationSettings()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
            LoadSettings();
        }

        private void LoadSettings()
        {
            settings = UserAccount.CurrentGroup.Settings;
            chkNotificationsEanbled.Checked = settings.OrdersNotifyEnabled;
            chkBuyOrders.Checked = settings.OrdersNotifyBuy;
            chkSellOrders.Checked = settings.OrdersNotifySell;
        }

        private bool SaveSettings()
        {
            bool retVal = false;
            try
            {
                settings.OrdersNotifyEnabled = chkNotificationsEanbled.Checked;
                settings.OrdersNotifyBuy = chkBuyOrders.Checked;
                settings.OrdersNotifySell = chkSellOrders.Checked;
                retVal = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem saving order notification settings: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return retVal;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (SaveSettings())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}