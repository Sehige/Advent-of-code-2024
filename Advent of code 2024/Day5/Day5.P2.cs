using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    partial class Day5
    {
        public static void RunP2(string[] sTextInput)
        {
            GenerateDictionary(sTextInput);

            int nSum = 0;
            List<string> listWrong = new List<string>();

            /// Generate the list of wrong values
            foreach (string s in sTextInput)
            {
                if (s.Contains(',') == false) continue;

                string[] sSplit = s.Split(",");

                listToCheck = [.. sSplit];

                bool bWasOk = IsListCorrect();

                if (bWasOk == true) continue;

                listWrong.Add(s);
            }

            for (int i = 0; i < listWrong.Count(); i++)
            {
                string sWrong = listWrong[i];

                bool bWrong = true;

                string[] sSplit = sWrong.Split(",");

                listToCheck = new List<string>(sSplit);

                /// Correct the list
                while (bWrong == true)
                {
                    for (int j = 0; j < listToCheck.Count; j++)
                    {
                        string sValue = listToCheck[j];

                        if (dictionaryValues.ContainsKey(sValue) == false) continue;

                        string sValues = dictionaryValues[sValue];
                        for (int ascend = j + 1; ascend < listToCheck.Count; ascend++)
                        {
                            bWrong = false;
                            if (sValues.Contains(listToCheck[ascend]) == true) continue;

                            SwapNumbers(j, ascend);
                            bWrong = true;
                            break;
                        }

                        if (bWrong == true) break;

                        for (int descend = j; descend > -1; descend--)
                        {
                            bWrong = false;
                            if (sValues.Contains(listToCheck[descend]) == false) continue;

                            SwapNumbers(j, descend);
                            bWrong = true;
                            break;
                        }

                        if (bWrong == true) break;
                    }
                }

                int middleIndex = (int)Math.Floor(listToCheck.Count / 2.0);

                if (int.TryParse(listToCheck[middleIndex], out int nMidd))
                {
                    nSum += nMidd;
                }
                Console.WriteLine(nMidd);
            }

            Console.WriteLine(nSum);
        }

        private static void SwapNumbers(int n1, int n2)
        {
            string sToSwap = listToCheck[n1];
            listToCheck[n1] = listToCheck[n2];
            listToCheck[n2] = sToSwap;
        }
    }

}
