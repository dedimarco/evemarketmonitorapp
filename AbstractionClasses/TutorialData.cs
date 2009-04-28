using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
using System.Windows.Forms;

using EveMarketMonitorApp.Common;

namespace EveMarketMonitorApp.AbstractionClasses
{
    public static class TutorialData
    {
        private static string _tutorialFile = string.Format("{0}Data{1}Tutorial_{2}.xml",
            AppDomain.CurrentDomain.BaseDirectory, Path.DirectorySeparatorChar,
            System.Globalization.CultureInfo.CurrentCulture.IetfLanguageTag);
        private static string _defaultTutorialFile = string.Format("{0}Data{1}Tutorial_default.xml",
            AppDomain.CurrentDomain.BaseDirectory, Path.DirectorySeparatorChar);
        private static TutSectionsList _tutorialData = null;


        public static TutSectionsList GetTutorialData()
        {
            if (_tutorialData == null)
            {
                try
                {
                    LoadXML();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading tutorial data: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return _tutorialData;
        }

        private static void LoadXML()
        {
            string filename = "";

            if (File.Exists(_tutorialFile))
            {
                filename = _tutorialFile;
            }
            else
            {
                if (File.Exists(_defaultTutorialFile))
                {
                    filename = _defaultTutorialFile;
                }
                else
                {
                    throw new EMMAException(ExceptionSeverity.Warning, "Tutorial file missing (" +
                        _tutorialFile + ")");
                }
            }

            try
            {
                XmlDocument xmlData = new XmlDocument();
                XmlReaderSettings settings = new XmlReaderSettings();
                xmlData.Load(XmlReader.Create(filename, settings));

                _tutorialData = new TutSectionsList();

                XmlNodeList tutorialNodes = xmlData.SelectNodes("/tutorial/section");
                AddSections(_tutorialData, tutorialNodes, null, 0, new List<string>());
            }
            catch (Exception ex)
            {
                EMMAException emmaex = ex as EMMAException;
                if (emmaex == null)
                {
                    emmaex = new EMMAException(ExceptionSeverity.Error, "Problem loading tutorial data", ex);
                }
                MessageBox.Show("There was a problem loading the tutorial data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _tutorialData = new TutSectionsList();
            }

        }

        private static void AddSections(TutSectionsList list, XmlNodeList nodes, 
            TutorialSection parent, int level, List<string> sectionNames)
        {
            foreach (XmlNode node in nodes)
            {
                string title = "No title";
                string nextSection = "";
                string prevSection = "";
                string text = "No text";

                XmlNode titleNode = node.SelectSingleNode("@title");
                if (titleNode != null) { title=  titleNode.Value; }
                XmlNode nextNode = node.SelectSingleNode("@next");
                if (nextNode != null) { nextSection = nextNode.Value; }
                XmlNode prevNode = node.SelectSingleNode("@previous");
                if (prevNode != null) { prevSection = prevNode.Value; }
                XmlNode textNode = node.SelectSingleNode("@text");
                if (textNode != null) { text = textNode.Value; }

                if (title.Equals("No Title"))
                {
                    int counter = 1;
                    while (sectionNames.Contains(title))
                    {
                        title = "No title " + counter;
                    }
                }
                if (sectionNames.Contains(title))
                {
                    throw new EMMAException(ExceptionSeverity.Error, "Tutorial file contains duplicate " +
                        "section name. (" + title + ")");
                }
                sectionNames.Add(title);
                TutorialSection section = new TutorialSection(title, nextSection, prevSection, text, 
                    level, parent);
                list.Add(section);

                XmlNodeList tutorialNodes = node.SelectNodes("section");
                AddSections(section.Subsections, tutorialNodes, section, level + 1, sectionNames);
            }
        }

        /*
        public static void WriteSections(TutSectionsList sections)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode root = xmldoc.CreateElement("tutorial");
            xmldoc.AppendChild(root);
            AddSections(sections, root);
            xmldoc.Save(_defaultTutorialFile);
        }

        private static void AddSections(TutSectionsList sections, XmlNode parent)
        {
            XmlDocument doc = parent.OwnerDocument;
            foreach (TutorialSection section in sections)
            {
                XmlElement node = doc.CreateElement("section");
                XmlAttribute titleAtt = doc.CreateAttribute("title");
                titleAtt.Value = section.Title;
                XmlAttribute nextAtt = doc.CreateAttribute("next");
                nextAtt.Value = section.NextSection;
                XmlAttribute prevAtt = doc.CreateAttribute("previous");
                prevAtt.Value = section.PrevSection;
                XmlAttribute textAtt = doc.CreateAttribute("text");
                textAtt.Value = section.Text;
                node.SetAttributeNode(titleAtt);
                node.SetAttributeNode(nextAtt);
                node.SetAttributeNode(prevAtt);
                node.SetAttributeNode(textAtt);
                AddSections(section.Subsections, node);
                parent.AppendChild(node);
            }
        }*/
    }

    public class TutorialSection
    {
        private string _title;
        private string _text;
        private TutSectionsList _subsections;
        private string _next;
        private string _prev;
        private int _level = 0;
        private TutorialSection _parent = null;
        
        public TutorialSection(string title, string nextSection, string prevSection, string text, int level,
            TutorialSection parentSection)
        {
            _title = title;
            _text = text;
            _next = nextSection;
            _prev = prevSection;
            _level = level;
            _parent = parentSection;
            _subsections = new TutSectionsList();
        }

        public TutSectionsList Subsections
        {
            get { return _subsections; }
        }

        public string Title
        {
            get { return _title; }
        }

        public string TitleText
        {
            get
            {
                return (_parent == null ? "" : _parent.TitleText + "->") + _title;
            }
        }

        public string Text
        {
            get { return _text; }
        }

        public string NextSection
        {
            get { return _next; }
            set { _next = value; }
        }

        public string PrevSection
        {
            get { return _prev; }
            set { _next = value; }
        }

        public TutorialSection ParentSection
        {
            get { return _parent; }
            set { _parent = value; }
        }

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }

        public TutorialSection GetSection(string name)
        {
            TutorialSection retVal = null;
            if (_title.Equals(name))
            {
                retVal = this;
            }
            else
            {
                for (int i = 0; i < _subsections.Count; i++)
                {
                    TutorialSection section = _subsections[i];
                    retVal = section.GetSection(name);
                    if (retVal != null)
                    {
                        i = _subsections.Count;
                    }
                }
            }
            return retVal;
        }
    }

    public class TutSectionsList : List<TutorialSection>
    {
        public TutSectionsList()
            : base()
        {
        }

        public TutorialSection GetSection(string name)
        {
            TutorialSection retVal = null;
            for (int i = 0; i < this.Count; i++)
            {
                TutorialSection section = this[i];
                retVal = section.GetSection(name);
                if (retVal != null)
                {
                    i = this.Count;
                }
            }
            return retVal;
        }
    }

}
