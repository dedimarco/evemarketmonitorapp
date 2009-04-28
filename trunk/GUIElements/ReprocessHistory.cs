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
    public partial class ReprocessHistory : Form
    {
        private DataGridViewRow _selectedRow = null;

        public ReprocessHistory()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(ReprocessHistory_FormClosing);
            UserAccount.Settings.GetFormSizeLoc(this);
        }

        private void ReprocessHistory_Load(object sender, EventArgs e)
        {
            reprocessJobsGrid.AutoGenerateColumns = false;

            reprocessJobsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            reprocessJobsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            ReprocessJobList jobList = ReprocessJobs.GetGroupJobs(UserAccount.CurrentGroup.ID);
            reprocessJobsGrid.DataSource = jobList;
            JobDateColumn.DataPropertyName = "Date";
            OwnerColumn.DataPropertyName = "Owner";
            StationColumn.DataPropertyName = "Station";
        }

        void ReprocessHistory_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserAccount.Settings != null)
            {
                UserAccount.Settings.StoreFormSizeLoc(this);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteJob(false);
        }

        private void btnReverse_Click(object sender, EventArgs e)
        {
            DeleteJob(true);
        }

        private void DeleteJob(bool reverse)
        {
            if (_selectedRow != null)
            {
                ReprocessJob jobData =(ReprocessJob)_selectedRow.DataBoundItem;
                if (reverse) { jobData.ReverseJob(); }

                ReprocessJobs.DeleteJob(jobData);

                _selectedRow = null;

                ReprocessJobList jobList = ReprocessJobs.GetGroupJobs(UserAccount.CurrentGroup.ID);
                reprocessJobsGrid.DataSource = jobList;
            }
        }

        private void reprocessJobsGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedRow = reprocessJobsGrid.Rows[e.RowIndex];
            }
            else
            {
                _selectedRow = null;
            }
        }
    }
}