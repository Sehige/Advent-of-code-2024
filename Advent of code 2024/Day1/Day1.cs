using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    partial class Day1
    {
        public static void Run(string[] sTextInput)
        {
            GetListFloats(sTextInput);
            return;
        }

        public static (List<long>, List<long>) GetListFloats(string[] sTextInput)
        {
            List<long> firstList = new List<long>();
            List<long> secondList = new List<long>();

            foreach (string s in sTextInput)
            {
                string[] strings = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                long nFirst = int.Parse(strings[0]);
                long nSecond = int.Parse(strings[1]);
                firstList.Add(nFirst);
                secondList.Add(nSecond);
            }

            secondList.Sort();

            firstList.Sort();

            //Part1(firstList, secondList);

            Part2(firstList, secondList);

            return (firstList, secondList);
        }


        public static void Part1(List<float> firstList, List<float> secondList)
        {
            bool bFound = true;
            float nSum = 0;
            while (bFound == true)
            {
                float nFirstNumber = firstList.First();
                float nSecondNumber = secondList.First();
                float nDiff = Math.Abs(nFirstNumber - nSecondNumber);
                Console.WriteLine(nDiff);
                nSum += nDiff;
                firstList.RemoveAt(0);
                secondList.RemoveAt(0);
                if (firstList.Count == 0 || secondList.Count == 0)
                {
                    bFound = false;
                }
            }
            Console.WriteLine(nSum);
        }

        public static void Part2(List<long> firstList, List<long> secondList)
        {
            float fSum = 0;
            for (int i = 0; i < firstList.Count; i++)
            {
                long nFirstNumber = firstList[i];
                int nNumberOf = 0;
                foreach (long nSecondNumber in secondList)
                {
                    if (nFirstNumber < nSecondNumber) break;
                    if (nFirstNumber != nSecondNumber) continue;

                    nNumberOf++;
                }

                if (nNumberOf == 0) continue;

                long nMulti = nFirstNumber * nNumberOf;
                Console.WriteLine(nMulti);
                fSum += nMulti;
            }

            Console.WriteLine(fSum);
        }
    }
}
