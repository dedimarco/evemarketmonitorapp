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
    public delegate void CPOptionSelected(object myObject, CPOptionSelectedArgs args);

    public partial class ControlPanel : Form
    {
        private bool _allowClose = false;
        private SettingsMenu _settingsMenu;

        public event CPOptionSelected OptionSelected;

        public bool AllowClose
        {
            get { return _allowClose; }
            set { _allowClose = value; }
        }

        public ControlPanel(SettingsMenu settingsMenu)
        {
            InitializeComponent();

            btnManageGroup.Tag = ControlPanelOption.ManageGroup;
            btnChangeGroup.Tag = ControlPanelOption.SelectGroup;
            btnSettings.Tag = ControlPanelOption.ChangeSettings;
            btnTutorial.Tag = ControlPanelOption.Tutorial;
            btnExport.Tag = ControlPanelOption.ExportData;
            btnImport.Tag = ControlPanelOption.ImportData;
            btnLicense.Tag = ControlPanelOption.LicenseDetails;
            btnVerifyDB.Tag = ControlPanelOption.VerifyDB;
            btnLogout.Tag = ControlPanelOption.Logout;
            btnAbout.Tag = ControlPanelOption.About;
            btnQuit.Tag = ControlPanelOption.Quit;
            _settingsMenu = settingsMenu;
            _settingsMenu.Retract += new HideSettings(settings_Hide);
            _settingsMenu.SetControlPanel(this);
        }

        public void InitSettings()
        {
            _settingsMenu.Show();
            _settingsMenu.Visible = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Never allow user to close this. 
            // If the close command has come from the parent window then we need to allow it though.
            e.Cancel = !_allowClose;
            if (_allowClose)
            {
                _settingsMenu.AllowClose = true;
                _settingsMenu.Close();
            }
            base.OnClosing(e);
        }

        public void Refresh(SystemStatus status)
        {
            switch (status)
            {
                case SystemStatus.NoUserLoggedIn:
                    btnManageGroup.Enabled = false;
                    btnChangeGroup.Enabled = false;
                    btnSettings.Enabled = false;
                    btnTutorial.Enabled = true;
                    btnExport.Enabled = false;
                    btnImport.Enabled = false;
                    btnLicense.Enabled = true;
                    btnVerifyDB.Enabled = true;
                    btnAbout.Enabled = true;
                    btnLogout.Text = "&Login";
                    btnLogout.Tag = ControlPanelOption.Login;
                    break;
                case SystemStatus.NoReportGroupSelected:
                    btnManageGroup.Enabled = false;
                    btnChangeGroup.Enabled = true;
                    btnSettings.Enabled = false;
                    btnTutorial.Enabled = true;
                    btnExport.Enabled = false;
                    btnImport.Enabled = false;
                    btnLicense.Enabled = true;
                    btnVerifyDB.Enabled = true;
                    btnAbout.Enabled = true;
                    btnLogout.Text = "&Logout";
                    btnLogout.Tag = ControlPanelOption.Logout;
                    break;
                case SystemStatus.Complete:
                    btnManageGroup.Enabled = true;
                    btnChangeGroup.Enabled = true;
                    btnSettings.Enabled = true;
                    btnTutorial.Enabled = true;
                    btnExport.Enabled = true;
                    btnLicense.Enabled = true;
                    btnVerifyDB.Enabled = true;
                    btnAbout.Enabled = true;
                    btnImport.Enabled = UserAccount.CurrentGroup.AccessLevel == GroupAccess.Full;
                    btnLogout.Text = "&Logout";
                    btnLogout.Tag = ControlPanelOption.Logout;
                    break;
                default:
                    break;
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (OptionSelected != null)
            {
                OptionSelected(this, new CPOptionSelectedArgs((ControlPanelOption)btn.Tag));
            }           
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (btnSettings.Text.Equals("&Settings"))
            {
                if (!_settingsMenu.Visible)
                {
                    // Start the settings menu in a position off the edge of the screen..
                    _settingsMenu.StartPosition = FormStartPosition.Manual;
                    _settingsMenu.Location = new Point(3000, 10);
                    _settingsMenu.Show();
                    // ..then focus on the control panel to bring it to the foreground...
                    this.Focus();
                    // ..finally, move the settings menu into position behind the control panel.
                    _settingsMenu.Location = new Point(this.Location.X,
                        this.Location.Y + (this.Height / 2) - (_settingsMenu.Height / 2));
                }

                btnSettings.Text = "Hide &Settings";
            }
            else
            {
                btnSettings.Text = "&Settings";
            }

            if (!settingsMenuTimer.Enabled)
            {
                settingsMenuTimer.Start();
            }
        }

        public void settings_Hide(object sender, EventArgs e)
        {
            btnSettings.Text = "&Settings";
            if (!settingsMenuTimer.Enabled)
            {
                settingsMenuTimer.Start();
            }
        }

        private void settingsMenuTimer_Tick(object sender, EventArgs e)
        {
            bool expanding = btnSettings.Text.Equals("Hide &Settings");
            int destinationX = this.Location.X;
            if (expanding)
            {
                destinationX -= _settingsMenu.Width - 4;
            }

            const int inverseSpeed = 10; 
            int change = (int)(((float)_settingsMenu.Location.X - (float)destinationX) / (float)inverseSpeed);
            _settingsMenu.Location = new Point(_settingsMenu.Location.X - 
                (change > 1 || change < -1 ? change : (expanding ? 1 : -1)), 
                _settingsMenu.Location.Y);

            if (_settingsMenu.Location.X == destinationX)
            {
                settingsMenuTimer.Stop();
                if (!expanding)
                {
                    _settingsMenu.Visible = false;
                }
            }
        }


    }

    public class CPOptionSelectedArgs
    {
        private ControlPanelOption _option;

        public ControlPanelOption Option
        {
            get { return _option; }
            set { _option = value; }
        }

        public CPOptionSelectedArgs(ControlPanelOption option)
        {
            _option = option;
        }
    }

    public enum ControlPanelOption
    {
        ManageGroup,
        SelectGroup,
        ChangeSettings,
        Tutorial,
        ExportData,
        ImportData,
        Logout,
        Login,
        VerifyDB,
        LicenseDetails,
        About,
        Quit
    }
}