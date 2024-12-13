using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    partial class Day5
    {
        public static Dictionary<string, string> dictionaryValues = new Dictionary<string, string>();
        public static List<string> listToCheck = new List<string>();

        public static void RunP1(string[] sTextInput)
        {
            GenerateDictionary(sTextInput);

            int nSum = 0;
            foreach (string s in sTextInput)
            {
                if (s.Contains(',') == false) continue;

                string[] sSplit = s.Split(",");

                listToCheck = new List<string>();

                foreach (string sValue in sSplit)
                {
                    listToCheck.Add(sValue);
                }

                bool bWasOk = IsListCorrect();

                if (bWasOk == false) continue;

                int middleIndex = (int)Math.Floor(listToCheck.Count / 2.0);
                
                if (int.TryParse(listToCheck[middleIndex], out int nMidd))
                {
                    nSum += nMidd;
                }
                Console.WriteLine(nMidd);
            }

            Console.WriteLine(nSum);
        }

        private static void GenerateDictionary(string[] sTextInput)
        {
            foreach (string s in sTextInput)
            {
                if (s.Contains('|') == false)
                {
                    break;
                }

                string[] sSplit = s.Split("|");
                string sKey = sSplit[0];
                string sValue = sSplit[1] + ",";

                if (dictionaryValues.ContainsKey(sKey))
                {
                    sValue += dictionaryValues[sKey];
                    dictionaryValues[sKey] = sValue;
                }
                else
                {
                    dictionaryValues.Add(sKey, sValue);
                }
            }
        }

        private static bool IsListCorrect()
        {
            bool bWasOk = true;

            for (int i = 0; i < listToCheck.Count; i++)
            {
                string sValue = listToCheck[i];

                if (dictionaryValues.ContainsKey(sValue) == false) continue;

                string sValues = dictionaryValues[sValue];

                /// Check if wrong numbers are after the Value
                for (int ascend = i + 1; ascend < listToCheck.Count; ascend++)
                {
                    if (sValues.Contains(listToCheck[ascend]) == true) continue;

                    bWasOk = false;
                }

                /// Check if wrong numbers are not before the Value
                for (int descend = i; descend > -1; descend--)
                {
                    if (sValues.Contains(listToCheck[descend]) == false) continue;

                    bWasOk = false;
                }
            }

            return bWasOk;
        }
    }
}
