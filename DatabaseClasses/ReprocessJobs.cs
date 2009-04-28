using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    static class ReprocessJobs
    {
        private static EMMADataSetTableAdapters.ReprocessItemTableAdapter itemTableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.ReprocessItemTableAdapter();
        private static EMMADataSetTableAdapters.ReprocessJobTableAdapter jobTableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.ReprocessJobTableAdapter();
        private static EMMADataSetTableAdapters.ReprocessResultTableAdapter resultTableAdapter =
            new EveMarketMonitorApp.DatabaseClasses.EMMADataSetTableAdapters.ReprocessResultTableAdapter();

        public static ReprocessJobList GetGroupJobs(int reportGroupID)
        {
            ReprocessJobList retVal = new ReprocessJobList();

            EMMADataSet.ReprocessJobDataTable table = new EMMADataSet.ReprocessJobDataTable();
            lock (jobTableAdapter)
            {
                jobTableAdapter.FillByGroup(table, reportGroupID);
            }

            foreach (EMMADataSet.ReprocessJobRow row in table)
            {
                retVal.Add(new ReprocessJob(row));
            }

            return retVal;
        }

        /// <summary>
        /// Get the items used in a specific reprocessing job.
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public static ReprocessItemList GetJobItems(int jobID)
        {
            ReprocessItemList retVal = new ReprocessItemList();

            EMMADataSet.ReprocessItemDataTable table = new EMMADataSet.ReprocessItemDataTable();
            lock (itemTableAdapter)
            {
                itemTableAdapter.FillByJob(table, jobID);
            }

            foreach (EMMADataSet.ReprocessItemRow row in table)
            {
                retVal.Add(new ReprocessItem(row));
            }

            return retVal;
        }

        /// <summary>
        /// Get the results of a specific reprocessing job.
        /// </summary>
        /// <param name="jobID"></param>
        /// <returns></returns>
        public static ReprocessResultList GetJobResults(int jobID)
        {
            ReprocessResultList retVal = new ReprocessResultList();

            EMMADataSet.ReprocessResultDataTable table = new EMMADataSet.ReprocessResultDataTable();
            lock (resultTableAdapter)
            {
                resultTableAdapter.FillByJob(table, jobID);
            }

            foreach (EMMADataSet.ReprocessResultRow row in table)
            {
                retVal.Add(new ReprocessResult(row));
            }

            return retVal;
        }

        /// <summary>
        /// Get a list of reprocess results that produced the specified item for the 
        /// specified report group.
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="reportGroupID"></param>
        /// <returns></returns>
        public static ReprocessResultList GetItemResults(int itemID, int reportGroupID)
        {
            ReprocessResultList retVal = new ReprocessResultList();

            EMMADataSet.ReprocessResultDataTable table = new EMMADataSet.ReprocessResultDataTable();
            lock (resultTableAdapter)
            {
                resultTableAdapter.FillByGroupAndItem(table, itemID, reportGroupID);
            }

            foreach (EMMADataSet.ReprocessResultRow row in table)
            {
                retVal.Add(new ReprocessResult(row));
            }

            return retVal;
        }

        /// <summary>
        /// Delete the specified reprocess job from the database.
        /// </summary>
        /// <param name="jobData"></param>
        public static void DeleteJob(ReprocessJob jobData)
        {
            StoreJob(jobData, true);
        }

        /// <summary>
        /// Store the specified reprocess job in the database.
        /// If the job already exists then the database is updated with any new information.
        /// </summary>
        /// <param name="jobData">The job data to be stored</param>
        /// <exception cref="EMMADataException"></exception>
        public static void StoreJob(ReprocessJob jobData)
        {
            StoreJob(jobData, false);
        }

        private static void StoreJob(ReprocessJob jobData, bool delete)
        {
            EMMADataSet.ReprocessJobDataTable table = new EMMADataSet.ReprocessJobDataTable();
            EMMADataSet.ReprocessJobRow row = null;
            bool newRow = false;
            int? newID = 0;

            try
            {
                if (jobData.ID != 0)
                {
                    // See if we can find the existing job in the database.
                    lock (jobTableAdapter)
                    {
                        jobTableAdapter.FillByID(table, jobData.ID);
                    }
                    row = table.FindByID(jobData.ID);
                    // make sure we clear the items and results for that job.
                    lock (itemTableAdapter)
                    {
                        itemTableAdapter.ClearByJob(jobData.ID);
                    }
                    lock (resultTableAdapter)
                    {
                        resultTableAdapter.ClearByJob(jobData.ID);
                    }
                }
                if (row == null)
                {
                    // We either couldn't find the existing job or we're dealing with a 
                    // new job.
                    // Either way, we need to create a new row.
                    row = table.NewReprocessJobRow();
                    newRow = true;
                }

                // Set the values for the job row itself and store it.
                row.JobDate = jobData.Date;
                row.StationID = jobData.StationID;
                row.GroupID = jobData.ReportGroupID;
                row.OwnerID = jobData.OwnerID;

                if (newRow)
                {
                    lock (jobTableAdapter)
                    {
                        jobTableAdapter.StoreNew(row.JobDate, row.StationID, row.GroupID, row.OwnerID, ref newID);
                    }
                }
                else
                {
                    if (delete)
                    {
                        row.Delete();
                    }
                    else
                    {
                        newID = row.ID;
                    }
                    lock (jobTableAdapter)
                    {
                        jobTableAdapter.Update(table);
                    }
                }

                if (newID.HasValue)
                {
                    // Store the items and results of the job.
                    foreach (ReprocessItem item in jobData.SourceItems)
                    {
                        item.JobID = newID.Value;
                        StoreItem(item);
                    }
                    foreach (ReprocessResult result in jobData.Results)
                    {
                        result.JobID = newID.Value;
                        StoreResult(result, jobData.Date);
                    }
                }
            }
            catch (Exception ex)
            {
                EMMAException emmaEx = ex as EMMAException;
                if (emmaEx == null)
                {
                    throw new EMMADataException(ExceptionSeverity.Error,
                        "Problem storing reprocessing job data", ex);
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Store the specified reprocess job item.
        /// Note that this method will ALWAYS try to create a new row. If one already exists in
        /// the database with the same job and item IDs then an EMMADataException is thrown.
        /// </summary>
        /// <param name="itemData">The item data to store</param>
        /// <exception cref="EMMADataException"></exception>
        private static void StoreItem(ReprocessItem itemData)
        {
            EMMADataSet.ReprocessItemDataTable table = new EMMADataSet.ReprocessItemDataTable();
            EMMADataSet.ReprocessItemRow row = table.NewReprocessItemRow();
            row.JobID = itemData.JobID;
            row.ItemID = itemData.ItemID;
            row.Quantity = itemData.Quantity;
            row.BuyPrice = itemData.BuyPrice;
            table.AddReprocessItemRow(row);
            try
            {
                lock (itemTableAdapter)
                {
                    itemTableAdapter.Update(table);
                }
            }
            catch (Exception ex)
            {
                throw new EMMADataException(ExceptionSeverity.Error, "Problem adding reprocess result data " +
                    "to the database.", ex);
            }
        }

        /// <summary>
        /// Store the specified reprocess job result.
        /// Note that this method will ALWAYS try to create a new row. If one already exists in
        /// the database with the same job and item IDs then an EMMADataException is thrown.
        /// </summary>
        /// <param name="itemData">The result data to be stored</param>
        /// <exception cref="EMMADataException"></exception>
        private static void StoreResult(ReprocessResult resultData, DateTime jobDate)
        {
            EMMADataSet.ReprocessResultDataTable table = new EMMADataSet.ReprocessResultDataTable();
            EMMADataSet.ReprocessResultRow row = table.NewReprocessResultRow();
            row.JobID = resultData.JobID;
            row.ItemID = resultData.ItemID;
            row.Quantity = resultData.Quantity;
            row.EffectiveBuyPrice = resultData.EffectiveBuyPrice;
            row.EstSellPrice = resultData.EstSellPrice;
            row.JobDate = jobDate;
            table.AddReprocessResultRow(row);
            try
            {
                lock (resultTableAdapter)
                {
                    resultTableAdapter.Update(table);
                }
            }
            catch (Exception ex)
            {
                throw new EMMADataException(ExceptionSeverity.Error, "Problem adding reprocess result data " +
                    "to the database.", ex);
            }
        }
    }
}
