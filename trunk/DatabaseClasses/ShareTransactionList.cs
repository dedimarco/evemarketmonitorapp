using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class ShareTransactionList: SortableCollection
    {
        public ShareTransactionList()
        {
            this.ItemType = typeof(ShareTransaction);
        }

        public new ShareTransaction this[int index]
        {
            get
            {
                return (ShareTransaction)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new ShareTransactionList GetChanges()
        {
            return (ShareTransactionList)base.GetChanges();
        }
    }
}
