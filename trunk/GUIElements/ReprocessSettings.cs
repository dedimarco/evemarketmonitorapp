using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.Common;
using EveMarketMonitorApp.AbstractionClasses;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class ReprocessSettings : Form
    {
        List<string> _recentStations;
        string _lastStation = "";
        float _baseYield = 0.0f;
        float _standing = 0.0f;

        public ReprocessSettings()
        {
            InitializeComponent();
            this.DialogResult = DialogResult.Cancel;
        }

        private void ReprocessSettings_Load(object sender, EventArgs e)
        {
            try
            {
                ReportGroupSettings settings = UserAccount.CurrentGroup.Settings;
                txtRefineLvl.Tag = settings.GetReprocessSkillLevel(Skills.Refining);
                txtRefineEfficiencyLvl.Tag = settings.GetReprocessSkillLevel(Skills.RefineryEfficiency);
                txtArkonor.Tag = settings.GetReprocessSkillLevel(Skills.ArkonorProcessing);
                txtBistot.Tag = settings.GetReprocessSkillLevel(Skills.BistotProcessing);
                txtCrokite.Tag = settings.GetReprocessSkillLevel(Skills.CrokiteProcessing);
                txtDarkOchre.Tag = settings.GetReprocessSkillLevel(Skills.DarkOchreProcessing);
                txtGneiss.Tag = settings.GetReprocessSkillLevel(Skills.GneissProcessing);
                txtHedbergite.Tag = settings.GetReprocessSkillLevel(Skills.HedbergiteProcessing);
                txtHemorphite.Tag = settings.GetReprocessSkillLevel(Skills.HemorphiteProcessing);
                txtJaspet.Tag = settings.GetReprocessSkillLevel(Skills.JaspetProcessing);
                txtKernite.Tag = settings.GetReprocessSkillLevel(Skills.KerniteProcessing);
                txtMercoxit.Tag = settings.GetReprocessSkillLevel(Skills.MercoxitProcessing);
                txtOmber.Tag = settings.GetReprocessSkillLevel(Skills.OmberProcessing);
                txtPlagioclase.Tag = settings.GetReprocessSkillLevel(Skills.PlagioclaseProcessing);
                txtPyroxeres.Tag = settings.GetReprocessSkillLevel(Skills.PyroxeresProcessing);
                txtScordite.Tag = settings.GetReprocessSkillLevel(Skills.ScorditeProcessing);
                txtScrapmetal.Tag = settings.GetReprocessSkillLevel(Skills.ScrapmetalProcessing);
                txtSpodumain.Tag = settings.GetReprocessSkillLevel(Skills.SpodumainProcessing);
                txtVeldspar.Tag = settings.GetReprocessSkillLevel(Skills.VeldsparProcessing);
                DisplaySkillLevels();

                List<CharCorpOption> charcorps = UserAccount.CurrentGroup.GetCharCorpOptions(true);
                cmbDefaultReprocessor.DisplayMember = "Name";
                cmbDefaultReprocessor.ValueMember = "Data";
                charcorps.Sort();
                cmbDefaultReprocessor.DataSource = charcorps;
                cmbDefaultReprocessor.SelectedIndexChanged += new EventHandler(cmbDefaultReprocessor_SelectedIndexChanged);
                cmbDefaultReprocessor.SelectedIndex = 0;

                _recentStations = UserAccount.CurrentGroup.Settings.RecentStations;
                _recentStations.Sort();
                AutoCompleteStringCollection stations = new AutoCompleteStringCollection();
                stations.AddRange(_recentStations.ToArray());
                txtStation.AutoCompleteCustomSource = stations;
                txtStation.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtStation.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtStation.Leave += new EventHandler(txtStation_Leave);
                txtStation.KeyDown += new KeyEventHandler(txtStation_KeyDown);
                txtStation.Tag = 0;

                txtStation.Tag = UserAccount.CurrentGroup.Settings.ReprocessStation;
                EveDataSet.staStationsRow stationData = Stations.GetStation((int)txtStation.Tag);
                if (stationData != null)
                {
                    txtStation.Text = stationData.stationName;
                    SetSelectedStation();
                }
                else
                {
                    txtStation.Tag = 0;
                    txtStation.Text = "";
                    SetSelectedStation();
                }

                txtTheyTake.Tag = UserAccount.CurrentGroup.Settings.ReprocessStationWillTakePerc;
                txtTheyTake.Text = txtTheyTake.Tag.ToString() + " %";
                txtTheyTake.Enter += new EventHandler(txtTheyTake_Enter);
                txtTheyTake.Leave += new EventHandler(txtTheyTake_Leave);

                txtRefineLvl.Leave += new EventHandler(SkillField_Leave);
                txtRefineEfficiencyLvl.Leave += new EventHandler(SkillField_Leave);
                txtArkonor.Leave += new EventHandler(SkillField_Leave);
                txtBistot.Leave += new EventHandler(SkillField_Leave);
                txtCrokite.Leave += new EventHandler(SkillField_Leave);
                txtDarkOchre.Leave += new EventHandler(SkillField_Leave);
                txtGneiss.Leave += new EventHandler(SkillField_Leave);
                txtHedbergite.Leave += new EventHandler(SkillField_Leave);
                txtHemorphite.Leave += new EventHandler(SkillField_Leave);
                txtJaspet.Leave += new EventHandler(SkillField_Leave);
                txtKernite.Leave += new EventHandler(SkillField_Leave);
                txtMercoxit.Leave += new EventHandler(SkillField_Leave);
                txtOmber.Leave += new EventHandler(SkillField_Leave);
                txtPlagioclase.Leave += new EventHandler(SkillField_Leave);
                txtPyroxeres.Leave += new EventHandler(SkillField_Leave);
                txtScordite.Leave += new EventHandler(SkillField_Leave);
                txtScrapmetal.Leave += new EventHandler(SkillField_Leave);
                txtSpodumain.Leave += new EventHandler(SkillField_Leave);
                txtVeldspar.Leave += new EventHandler(SkillField_Leave);

                if (settings.ReprocessImplantPerc == 0)
                {
                    rdbNoImplant.Checked = true;
                }
                else if (settings.ReprocessImplantPerc == 1)
                {
                    rdbH40.Checked = true;
                }
                else if (settings.ReprocessImplantPerc == 2)
                {
                    rdbH50.Checked = true;
                }
                else if (settings.ReprocessImplantPerc == 4)
                {
                    rdbH60.Checked = true;
                }
                rdbNoImplant.CheckedChanged += new EventHandler(Implant_Changed);
                rdbH40.CheckedChanged += new EventHandler(Implant_Changed);
                rdbH50.CheckedChanged += new EventHandler(Implant_Changed);
                rdbH60.CheckedChanged += new EventHandler(Implant_Changed);

                this.FormClosing += new FormClosingEventHandler(ReprocessSettings_FormClosing);
                RecalcValues();
            }
            catch (Exception ex)
            {
                EMMAException emmaEx = ex as EMMAException;
                if (emmaEx == null)
                {
                    new EMMAException(ExceptionSeverity.Error, "Problem loading reprocessor settings form", ex);
                }
                MessageBox.Show("Problem loading reprocessor settings form:\r\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ReprocessSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            UserAccount.CurrentGroup.Settings.RecentStations = _recentStations;
        }

        void txtTheyTake_Leave(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            try
            {
                try
                {
                    field.Tag = float.Parse(field.Text);
                }
                catch
                {
                    field.Tag = 0;
                }


                txtTheyTake.Text = field.Tag.ToString() + " %";
            }
            catch { }
        }

        void txtTheyTake_Enter(object sender, EventArgs e)
        {
            TextBox field = sender as TextBox;
            try
            {
                float data = (float)field.Tag;
                field.Text = data.ToString();
            }
            catch { }
        }

        void SkillField_Leave(object sender, EventArgs e)
        {
            int tmp = 0;
            TextBox obj = sender as TextBox;
            try
            {
                tmp = int.Parse(obj.Text);
                if (tmp < 0) tmp = 0;
                if (tmp > 5) tmp = 5;
            }
            catch { }
            obj.Tag = tmp;
            obj.Text = tmp.ToString();
            RecalcValues();
        }

        void Implant_Changed(object sender, EventArgs e)
        {
            RecalcValues();
        }

        void cmbDefaultReprocessor_SelectedIndexChanged(object sender, EventArgs e)
        {
            _lastStation = "";
            SetSelectedStation();
        }

        void txtStation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                SetSelectedStation();
            }
        }

        void txtStation_Leave(object sender, EventArgs e)
        {
            SetSelectedStation();
        }

        private void SetSelectedStation()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!txtStation.Text.Equals(_lastStation))
                {
                    txtStation.Tag = 0;
                    if (!txtStation.Text.Equals(""))
                    {
                        try
                        {
                            EveDataSet.staStationsRow station = Stations.GetStation(txtStation.Text);
                            if (station != null)
                            {
                                txtStation.Tag = station.stationID;
                                string name = station.stationName;
                                txtStation.Text = name;
                                if (!_recentStations.Contains(name))
                                {
                                    _recentStations.Add(name);
                                    txtStation.AutoCompleteCustomSource.Add(name);
                                }
                                _baseYield = (float)station.reprocessingEfficiency * 100.0f;
                                lblStationYield.Text = "Base Yield = " + _baseYield + " %";
                                _standing = (float)Standings.GetStanding(
                                    ((CharCorp)cmbDefaultReprocessor.SelectedValue).ID,
                                    station.corporationID);
                                string corpName = "Unknown Corp (" + station.corporationID + ")";
                                try
                                {
                                    corpName = Names.GetName(station.corporationID);
                                }
                                catch (EMMADataMissingException) { }
                                lblStanding.Text = "Standing with " + corpName + " is " + _standing;
                                txtTheyTake.Tag = station.IsreprocessingStationsTakeNull() ?
                                    100 : (float)((station.reprocessingStationsTake * 100.0f) - (0.75 * _standing));
                                if ((float)txtTheyTake.Tag < 0) { txtTheyTake.Tag = 0.0f; }
                                txtTheyTake.Text = txtTheyTake.Tag.ToString() + " %"; 
                            }
                        }
                        catch (EMMADataException) { }

                        _lastStation = txtStation.Text;
                    }

                    if ((int)txtStation.Tag == 0) 
                    { 
                        txtStation.Text = "";
                        lblStationYield.Text = "Base Yield = ??";
                        lblStanding.Text = "Standing with ?? is ??";
                        txtTheyTake.Text = "0";
                        _baseYield = 0;
                        _standing = 0;
                        txtTheyTake.Tag = 0;
                    }
                    RecalcValues();
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void RecalcValues()
        {
            int displayedAccuracy = 6;
            lblArkonor.Text = "(" + Math.Round(GetReprocessPerc((int)txtArkonor.Tag), displayedAccuracy) + " %)";
            lblBistot.Text = "(" + Math.Round(GetReprocessPerc((int)txtBistot.Tag), displayedAccuracy) + " %)";
            lblCrokite.Text = "(" + Math.Round(GetReprocessPerc((int)txtCrokite.Tag), displayedAccuracy) + " %)";
            lblDarkOchre.Text = "(" + Math.Round(GetReprocessPerc((int)txtDarkOchre.Tag), displayedAccuracy) + " %)";
            lblGneiss.Text = "(" + Math.Round(GetReprocessPerc((int)txtGneiss.Tag), displayedAccuracy) + " %)";
            lblHedbergite.Text = "(" + Math.Round(GetReprocessPerc((int)txtHedbergite.Tag), displayedAccuracy) + " %)";
            lblHemorphite.Text = "(" + Math.Round(GetReprocessPerc((int)txtHemorphite.Tag), displayedAccuracy) + " %)";
            lblJaspet.Text = "(" + Math.Round(GetReprocessPerc((int)txtJaspet.Tag), displayedAccuracy) + " %)";
            lblKernite.Text = "(" + Math.Round(GetReprocessPerc((int)txtKernite.Tag), displayedAccuracy) + " %)";
            lblMercoxit.Text = "(" + Math.Round(GetReprocessPerc((int)txtMercoxit.Tag), displayedAccuracy) + " %)";
            lblOmber.Text = "(" + Math.Round(GetReprocessPerc((int)txtOmber.Tag), displayedAccuracy) + " %)";
            lblPlagioclase.Text = "(" + Math.Round(GetReprocessPerc((int)txtPlagioclase.Tag), displayedAccuracy) + " %)";
            lblPyroxeres.Text = "(" + Math.Round(GetReprocessPerc((int)txtPyroxeres.Tag), displayedAccuracy) + " %)";
            lblScordite.Text = "(" + Math.Round(GetReprocessPerc((int)txtScordite.Tag), displayedAccuracy) + " %)";
            lblScrapmetal.Text = "(" + Math.Round(GetReprocessPerc((int)txtScrapmetal.Tag), displayedAccuracy) + " %)";
            lblSpodumain.Text = "(" + Math.Round(GetReprocessPerc((int)txtSpodumain.Tag), displayedAccuracy) + " %)";
            lblVeldspar.Text = "(" + Math.Round(GetReprocessPerc((int)txtVeldspar.Tag), displayedAccuracy) + " %)";
        }

        private double GetReprocessPerc(int specificSkillLevel)
        {
            float implantMod = 0;
            if (rdbH40.Checked)
            {
                implantMod = 0.01f;
            }
            else if (rdbH50.Checked)
            {
                implantMod = 0.02f;
            }
            else if (rdbH60.Checked)
            {
                implantMod = 0.04f;
            }
            double percentage = (_baseYield / 100) + 
                (0.375 * 
                (1 + ((int)txtRefineLvl.Tag * 0.02f)) * 
                (1 + ((int)txtRefineEfficiencyLvl.Tag * 0.04f)) *
                (1 + (specificSkillLevel * 0.05)) *
                (1 + implantMod));
            percentage *= 100;
            if (percentage > 100) percentage = 100;
            return percentage;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ReportGroupSettings settings = UserAccount.CurrentGroup.Settings;
            settings.ReprocessCharacter = ((CharCorp)cmbDefaultReprocessor.SelectedValue).ID;
            int implantMod = 0;
            if (rdbH40.Checked)
            {
                implantMod = 1;
            }
            else if (rdbH50.Checked)
            {
                implantMod = 2;
            }
            else if (rdbH60.Checked)
            {
                implantMod = 4;
            }
            settings.ReprocessImplantPerc = implantMod;
            settings.ReprocessStation = (int)txtStation.Tag;
            settings.ReprocessStationYieldPerc = _baseYield;
            settings.ReprocessStationWillTakePerc = (float)txtTheyTake.Tag;
            settings.SetReprocessSkillLevel(Skills.Refining, (int)txtRefineLvl.Tag);
            settings.SetReprocessSkillLevel(Skills.RefineryEfficiency, (int)txtRefineEfficiencyLvl.Tag);
            settings.SetReprocessSkillLevel(Skills.ArkonorProcessing, (int)txtArkonor.Tag);
            settings.SetReprocessSkillLevel(Skills.BistotProcessing, (int)txtBistot.Tag);
            settings.SetReprocessSkillLevel(Skills.CrokiteProcessing, (int)txtCrokite.Tag);
            settings.SetReprocessSkillLevel(Skills.DarkOchreProcessing, (int)txtDarkOchre.Tag);
            settings.SetReprocessSkillLevel(Skills.GneissProcessing, (int)txtGneiss.Tag);
            settings.SetReprocessSkillLevel(Skills.HedbergiteProcessing, (int)txtHedbergite.Tag);
            settings.SetReprocessSkillLevel(Skills.HemorphiteProcessing, (int)txtHemorphite.Tag);
            settings.SetReprocessSkillLevel(Skills.JaspetProcessing, (int)txtJaspet.Tag);
            settings.SetReprocessSkillLevel(Skills.KerniteProcessing, (int)txtKernite.Tag);
            settings.SetReprocessSkillLevel(Skills.MercoxitProcessing, (int)txtMercoxit.Tag);
            settings.SetReprocessSkillLevel(Skills.OmberProcessing, (int)txtOmber.Tag);
            settings.SetReprocessSkillLevel(Skills.PlagioclaseProcessing, (int)txtPlagioclase.Tag);
            settings.SetReprocessSkillLevel(Skills.PyroxeresProcessing, (int)txtPyroxeres.Tag);
            settings.SetReprocessSkillLevel(Skills.ScorditeProcessing, (int)txtScordite.Tag);
            settings.SetReprocessSkillLevel(Skills.ScrapmetalProcessing, (int)txtScrapmetal.Tag);
            settings.SetReprocessSkillLevel(Skills.SpodumainProcessing, (int)txtSpodumain.Tag);
            settings.SetReprocessSkillLevel(Skills.VeldsparProcessing, (int)txtVeldspar.Tag);

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void btnUpdateSkills_Click(object sender, EventArgs e)
        {
            if (cmbDefaultReprocessor.SelectedItem != null)
            {
                APICharacter charData = ((CharCorpOption)cmbDefaultReprocessor.SelectedItem).CharacterObj;
                charData.RefreshCharXMLFromAPI();
                txtRefineLvl.Tag = charData.GetSkillLvl(Skills.Refining);
                txtRefineEfficiencyLvl.Tag = charData.GetSkillLvl(Skills.RefineryEfficiency);
                txtArkonor.Tag = charData.GetSkillLvl(Skills.ArkonorProcessing);
                txtBistot.Tag = charData.GetSkillLvl(Skills.BistotProcessing);
                txtCrokite.Tag = charData.GetSkillLvl(Skills.CrokiteProcessing);
                txtDarkOchre.Tag = charData.GetSkillLvl(Skills.DarkOchreProcessing);
                txtGneiss.Tag = charData.GetSkillLvl(Skills.GneissProcessing);
                txtHedbergite.Tag = charData.GetSkillLvl(Skills.HedbergiteProcessing);
                txtHemorphite.Tag = charData.GetSkillLvl(Skills.HemorphiteProcessing);
                txtJaspet.Tag = charData.GetSkillLvl(Skills.JaspetProcessing);
                txtKernite.Tag = charData.GetSkillLvl(Skills.KerniteProcessing);
                txtMercoxit.Tag = charData.GetSkillLvl(Skills.MercoxitProcessing);
                txtOmber.Tag = charData.GetSkillLvl(Skills.OmberProcessing);
                txtPlagioclase.Tag = charData.GetSkillLvl(Skills.PlagioclaseProcessing);
                txtPyroxeres.Tag = charData.GetSkillLvl(Skills.PyroxeresProcessing);
                txtScordite.Tag = charData.GetSkillLvl(Skills.ScorditeProcessing);
                txtScrapmetal.Tag = charData.GetSkillLvl(Skills.ScrapmetalProcessing);
                txtSpodumain.Tag = charData.GetSkillLvl(Skills.SpodumainProcessing);
                txtVeldspar.Tag = charData.GetSkillLvl(Skills.VeldsparProcessing);
                DisplaySkillLevels();
                RecalcValues();
            }
            else
            {
                MessageBox.Show("Please select a default reprocessor before updating skills.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplaySkillLevels()
        {
            txtRefineLvl.Text = txtRefineLvl.Tag.ToString();
            txtRefineEfficiencyLvl.Text = txtRefineEfficiencyLvl.Tag.ToString();
            txtArkonor.Text = txtArkonor.Tag.ToString();
            txtBistot.Text = txtBistot.Tag.ToString();
            txtCrokite.Text = txtCrokite.Tag.ToString();
            txtDarkOchre.Text = txtDarkOchre.Tag.ToString();
            txtGneiss.Text = txtGneiss.Tag.ToString();
            txtHedbergite.Text = txtHedbergite.Tag.ToString();
            txtHemorphite.Text = txtHemorphite.Tag.ToString();
            txtJaspet.Text = txtJaspet.Tag.ToString();
            txtKernite.Text = txtKernite.Tag.ToString();
            txtMercoxit.Text = txtMercoxit.Tag.ToString();
            txtOmber.Text = txtOmber.Tag.ToString();
            txtPlagioclase.Text = txtPlagioclase.Tag.ToString();
            txtPyroxeres.Text = txtPyroxeres.Tag.ToString();
            txtScordite.Text = txtScordite.Tag.ToString();
            txtScrapmetal.Text = txtScrapmetal.Tag.ToString();
            txtSpodumain.Text = txtSpodumain.Tag.ToString();
            txtVeldspar.Text = txtVeldspar.Tag.ToString();
        }

    }
}