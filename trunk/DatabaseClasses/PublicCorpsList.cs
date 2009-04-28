using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class PublicCorpsList : SortableCollection
    {
        public PublicCorpsList()
        {
            this.ItemType = typeof(PublicCorp);
        }

        public new PublicCorp this[int index]
        {
            get
            {
                return (PublicCorp)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new PublicCorpsList GetChanges()
        {
            return (PublicCorpsList)base.GetChanges();
        }
    }
}
