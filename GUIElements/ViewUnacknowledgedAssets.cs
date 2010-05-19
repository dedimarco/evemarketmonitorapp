﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using EveMarketMonitorApp.DatabaseClasses;
using EveMarketMonitorApp.AbstractionClasses;
using EveMarketMonitorApp.Common;


namespace EveMarketMonitorApp.GUIElements
{
    public delegate void AssetChangesAcknowledgedHandler(object myObject, EventArgs args);



    public partial class ViewUnacknowledgedAssets : Form, IProvideStatus
    {
        private AssetList _lostAssets = null;
        private AssetList _gainedAssets = null;
        private List<AssetChangeType> _assetGainChangeTypes = null;
        private List<AssetChangeType> _assetLossChangeTypes = null;

        private Dictionary<TempAssetKey, List<TempAssetKey>> _assetsUsedForManufacture =
            new Dictionary<TempAssetKey, List<TempAssetKey>>();

        public event AssetChangesAcknowledgedHandler AssetChangesAcknowledged; 
        private delegate void Callback();

        private static StatusChangeArgs _status;

        #region IProvideStatus Members
        public event StatusChangeHandler StatusChange;
        #endregion


        public ViewUnacknowledgedAssets()
        {
            InitializeComponent();

            UserAccount.Settings.GetFormSizeLoc(this);
            UserAccount.Settings.GetColumnWidths(this.Name, gainedItemsGrid);
            UserAccount.Settings.GetColumnWidths(this.Name, lostItemsGrid);
            this.FormClosing += new FormClosingEventHandler(ViewUnacknowledgedAssets_FormClosing);

            lblBusy.Hide();
        }

        private void ViewUnacknowledgedAssets_Load(object sender, EventArgs e)
        {
            try
            {
                CrossCheckAssetChanges();

                _assetGainChangeTypes = AssetChangeTypes.GetAllChangeTypes(AssetChangeTypes.ChangeMetaType.Gain);
                _assetLossChangeTypes = AssetChangeTypes.GetAllChangeTypes(AssetChangeTypes.ChangeMetaType.Loss);

                gainedItemsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                gainedItemsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                gainedItemsGrid.AutoGenerateColumns = false;
                GainedOwnerColumn.DataPropertyName = "Owner";
                GainedItemColumn.DataPropertyName = "Item";
                GainedLocationColumn.DataPropertyName = "Location";
                GainedQuantityColumn.DataPropertyName = "Quantity";
                GainedReasonColumn.DataPropertyName = "ChangeTypeID";
                GainedReasonColumn.DataSource = _assetGainChangeTypes;
                GainedReasonColumn.ValueMember = "ID";
                GainedReasonColumn.DisplayMember = "Description";
                GainedReasonColumn.ReadOnly = false;
                gainedItemsGrid.CellEndEdit += new DataGridViewCellEventHandler(gainedItemsGrid_CellEndEdit);
                gainedItemsGrid.CellBeginEdit += new DataGridViewCellCancelEventHandler(itemsGrid_CellBeginEdit);


                lostItemsGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                lostItemsGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                lostItemsGrid.AutoGenerateColumns = false;
                LostOwnerColumn.DataPropertyName = "Owner";
                LostItemColumn.DataPropertyName = "Item";
                LostLocationColumn.DataPropertyName = "Location";
                LostQuantityColumn.DataPropertyName = "Quantity";
                LostReasonColumn.DataPropertyName = "ChangeTypeID";
                LostReasonColumn.DataSource = _assetLossChangeTypes;
                LostReasonColumn.ValueMember = "ID";
                LostReasonColumn.DisplayMember = "Description";
                LostReasonColumn.ReadOnly = false;
                lostItemsGrid.CellBeginEdit += new DataGridViewCellCancelEventHandler(itemsGrid_CellBeginEdit);
            }
            catch (Exception ex)
            {
                EMMAException emmaEx = ex as EMMAException;
                if (emmaEx == null)
                {
                    new EMMAException(ExceptionSeverity.Error, "Problem loading unacknowledged assets view", ex);
                }
                MessageBox.Show("Problem loading unacknowledged assets view:\r\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowData()
        {
            btnOk.Enabled = true;

            lblBusy.Hide();
            busyProgress.Hide();

            lostItemsGrid.DataSource = _lostAssets;
            gainedItemsGrid.DataSource = _gainedAssets;
            lostItemsGrid.Enabled = true;
            gainedItemsGrid.Enabled = true;
        }
        private void HideData()
        {
            btnOk.Enabled = false;

            lblBusy.BringToFront();
            lblBusy.Font = new Font(lblBusy.Font.FontFamily, 20, FontStyle.Bold);
            lblBusy.Dock = DockStyle.Fill;
            lblBusy.BackColor = Color.Transparent;
            lblBusy.Text = "Busy";
            lblBusy.Show();

            busyProgress.BringToFront();
            busyProgress.Value = 0;
            busyProgress.Maximum = 1;
            busyProgress.Show();

            lostItemsGrid.Enabled = false;
            gainedItemsGrid.Enabled = false;
            lostItemsGrid.DataSource = null;
            gainedItemsGrid.DataSource = null;
        }

        void ViewUnacknowledgedAssets_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnOk.Enabled)
            {
                e.Cancel = true;
            }
            else
            {
                if (UserAccount.Settings != null)
                {
                    UserAccount.Settings.StoreFormSizeLoc(this);
                    UserAccount.Settings.StoreColumnWidths(this.Name, gainedItemsGrid);
                    UserAccount.Settings.StoreColumnWidths(this.Name, lostItemsGrid);
                }
            }
        }


        public void CrossCheckAssetChanges()
        {
            if (!this.InvokeRequired)
            {
                // Only do this if we are not in manufacturing mode
                if (!UserAccount.Settings.ManufacturingMode)
                {
                    this.StatusChange += new StatusChangeHandler(ViewUnacknowledgedAssets_StatusChange);

                    Thread t0 = new Thread(new ThreadStart(CrossCheckAssetChanges));
                    t0.Start();
                }
            }
            else 
            {
                DoCrossCheck();

                this.StatusChange -= new StatusChangeHandler(ViewUnacknowledgedAssets_StatusChange);
            }
        }

        private void DoCrossCheck()
        {
            // Only allow one of these checks to be running at once. If a later check 
            // attempts to start then it must wait for the current one to finish and then run.
            lock (_lostAssets)
            {
                this.Invoke(new Callback(HideData));

                try
                {
                    if (_lostAssets == null) { _lostAssets = new AssetList(); }
                    if (_gainedAssets == null) { _gainedAssets = new AssetList(); }

                    // Build complete lists of unacknowledged gained/lost assets for all 
                    // characters and corps within the report group.
                    foreach (EVEAccount account in UserAccount.CurrentGroup.Accounts)
                    {
                        foreach (APICharacter character in account.Chars)
                        {
                            if (character.UnacknowledgedGains != null && character.UnacknowledgedGains.Count > 0)
                            {
                                _gainedAssets.Add(character.UnacknowledgedGains);
                                character.UnacknowledgedGains = null;
                            }
                            if (character.CorpUnacknowledgedGains != null && character.CorpUnacknowledgedGains.Count > 0)
                            {
                                _gainedAssets.Add(character.CorpUnacknowledgedGains);
                                character.CorpUnacknowledgedGains = null;
                            }
                            if (character.UnacknowledgedLosses != null && character.UnacknowledgedLosses.Count > 0)
                            {
                                _lostAssets.Add(character.UnacknowledgedLosses);
                                character.UnacknowledgedLosses = null;
                            }
                            if (character.CorpUnacknowledgedLosses != null && character.CorpUnacknowledgedLosses.Count > 0)
                            {
                                _lostAssets.Add(character.CorpUnacknowledgedLosses);
                                character.CorpUnacknowledgedLosses = null;
                            }
                        }
                    }

                    EMMADataSet.AssetsDataTable assetChanges = new EMMADataSet.AssetsDataTable();

                    // Try and match one character/corp gains to anothers losses.
                    List<int> gIndiciesToRemove = new List<int>();
                    for (int i = 0; i < _gainedAssets.Count; i++)
                    {
                        UpdateStatus(i, _gainedAssets.Count, "", "", false);

                        Asset gainedAsset = _gainedAssets[i];
                        decimal totalCost = 0;
                        long qRemaining = gainedAsset.Quantity;
                        _lostAssets.ItemFilter = "ItemID = " + gainedAsset.ItemID;
                        List<int> indiciesToRemove = new List<int>();
                        for (int j = 0; j < _lostAssets.FiltredItems.Count; j++)
                        {
                            Asset lostAsset = (Asset)_lostAssets.FiltredItems[j];

                            // If a match is found then use the cost of the lost items to calculate
                            // the cost of the gained items.
                            if (lostAsset.Quantity < 0 && gainedAsset.Quantity > 0)
                            {
                                long deltaQ = Math.Min(qRemaining, Math.Abs(lostAsset.Quantity));
                                totalCost += lostAsset.UnitBuyPrice * deltaQ;
                                qRemaining -= deltaQ;

                                lostAsset.Quantity += deltaQ;
                            }
                            if (lostAsset.Quantity == 0) { indiciesToRemove.Add(j); }
                        }
                        // Remove any lost items that have been accounted for.
                        foreach (int index in indiciesToRemove)
                        {
                            _lostAssets.FiltredItems.RemoveAt(index);
                        }

                        // If we found some lost items to match against this gained item then
                        // retrieve the gained asset row from the database and recalculate
                        // the cost of the stack.
                        if (qRemaining < gainedAsset.Quantity)
                        {
                            long assetID = 0;
                            Assets.AssetExists(assetChanges, gainedAsset.OwnerID, gainedAsset.CorpAsset,
                                gainedAsset.LocationID, gainedAsset.ItemID, gainedAsset.StatusID,
                                gainedAsset.ContainerID != 0, gainedAsset.ContainerID, gainedAsset.IsContainer,
                                false, true, gainedAsset.AutoConExclude, ref assetID);
                            EMMADataSet.AssetsRow assetRow = assetChanges.FindByID(assetID);

                            long totalQ = gainedAsset.Quantity - qRemaining;
                            if (assetRow.Quantity > gainedAsset.Quantity && assetRow.CostCalc)
                            {
                                // If the asset stack contains more items than our 'gained' record
                                // and it alreay has a calculated cost then take the stack's current
                                // cost into account as well.
                                totalCost += assetRow.Cost * (assetRow.Quantity - gainedAsset.Quantity);
                                totalQ += assetRow.Quantity - gainedAsset.Quantity;
                            }
                            assetRow.Cost = totalCost / totalQ;
                            assetRow.CostCalc = true;
                        }

                        gainedAsset.Quantity = qRemaining;
                        if (gainedAsset.Quantity == 0)
                        {
                            gIndiciesToRemove.Add(i);
                        }
                    }

                    // Remove any gained items that have been accounted for.
                    foreach (int index in gIndiciesToRemove)
                    {
                        _gainedAssets.RemoveAt(index);
                    }

                    Assets.UpdateDatabase(assetChanges);

                    _lostAssets.ItemFilter = "";
                    _gainedAssets.ItemFilter = "";
                }
                catch (Exception ex)
                {
                    EMMAException emmaEx = ex as EMMAException;
                    if (emmaEx == null)
                    {
                        new EMMAException(ExceptionSeverity.Error, "Problem cross checking asset changes in " +
                            "unacknowledged assets view", ex);
                    }
                    MessageBox.Show("Problem cross checking asset changes in unacknowledged assets view:\r\n" +
                        ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Invoke(new Callback(ShowData));
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            EMMADataSet.AssetsDataTable assetChanges = new EMMADataSet.AssetsDataTable();
            foreach (Asset gainedAsset in _gainedAssets)
            {
                long assetID = 0;
                Assets.AssetExists(assetChanges, gainedAsset.OwnerID, gainedAsset.CorpAsset,
                    gainedAsset.LocationID, gainedAsset.ItemID, gainedAsset.StatusID,
                    gainedAsset.ContainerID != 0, gainedAsset.ContainerID, gainedAsset.IsContainer,
                    false, true, gainedAsset.AutoConExclude, ref assetID);
                EMMADataSet.AssetsRow assetRow = assetChanges.FindByID(assetID);

                switch (gainedAsset.ChangeTypeID)
                {
                    case AssetChangeTypes.ChangeType.Found:
                        assetRow.Cost = 0;
                        assetRow.CostCalc = true;
                        AssetsProduced.Add(gainedAsset);
                        break;
                    case AssetChangeTypes.ChangeType.Made:
                        assetRow.Cost = gainedAsset.UnitBuyPricePrecalculated ? gainedAsset.UnitBuyPrice : 0;
                        assetRow.CostCalc = gainedAsset.UnitBuyPricePrecalculated;
                        AssetsProduced.Add(gainedAsset);
                        break;
                    case AssetChangeTypes.ChangeType.Unknown:
                        break;
                    default:
                        throw new EMMAException(ExceptionSeverity.Error, "Unexpected gained asset change type: '" + 
                            gainedAsset.ChangeType + "' ", true);
                        break;
                }
            }
            foreach (Asset lostAsset in _lostAssets)
            {
                switch (lostAsset.ChangeTypeID)
                {
                    case AssetChangeTypes.ChangeType.ForSaleViaContract:
                        EMMADataSet.AssetsRow assetRow = assetChanges.NewAssetsRow();
                        assetRow.AutoConExclude = true;
                        assetRow.ContainerID = lostAsset.ContainerID;
                        assetRow.CorpAsset = lostAsset.CorpAsset;
                        assetRow.Cost = lostAsset.UnitBuyPricePrecalculated ? lostAsset.UnitBuyPrice : 0;
                        assetRow.CostCalc = lostAsset.UnitBuyPricePrecalculated;
                        assetRow.IsContainer = lostAsset.IsContainer;
                        assetRow.ItemID = lostAsset.ItemID;
                        assetRow.LocationID = lostAsset.LocationID;
                        assetRow.OwnerID = lostAsset.OwnerID;
                        assetRow.Processed = false;
                        assetRow.Quantity = lostAsset.Quantity * -1;
                        assetRow.RegionID = lostAsset.RegionID;
                        assetRow.ReprocExclude = true;
                        assetRow.Status = (int)AssetStatus.States.ForSaleViaContract;
                        assetRow.SystemID = lostAsset.SystemID;
                        assetChanges.AddAssetsRow(assetRow);
                        break;
                    case AssetChangeTypes.ChangeType.DestroyedOrUsed:
                        AssetsLost.Add(lostAsset);
                        break;
                    case AssetChangeTypes.ChangeType.Unknown:
                        break;
                    default:
                        throw new EMMAException(ExceptionSeverity.Error, "Unexpected lost asset change type: '" + 
                            lostAsset.ChangeType + "' ", true);
                        break;
                }
            }

            if (UserAccount.Settings.ManufacturingMode)
            {
                //// Need to remove assets not set to 'Unknown' first.
                DoCrossCheck();
            }

            if (AssetChangesAcknowledged != null)
            {
                AssetChangesAcknowledged(this, null);
            }
        }

        void itemsGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (gainedItemsGrid.Columns[e.ColumnIndex].Equals(GainedReasonColumn))
                {
                    Asset asset = (Asset)gainedItemsGrid.Rows[e.RowIndex].DataBoundItem;
                    e.Cancel = asset.ChangeTypeLocked;
                }
                else { e.Cancel = true; }
            }
        }

        void gainedItemsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // If the user has set a gained item to 'Made' then try and find the
            // items that were used in it's construction and calculate it's cost
            // accordingly.
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (gainedItemsGrid.Columns[e.ColumnIndex].Equals(GainedReasonColumn))
                {
                    this.Cursor = Cursors.WaitCursor;

                    try
                    {
                        Asset producedAsset = (Asset)gainedItemsGrid.Rows[e.RowIndex].DataBoundItem;
                        TempAssetKey prodAssetKey = new TempAssetKey(producedAsset.ID, producedAsset.OwnerID, 
                            producedAsset.CorpAsset);
                        if ((int)gainedItemsGrid[e.ColumnIndex, e.RowIndex].Value ==
                            (int)AssetChangeTypes.ChangeType.Made)
                        {
                            //
                            // Ideally what we want to do here is match manufactured items with
                            // materials that have been used in thier construction.
                            // However, this is made almost impossible by various factors
                            // (gained/lost stacks being mixed together, invention jobs taking 
                            // multiple runs, etc)
                            // For now, just leave it.
                            // In order to properly support manufacturers, add a manufacturing mode.
                            // This would stop EMMA from balancing losses in one place with gains
                            // elsewhere.
                            // All gained/lost items would then appear in this screen.
                            //

                        }
                        else
                        {
                            // If this item was previously set to having been made then clear the
                            // locked flag of any items that were thought to have been used in it's 
                            // construction.
                            if (_assetsUsedForManufacture.ContainsKey(prodAssetKey))
                            {
                                List<TempAssetKey> materials = _assetsUsedForManufacture[prodAssetKey];
                                foreach (TempAssetKey mat in materials)
                                {
                                    _lostAssets.ItemFilter = "ID = " + mat.AssetID + " AND OwnerID = " +
                                        mat.OwnerID + " AND CorpAsset = " + mat.ForCorp;
                                    if (_lostAssets.ItemFilter.Length > 0)
                                    {
                                        Asset materialAsset = (Asset)_lostAssets.FiltredItems[0];
                                        materialAsset.ChangeTypeLocked = false;
                                    }
                                }
                                _assetsUsedForManufacture.Remove(prodAssetKey);
                            }
                        }
                    }
                    finally
                    {
                        this.Cursor = Cursors.Default;
                    }
                }
            }
        }



        void ViewUnacknowledgedAssets_StatusChange(object myObject, StatusChangeArgs args)
        {
            _status = args;
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Callback(UpdateProgress));
            }
            else
            {
                busyProgress.Maximum = _status.MaxProgress;
                busyProgress.Value = _status.CurrentProgress;
            }
        }

        private void UpdateStatus(int progress, int maxprogress, string sectionName, string status, bool complete)
        {
            if (StatusChange != null)
            {
                StatusChange(this, new StatusChangeArgs(progress, maxprogress, sectionName, status, complete));
            }
        }


        private class TempAssetKey
        {
            private long _assetID;
            private int _ownerID;
            private bool _forCorp;

            public TempAssetKey(long assetID, int ownerID, bool forCorp)
            {
                _assetID = assetID;
                _ownerID = ownerID;
                _forCorp = forCorp;
            }

            public long AssetID
            {
                get { return _assetID; }
                set { _assetID = value; }
            }
            public int OwnerID
            {
                get { return _ownerID; }
                set { _ownerID = value; }
            }
            public bool ForCorp
            {
                get { return _forCorp; }
                set { _forCorp = value; }
            }

            public override bool Equals(object obj)
            {
                return this.GetHashCode() == obj.GetHashCode();
            }

            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

            public override string ToString()
            {
                return _assetID.ToString() + _ownerID.ToString() + _forCorp.ToString();
            }
        }
    }



}