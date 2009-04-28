using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class OptionPicker : Form
    {
        private List<RadioButton> _optionButtons = new List<RadioButton>();
        private SortedList<object, string> _options;
        private List<string> _sortedItems;
        private object _selectedItem;

        public object SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; }
        }

        public OptionPicker(string title, string helpText, SortedList<object, string> options)
        {
            InitializeComponent();

            this.Text = title;
            lblInfo.Text = helpText;
            _options = options;
            _sortedItems = new List<string>();
            foreach (KeyValuePair<object, string> option in _options)
            {
                _sortedItems.Add(option.Value);
            }
            _sortedItems.Sort(new OptionSorter());
        }

        private void OptionPicker_Load(object sender, EventArgs e)
        {
            BuildOptions();
        }


        private void BuildOptions()
        {
            int index = 0;
            int x = 8;
            int y = 6;

            _optionButtons = new List<RadioButton>();

            foreach (string text in _sortedItems)
            {
                object key = _options.Keys[_options.IndexOfValue(text)];
                _optionButtons.Add(new RadioButton());
                _optionButtons[index].Text = text;
                _optionButtons[index].Width = optionsPanel.Width - x - 20;
                _optionButtons[index].Parent = optionsPanel;
                _optionButtons[index].Location = new Point(x, y);
                _optionButtons[index].Checked = index == 0;
                _optionButtons[index].TextAlign = ContentAlignment.MiddleLeft;
                _optionButtons[index].Tag = key;
                _optionButtons[index].Show();
                y = y + _optionButtons[index].Height;
                index++;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            foreach (RadioButton button in _optionButtons)
            {
                if (button.Checked)
                {
                    SelectedItem = button.Tag;
                }
            }
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private class OptionSorter : IComparer<string>
        {
            public int Compare(string a, string b)
            {
                int retVal = 0;

                if (a != null && b == null) { retVal = 1; }
                else if (a == null && b != null) { retVal = -1; }
                else if (a == null && b == null) { retVal = 0; }
                else
                {
                    retVal = string.Compare(a, b, StringComparison.Ordinal);
                }

                return retVal;
            }
        }
    }
}