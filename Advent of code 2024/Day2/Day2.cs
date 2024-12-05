using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    partial class Day2
    {
        public static void Run(string[] sInput, bool bPart1Check)
        {
            int nSum = 0;

            foreach (string s in sInput)
            {
                string[] strings = s.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                List<int> list = new List<int>();
                List<int> listOG = new List<int>();

                /// Generate the list of levels
                foreach (string s1 in strings)
                {
                    listOG.Add(int.Parse(s1));
                }

                list = new List<int>(listOG);

                bool bWeSafe = true;

                int nIndexFirstCheck = CheckList(list);

                /// For Part 2
                if (nIndexFirstCheck != -1 && bPart1Check == false)
                {
                    /// Check levels without the first number
                    list.RemoveAt(nIndexFirstCheck);
                    int nIndexSecondCheck = CheckList(list);

                    if (nIndexSecondCheck != -1 )
                    {
                        /// If the problematic numbers are the same and we removed the first and the problem is still there, 
                        /// removing the second will not make a difference
                        if (listOG[nIndexFirstCheck] == listOG[nIndexFirstCheck + 1])
                        {
                            bWeSafe = false;
                        }
                        else
                        {
                            list = new List<int>(listOG);
                            /// Check levels without the second number
                            list.RemoveAt(nIndexFirstCheck + 1);
                            int nIndexThirdCheck = CheckList(list);
                            if (nIndexThirdCheck != -1)
                            {
                                bWeSafe = false;
                            }
                        }
                    }
                }
                /// For Part 1
                else if (nIndexFirstCheck != -1 && bPart1Check == true)
                {
                    bWeSafe = false;
                }

                if (bWeSafe == true ) nSum++;
            }

            Console.WriteLine(nSum);
        }

        /// <summary>
        ///  Check if the levels are ok
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        private static int CheckList(List<int> list)
        {
            bool bIncrease = list[0] < list[1];
            for (int i = 0; i < list.Count - 1; i++)
            {
                int nFirst = list[i];
                int nSecond = list[i + 1];

                if (AreLevelsOk(nFirst, nSecond, bIncrease) == false)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Conditions for the levels to be ok
        /// </summary>
        /// <param name="nFirst"></param>
        /// <param name="nSecond"></param>
        /// <param name="bIncrease"></param>
        /// <returns></returns>
        private static bool AreLevelsOk(int nFirst, int nSecond, bool bIncrease)
        {
            bool bWeSafe = true;

            int nDiff = Math.Abs(nFirst - nSecond);

            if (bIncrease == true && nFirst > nSecond ||
                bIncrease == false && nFirst < nSecond)
            {
                bWeSafe = false;
            }

            if (nDiff > 3 || nDiff == 0)
            {
                bWeSafe = false;
            }

            return bWeSafe;
        }
    }
}
