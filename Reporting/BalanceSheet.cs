using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.AbstractionClasses;
using EveMarketMonitorApp.DatabaseClasses;

namespace EveMarketMonitorApp.Reporting
{
    class BalanceSheet //: ReportBase
    {
        public BalanceSheet()
        {
/*            title = "Balance Sheet";
            subtitle = "";

            sectionTypes = new ReportSectionTypes();
            sectionTypes.Add(new ReportSectionType("Assets"));
            //sectionTypes.Add(new ReportSectionType("Liabilities"));
            sectionTypes.Add(new ReportSectionType("Equity"));
*/        }

/*        /// <summary>
        /// Fill report with data 
        /// </summary>
        public override void FillReport()
        {
            GetDataFromDatabase();
        }

        /// <summary>
        /// Gets the required data from the database
        /// </summary>
        public void GetDataFromDatabase()
        {
            int maxProgress = 0;
            UpdateStatus(0, maxProgress, "", "Getting Report Data...", false);

            // Set the text displayed on the columns, we want somthing slightly different to the default...
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i].Text = columns[i].EndDate.ToShortDateString();
            }

            // Setup the section header rows...
            for (int i = 0; i < sectionTypes.Count; i++)
            {
                ReportSectionType type = sectionTypes[i];

                // Add a blank row at the top of this section...
                if (GetRowByName("Blank" + i) == null)
                {
                    AddRow(type, "Blank" + i, "");
                }
                // Add the section header row
                if (GetRowByName(type.Name) == null)
                {
                    AddRow(type, type.Name, type.Name);
                }
            }

            // Now add build and add the actual data...
            string[] dataLines = Enum.GetNames(Type.GetType("BalanceSheetItemType"));
            for (int line = 0; line < dataLines.Length; line++)
            {
                BalanceSheetItemType lineType = (BalanceSheetItemType)Enum.Parse(
                    Type.GetType("BalanceSheetItemType"), dataLines[line]);

                for (int i = 0; i < columns.Length; i++)
                {
                    ReportSectionType type = null;
                    string text = "";

                    switch (lineType)
                    {
                        case BalanceSheetItemType.CashOnHand:
                            type = sectionTypes.GetSection("Assets");
                            text = "Cash On Hand";
                            EveAPI.GetWalletBalance(walletIDs);
                            break;
                        case BalanceSheetItemType.CashInEscrow:
                            type = sectionTypes.GetSection("Assets");
                            text = "Cash In Escrow";
                            break;
                        case BalanceSheetItemType.Inventory:
                            type = sectionTypes.GetSection("Assets");
                            text = "Inventory";
                            Assets.GetAssetHistoryData(columns[i].EndDate);
                            break;
                        case BalanceSheetItemType.RetainedEarnings:
                            type = sectionTypes.GetSection("Equity");
                            text = "Retained Earnings";
                            break;
                        case BalanceSheetItemType.StartingCapital:
                            type = sectionTypes.GetSection("Equity");
                            text = "Starting Capital";
                            break;
                        default:
                            break;
                    }

                    if (GetRowByName(type.Name + lineType.ToString()) == null)
                    {
                        // Add this row if one does not already exist in the report.
                        AddRow(type, type.Name + lineType.ToString(), "    " + text);
                    }

                    // Add the data for this row & column.
                    /*SetValue(columns[i].Name, type.Name + JournalRefTypes.GetReferenceDesc(refTypeID),
                        amount);
                    UpdateStatus(2 + refTypeIDs.IndexOf(refTypeID) + i * refTypeIDs.Count +
                        section * (2 + columns.Length * refTypeIDs.Count),
                        maxProgress, "", "", false);*/
/*
                }
            }

        }

*/

    }

    enum BalanceSheetItemType
    {
        //Assets
        CashInWallet,
        CashInEscrow,
        Inventory,
        //Liabilities (None atm, might introduce loans at some point)
        //Equity
        RetainedEarnings,
        StartingCapital
    }

}
