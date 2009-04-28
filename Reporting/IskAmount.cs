using System;
using System.Collections.Generic;
using System.Text;

namespace EveMarketMonitorApp.Reporting
{
    class IskAmount
    {
        private decimal amount;
        private IskMultiplier outputMultiplier = IskMultiplier.ISK;
        //private static string thouSep = System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.CurrencyGroupSeparator;
        //private static string decSep = System.Globalization.CultureInfo.CurrentUICulture.NumberFormat.CurrencyDecimalSeparator;
        private static string thouSep = System.Globalization.CultureInfo.InvariantCulture.NumberFormat.CurrencyGroupSeparator;
        private static string decSep = System.Globalization.CultureInfo.InvariantCulture.NumberFormat.CurrencyDecimalSeparator;

        public IskAmount(decimal amount)
        {
            this.amount = amount;
        }

        public IskAmount(decimal amount, IskMultiplier outputValue)
        {
            this.amount = amount;
            outputMultiplier = outputValue;
        }

        public static string FormatString()
        {
            return "#" + thouSep + "##0" + decSep + "00 ISK;(#" + thouSep + "##0" + decSep + "00) ISK;-";
        }

        public override string ToString()
        {
            string iskFormat = FormatString();

            switch (outputMultiplier)
            {
                case IskMultiplier.ISK:
                    iskFormat = "{0:#" + thouSep + "##0" + decSep + "00;(#" + thouSep + "##0" + decSep + "00);-} ISK";
                    break;
                case IskMultiplier.Thousands:
                    iskFormat = "{0:#" + thouSep + "##0" + thouSep + decSep + "00;(#" + thouSep + "##0" + thouSep + decSep + "00);-} ISK";
                    break;
                case IskMultiplier.Millions:
                    iskFormat = "{0:#" + thouSep + "##0" + thouSep + thouSep + decSep + "00;(#" + thouSep + "##0" + thouSep + thouSep + decSep + "00);-} ISK";
                    break;
                case IskMultiplier.Billions:
                    iskFormat = "{0:#" + thouSep + "##0" + thouSep + thouSep + thouSep + decSep + "00;(#" + thouSep + "##0" + thouSep + thouSep + thouSep + decSep + "00);-} ISK";
                    break;
                default:
                    break;
            }

            return string.Format(iskFormat, amount);
        }

    }

    public enum IskMultiplier
    {
        ISK,
        Thousands,
        Millions,
        Billions
    }
}
