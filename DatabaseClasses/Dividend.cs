using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class Dividend : SortableObject
    {
        private int _id;
        private DateTime _divDate;
        private decimal _sharePayout;
        private int _corpID;
        private bool _gotCorp = false;
        private PublicCorp _corp;

        public Dividend(int corpID)
        {
            _id = 0;
            _divDate = DateTime.Now;
            _sharePayout = 0;
            _corpID = corpID;
        }

        public Dividend(EMMADataSet.DividendsRow data)
        {
            _id = data.DividendID;
            _divDate = data.DateTime;
            if (UserAccount.Settings.UseLocalTimezone)
            {
                _divDate = _divDate.AddHours(Globals.HoursOffset);
            }
            _sharePayout = data.PayoutPerShare;
            _corpID = data.CorpID;
        }

        public EMMADataSet.DividendsRow GetAsDataRow()
        {
            EMMADataSet.DividendsDataTable table = new EMMADataSet.DividendsDataTable();
            EMMADataSet.DividendsRow retVal = table.NewDividendsRow();
            retVal.DividendID = _id;
            retVal.DateTime = _divDate.AddHours(-1 * Globals.HoursOffset);
            retVal.PayoutPerShare = _sharePayout;
            retVal.CorpID = _corpID;
            // need to add this row to the table otherwise it will be in a 'detached' state
            table.AddDividendsRow(retVal);
            return retVal;
        }

        public int ID
        {
            get { return _id; }
        }

        public DateTime Date
        {
            get { return _divDate; }
            set { _divDate = value; }
        }

        public decimal PayoutPerShare
        {
            get { return _sharePayout; }
            set { _sharePayout = value; }
        }

        public int CorpID
        {
            get { return _corpID; }
            set { _corpID = value; }
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
                if (_corp != null)
                {
                    name = _corp.Name;
                }
                return name;
            }
        }


    }
}
