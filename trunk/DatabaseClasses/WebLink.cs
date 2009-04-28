using System;
using System.Collections.Generic;
using System.Text;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public class WebLink : SortableObject
    {
        private int _id;
        private string _link;
        private string _desc;
        private int _corpID;

        public WebLink(int corpID)
        {
            _id = 0;
            _link = "";
            _desc = "";
            _corpID = corpID;
        }

        public WebLink(EMMADataSet.WebLinksRow data)
        {
            _id = data.WebLinkID;
            _link = data.Link;
            _desc = data.Description;
            _corpID = data.CorpID;
        }

        public int ID
        {
            get { return _id; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public string Description
        {
            get { return _desc; }
            set { _desc = value; }
        }

        public int CorpID
        {
            get { return _corpID; }
            set { _corpID = value; }
        }
    }
}
