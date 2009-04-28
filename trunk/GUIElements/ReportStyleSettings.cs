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
    public partial class ReportStyleSettings : Form
    {
        ReportGroupSettings _settings;

        public ReportStyleSettings()
        {
            InitializeComponent();
        }

        private void ReportStyleSettings_Load(object sender, EventArgs e)
        {
            _settings = UserAccount.CurrentGroup.Settings;

            txtColHeaderFont.Text = _settings.Rpt_ColHeaderFont.ToString();
            txtDataFont.Text = _settings.Rpt_DataFont.ToString();
            txtRowHeaderFont.Text = _settings.Rpt_RowHeaderFont.ToString();
            txtTitleFont.Text = _settings.Rpt_TitleFont.ToString();

            chkAltRowEnabled.Checked = _settings.Rpt_AltRowInUse;
            chkSectHeaderRowBold.Checked = _settings.Rpt_SectionHeaderFont.Bold;
            chkSectHeaderRowUnderline.Checked = _settings.Rpt_SectionHeaderFont.Underline;

            btnAltRowBackgroundCol.BackColor = _settings.Rpt_AltRowBackColour;
            btnAltRowTextCol.BackColor = _settings.Rpt_AltRowTextColour;
            btnBackgroundCol.BackColor = _settings.Rpt_DataBackColour;
            btnColHeaderBackgroundCol.BackColor = _settings.Rpt_ColHeaderBackColour;
            btnColHeaderTextCol.BackColor = _settings.Rpt_ColHeaderTextColour;
            btnNegValTextCol.BackColor = _settings.Rpt_NegDataTextColour;
            btnDangerValTextCol.BackColor = _settings.Rpt_DangerDataTextColour;
            btnWarningValTextCol.BackColor = _settings.Rpt_WarningDataTextColour;
            btnGoodValTextCol.BackColor = _settings.Rpt_GoodDataTextColour;
            btnRowHeaderBackgroundCol.BackColor = _settings.Rpt_RowHeaderBackColour;
            btnRowHeaderTextCol.BackColor = _settings.Rpt_RowHeaderTextColour;
            btnTextCol.BackColor = _settings.Rpt_DataTextColour;
            btnRptTitleBackCol.BackColor = _settings.Rpt_TitleBackColour;
            btnRptTitleTextCol.BackColor = _settings.Rpt_TitleTextColour;

            SetEnabled();

            if (System.IO.File.Exists(_settings.Rpt_LogoFile))
            {
                imgLogo.Image = Image.FromFile(_settings.Rpt_LogoFile);
            }
            else
            {
                imgLogo.Image = null;
            }
        }

        private Color SelectColour(Color currentColour)
        {
            Color retVal = currentColour;

            ColorDialog colDialog = new ColorDialog();
            colDialog.AllowFullOpen = true;
            colDialog.Color = currentColour;
            colDialog.CustomColors = GetCustomCols();
            if (colDialog.ShowDialog() != DialogResult.Cancel)
            {
                retVal = colDialog.Color;
            }

            SaveCustCols(colDialog.CustomColors);
            
            return retVal;
        }

        private Font SelectFont(Font currentFont)
        {
            Font retVal = currentFont;

            FontDialog fontDialog = new FontDialog();
            fontDialog.AllowSimulations = true;
            fontDialog.AllowVerticalFonts = false;
            fontDialog.Font = currentFont;
            fontDialog.FontMustExist = true;
            fontDialog.ShowColor = false;
            fontDialog.ShowEffects = true;
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                retVal = fontDialog.Font;
            }

            return retVal;
        }

        private string SelectImageFile(string currentFile)
        {
            string retVal = currentFile;

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.CheckFileExists = true;
            fileDialog.FileName = currentFile;
            fileDialog.Filter = "Image Files (*.bmp;*.gif;*.jpg;*.png)|*.bmp;*.gif;*.jpg;*.png";
            fileDialog.Multiselect = false;
            fileDialog.Title = "Choose Logo Image";
            if (fileDialog.ShowDialog() != DialogResult.Cancel)
            {
                retVal = fileDialog.FileName;
            }

            return retVal;
        }

        private void SaveCustCols(int[] colours)
        {
            _settings.Rpt_CustomColourSet(0, Color.FromArgb(colours[0]));
            _settings.Rpt_CustomColourSet(1, Color.FromArgb(colours[8]));
            _settings.Rpt_CustomColourSet(2, Color.FromArgb(colours[1]));
            _settings.Rpt_CustomColourSet(3, Color.FromArgb(colours[9]));
            _settings.Rpt_CustomColourSet(4, Color.FromArgb(colours[2]));
            _settings.Rpt_CustomColourSet(5, Color.FromArgb(colours[10]));
            _settings.Rpt_CustomColourSet(6, Color.FromArgb(colours[3]));
            _settings.Rpt_CustomColourSet(7, Color.FromArgb(colours[11]));
        }

        private int[] GetCustomCols()
        {
            int[] retVal = new int[16];
            retVal[0] = _settings.Rpt_CustomColourGet(0).ToArgb();
            retVal[8] = _settings.Rpt_CustomColourGet(1).ToArgb();
            retVal[1] = _settings.Rpt_CustomColourGet(2).ToArgb();
            retVal[9] = _settings.Rpt_CustomColourGet(3).ToArgb();
            retVal[2] =  _settings.Rpt_CustomColourGet(4).ToArgb();
            retVal[10] =  _settings.Rpt_CustomColourGet(5).ToArgb();
            retVal[3] = _settings.Rpt_CustomColourGet(6).ToArgb();
            retVal[11] = _settings.Rpt_CustomColourGet(7).ToArgb();
            return retVal;
        }

        private void SetEnabled()
        {
            bool altRowEnabled = _settings.Rpt_AltRowInUse;
            btnAltRowBackgroundCol.Enabled = altRowEnabled;
            btnAltRowTextCol.Enabled = altRowEnabled;
            lblAltRowBackCol.Enabled = altRowEnabled;
            lblAltRowTextCol.Enabled = altRowEnabled;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EveMarketMonitorApp.Properties.Settings.Default.Save();

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkSectHeaderRowBold_CheckedChanged(object sender, EventArgs e)
        {
            int style = (int)_settings.Rpt_SectionHeaderFont.Style;

            if (chkSectHeaderRowBold.Checked)
            {
                if ((_settings.Rpt_SectionHeaderFont.Style & FontStyle.Bold) != FontStyle.Bold)
                {
                    style += 1;
                }
            }
            else
            {
                if ((_settings.Rpt_SectionHeaderFont.Style & FontStyle.Bold) == FontStyle.Bold)
                {
                    style -= 1;
                }
            }
            _settings.Rpt_SectionHeaderFont = new Font(_settings.Rpt_SectionHeaderFont, (FontStyle)style);
        }

        private void chkSectHeaderRowUnderline_CheckedChanged(object sender, EventArgs e)
        {
            int style = (int)_settings.Rpt_SectionHeaderFont.Style;

            if (chkSectHeaderRowUnderline.Checked)
            {
                if ((_settings.Rpt_SectionHeaderFont.Style & FontStyle.Underline) != FontStyle.Underline)
                {
                    style += 4;
                }
            }
            else
            {
                if ((_settings.Rpt_SectionHeaderFont.Style & FontStyle.Underline) == FontStyle.Underline)
                {
                    style -= 4;
                }
            }
            _settings.Rpt_SectionHeaderFont = new Font(_settings.Rpt_SectionHeaderFont, (FontStyle)style);
        }

        private void btnNegValTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_NegDataTextColour);
            _settings.Rpt_NegDataTextColour = col;
            btnNegValTextCol.BackColor = col;
        }

        private void btnDangerValTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_DangerDataTextColour);
            _settings.Rpt_DangerDataTextColour = col;
            btnDangerValTextCol.BackColor = col;
        }

        private void btnWarningValTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_WarningDataTextColour);
            _settings.Rpt_WarningDataTextColour = col;
            btnWarningValTextCol.BackColor = col;
        }

        private void btnGoodValTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_GoodDataTextColour);
            _settings.Rpt_GoodDataTextColour = col;
            btnGoodValTextCol.BackColor = col;
        }

        private void btnDataRowFont_Click(object sender, EventArgs e)
        {
            _settings.Rpt_DataFont = SelectFont(
                _settings.Rpt_DataFont);
            txtDataFont.Text = _settings.Rpt_DataFont.ToString();
        }

        private void btnRowHeaderBackgroundCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_RowHeaderBackColour);
            _settings.Rpt_RowHeaderBackColour = col;
            btnRowHeaderBackgroundCol.BackColor = col;
        }

        private void btnRowHeaderTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_RowHeaderTextColour);
            _settings.Rpt_RowHeaderTextColour = col;
            btnRowHeaderTextCol.BackColor = col;
        }

        private void btnRowHeaderFont_Click(object sender, EventArgs e)
        {
            _settings.Rpt_RowHeaderFont = SelectFont(
                _settings.Rpt_RowHeaderFont);
            txtRowHeaderFont.Text = _settings.Rpt_RowHeaderFont.ToString();
        }

        private void btnColHeaderBackgroundCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_ColHeaderBackColour);
            _settings.Rpt_ColHeaderBackColour = col;
            btnColHeaderBackgroundCol.BackColor = col;
        }

        private void btnColHeaderTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_ColHeaderTextColour);
            _settings.Rpt_ColHeaderTextColour = col;
            btnColHeaderTextCol.BackColor = col;
        }

        private void btnColHeaderFont_Click(object sender, EventArgs e)
        {
            _settings.Rpt_ColHeaderFont = SelectFont(
                _settings.Rpt_ColHeaderFont);
            txtColHeaderFont.Text = _settings.Rpt_ColHeaderFont.ToString();
        }

        private void btnAltRowBackgroundCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_AltRowBackColour);
            _settings.Rpt_AltRowBackColour = col;
            btnAltRowBackgroundCol.BackColor = col;
        }

        private void btnAltRowTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_AltRowTextColour);
            _settings.Rpt_AltRowTextColour = col;
            btnAltRowTextCol.BackColor = col;
        }

        private void chkAltRowEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _settings.Rpt_AltRowInUse = chkAltRowEnabled.Checked;
            SetEnabled();
        }

        private void btnBackgroundCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_DataBackColour);
            _settings.Rpt_DataBackColour = col;
            btnBackgroundCol.BackColor = col;
        }

        private void btnTextCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_DataTextColour);
            _settings.Rpt_DataTextColour = col;
            btnTextCol.BackColor = col;
        }

        private void imgLogo_Click(object sender, EventArgs e)
        {
            _settings.Rpt_LogoFile = SelectImageFile(
                _settings.Rpt_LogoFile);

            try
            {
                imgLogo.Image = Image.FromFile(_settings.Rpt_LogoFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problem loading the selected image: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                imgLogo.Image = null;
            }
        }

        private void btnClearLogo_Click(object sender, EventArgs e)
        {
            _settings.Rpt_LogoFile = "";
            imgLogo.Image = null;
        }

        private void btnRptTitleTextCol_Click(object sender, EventArgs e)
        {
            Color col =SelectColour(_settings.Rpt_TitleTextColour);
            _settings.Rpt_TitleTextColour = col;
            btnRptTitleTextCol.BackColor = col;
        }

        private void btnRptTitleBackCol_Click(object sender, EventArgs e)
        {
            Color col = SelectColour(_settings.Rpt_TitleBackColour);
            _settings.Rpt_TitleBackColour = col;
            btnRptTitleBackCol.BackColor = col;
        }

        private void btnReportTitleFont_Click(object sender, EventArgs e)
        {
            _settings.Rpt_TitleFont = SelectFont(
                _settings.Rpt_TitleFont);
        }



        
    }
}