using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EveMarketMonitorApp.GUIElements
{
    public partial class ExportData : Form
    {
        public ExportData()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Format format = Format.XML;

            if (rdbCSV.Checked)
            {
                format = Format.CSV;
            }

            SortedList<object, string> options = new SortedList<object, string>();
            Type enumType = typeof(Table);
            foreach(string value in Enum.GetNames(enumType))
            {
                options.Add(Enum.Parse(enumType, value), value);
            }
            OptionPicker dialog = new OptionPicker("Data to export", "Choose the data that " +
                "you wish to export from EMMA.\r\nNote that you can also create CSV files " +
                "from any report by right clicking it and choosing the 'export to CSV option'",
                options);
            if (dialog.ShowDialog() != DialogResult.Cancel)
            {
                Table result = (Table)dialog.SelectedItem;

                switch (format)
                {
                    case Format.CSV:
                        ExportCSV(result);
                        break;
                    case Format.XML:
                        ExportXML(result);
                        break;
                    default:
                        break;
                }

                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ExportCSV(Table table)
        {
            //DataTable tableData = null;

            switch (table)
            {
                case Table.Transactions:
                    break;
                case Table.Journal:
                    break;
                case Table.Orders:
                    break;
                case Table.Assets:
                    break;
                case Table.Contracts:
                    break;
                default:
                    break;
            }
        }

        private void ExportXML(Table table)
        {
            switch (table)
            {
                case Table.Transactions:
                    break;
                case Table.Journal:
                    break;
                case Table.Orders:
                    break;
                case Table.Assets:
                    break;
                case Table.Contracts:
                    break;
                default:
                    break;
            }
        }

        private enum Format
        {
            CSV,
            XML
        }

        private enum Table
        {
            Transactions,
            Journal,
            Orders,
            Assets,
            Contracts
        }
    }
}