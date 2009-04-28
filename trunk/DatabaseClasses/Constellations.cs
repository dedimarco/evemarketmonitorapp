using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    static class Constellations
    {
        static private EveDataSetTableAdapters.mapConstellationsTableAdapter tableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EveDataSetTableAdapters.mapConstellationsTableAdapter();
        static private Cache<int, int> _locationCache = new Cache<int,int>(800);
        static bool _initalised = false;

        static public EveDataSet.mapConstellationsDataTable GetConstellations()
        {
            EveDataSet.mapConstellationsDataTable retVal = new EveDataSet.mapConstellationsDataTable();
            tableAdapter.Fill(retVal);
            return retVal;
        }

        static public string GetName(int constellationID)
        {
            string retVal = "";

            tableAdapter.GetName(constellationID, ref retVal);

            return retVal;
        }

        static public bool InRegion(int constellationID, List<int> regionIDs)
        {
            if (!_initalised) { Initalise(); }
            int region = _locationCache.Get(constellationID);
            return regionIDs.Contains(region);
        }


        static public void Initalise()
        {
            if (!_initalised)
            {
                _locationCache.DataUpdateNeeded +=
                    new Cache<int, int>.DataUpdateNeededHandler(LocationCache_DataUpdateNeeded);
                _initalised = true;
            }
        }

        static void LocationCache_DataUpdateNeeded(object myObject, DataUpdateNeededArgs<int, int> args)
        {
            EveDataSet.mapConstellationsDataTable retVal = new EveDataSet.mapConstellationsDataTable();
            lock (tableAdapter)
            {
                tableAdapter.FillByIDs(retVal, args.Key.ToString());
            }

            if (retVal.Count > 0)
            {
                args.Data = retVal[0].regionID;
            }
        }

    }
}
