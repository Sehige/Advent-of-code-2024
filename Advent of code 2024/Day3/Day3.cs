using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    internal class Day3
    {
        public static string startDelimiter = "mul(";
        public static string endDelimiter = ")";

        public static string sEnable = "do()";
        public static string sDisable = "don't()";

        public static void Run(string[] inputString)
        {
            string sFullString = string.Join("", inputString);

            long lSum = 0;

            List<string> listNumbers = ExtractSubstrings(sFullString);

            foreach (string substring in listNumbers)
            {
                if (substring.Contains(',') == false) continue;

                string[] sNumbers = substring.Split(",", StringSplitOptions.RemoveEmptyEntries);

                if (int.TryParse(sNumbers[0], out int nFirst) == false)
                {
                    Console.WriteLine("BAD at first");
                    continue;
                }

                if (int.TryParse(sNumbers[1], out int nSecond) == false)
                {
                    Console.WriteLine("BAD at second");
                    continue;
                }

                lSum += nFirst * nSecond;
            }

            Console.WriteLine(lSum);
        }

        /// <summary>
        /// Extracts all substrings between "mul(" and ")".
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<string> ExtractSubstrings(string input)
        {
            List<string> substrings = new List<string>();
            int startIndex = 0;

            int nIndexEnable = 0;
            int nIndexDisable = input.IndexOf(sDisable);

            int nBiggerValue = nIndexDisable;

            while ((startIndex = input.IndexOf(startDelimiter, startIndex)) != -1)
            {
                #region Part 2

                if (nBiggerValue < startIndex)
                {
                    nIndexEnable = input.IndexOf(sEnable, nBiggerValue);
                    nIndexDisable = input.IndexOf(sDisable, nBiggerValue);

                    if (nIndexEnable == -1) break;

                    nBiggerValue = Math.Max(nIndexEnable, nIndexDisable);
                }

                if (startIndex < nIndexEnable && startIndex > nIndexDisable && nIndexDisable != -1)
                {
                    startIndex = nIndexEnable;
                    continue;
                }

                #endregion

                startIndex += startDelimiter.Length;
                int endIndex = input.IndexOf(endDelimiter, startIndex);
                if (endIndex == -1)
                {
                    break; // End delimiter not found
                }

                if (Math.Abs(startIndex - endIndex) > 7)
                {
                    continue; // Skip if the substring is too long
                }

                string substring = input.Substring(startIndex, endIndex - startIndex);
                substrings.Add(substring);

                startIndex = endIndex + endDelimiter.Length;
            }

            return substrings;
        }
    }
}
