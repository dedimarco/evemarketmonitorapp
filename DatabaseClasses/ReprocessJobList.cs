using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    class ReprocessJobList : SortableCollection
    {
        public ReprocessJobList()
		{
			this.ItemType = typeof(ReprocessJob);
		}

        public new ReprocessJob this[int index] 
		{
			get 
			{
                return (ReprocessJob)(base[index]);
			}
			set 
			{
				base[index] = value;
			}
		}

        public new ReprocessJobList GetChanges()
		{
            return (ReprocessJobList)base.GetChanges();
		}
    }
}
