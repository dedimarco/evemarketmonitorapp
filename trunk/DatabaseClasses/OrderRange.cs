using System;
using System.Collections.Generic;
using System.Text;

namespace EveMarketMonitorApp.DatabaseClasses
{
    public static class OrderRange
    {
        private static Dictionary<int, string> _rangeText = new Dictionary<int, string>();
        private static bool _initalised = false;

        /// <summary>
        /// Get the text description of the specified range value
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static string GetRangeText(int range)
        {
            string retVal = "";
            if (!_initalised) { Initialise(); }

            _rangeText.TryGetValue(range, out retVal);
            if (retVal == null || retVal.Equals(""))
            {
                retVal = range + " Jumps";
                _rangeText.Add(range, retVal);
            }

            return retVal;
        }

        /// <summary>
        /// Get the range value for the specified text description.
        /// </summary>
        /// <param name="rangeText"></param>
        /// <returns></returns>
        public static int GetRangeFromText(string rangeText)
        {
            int retVal = 0;
            int spacePos = rangeText.IndexOf(" ");
            if (spacePos >= 0 && spacePos < rangeText.Length && !rangeText.Equals("Solar System"))
            {
                retVal = int.Parse(rangeText.Remove(rangeText.IndexOf(" ")));
            }
            else
            {
                if (rangeText.Equals("Station")) retVal = -1;
                if (rangeText.Equals("Solar System")) retVal = 0;
                if (rangeText.Equals("Region")) retVal = 32767;
            }

            return retVal;
        }

        /// <summary>
        /// Get a list of the descriptions of the most common range values
        /// </summary>
        /// <returns></returns>
        public static string[] GetStandardRanges()
        {
            string[] retVal = { "Station", "Solar System", "1 Jump", "2 Jumps", "3 Jumps", "4 Jumps", "5 Jumps", 
                "6 Jumps", "7 Jumps", "8 Jumps", "9 Jumps", "10 Jumps", "15 Jumps", "20 Jumps" };
            return retVal;
        }


        private static void Initialise()
        {
            _rangeText.Clear();
            _rangeText.Add(-1, "Station");
            _rangeText.Add(0, "Solar System");
            _rangeText.Add(1, "1 Jump");
            _rangeText.Add(32767, "Region");
        }
    }
}
