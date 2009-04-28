using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class VerifyDatabase : IProvideStatus
    {
        public event StatusChangeHandler StatusChange;

        public void Run()
        {
            Thread.Sleep(500); // Wait for half a second to allow the calling thread to display the dialog...
            int checks = 1;

            try
            {
                UpdateStatus(0, checks, "Checking database", "", false);

                // Check 1 - Check for duplicated, dividend data.
                UpdateStatus(0, checks, "", "Checking for duplicated dividend entries", false);
                int total = Dividends.ClearDuplicates();
                if (total == 0)
                {
                    UpdateStatus(1, checks, "", "No duplicates found", false);
                }
                else
                {
                    UpdateStatus(1, checks, "", total + " duplicates found and removed.", false);
                }

                UpdateStatus(checks, checks, "Checks complete", "", true);
            }
            catch (Exception ex)
            {
                EMMAException emmaex = ex as EMMAException;
                if (emmaex == null)
                {
                    emmaex = new EMMAException(ExceptionSeverity.Error, "Problem verifying data integrity", ex);
                }
                UpdateStatus(-1, -1, "Error", "Problem verifying data integrity: " + ex.Message, true);
            }
        }


        private void UpdateStatus(int progress, int maxprogress, string sectionName, string status, bool complete)
        {
            if (StatusChange != null)
            {
                StatusChange(this, new StatusChangeArgs(progress, maxprogress, sectionName, status, complete));
            }
        }

    }
}
