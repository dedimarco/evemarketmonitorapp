using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class ManageReportGroups : Form
    {
        private List<ReportGroup> _groups;
        private ReportGroup _selectedGroup;
        private bool _tutorial;

        public ManageReportGroups()
        {
            InitializeComponent();
            _tutorial = UserAccount.Settings.FirstRun;
            ShowGroups();
        }

        private void ManageReportGroups_Load(object sender, EventArgs e)
        {
            /*if (_tutorial)
            {
                MessageBox.Show("If this is your first time using EMMA then create a new report group" +
                    " as described in the quick start guide.\r\nYou can then enter the tutorial group" +
                    " to learn how to make use of all the features in the software.", "Help", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/
        }
        
        private void ShowGroups()
        {
            _groups = UserAccount.GetReportGroups(chkShowPublic.Checked);

            reportGroupsGrid.AutoGenerateColumns = false;
            reportGroupsGrid.DataSource = _groups;
            GroupNameColumn.DataPropertyName = "Name";
            GroupIDColumn.DataPropertyName = "ID";
            GroupTypeColumn.DataPropertyName = "Type";
            UserAccessLevelColumn.DataPropertyName = "AccessLevelText";

            if (_groups.Count == 0)
            {
                lblNoGroups.Visible = true;
                reportGroupsGrid.ColumnHeadersVisible = false;
            }
            else
            {
                lblNoGroups.Visible = false;
                reportGroupsGrid.ColumnHeadersVisible = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            _selectedGroup = (ReportGroup)reportGroupsGrid.CurrentRow.DataBoundItem;
            Ok();
        }

        private void reportGroupsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _selectedGroup = (ReportGroup)reportGroupsGrid.Rows[e.RowIndex].DataBoundItem;
            Ok();
        }

        private void Ok()
        {
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (reportGroupsGrid.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you wish to delete the " +
                    reportGroupsGrid.CurrentRow.Cells[GroupNameColumn.Name].Value.ToString() + " report group?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        ReportGroups.Delete(int.Parse(reportGroupsGrid.CurrentRow.Cells[GroupIDColumn.Name].Value.ToString()));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ShowGroups();
                }
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            NewRptGroup newRptGroup = new NewRptGroup();
            if (newRptGroup.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ReportGroups.NewGroup(UserAccount.Name, newRptGroup.SelectedName, newRptGroup.PublicAccess);
                }
                catch (EMMAException emmaEx)
                {
                    MessageBox.Show(emmaEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            ShowGroups();
        }


        private void chkShowPublic_CheckedChanged(object sender, EventArgs e)
        {
            ShowGroups();
        }

        public ReportGroup SelectedGroup
        {
            get { return _selectedGroup; }
            set { _selectedGroup = value; }
        }

 


 
    }
}