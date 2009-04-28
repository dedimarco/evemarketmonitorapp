using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

using EveMarketMonitorApp.AbstractionClasses;
using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    static class JournalRefTypes
    {
        static private EMMADataSet.JournalRefTypesDataTable journRefTypes = new EMMADataSet.JournalRefTypesDataTable();
        static private EMMADataSetTableAdapters.JournalRefTypesTableAdapter journRefTableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.JournalRefTypesTableAdapter();

        static public EMMADataSet.JournalRefTypesDataTable GetTypesByJournal(List<FinanceAccessParams> accessParams)
        {
            EMMADataSet.JournalRefTypesDataTable retVal = new EMMADataSet.JournalRefTypesDataTable();
            lock (journRefTableAdapter)
            {
                journRefTableAdapter.FillByUser(retVal, FinanceAccessParams.BuildAccessList(accessParams));
            }
            return retVal;
        }

        static public EMMADataSet.JournalRefTypesDataTable GetAllTypes()
        {
            EMMADataSet.JournalRefTypesDataTable retVal = new EMMADataSet.JournalRefTypesDataTable();
            lock (journRefTableAdapter)
            {
                journRefTableAdapter.Fill(retVal);
            }
            return retVal;
        }

        /// <summary>
        /// Returns a list containing all the journal entry type IDs
        /// </summary>
        /// <returns></returns>
        static public List<short> GetRefTypeIDs()
        {
            List<short> retVal = new List<short>();

            if (journRefTypes.Count == 0) LoadData();

            foreach (EMMADataSet.JournalRefTypesRow journRefType in journRefTypes)
            {
                retVal.Add(journRefType.ID);
            }

            return retVal;
        }

        /// <summary>
        /// Get the journal reference description for the specified reference code.
        /// </summary>
        /// <param name="refCode"></param>
        /// <returns></returns>
        static public string GetReferenceDesc(short refCode)
        {
            int counter = 0;

            if (journRefTypes.Count == 0) LoadData();

            EMMADataSet.JournalRefTypesRow data = journRefTypes.FindByID(refCode);

            while (data == null)
            {
                counter++;
                if (counter == 1 && UpdateFromEveApi().Type == UpdateResultType.ChangesSuccessful)
                {
                    data = journRefTypes.FindByID(refCode);
                }
                if (counter >= 2)
                {
                    throw new EMMADataException(ExceptionSeverity.Warning, "Supplied journal reference code (" +
                        refCode + ") is not in the EMMA database or returned from the Eve API.");
                }
            }

            return data.RefName;
        }

        /// <summary>
        /// Get the journal reference ID representing the specified description.
        /// </summary>
        /// <param name="refCode"></param>
        /// <returns></returns>
        static public short GetReferenceID(string description)
        {
            int counter = 0;

            if (journRefTypes.Count == 0) LoadData();

            EMMADataSet.JournalRefTypesRow data = null;

            for (int i = 0; i < journRefTypes.Count; i++)
            {
                if (description.Equals(journRefTypes[i].RefName))
                {
                    data = journRefTypes[i];
                }
            }

            while (data == null)
            {
                counter++;
                if (counter == 1 && UpdateFromEveApi().Type == UpdateResultType.ChangesSuccessful)
                {
                    for (int i = 0; i < journRefTypes.Count; i++)
                    {
                        if (description.Equals(journRefTypes[i].RefName))
                        {
                            data = journRefTypes[i];
                        }
                    }
                }
                if (counter >= 2)
                {
                    throw new EMMADataException(ExceptionSeverity.Warning, "Supplied journal reference description (" +
                        description + ") is not in the EMMA database or returned from the Eve API.");
                }
            }

            return data.ID;
        }

        /// <summary>
        /// Adds a journal reference type with the specified code and a description of 'Unspecified'.
        /// This will act as a placeholder until the Eve API returns a proper name at which point it will
        /// be updated automatically.
        /// </summary>
        /// <param name="refCode"></param>
        static public void AddUnspecifiedRefType(short refCode)
        {
            if (journRefTypes.Count == 0) LoadData();

            EMMADataSet.JournalRefTypesRow data = journRefTypes.FindByID(refCode);

            if (data == null)
            {
                data = journRefTypes.NewJournalRefTypesRow();
                data.ID = refCode;
                data.RefName = "Unspecified";
                journRefTypes.AddJournalRefTypesRow(data);

                lock (journRefTableAdapter)
                {
                    journRefTableAdapter.Update(journRefTypes);
                }
                journRefTypes.AcceptChanges();
            }
        }

        /// <summary>
        /// Update the EMMA database table JournalRefTypes with the latest data from the Eve Online API. 
        /// </summary>
        /// <returns>The result of the update.</returns>
        static private UpdateResult UpdateFromEveApi()
        {
            UpdateResult retVal = null;
            bool change = false;

            try
            {
                // First make sure we have the same data as the database.
                LoadData();
                // Now get the journal references from the Eve API.
                SortedList refTypes = EveAPI.GetJournalRefs();

                foreach (DictionaryEntry refType in refTypes)
                {
                    short code = short.Parse(refType.Key.ToString());
                    EMMADataSet.JournalRefTypesRow row = journRefTypes.FindByID(code);
                    if (row == null)
                    {
                        // Create a new row using the data provided by the Eve API and add it to our database.
                        change = true;
                        EMMADataSet.JournalRefTypesRow newRow = journRefTypes.NewJournalRefTypesRow();
                        newRow.ID = code;
                        newRow.RefName = refType.Value.ToString();
                        journRefTypes.AddJournalRefTypesRow(newRow);
                    }
                    else
                    {
                        // If we have the code in the database already but the description from Eve API is
                        // different then update our description to match.
                        if (!row.RefName.Equals(refType.Value.ToString()))
                        {
                            change = true;
                            row.RefName = refType.Value.ToString();
                        }
                    }
                }

                if (change)
                {
                    // If changes have been made then save those changes to the database.
                    lock (journRefTableAdapter)
                    {
                        journRefTableAdapter.Update(journRefTypes);
                    }
                    journRefTypes.AcceptChanges();
                }

                retVal = new UpdateResult(change ? UpdateResultType.ChangesSuccessful : UpdateResultType.NoChanges);
            }
            catch (Exception ex)
            {
                throw new EMMADataException(ExceptionSeverity.Error, "Problem updating journal reference types " +
                    "from the Eve API.", ex);
            }

            return retVal;
        }

        /// <summary>
        /// Load data from the EMMA database into the journRefTypes table.
        /// </summary>
        static private void LoadData()
        {
            journRefTableAdapter.ClearBeforeFill = true;

            try
            {
                lock (journRefTableAdapter)
                {
                    journRefTableAdapter.Fill(journRefTypes);
                }
            }
            catch (Exception ex)
            {
                throw new EMMADataException(ExceptionSeverity.Critical, "Problem loading journal reference type " +
                    "data from the EMMA database.", ex);
            }
        }

    }
}
