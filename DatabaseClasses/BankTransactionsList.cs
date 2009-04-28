using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class BankTransactionsList : SortableCollection
    {
        public BankTransactionsList()
        {
            this.ItemType = typeof(BankTransaction);
        }

        public new BankTransaction this[int index]
        {
            get
            {
                return (BankTransaction)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new BankTransactionsList GetChanges()
        {
            return (BankTransactionsList)base.GetChanges();
        }
    
    }
}
