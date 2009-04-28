using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class GroupLocationsList : SortableCollection
    {
        public GroupLocationsList()
        {
            this.ItemType = typeof(GroupLocation);
        }

        public new GroupLocation this[int index]
        {
            get
            {
                return (GroupLocation)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new GroupLocationsList GetChanges()
        {
            return (GroupLocationsList)base.GetChanges();
        }
    
    }
}
