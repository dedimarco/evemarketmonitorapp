using System;
using System.Collections.Generic;
using System.Text;

namespace EveMarketMonitorApp.Common
{
    public delegate void StatusChangeHandler(object myObject, StatusChangeArgs args);

    /// <summary>
    /// Classes wishing to use the progress indicator dialog must implement this interface and fire the 
    /// OnStatusChange event to update the dialog.
    /// </summary>
    public interface IProvideStatus
    {
        event StatusChangeHandler StatusChange;
    }

    public class StatusChangeArgs : EventArgs
    {
        private int maxProgress;
        private int currentProgress;
        private string section;
        private string sectionStatus;
        private bool done;

        public StatusChangeArgs(int currentProgress, int maxProgress, string section, string sectionStatus, bool done)
        {
            this.section = section;
            this.sectionStatus = sectionStatus;
            this.maxProgress = maxProgress;
            this.currentProgress = currentProgress;
            this.done = done;
        }


        public int MaxProgress
        {
            get { return maxProgress; }
            set { maxProgress = value; }
        }

        public int CurrentProgress
        {
            get { return currentProgress; }
            set { currentProgress = value; }
        }

        public string Section
        {
            get { return section; }
            set { section = value; }
        }

        public string SectionStatus
        {
            get { return sectionStatus; }
            set { sectionStatus = value; }
        }

        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

    }
}
