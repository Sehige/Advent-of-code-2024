using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    internal class Day7
    {
        public static List<ulong> listNumbers = new List<ulong>();
        public static List<string> listSymbols = new List<string>();
        public static bool bP2 = true;

        public static void RunP1(string[] strings)
        {
            ulong nSumFinal = 0;

            foreach (var s in strings)
            {
                string[] line = s.Split(":");
                ulong nFinalNumber = ulong.Parse(line[0]);

                List<string> listNumbersString = line[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();
                listNumbers = listNumbersString.Select(ulong.Parse).ToList();

                List<ulong> results = new List<ulong>();

                foreach (ulong nNr in listNumbers)
                {
                    if (results.Count == 0)
                    {
                        results.Add(nNr);
                        continue;
                    }
                     
                    List<ulong> newResults = new List<ulong>();
                    for (int i = 0; i < results.Count; i++)
                    {
                        ulong sum = results[i] + nNr;
                        ulong mul = results[i] * nNr;
                        ulong concat = ulong.Parse(results[i].ToString() + nNr.ToString());

                        if (sum <= nFinalNumber)
                        {
                            newResults.Add(sum);
                        }
                        if (mul <= nFinalNumber)
                        {
                            newResults.Add(mul);
                        }
                        if (concat <= nFinalNumber && bP2 == true)
                        {
                            newResults.Add(concat);
                        }
                    }

                    results = newResults;
                }

                if (results.Contains(nFinalNumber) == false) continue;

                nSumFinal += nFinalNumber;
            }

            Console.WriteLine("Day 7: " + nSumFinal);
        }
    }
}
