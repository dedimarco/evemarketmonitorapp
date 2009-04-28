using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class WebLinkList: SortableCollection
    {
        public WebLinkList()
        {
            this.ItemType = typeof(WebLink);
        }

        public new WebLink this[int index]
        {
            get
            {
                return (WebLink)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new WebLinkList GetChanges()
        {
            return (WebLinkList)base.GetChanges();
        }
    }
}
