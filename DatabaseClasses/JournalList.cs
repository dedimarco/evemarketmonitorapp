using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    class JournalList : SortableCollection
    {
        public JournalList()
		{
			this.ItemType = typeof(JournalEntry);
		}

        public new JournalEntry this[int index] 
		{
			get 
			{
                return (JournalEntry)(base[index]);
			}
			set 
			{
				base[index] = value;
			}
		}

        public new JournalList GetChanges()
		{
            return (JournalList)base.GetChanges();
		}
    
    }
}
