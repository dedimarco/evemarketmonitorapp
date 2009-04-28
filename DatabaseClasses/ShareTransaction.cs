using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class ShareTransaction : SortableObject
    {
        private int _id;
        private int _reportGroupID;
        private int _corpID;
        private bool _gotCorp = false;
        private PublicCorp _corp;
        private decimal _pricePerShare;
        private int _deltaQuantity;
        private DateTime _transDate;

        public ShareTransaction()
        {
            _id = 0;
            _reportGroupID = UserAccount.CurrentGroup.ID;
            _corpID = 0;
            _pricePerShare = 0;
            _deltaQuantity = 0;
            _transDate = DateTime.Now;
        }

        public ShareTransaction(EMMADataSet.ShareTransactionRow data)
        {
            _id = data.TransID;
            _reportGroupID = data.ReportGroupID;
            _corpID = data.CorpID;
            _pricePerShare = data.PricePerShare;
            _deltaQuantity = data.DeltaQuantity;
            _transDate = data.DateTime;
            if (UserAccount.Settings.UseLocalTimezone)
            {
                _transDate = _transDate.AddHours(Globals.HoursOffset);
            }
        }

        public int ID
        {
            get { return _id; }
        }

        public int ReportGroupID
        {
            get { return _reportGroupID; }
        }

        public int CorpID
        {
            get { return _corpID; }
            set
            {
                _corpID = value;
                _gotCorp = false;
            }
        }

        public string CorpName
        {
            get
            {
                string name = "";
                if (!_gotCorp)
                {
                    _corp = PublicCorps.GetCorp(_corpID);
                    _gotCorp = true;
                }
                if (_corp != null) { name = _corp.Name; }
                return name;
            }
        }

        public decimal PricePerShare
        {
            get { return _pricePerShare; }
            set { _pricePerShare = value; }
        }

        public int DeltaQuantity
        {
            get { return _deltaQuantity; }
            set { _deltaQuantity = value; }
        }

        public int Quantity
        {
            get { return Math.Abs(_deltaQuantity); }
        }

        public string Type
        {
            get { return (_deltaQuantity > 0 ? "Buy" : "Sell"); }
        }

        public DateTime TransactionDate
        {
            get { return _transDate; }
            set { _transDate = value; }
        }

    }
}
