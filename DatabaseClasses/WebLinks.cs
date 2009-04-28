using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public static class WebLinks
    {
        private static EMMADataSetTableAdapters.WebLinksTableAdapter tableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.WebLinksTableAdapter();

        public static WebLinkList GetWebLinks(int corpID)
        {
            WebLinkList retVal = new WebLinkList();
            EMMADataSet.WebLinksDataTable table = new EMMADataSet.WebLinksDataTable();
            tableAdapter.FillByCorp(table, corpID);
            foreach (EMMADataSet.WebLinksRow row in table)
            {
                retVal.Add(new WebLink(row));
            }
            return retVal;
        }

        public static void StoreLink(WebLink link)
        {
            bool newRow = false;
            EMMADataSet.WebLinksDataTable table = new EMMADataSet.WebLinksDataTable();
            EMMADataSet.WebLinksRow row;

            tableAdapter.FillByID(table, link.ID);
            if (table.Count > 0)
            {
                row = table[0];
            }
            else
            {
                row = table.NewWebLinksRow();
                newRow = true;
            }

            row.CorpID = link.CorpID;
            row.Description = link.Description;
            row.Link = link.Link;

            if (newRow)
            {
                table.AddWebLinksRow(row);
            }

            tableAdapter.Update(table);
        }


        public static void DeleteLink(int linkID)
        {
            EMMADataSet.WebLinksDataTable table = new EMMADataSet.WebLinksDataTable();
            tableAdapter.FillByID(table, linkID);
            if (table.Count > 0)
            {
                table[0].Delete();
            }
            tableAdapter.Update(table);
        }


        public static void LoadOldEmmaXML(string filename, Dictionary<int, int> IDChanges)
        {
            EMMADataSet.WebLinksDataTable table = new EMMADataSet.WebLinksDataTable();
            XmlDocument xml = new XmlDocument();
            xml.Load(filename);

            XmlNodeList nodes = xml.SelectNodes("/DocumentElement/WebLinks");

            int counter = 0;
            //UpdateStatus(0, 0, "", "Extracting data from XML", false);
            foreach (XmlNode node in nodes)
            {
                int oldID = int.Parse(node.SelectSingleNode("CorpID").FirstChild.Value,
                    System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                if (IDChanges.ContainsKey(oldID))
                {
                    int newID = IDChanges[oldID];
                    string link = node.SelectSingleNode("Link").FirstChild.Value;
                    string description = node.SelectSingleNode("Description").FirstChild.Value;

                    EMMADataSet.WebLinksRow newLink = table.NewWebLinksRow();
                    newLink.CorpID = newID;
                    newLink.Description = description;
                    newLink.Link = link;
                    table.AddWebLinksRow(newLink);
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
    

    }
}
