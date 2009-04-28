using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    class OrdersList: SortableCollection
    {
        public OrdersList()
		{
			this.ItemType = typeof(Order);
		}

        public new Order this[int index] 
		{
			get 
			{
                return (Order)(base[index]);
			}
			set 
			{
				base[index] = value;
			}
		}

        public new OrdersList GetChanges()
		{
            return (OrdersList)base.GetChanges();
		}
    }
}
