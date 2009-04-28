using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using EveMarketMonitorApp.AbstractionClasses;

namespace EveMarketMonitorApp.GUIElements
{
    public delegate void TutorialSectionSelectedHandler(object myObject, TutorialSectionArgs args);
    
    public partial class TutorialIndex : Form
    {
        public event TutorialSectionSelectedHandler TutorialSectionSelected;
        private TutSectionsList _sections;

        public TutorialIndex(TutSectionsList sections)
        {
            InitializeComponent();
            _sections = sections;
        }

        private void TutorialIndex_Load(object sender, EventArgs e)
        {
            tutorialTreeView.Nodes.Clear();
            tutorialTreeView.BeginUpdate();
            foreach (TutorialSection section in _sections)
            {
                TreeNode newNode = new TreeNode(section.Title);
                if (section.Subsections.Count > 0)
                {
                    BuildTree(newNode, section);
                }
                tutorialTreeView.Nodes.Add(newNode);
            }
            tutorialTreeView.EndUpdate();
        }

        private void BuildTree(TreeNode rootNode, TutorialSection rootSection)
        {
            foreach (TutorialSection section in rootSection.Subsections)
            {
                TreeNode newNode = new TreeNode(section.Title);
                rootNode.Nodes.Add(newNode);
                if (section.Subsections.Count > 0)
                {
                    BuildTree(newNode, section);
                }
            }
        }

        public void SetSelected(string sectionName)
        {
            tutorialTreeView.SelectedNode = FindNode(sectionName, tutorialTreeView.Nodes);
        }

        private TreeNode FindNode(string sectionName, TreeNodeCollection nodes)
        {
            TreeNode retVal = null;
            for (int i = 0; i < nodes.Count; i++)
            {
                TreeNode node = nodes[i];
                if (node.Text.Equals(sectionName))
                {
                    retVal = node;
                    i = nodes.Count;
                }
                else if (node.Nodes.Count > 0)
                {
                    node = FindNode(sectionName, node.Nodes);
                    if (node != null)
                    {
                        retVal = node;
                        i = nodes.Count;
                    }
                }
            }
            return retVal;
        }

        private void SectionSelected(string sectionName)
        {
            if (TutorialSectionSelected != null)
            {
                TutorialSectionSelected(this, new TutorialSectionArgs(sectionName));
            }
        }

        private void tutorialTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           // SectionSelected(e.Node.Text);
        }

        private void tutorialTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SectionSelected(e.Node.Text);
        }

    }

    public class TutorialSectionArgs : EventArgs
    {
        private string _sectionName;

        public TutorialSectionArgs(string sectionName)
        {
            _sectionName = sectionName;
        }


        public string SectionName
        {
            get { return _sectionName; }
            set { _sectionName = value; }
        }

    }
}