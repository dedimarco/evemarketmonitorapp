using System;
using System.Collections.Generic;
using System.Text;

namespace EveMarketMonitorApp.Common
{
    public class HList<T> : List<T>
    {
        public override int GetHashCode()
        {
            StringBuilder str = new StringBuilder();

            foreach (T item in this)
            {
                if (item != null)
                {
                    str.Append(item.GetHashCode());
                }
            }

            return str.ToString().GetHashCode();
        }
    }
}
