using System;
using System.Collections.Generic;
using System.Text;

namespace EveMarketMonitorApp.DatabaseClasses
{
    class ContractStatus
    {
        private static EMMADataSet.ContractStatesDataTable table = new EMMADataSet.ContractStatesDataTable();
        private static EMMADataSetTableAdapters.ContractStatesTableAdapter tableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.ContractStatesTableAdapter();

        public static string GetDescription(short status)
        {
            string retVal = "";
            if (table.Count == 0) { LoadData(); }
            EMMADataSet.ContractStatesRow data = table.FindByID(status);
            if (data != null) { retVal = data.Description.Trim(); }
            return retVal;
        }

        public static EMMADataSet.ContractStatesDataTable GetAll()
        {
            EMMADataSet.ContractStatesDataTable tmpTable = new EMMADataSet.ContractStatesDataTable();
            tableAdapter.Fill(tmpTable);
            return tmpTable;
        }

        private static void LoadData()
        {
            tableAdapter.Fill(table);
        }
    }
}
