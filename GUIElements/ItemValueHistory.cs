using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using ZedGraph;

using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.Common;


namespace EveMarketMonitorApp.GUIElements
{
    public partial class ItemValueHistory : Form
    {
        private List<string> _recentItems = new List<string>();
        private string _lastItem = "";


        public ItemValueHistory()
        {
            InitializeComponent();
        }

        private void ItemValueHistory_Load(object sender, EventArgs e)
        {
            try
            {
                GraphPane pane = priceHistoryGraph.GraphPane;
                pane.Title.Text = "Item price history";
                
                _recentItems = UserAccount.CurrentGroup.Settings.RecentItems;
                _recentItems.Sort();
                AutoCompleteStringCollection items = new AutoCompleteStringCollection();
                items.AddRange(_recentItems.ToArray());
                txtItem.AutoCompleteCustomSource = items;
                txtItem.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtItem.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtItem.Leave += new EventHandler(txtItem_Leave);
                txtItem.KeyDown += new KeyEventHandler(txtItem_KeyDown);
                txtItem.Tag = 0;
                txtItem.Text = "";

                EveDataSet.mapRegionsDataTable regions = Regions.GetAllRegions();
                EveDataSet.mapRegionsRow allRegions = regions.NewmapRegionsRow();
                allRegions.regionID = 0;
                allRegions.regionName = "Any Region";
                regions.AddmapRegionsRow(allRegions);
                cmbRegion.DataSource = regions;
                cmbRegion.ValueMember = "regionID";
                cmbRegion.DisplayMember = "regionName";
                cmbRegion.SelectedValue = 0;
                cmbRegion.SelectedValueChanged += new EventHandler(cmbRegion_SelectedValueChanged);
            }
            catch (Exception ex)
            {
                EMMAException emmaEx = ex as EMMAException;
                if (emmaEx == null)
                {
                    emmaEx = new EMMAException(ExceptionSeverity.Error, "Problem loading grid calculator: " +
                        ex.Message, ex);
                }
                MessageBox.Show("Problem loading grid calculator: " + ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void cmbRegion_SelectedValueChanged(object sender, EventArgs e)
        {
            RefreshGraph();
        }

        void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                SetSelectedItem();
                RefreshGraph();
            }
        }

        void txtItem_Leave(object sender, EventArgs e)
        {
            SetSelectedItem();
            RefreshGraph();
        }

        private void SetSelectedItem()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                if (!txtItem.Text.Equals(_lastItem))
                {
                    txtItem.Tag = 0;
                    if (!txtItem.Text.Equals(""))
                    {
                        try
                        {
                            EveDataSet.invTypesRow item = Items.GetItem(txtItem.Text);
                            if (item != null)
                            {
                                txtItem.Tag = item.typeID;
                                string name = item.typeName;
                                txtItem.Text = name;
                                if (!_recentItems.Contains(name))
                                {
                                    _recentItems.Add(name);
                                    txtItem.AutoCompleteCustomSource.Add(name);
                                }
                            }
                        }
                        catch (EMMADataException) { }

                        _lastItem = txtItem.Text;
                    }

                    if ((int)txtItem.Tag == 0)
                    {
                        txtItem.Text = "";
                    }
                }
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void RefreshGraph()
        {
            int itemID = 0;
            int regionID = 0;

            if (txtItem.Tag != null)
            {
                itemID = (int)txtItem.Tag;
            }
            if (cmbRegion.SelectedValue != null)
            {
                regionID = (int)cmbRegion.SelectedValue;
            }

            if (itemID != 0)
            {
                EveDataSet.invTypesRow item = Items.GetItem(itemID);
                string regionName = "New Eden";
                if (regionID != 0)
                {
                    regionName = Regions.GetRegionName(regionID);
                }
                GraphPane pane = priceHistoryGraph.GraphPane;

                pane.Title.Text = item.typeName + " price history in " + regionName;
                pane.XAxis.Title.Text = "Time";
                pane.YAxis.Title.Text = "Price";

                //PointPairList buyPrice;
                //PointPairList sellPrice;
                //PointPairList buyWebPrice;
                //PointPairList sellWebPrice;


            }
            else
            {
                //clear graph data
            }
        }

        private void ItemValueHistory_Resize(object sender, EventArgs e)
        {
            // Leave a small margin around the outside of the control
            //zedGraphControl1.Size = new Size(ClientRectangle.Width - 20,
            //                        ClientRectangle.Height - 20);
        }
    }
}