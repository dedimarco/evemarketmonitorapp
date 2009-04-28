using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class ContractList : SortableCollection
    {
        public ContractList()
        {
            this.ItemType = typeof(Contract);
        }

        public new Contract this[int index]
        {
            get
            {
                return (Contract)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new ContractList GetChanges()
        {
            return (ContractList)base.GetChanges();
        }

    }



    public class ContractItemList : SortableCollection
    {
        public ContractItemList()
        {
            this.ItemType = typeof(ContractItem);
        }

        public new ContractItem this[int index]
        {
            get
            {
                return (ContractItem)(base[index]);
            }
            set
            {
                base[index] = value;
            }
        }

        public new ContractItemList GetChanges()
        {
            return (ContractItemList)base.GetChanges();
        }

    }

}
