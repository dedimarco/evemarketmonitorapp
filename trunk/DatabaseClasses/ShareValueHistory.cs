using System;
using System.Collections.Generic;
using System.Text;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public static class ShareValueHistory
    {
        private static EMMADataSetTableAdapters.ShareValueHistoryTableAdapter tableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.ShareValueHistoryTableAdapter();

        public static EMMADataSet.ShareValueHistoryDataTable GetValueHistory(int corpID)
        {
            EMMADataSet.ShareValueHistoryDataTable table = new EMMADataSet.ShareValueHistoryDataTable();
            lock (tableAdapter)
            {
                tableAdapter.FillByCorp(table, corpID);
            }
            return table;
        }

        public static decimal GetShareValue(int corpID, DateTime date)
        {
            decimal retVal = 0;
            EMMADataSet.ShareValueHistoryDataTable table = new EMMADataSet.ShareValueHistoryDataTable();
            lock (tableAdapter)
            {
                tableAdapter.FillByDate(table, corpID, date);
            }

            if (table.Count > 0)
            {
                retVal = table[0].ShareValue;
            }
            else
            {
                retVal = PublicCorps.GetCorp(corpID).ShareValue;
            }
            return retVal;
        }

        public static void SetShareValue(int corpID, DateTime date, decimal value)
        {
            EMMADataSet.ShareValueHistoryDataTable table = new EMMADataSet.ShareValueHistoryDataTable();
            EMMADataSet.ShareValueHistoryRow rowData = null;
            lock (tableAdapter)
            {
                tableAdapter.FillByDate(table, corpID, date);
            }

            if (table.Count > 0)
            {
                if (date.CompareTo(table[0].DateTime) == 0)
                {
                    rowData = table[0];
                }
            }

            if (rowData == null)
            {
                rowData = table.NewShareValueHistoryRow();
                rowData.PublicCorpID = corpID;
                rowData.DateTime = date;
                rowData.ShareValue = 0;
                table.AddShareValueHistoryRow(rowData);
            }

            rowData.ShareValue = value;

            lock (tableAdapter)
            {
                tableAdapter.Update(table);
            }
        }

        public static void DeleteEntry(int corpID, DateTime date)
        {
            EMMADataSet.ShareValueHistoryDataTable table = new EMMADataSet.ShareValueHistoryDataTable();
            lock (tableAdapter)
            {
                tableAdapter.FillByDate(table, corpID, date);
            }

            if (table.Count > 0)
            {
                if (date.CompareTo(table[0].DateTime) == 0)
                {
                    table[0].Delete();
                    lock (tableAdapter)
                    {
                        tableAdapter.Update(table);
                    }
                }
            }

        }
    }
}
