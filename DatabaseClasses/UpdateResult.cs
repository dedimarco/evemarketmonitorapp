using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class UpdateResult
    {
        string detail;
        UpdateResultType type;

        public UpdateResult(UpdateResultType type)
        {
            this.type = type;
            this.detail = "";
        }
        public UpdateResult(UpdateResultType type, string detail)
        {
            this.type = type;
            this.detail = detail;
        }

        public string Detail
        {
            get { return detail; }
            set { detail = value; }
        }

        public UpdateResultType Type
        {
            get { return type; }
            set { type = value; }
        }
    }

    public enum UpdateResultType
    {
        NoChanges,
        ChangesSuccessful,
        TryAgainLater,
        LimitedAccessKeyProvided
    }

}
