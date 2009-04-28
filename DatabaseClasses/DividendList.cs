using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class DividendList : SortableCollection
    {
        public DividendList()
        {
            this.ItemType = typeof(Dividend);
        }

        public new Dividend this[int index]
        {
            get
            {
                return (Dividend)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new DividendList GetChanges()
        {
            return (DividendList)base.GetChanges();
        }
    
    }
}
