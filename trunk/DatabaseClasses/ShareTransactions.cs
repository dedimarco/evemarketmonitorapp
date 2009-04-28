using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class ShareTransactions : IProvideStatus
    {
        private static EMMADataSetTableAdapters.ShareTransactionTableAdapter tableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.ShareTransactionTableAdapter();

        public event StatusChangeHandler StatusChange;

        static public void GetCorpTransInfo(int reportGroupID, int corpID, ref decimal avgBuyPrice, 
            ref decimal avgSellPrice, ref decimal unitsBought, ref decimal unitsSold, ref decimal investedDays)
        {
            EMMADataSet.ShareTransactionDataTable table = new EMMADataSet.ShareTransactionDataTable();

            tableAdapter.FillByAny(table, reportGroupID, corpID);
            avgBuyPrice = 0;
            avgSellPrice = 0;
            unitsBought = 0;
            unitsSold = 0;
            investedDays = 0;
            decimal avgPriceOfCurrentShares = 0;
            decimal investedNow = 0;
            DateTime lastTransDate = DateTime.MaxValue;

            foreach (EMMADataSet.ShareTransactionRow transData in table)
            {
                if (transData.DeltaQuantity > 0)
                {
                    // This holds the average buy price for the shares currently held by the player.
                    if (((unitsBought - unitsSold) + transData.DeltaQuantity) != 0)
                    {
                        avgPriceOfCurrentShares = ((transData.PricePerShare * transData.DeltaQuantity) +
                            (avgPriceOfCurrentShares * (unitsBought - unitsSold))) /
                            ((unitsBought - unitsSold) + transData.DeltaQuantity);
                    }
                    else
                    {
                        avgPriceOfCurrentShares = 0;
                    }

                    avgBuyPrice += transData.PricePerShare * transData.DeltaQuantity;
                    unitsBought += transData.DeltaQuantity;

                    if (lastTransDate != DateTime.MaxValue)
                    {
                        investedDays += investedNow * (decimal)((TimeSpan)transData.DateTime.Subtract(lastTransDate)).TotalDays;
                    }
                    investedNow += transData.DeltaQuantity * transData.PricePerShare;
                    lastTransDate = transData.DateTime;
                }
                else if (transData.DeltaQuantity < 0)
                {
                    avgSellPrice -= transData.PricePerShare * transData.DeltaQuantity;
                    unitsSold -= transData.DeltaQuantity;

                    if (lastTransDate != null)
                    {
                        investedDays += investedNow * (decimal)((TimeSpan)transData.DateTime.Subtract(lastTransDate)).TotalDays;
                    }
                    investedNow += transData.DeltaQuantity * avgPriceOfCurrentShares;
                    lastTransDate = transData.DateTime;
                }
            }

            if (lastTransDate != null)
            {
                // Add the final 'amount invested'.
                investedDays += investedNow * (decimal)((TimeSpan)DateTime.UtcNow.Subtract(lastTransDate)).TotalDays;
            }

            if (unitsBought > 0)
            {
                avgBuyPrice /= unitsBought;
            }
            if (unitsSold > 0)
            {
                avgSellPrice /= unitsSold;
            }
        }


        public static int GetSharesOwned(DateTime date, int reportGroupID, int corpID)
        {
            int retVal = 0;
            EMMADataSet.ShareTransactionDataTable table = new EMMADataSet.ShareTransactionDataTable();

            date = date.ToUniversalTime();
            tableAdapter.FillByAny(table, reportGroupID, corpID);
            foreach (EMMADataSet.ShareTransactionRow row in table)
            {
                if (row.DateTime.CompareTo(date) <= 0)
                {
                    retVal += row.DeltaQuantity;
                }
            }

            return retVal;
        }


        public static ShareTransactionList GetTransactions(int reportGroupID, int corpID)
        {
            ShareTransactionList retVal = new ShareTransactionList();
            EMMADataSet.ShareTransactionDataTable table = new EMMADataSet.ShareTransactionDataTable();
            tableAdapter.FillByAny(table, reportGroupID, corpID);
            foreach (EMMADataSet.ShareTransactionRow row in table)
            {
                retVal.Add(new ShareTransaction(row));
            }
            return retVal;
        }


        public static void StoreTransaction(ShareTransaction trans) 
        {
            bool newRow = false;
            EMMADataSet.ShareTransactionDataTable table = new EMMADataSet.ShareTransactionDataTable();
            EMMADataSet.ShareTransactionRow row;

            tableAdapter.FillByTransID(table, trans.ID);
            if (table.Count > 0)
            {
                row = table[0];
            }
            else
            {
                row = table.NewShareTransactionRow();
                newRow = true;
            }

            row.CorpID = trans.CorpID;
            row.DeltaQuantity = trans.DeltaQuantity;
            row.DateTime = trans.TransactionDate;
            row.PricePerShare = trans.PricePerShare;
            row.ReportGroupID = trans.ReportGroupID;

            if (newRow)
            {
                table.AddShareTransactionRow(row);
            }

            tableAdapter.Update(table);
        }


        public static void DeleteTrans(int transID)
        {
            EMMADataSet.ShareTransactionDataTable table = new EMMADataSet.ShareTransactionDataTable();
            tableAdapter.FillByTransID(table, transID);
            if (table.Count > 0)
            {
                table[0].Delete();
            }
            tableAdapter.Update(table);
        }


        public void LoadOldEmmaXML(string filename, int reportGroupID)
        {
            EMMADataSet.ShareTransactionDataTable table = new EMMADataSet.ShareTransactionDataTable();
            XmlDocument xml = new XmlDocument();
            UpdateStatus(0, 0, "", "Loading file", false);
            xml.Load(filename);

            XmlNodeList nodes = xml.SelectNodes("/DocumentElement/ShareTransaction");

            int counter = 0;
            UpdateStatus(0, 0, "", "Extracting data from XML", false);
            foreach (XmlNode node in nodes)
            {
                EMMADataSet.ShareTransactionRow trans = table.NewShareTransactionRow();
                trans.DateTime = DateTime.Parse(node.SelectSingleNode("DateTime").FirstChild.Value);
                string corpName = node.SelectSingleNode("CorpName").FirstChild.Value;
                try
                {
                    trans.CorpID = PublicCorps.GetCorp(corpName).ID;
                }
                catch (EMMADataMissingException)
                {
                    PublicCorp newCorp = new PublicCorp();
                    newCorp.Name = corpName;
                    PublicCorps.StoreCorp(newCorp);
                    trans.CorpID = PublicCorps.GetCorp(corpName).ID;
                }
                trans.ReportGroupID = reportGroupID;
                bool sell = node.SelectSingleNode("Type").FirstChild.Value.Trim().ToUpper().Equals("SELL");
                trans.DeltaQuantity = int.Parse(node.SelectSingleNode("Quantity").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                if (sell) { trans.DeltaQuantity *= -1; }
                trans.PricePerShare = decimal.Parse(node.SelectSingleNode("Price").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                table.AddShareTransactionRow(trans);

                counter++;
                UpdateStatus(counter, nodes.Count, "", "", false);
            }

            UpdateStatus(0, 0, "", "Updating database", false);
            lock (tableAdapter)
            {
                tableAdapter.Update(table);
            }
        }


        public void UpdateStatus(int progress, int maxProgress, string section, string sectionStatus, bool done)
        {
            if (StatusChange != null)
            {
                StatusChange(null, new StatusChangeArgs(progress, maxProgress, section, sectionStatus, done));
            }
        }
    }
}
