using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    class ReprocessItemList: SortableCollection
    {
        public ReprocessItemList()
		{
			this.ItemType = typeof(ReprocessItem);
		}

        public new ReprocessItem this[int index] 
		{
			get 
			{
                return (ReprocessItem)(base[index]);
			}
			set 
			{
				base[index] = value;
			}
		}

        public new ReprocessItemList GetChanges()
		{
            return (ReprocessItemList)base.GetChanges();
		}
    }
}
