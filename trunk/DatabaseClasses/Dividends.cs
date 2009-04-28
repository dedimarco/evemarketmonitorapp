using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Data.SqlTypes;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public static class Dividends
    {
        private static EMMADataSetTableAdapters.DividendsTableAdapter tableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.DividendsTableAdapter();
        private static EMMADataSetTableAdapters.JournalDividendLinkTableAdapter linkTableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.JournalDividendLinkTableAdapter();



        public static void GetCorpDivInfo(int corpID, int reportGroupID,
            ref decimal avgDivPerShare, ref decimal totalDivs)
        {
            DividendList divs = GetDividends(corpID);
            avgDivPerShare = 0;
            totalDivs = 0;
            int shareDivs = 0;

            foreach (Dividend div in divs)
            {
                int sharesOnDivDate = ShareTransactions.GetSharesOwned(div.Date, reportGroupID, corpID);
                totalDivs += div.PayoutPerShare * sharesOnDivDate;
                shareDivs += sharesOnDivDate;
            }

            if (shareDivs > 0)
            {
                avgDivPerShare = totalDivs / shareDivs;
            }
        }


        public static DividendList GetDividends(int corpID)
        {
            DividendList retVal = new DividendList();
            EMMADataSet.DividendsDataTable table = new EMMADataSet.DividendsDataTable();
            tableAdapter.FillByCorp(table, corpID);
            foreach (EMMADataSet.DividendsRow row in table)
            {
                retVal.Add(new Dividend(row));
            }
            return retVal;
        }

        public static void StoreDividend(Dividend div)
        {
            bool newRow = false;
            EMMADataSet.DividendsDataTable table = new EMMADataSet.DividendsDataTable();
            EMMADataSet.DividendsRow row;

            tableAdapter.FillByID(table, div.ID);
            if (table.Count > 0)
            {
                row = table[0];
            }
            else
            {
                row = table.NewDividendsRow();
                newRow = true;
            }

            row.CorpID = div.CorpID;
            row.DateTime = div.Date;
            row.PayoutPerShare = div.PayoutPerShare;

            if (newRow)
            {
                table.AddDividendsRow(row);
            }

            tableAdapter.Update(table);
        }


        public static void DeleteDividend(int divID)
        {
            EMMADataSet.DividendsDataTable table = new EMMADataSet.DividendsDataTable();
            tableAdapter.FillByID(table, divID);
            if (table.Count > 0)
            {
                table[0].Delete();
            }
            tableAdapter.Update(table);
        }


        public static DivUpdateInfo UpdateFromJournal(bool buildLinksOnly)
        {
            DivUpdateInfo retVal = new DivUpdateInfo();
            retVal.missingCorps = new List<string>();
            retVal.dividendsNotAdded = 0;
            retVal.dividendsAdded = 0;
            EMMADataSet.DividendsDataTable tempDivs = new EMMADataSet.DividendsDataTable();
            EMMADataSet.JournalDataTable table = Journal.GetUnprocessedDivs();
            EMMADataSet.JournalDividendLinkDataTable links = new EMMADataSet.JournalDividendLinkDataTable();
            // 'addedDivs' tracks the divdends that are added to the table so that when we're
            // done, we can find the added dividends and match the ID to the journal ref.
            // the dict is keyed by journal ref.
            Dictionary<long, MiniDivData> addedDivs = new Dictionary<long, MiniDivData>();

            foreach (EMMADataSet.JournalRow row in table)
            {
                int pubCorpID = 0;
                bool cancel = false;

                if (row.RArgName.Equals(""))
                {
                    row.RArgName = Names.GetName(row.RArgID);
                }

                if (!row.RArgName.Equals(""))
                {
                    try
                    {
                        pubCorpID = PublicCorps.GetCorp(row.RArgName).ID;
                    }
                    catch (EMMADataMissingException)
                    {
                        if (!retVal.missingCorps.Contains(row.RArgName))
                        {
                            retVal.missingCorps.Add(row.RArgName);
                        }
                        cancel = true;
                    }

                    if (!cancel)
                    {
                        retVal.dividendsAdded++;
                        DateTime dateOnly = row.Date;
                        dateOnly = dateOnly.AddSeconds(dateOnly.Second * -1);
                        dateOnly = dateOnly.AddMinutes(dateOnly.Minute * -1);
                        dateOnly = dateOnly.AddHours(dateOnly.Hour * -1);

                        EMMADataSet.DividendsRow newDiv = null;

                        DataRow[] existingDiv = tempDivs.Select("DateTime = '" + dateOnly.ToString() +
                            "' AND CorpID = " + pubCorpID);

                        if (existingDiv == null || existingDiv.Length == 0)
                        {
                            DividendList corpDivs = Dividends.GetDividends(pubCorpID);
                            foreach (Dividend div in corpDivs)
                            {
                                DateTime entryDateOnly = div.Date;
                                entryDateOnly = entryDateOnly.AddSeconds(entryDateOnly.Second * -1);
                                entryDateOnly = entryDateOnly.AddMinutes(entryDateOnly.Minute * -1);
                                entryDateOnly = entryDateOnly.AddHours(entryDateOnly.Hour * -1);
                                if (entryDateOnly.CompareTo(dateOnly) == 0)
                                {
                                    newDiv = div.GetAsDataRow();
                                }
                            }
                            if (newDiv != null)
                            {
                                tempDivs.ImportRow(newDiv);
                            }
                        }
                        else
                        {
                            newDiv = (EMMADataSet.DividendsRow)existingDiv[0];
                        }

                        if (newDiv == null)
                        {
                            newDiv = tempDivs.NewDividendsRow();
                            newDiv.CorpID = pubCorpID;
                            newDiv.DateTime = dateOnly;
                            newDiv.PayoutPerShare = 0;
                            tempDivs.AddDividendsRow(newDiv);
                        }

                        int sharesOwned = ShareTransactions.GetSharesOwned(row.Date,
                            UserAccount.CurrentGroup.ID, pubCorpID);
                        newDiv.PayoutPerShare = (sharesOwned > 0 ? (newDiv.PayoutPerShare +
                            (row.Amount / sharesOwned)) : 1);

                        if (!addedDivs.ContainsKey(row.ID))
                        {
                            addedDivs.Add(row.ID, new MiniDivData(pubCorpID, newDiv.DateTime));
                        }
                    }
                    else
                    {
                        retVal.dividendsNotAdded++;
                    }
                }
                else
                {
                    retVal.dividendsNotAdded++;
                }
            }

            if (!buildLinksOnly)
            {
                tableAdapter.Update(tempDivs);
            }

            Dictionary<long, MiniDivData>.Enumerator enumerator = addedDivs.GetEnumerator();
            while (enumerator.MoveNext())
            {
                MiniDivData data = addedDivs[enumerator.Current.Key];

                tempDivs.Clear();
                lock (tableAdapter)
                {
                    tableAdapter.FillByCorpAndDate(tempDivs, data.corpID, data.divDate.AddSeconds(-1),
                        data.divDate.AddSeconds(1), false, false);
                }
                if (tempDivs != null && tempDivs.Count > 0)
                {
                    EMMADataSet.DividendsRow divData = tempDivs[0];
                    EMMADataSet.JournalDividendLinkRow newLink = links.NewJournalDividendLinkRow();
                    newLink.DividendID = divData.DividendID;
                    newLink.JournalID = enumerator.Current.Key;
                    links.AddJournalDividendLinkRow(newLink);
                }
            }

            linkTableAdapter.Update(links);

            return retVal;
        }

        public static void LoadOldEmmaXML(string filename, Dictionary<int, int> IDChanges)
        {
            EMMADataSet.DividendsDataTable table = new EMMADataSet.DividendsDataTable();
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);

            XmlNodeList nodes = xml.SelectNodes("/DocumentElement/Dividends");

            int counter = 0;
            //UpdateStatus(0, 0, "", "Extracting data from XML", false);
            foreach (XmlNode node in nodes)
            {
                int oldID = int.Parse(node.SelectSingleNode("CorpID").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                if (IDChanges.ContainsKey(oldID))
                {
                    int newID = IDChanges[oldID];
                    DateTime date = DateTime.Parse(node.SelectSingleNode("DateTime").FirstChild.Value);
                    decimal payout = decimal.Parse(node.SelectSingleNode("PayoutPerShare").FirstChild.Value,
                        System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

                    EMMADataSet.DividendsDataTable tmpTable = new EMMADataSet.DividendsDataTable();
                    tableAdapter.FillByCorpAndDate(tmpTable, newID, date.AddSeconds(-1), date.AddSeconds(1),
                        false, false);
                    if (tmpTable.Count == 0)
                    {
                        EMMADataSet.DividendsRow newDiv = table.NewDividendsRow();
                        newDiv.CorpID = newID;
                        newDiv.DateTime = date;
                        newDiv.PayoutPerShare = payout;
                        table.AddDividendsRow(newDiv);
                    }
                }

                counter++;
                //UpdateStatus(counter, nodes.Count, "", "", false);
            }
            //UpdateStatus(1, 1, "", "Complete", false);

            //UpdateStatus(0, 0, "", "Updating database", false);
            lock (tableAdapter)
            {
                tableAdapter.Update(table);
            }
            //UpdateStatus(1, 1, "", "Complete", false);
        }

        public static int ClearDuplicates()
        {
            int retVal = 0;

            // Get a table filled with dividends that do NOT have a related journal entry.
            EMMADataSet.DividendsDataTable table = new EMMADataSet.DividendsDataTable();
            lock (tableAdapter)
            {
                tableAdapter.FillByCorpAndDate(table, 0,
                    SqlDateTime.MinValue.Value, SqlDateTime.MaxValue.Value, false, true);
            }
            // For each of those dividends, try and find a matching dividend that DOES have
            // a related journal entry.
            foreach (EMMADataSet.DividendsRow div in table)
            {
                EMMADataSet.DividendsDataTable table2 = new EMMADataSet.DividendsDataTable();
                lock (tableAdapter)
                {
                    tableAdapter.FillByCorpAndDate(table2, div.CorpID, div.DateTime.AddSeconds(-1),
                        div.DateTime.AddSeconds(1), true, false);
                }

                if (table2.Count > 0)
                {
                    // The dividend without a journal entry has a matching dividend that does have 
                    // a journal entry so delete the one without. 
                    div.Delete();
                    retVal++;
                }
            }

            lock (tableAdapter)
            {
                tableAdapter.Update(table);
            }

            return retVal;
        }
    }

    struct MiniDivData
    {
        public int corpID;
        public DateTime divDate;

        public MiniDivData(int corpID, DateTime divDate)
        {
            this.corpID = corpID;
            this.divDate = divDate;
        }
    }

    public struct DivUpdateInfo
    {
        public int dividendsAdded;
        public int dividendsNotAdded;
        public List<string> missingCorps;
    }
}
