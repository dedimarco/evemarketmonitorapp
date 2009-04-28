using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.Common;
using EveMarketMonitorApp.Reporting;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class MaintShareTrans : Form
    {
        private ShareTransaction _data;
        private PublicCorpsList _corpData;

        public MaintShareTrans()
        {
            InitializeComponent();
            _data = new ShareTransaction();
        }

        public MaintShareTrans(ShareTransaction data)
        {
            InitializeComponent();
            _data = data;
        }

        private void NewShareTrans_Load(object sender, EventArgs e)
        {
            _corpData = PublicCorps.GetAll(false);
            _corpData.Sort("Name ASC");
            cmbCorp.DataSource = _corpData;
            cmbCorp.DisplayMember = "Name";
            cmbCorp.ValueMember = "ID";
            if (_data.CorpID != 0)
            {
                cmbCorp.SelectedValue = _data.CorpID;
            }
            txtPrice.Tag = _data.PricePerShare;
            dtpTransDate.Value = _data.TransactionDate;
            cmbType.SelectedIndex = 0;
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (StoreTrans())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool StoreTrans()
        {
            int quantity = 0;
            bool abort = false;

            try
            {
                quantity = int.Parse(txtQuantity.Text, 
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            }
            catch
            {
                txtQuantity.Text = "0";
                abort = true;
            }

            if (_data.PricePerShare < 0 || cmbCorp.SelectedItem == null)
            {
                abort = true;
            }

            if (!abort)
            {
                if (cmbType.Text.Trim().ToLower().Equals("sell"))
                {
                    quantity *= -1;
                }
                _data.DeltaQuantity = quantity;
                _data.CorpID = (int)cmbCorp.SelectedValue;
                _data.PricePerShare = (decimal)txtPrice.Tag;
                _data.TransactionDate = dtpTransDate.Value;

                try
                {
                    ShareTransactions.StoreTransaction(_data);
                }
                catch (Exception ex)
                {
                    EMMAException emmaex = ex as EMMAException;
                    if (emmaex == null)
                    {
                        emmaex = new EMMAException(ExceptionSeverity.Error, "Error saving" +
                            " share transaction data to database", ex);
                    }
                    MessageBox.Show("Error adding data to database: " + ex.Message, "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    abort = true;
                }
            }

            return !abort;
        }

        private void txtPrice_Enter(object sender, EventArgs e)
        {
            txtPrice.Text = txtPrice.Tag.ToString();
        }

        private void txtPrice_Leave(object sender, EventArgs e)
        {
            decimal newPrice = 0;

            try
            {
                newPrice = decimal.Parse(txtPrice.Text);
            }
            finally
            {
                txtPrice.Tag = newPrice;
                txtPrice.Text = new IskAmount(newPrice).ToString();
            }
        }

        private void btnNewCorp_Click(object sender, EventArgs e)
        {
            MaintPublicCorp newCorp = new MaintPublicCorp();
            if (newCorp.ShowDialog() != DialogResult.Cancel)
            {
                _corpData = PublicCorps.GetAll();
                cmbCorp.SelectedValue = newCorp.CorpData.ID;
            }
        }

    }
}