using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class BankTransaction : SortableObject
    {
        private long _id;
        private DateTime _date;
        private int _accountID;
        private decimal _change;
        private BankTransactionType _type;

        public BankTransaction(int accountID, BankTransactionType type)
        {
            _date = DateTime.Now;
            _accountID = accountID;
            _change = 0;
            _type = type;
            _id = 0;
        }

        public BankTransaction(DateTime date, int accountID, decimal change, BankTransactionType type)
        {
            _date = date;
            _accountID = accountID;
            _change = change;
            _type = type;
            _id = 0;
        }

        public BankTransaction(EMMADataSet.BankTransactionRow data)
        {
            _id = data.TransactionID;
            _date = data.DateTime;
            if (UserAccount.Settings.UseLocalTimezone)
            {
                _date = _date.AddHours(Globals.HoursOffset);
            }
            _accountID = data.AccountID;
            _change = data.Change;
            _type = (BankTransactionType)data.Type;
        }

        public long ID
        {
            get { return _id; }
        }

        public int AccountID
        {
            get { return _accountID; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public decimal Change
        {
            get { return _change; }
            set { _change = value; }
        }

        public string TypeDescription
        {
            get { return BankTransactionTypes.GetDescription(_type); }
        }

        public BankTransactionType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public short TypeID
        {
            get { return (short)_type; }
        }
    }
}
