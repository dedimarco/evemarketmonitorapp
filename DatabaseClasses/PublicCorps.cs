using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

using EveMarketMonitorApp.GUIElements;
using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public static class PublicCorps
    {
        private static EMMADataSetTableAdapters.PublicCorpsTableAdapter tableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.PublicCorpsTableAdapter();
        private static EMMADataSetTableAdapters.InvestmentsTableAdapter invTableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.InvestmentsTableAdapter();
        private static Cache<int, PublicCorp> _cache = new Cache<int, PublicCorp>(100);
        public static bool _initalised = false;


        public static void Delete(int corpID)
        {
            EMMADataSet.PublicCorpsDataTable table = new EMMADataSet.PublicCorpsDataTable();
            lock (tableAdapter)
            {
                tableAdapter.FillByID(table, corpID);
            }
            table.FindByCorpID(corpID).Delete();
            tableAdapter.Update(table);
        }

        public static bool AllowDelete(int corpID)
        {
            bool? retVal = false;
            tableAdapter.AllowDelete(corpID, ref retVal);

            return retVal.HasValue ? retVal.Value : false;
        }

        public static PublicCorp GetCorp(string corpName)
        {
            PublicCorp retVal = null;
            EMMADataSet.PublicCorpsDataTable table = new EMMADataSet.PublicCorpsDataTable();
            EMMADataSet.PublicCorpsRow rowData = null;

            lock (tableAdapter)
            {
                tableAdapter.FillByName(table, corpName);
            }
            if (table.Count == 1)
            {
                rowData = table[0];
            }
            else
            {
                lock (tableAdapter)
                {
                    tableAdapter.FillByName(table, "%" + corpName + "%");
                }

                if (table.Count < 1)
                {
                    throw new EMMADataMissingException(ExceptionSeverity.Error, "No public corp found " +
                        "matching '" + corpName + "'", "PublicCorps", corpName);
                }
                else if (table.Count > 1)
                {
                    SortedList<object, string> options = new SortedList<object, string>();
                    foreach (EMMADataSet.PublicCorpsRow corp in table)
                    {
                        options.Add(corp.CorpID, corp.CorpName);
                    }
                    OptionPicker picker = new OptionPicker("Select Corp (" + corpName + ")", 
                        "Choose the specific corp you want from those listed below.", options);
                    if (picker.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
                    {
                        rowData = table.FindByCorpID((int)picker.SelectedItem);
                    }
                }
                else
                {
                    rowData = table[0];
                }
            }

            if (rowData != null) { retVal = new PublicCorp(rowData); }
            return retVal;
        }

        public static PublicCorp GetCorp(int corpID)
        {
            if (!_initalised) { InitaliseCache(); }
            PublicCorp retVal = _cache.Get(corpID);
            return retVal;
        }

        public static void InitaliseCache()
        {
            if(!_initalised) 
            {
                _cache.DataUpdateNeeded += new Cache<int, PublicCorp>.DataUpdateNeededHandler(Cache_DataUpdateNeeded);
                _initalised = true;
            }
        }

        static void Cache_DataUpdateNeeded(object myObject, DataUpdateNeededArgs<int, PublicCorp> args)
        {
            PublicCorp data = null;
            EMMADataSet.PublicCorpsDataTable table =new EMMADataSet.PublicCorpsDataTable();
            tableAdapter.FillByID(table, args.Key);
            if (table.Count > 0)
            {
                data = new PublicCorp(table[0]);
            }
            args.Data = data;
        }

        public static PublicCorpsList GetReportGroupInvestments(int reportGroupID, bool banks)
        {
            PublicCorpsList retVal = new PublicCorpsList();
            EMMADataSet.InvestmentsDataTable table = new EMMADataSet.InvestmentsDataTable();
            invTableAdapter.FillByReportGroup(table, reportGroupID, banks);
            foreach (EMMADataSet.InvestmentsRow row in table)
            {
                if (banks)
                {
                    // If this is a bank then we need to get the owner IDs that hold accounts with 
                    // this corp and group.
                    EMMADataSet.BankAccountDataTable accounts = BankAccounts.GetBankAccountData(
                        UserAccount.CurrentGroup.ID, 0, row.CorpID);
                    foreach (EMMADataSet.BankAccountRow account in accounts)
                    {
                        PublicCorp corpData = new PublicCorp(row);
                        corpData.OwnerID = account.OwnerID;
                        retVal.Add(corpData);
                    }
                    if (accounts.Count == 0)
                    {
                        PublicCorp corpData = new PublicCorp(row);
                        retVal.Add(corpData);
                    }
                }
                else
                {
                    retVal.Add(new PublicCorp(row));
                }
            }
            return retVal;
        }

        public static PublicCorpsList GetAll()
        {
            return GetAll(true);
        }

        public static PublicCorpsList GetAll(bool includeBanks)
        {
            return GetAll(includeBanks, true);
        }
        public static PublicCorpsList GetAll(bool includeBanks, bool includeNonBanks)
        {
            PublicCorpsList retVal = new PublicCorpsList();
            EMMADataSet.PublicCorpsDataTable table = new EMMADataSet.PublicCorpsDataTable();
            tableAdapter.Fill(table);
            foreach (EMMADataSet.PublicCorpsRow row in table)
            {
                if ((row.Bank && includeBanks) || (!row.Bank && includeNonBanks))
                {
                    retVal.Add(new PublicCorp(row));
                }
            }
            return retVal;
        }


        public static void StoreCorp(PublicCorp data)
        {
            bool newRow = false;
            EMMADataSet.PublicCorpsDataTable table = new EMMADataSet.PublicCorpsDataTable();
            EMMADataSet.PublicCorpsRow row;

            tableAdapter.FillByID(table, data.ID);
            if (table.Count > 0)
            {
                row = table[0];
            }
            else
            {
                row = table.NewPublicCorpsRow();
                newRow = true;
            }

            row.CorpName = data.Name;
            row.Ticker = data.Ticker;
            row.Description = data.Description;
            row.CEO = data.CEO;
            row.EstimatedNAV = data.NAV;
            row.NAVTakenAt = data.NAVDate;
            row.ValuePerShare = data.ShareValue;
            row.ExpectedPayoutPerShare = data.ExpectedPayout;
            row.PayoutPeriodID = (short)data.PayoutPeriod;
            row.Bank = data.Bank;
            row.RiskRatingID = (short)data.CorpRiskRating;

            if (newRow)
            {
                table.AddPublicCorpsRow(row);
            }

            tableAdapter.Update(table);
        }


        public static void LoadOldEmmaXML(string filename, ref Dictionary<int, int> IDChanges)
        {
            EMMADataSet.PublicCorpsDataTable table = new EMMADataSet.PublicCorpsDataTable();
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);

            XmlNodeList nodes = xml.SelectNodes("/DocumentElement/PublicCorps");

            int counter = 0;
            //UpdateStatus(0, 0, "", "Extracting data from XML", false);
            foreach (XmlNode node in nodes)
            {
                string corpName = node.SelectSingleNode("CorpName").FirstChild.Value;
                PublicCorp existingCorp = null;
                int oldID = int.Parse(node.SelectSingleNode("CorpID").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                decimal nav = decimal.Parse(node.SelectSingleNode("EstimatedNAV").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                DateTime navDate = DateTime.Parse(node.SelectSingleNode("NAVTakenAt").FirstChild.Value);
                string payoutPeriod = node.SelectSingleNode("PayoutPeriod").FirstChild.Value;
                CorpPayoutPeriod period = CorpPayoutPeriod.Unspecified;
                if (payoutPeriod.Equals("Monthly"))
                {
                    period = CorpPayoutPeriod.Monthly30;
                }
                else if (payoutPeriod.Equals("BiMonthly"))
                {
                    period = CorpPayoutPeriod.BiMonthly;
                }
                else if (payoutPeriod.Equals("Weekly"))
                {
                    period = CorpPayoutPeriod.Weekly;
                }
                else if (payoutPeriod.Equals("Dayley") || payoutPeriod.Equals("Dailey"))
                {
                    period = CorpPayoutPeriod.Dailey;
                }
                else if (payoutPeriod.Equals("Quaterly"))
                {
                    period = CorpPayoutPeriod.Quaterly;
                }
                decimal shareValue = decimal.Parse(node.SelectSingleNode("ValuePerShare").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                decimal expectedPayout = decimal.Parse(node.SelectSingleNode("ExpectedPayoutPerShare").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                XmlNode tickerNode = node.SelectSingleNode("Ticker");
                string ticker = "";
                if (tickerNode.FirstChild != null)
                {
                    ticker = tickerNode.FirstChild.Value;
                }
                XmlNode descNode = node.SelectSingleNode("Description");
                string description = "";
                if (descNode.FirstChild != null)
                {
                    description = descNode.FirstChild.Value;
                }
                XmlNode ceoNode = node.SelectSingleNode("CEO");
                string ceo = "";
                if (ceoNode.FirstChild != null)
                {
                    ceo = ceoNode.FirstChild.Value;
                }

                try
                {
                    existingCorp = GetCorp(corpName);
                    if (existingCorp.NAV == 0)
                    {
                        existingCorp.NAV = nav;
                        existingCorp.NAVDate = navDate;
                    }
                    if (existingCorp.PayoutPeriod == CorpPayoutPeriod.Unspecified) { 
                        existingCorp.PayoutPeriod = period; }
                    if (existingCorp.ShareValue == 0) { existingCorp.ShareValue = shareValue; }
                    if (existingCorp.Ticker.Length == 0) { existingCorp.Ticker = ticker; }
                    if (existingCorp.Description.Length == 0) { existingCorp.Description = description; }
                    if (existingCorp.CEO.Length == 0) { existingCorp.CEO = ceo; }
                    if (existingCorp.ExpectedPayout == 0) { existingCorp.ExpectedPayout = expectedPayout; }
                    StoreCorp(existingCorp);
                }
                catch (EMMADataMissingException)
                {
                    EMMADataSet.PublicCorpsRow corp = table.NewPublicCorpsRow();
                    corp.CorpName = corpName;
                    corp.Description = description;
                    corp.CEO = ceo;
                    corp.Ticker = ticker;
                    corp.EstimatedNAV = nav;
                    corp.NAVTakenAt = navDate;
                    corp.ExpectedPayoutPerShare = expectedPayout;
                    corp.ValuePerShare = shareValue;
                    corp.PayoutPeriodID = (short)period;
                    corp.Bank = false;
                    table.AddPublicCorpsRow(corp);
                    lock (tableAdapter)
                    {
                        tableAdapter.Update(corp);
                        corp.AcceptChanges();
                    }
                }

                PublicCorp newCorp = GetCorp(corpName);
                IDChanges.Add(oldID, newCorp.ID);

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
    }
}
