using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Globalization;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public delegate void SettingsUpdatedHandler(object myObject, EventArgs args);

    public class APICharSettings
    {
        private XmlDocument _xml;
        private bool _changed;

        public event SettingsUpdatedHandler SettingsUpdated;

        public APICharSettings(int charID)
        {
            BuildDefaultSettings(charID);
            _changed = true;
        }

        public APICharSettings(XmlDocument xml)
        {
            _xml = xml;
            _changed = false;
        }

        public XmlDocument Xml 
        {
            get { return _xml; }
        }

        public bool Changed
        {
            get { return _changed; }
            set { _changed = value; }
        }

        #region Private methods
        /// <summary>
        /// Build a new settings file containing default data.
        /// </summary>
        /// <param name="keepAccountDetails"></param>
        private void BuildDefaultSettings(int charID)
        {
            _xml = new XmlDocument();

            XmlDeclaration declNode = _xml.CreateXmlDeclaration("1.0", "UTF-16", String.Empty);
            XmlComment commentNode = _xml.CreateComment("EMMA settings file");
            XmlElement settingsNode = _xml.CreateElement("CharacterSettings");
            XmlAttribute idAttrib = _xml.CreateAttribute("CharacterID");
            idAttrib.Value = charID.ToString();
            settingsNode.Attributes.Append(idAttrib);

            _xml.AppendChild(declNode);
            _xml.AppendChild(commentNode);
            _xml.AppendChild(settingsNode);

            // Calling GetValue will create the xml nodes for each setting with default data.
            GetValue(Setting.charAssetsEffectiveDate);
            GetValue(Setting.charAssetsTransUpdateID);
            GetValue(Setting.corpAssetsEffectiveDate);
            GetValue(Setting.corpAssetsTransUpdateID);
            GetValue(Setting.lastCourierDest);
            GetValue(Setting.corpOrdersAPIAccess);
            GetValue(Setting.corpTransactionsAPIAccess);
            GetValue(Setting.corpJournalAPIAccess);
            GetValue(Setting.corpAssetsAPIAccess);
            GetValue(Setting.firstUpdateDoneAssetsChar);
            GetValue(Setting.firstUpdateDoneAssetsCorp);
        }

        /// <summary>
        /// Internal method to return the value of a specified setting from the in-memory settings file.
        /// If the value does not exist then it is added from the default values returned by GetDefaultValue.
        /// </summary>
        /// <param name="node">The setting to return the value for</param>
        /// <returns></returns>
        private string GetValue(Setting node)
        {
            return GetValueNode(node).FirstChild.Value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        private XmlNode GetValueNode(Setting node)
        {
            XmlNode xmlNode = _xml.SelectSingleNode("/CharacterSettings/" + node.ToString());

            try
            {
                if (xmlNode == null)
                {
                    XmlNode parent = _xml.SelectSingleNode("/CharacterSettings");
                    xmlNode = _xml.CreateElement(node.ToString());
                    parent.AppendChild(xmlNode);
                }
                if (xmlNode.FirstChild == null)
                {
                    XmlText xmlValue = _xml.CreateTextNode(GetDefaultValue(node));
                    xmlNode.AppendChild(xmlValue);
                }
            }
            catch (Exception ex)
            {
                EMMASettingsException emmaEx = new EMMASettingsException(ExceptionSeverity.Error,
                    "Error getting value from character settings file for " + node.ToString(), ex);
            }

            return xmlNode;
        }

        /// <summary>
        /// Internal method to set the value of a specified setting in the in-memory settings file.
        /// If the specified setting does not exist then it is added.
        /// </summary>
        /// <param name="node">The setting to set the value of</param>
        /// <param name="value">The value to assign to the specified setting</param>
        private void SetValue(Setting node, string value)
        {
            XmlNode xmlNode = _xml.SelectSingleNode("/CharacterSettings/" + node.ToString());

            try
            {
                if (xmlNode == null)
                {
                    XmlNode parent = _xml.SelectSingleNode("/CharacterSettings");
                    xmlNode = _xml.CreateElement(node.ToString());
                    parent.AppendChild(xmlNode);
                }
                if (xmlNode.FirstChild == null)
                {
                    XmlText xmlValue = _xml.CreateTextNode(value);
                    xmlNode.AppendChild(xmlValue);
                }
                else
                {
                    xmlNode.FirstChild.Value = value;
                }
                _changed = true;
                if (SettingsUpdated != null)
                {
                    SettingsUpdated(this, null);
                }
            }             
            catch (Exception ex)
            {
                EMMASettingsException emmaEx = new EMMASettingsException(ExceptionSeverity.Error,
                    "Error setting value in character settings file for " + node.ToString(), ex);
            }
        }

        /// <summary>
        /// Returns a hardcoded default value for the specified setting
        /// </summary>
        /// <param name="node">The setting to return the default value for</param>
        /// <returns>The default value of the specified setting</returns>
        private string GetDefaultValue(Setting node)
        {
            string retVal = "";
            DateTime defaultDateTime = new DateTime(2000, 01, 01, 01, 01, 01);

            switch (node)
            {
                case Setting.charAssetsEffectiveDate:
                    retVal = defaultDateTime.ToString(CultureInfo.InvariantCulture.DateTimeFormat);
                    break;
                case Setting.charAssetsTransUpdateID:
                    retVal = "0";
                    break;
                case Setting.corpAssetsEffectiveDate:
                    retVal = defaultDateTime.ToString(CultureInfo.InvariantCulture.DateTimeFormat);
                    break;
                case Setting.corpAssetsTransUpdateID:
                    retVal = "0";
                    break;
                case Setting.lastCourierDest:
                    retVal = "60003760"; // Default is Jita 4-4
                    break;
                case Setting.corpOrdersAPIAccess:
                    retVal = bool.TrueString;
                    break;
                case Setting.corpTransactionsAPIAccess:
                    retVal = bool.TrueString;
                    break;
                case Setting.corpJournalAPIAccess:
                    retVal = bool.TrueString;
                    break;
                case Setting.corpAssetsAPIAccess:
                    retVal = bool.TrueString;
                    break;
                case Setting.firstUpdateDoneAssetsChar:
                    retVal = bool.FalseString;
                    break;
                case Setting.firstUpdateDoneAssetsCorp:
                    retVal = bool.FalseString;
                    break;
                default:
                    break;
            }

            return retVal;
        }
        #endregion

        #region Public properties to access settings
        public DateTime CharAssetsEffectiveDate
        {
            get { return DateTime.Parse(GetValue(Setting.charAssetsEffectiveDate), CultureInfo.InvariantCulture.DateTimeFormat); }
            set { SetValue(Setting.charAssetsEffectiveDate, value.ToString(CultureInfo.InvariantCulture.DateTimeFormat)); }
        }

        public long CharAssetsTransUpdateID
        {
            get { return long.Parse(GetValue(Setting.charAssetsTransUpdateID), System.Globalization.CultureInfo.InvariantCulture.NumberFormat); }
            set { SetValue(Setting.charAssetsTransUpdateID, value.ToString(CultureInfo.InvariantCulture.NumberFormat)); }
        }

        public DateTime CorpAssetsEffectiveDate
        {
            get { return DateTime.Parse(GetValue(Setting.corpAssetsEffectiveDate), CultureInfo.InvariantCulture.DateTimeFormat); }
            set { SetValue(Setting.corpAssetsEffectiveDate, value.ToString(CultureInfo.InvariantCulture.DateTimeFormat)); }
        }

        public long CorpAssetsTransUpdateID
        {
            get { return long.Parse(GetValue(Setting.corpAssetsTransUpdateID), System.Globalization.CultureInfo.InvariantCulture.NumberFormat); }
            set { SetValue(Setting.corpAssetsTransUpdateID, value.ToString(CultureInfo.InvariantCulture.NumberFormat)); }
        }

        public int LastCourierDestination
        {
            get { return int.Parse(GetValue(Setting.lastCourierDest), System.Globalization.CultureInfo.InvariantCulture.NumberFormat); }
            set { SetValue(Setting.lastCourierDest, value.ToString(CultureInfo.InvariantCulture.NumberFormat)); }
        }

        public bool CorpOrdersAPIAccess
        {
            get { return bool.Parse(GetValue(Setting.corpOrdersAPIAccess)); }
            set { SetValue(Setting.corpOrdersAPIAccess, value.ToString()); }
        }
        public bool CorpJournalAPIAccess
        {
            get { return bool.Parse(GetValue(Setting.corpJournalAPIAccess)); }
            set { SetValue(Setting.corpJournalAPIAccess, value.ToString()); }
        }
        public bool CorpTransactionsAPIAccess
        {
            get { return bool.Parse(GetValue(Setting.corpTransactionsAPIAccess)); }
            set { SetValue(Setting.corpTransactionsAPIAccess, value.ToString()); }
        }
        public bool CorpAssetsAPIAccess
        {
            get { return bool.Parse(GetValue(Setting.corpAssetsAPIAccess)); }
            set { SetValue(Setting.corpAssetsAPIAccess, value.ToString()); }
        }

        public bool FirstUpdateDoneAssetsChar
        {
            get { return bool.Parse(GetValue(Setting.firstUpdateDoneAssetsChar)); }
            set { SetValue(Setting.firstUpdateDoneAssetsChar, value.ToString()); }
        }
        public bool FirstUpdateDoneAssetsCorp
        {
            get { return bool.Parse(GetValue(Setting.firstUpdateDoneAssetsCorp)); }
            set { SetValue(Setting.firstUpdateDoneAssetsCorp, value.ToString()); }
        }
        #endregion

        private enum Setting
        {
            charAssetsEffectiveDate,
            charAssetsTransUpdateID,
            corpAssetsEffectiveDate,
            corpAssetsTransUpdateID,
            lastCourierDest,
            corpOrdersAPIAccess,
            corpJournalAPIAccess,
            corpTransactionsAPIAccess,
            corpAssetsAPIAccess,
            firstUpdateDoneAssetsChar,
            firstUpdateDoneAssetsCorp
        }

    }
}