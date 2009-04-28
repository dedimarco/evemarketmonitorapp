using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    class ReprocessResultList : SortableCollection
    {
        public ReprocessResultList()
		{
			this.ItemType = typeof(ReprocessResult);
		}

        public new ReprocessResult this[int index] 
		{
			get 
			{
                return (ReprocessResult)(base[index]);
			}
			set 
			{
				base[index] = value;
			}
		}

        public new ReprocessResultList GetChanges()
		{
            return (ReprocessResultList)base.GetChanges();
		}
    }
}
