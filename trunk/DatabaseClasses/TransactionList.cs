using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class TransactionList : SortableCollection
    {
        public TransactionList()
		{
			this.ItemType = typeof(Transaction);
		}

        public new Transaction this[int index] 
		{
			get 
			{
                return (Transaction)(base[index]);
			}
			set 
			{
				base[index] = value;
			}
		}

        public new TransactionList GetChanges()
		{
            return (TransactionList)base.GetChanges();
		}
    
    }
}
