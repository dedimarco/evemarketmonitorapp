using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.AbstractionClasses
{
    /// <summary>
    /// Uses Eve-prices.net to retrieve price data for faction/officer/deadspace items.
    /// </summary>
    public static class EvePrices
    {
        private static XmlDocument _xml = null;

        public static decimal GetValue(int itemID)
        {
            decimal retVal = 0;

            try
            {
                if (!Globals.EvePricesDown)
                {
                    if (_xml == null)
                    {
                        DownloadXML();
                    }
                    try
                    {
                        XmlNode itemNode = _xml.SelectSingleNode("/factionPriceData/items/item[typeID=" + itemID + "]");
                        if (itemNode != null)
                        {
                            retVal = decimal.Parse(itemNode.SelectSingleNode("price").FirstChild.Value,
                                System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new EMMAException(ExceptionSeverity.Error, "Problem processing XML from eve-prices.net" +
                            "(ItemID = " + itemID + ")", ex);
                    }
                }
            }
            catch (EMMAException) { }

            return retVal;
        }

        public static void DownloadXML()
        {
            string tmpFile = string.Format("{0}Temp{1}prices.xml", AppDomain.CurrentDomain.BaseDirectory,
                Path.DirectorySeparatorChar);
            WebClient client = new WebClient();

            if (File.Exists(tmpFile)) { File.Delete(tmpFile); }
            try
            {
                client.DownloadFile(@"http://www.eve-prices.net/xml/today.xml", tmpFile);
                _xml = new XmlDocument();
                _xml.Load(tmpFile);
            }
            catch (Exception ex)
            {
                throw new EMMAException(ExceptionSeverity.Error, "Problem reading XML from eve-prices.net", ex);
            }
        }
    }
}
