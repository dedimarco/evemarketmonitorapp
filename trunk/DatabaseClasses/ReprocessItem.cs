using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    class ReprocessItem : SortableObject
    {
        private int _jobID;
        private int _itemID;
        private bool _gotItem = false;
        private string _itemName = "";
        private long _quantity;
        private decimal _buyPrice;

        public ReprocessItem(EMMADataSet.ReprocessItemRow data)
        {
            _jobID = data.JobID;
            _itemID = data.ItemID;
            _quantity = data.Quantity;
            _buyPrice = data.BuyPrice;
        }

        public ReprocessItem(int jobID, int itemID, long quantity, decimal buyPrice)
        {
            _jobID = jobID;
            _itemID = itemID;
            _quantity = quantity;
            _buyPrice = buyPrice;
        }

        public int JobID
        {
            get { return _jobID; }
            set { _jobID = value; }
        }

        public string Item
        {
            get
            {
                if (!_gotItem)
                {
                    try
                    {
                        _itemName = Items.GetItemName(_itemID);
                    }
                    catch (EMMADataMissingException)
                    {
                        _itemName = "Unknown Item";
                    }
                    _gotItem = true;
                }
                return _itemName; 
            }
            set { _itemName = value; }
        }

        public int ItemID
        {
            get { return _itemID; }
            set
            {
                _itemID = value;
                _gotItem = false;
                _itemName = "";
            }
        }

        public long Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal BuyPrice
        {
            get { return _buyPrice; }
            set { _buyPrice = value; }
        }
    }
}
