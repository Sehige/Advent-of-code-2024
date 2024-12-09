using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    partial class Day4
    {
        public static string[] sInputString;
        public const string sNull = "..........";
        public static int nMAS = 0;
        public static string sMAS = "MAS";

        public static void Run(string[] inputString)
        {
            string line1 = null, line2, line3 = null;

            sInputString = inputString;
            nMAS = 0;

            for (int i = 0; i < sInputString.Length; i++)
            {
                //SearchForX(i);

                if(i == 0 || i == sInputString.Length - 1) continue;
                // Part 2
                SearchForA(i);
            }

            //Console.WriteLine(nMAS);

            // Part 2
            Console.WriteLine(nXMAS);
        }

        private static void SearchForX(int nLine2)
        {
            string line2 = sInputString[nLine2];
            
            for (int i = 0; i < line2.Length; i++)
            {
                if (line2[i] != 'X') continue;

                if (IsSpaceAbove(nLine2))
                {
                    if (SearchAboveForMAS(nLine2, i, 0))
                    {
                        nMAS++;
                    }

                    if (IsSpaceLeft(i) == true)
                    {
                        SearchDiagForMAS(nLine2, i, 0, -1, -1);
                    }
                    if (IsSpaceRight(i) == true)
                    {
                        SearchDiagForMAS(nLine2, i, 0, 1, -1);
                    }
                }

                if(IsSpaceBelow(nLine2))
                {
                    if (SearchBelowForMAS(nLine2, i, 0))
                    {
                        nMAS++;
                    }

                    if (IsSpaceLeft(i) == true)
                    {
                        SearchDiagForMAS(nLine2, i, 0, -1, 1);
                    }
                    if (IsSpaceRight(i) == true)
                    {
                        SearchDiagForMAS(nLine2, i, 0, 1, 1);
                    }
                }

                SearchLongForMAS(nLine2, i, 0);
            }

            Console.WriteLine("Line:{0}, Value: {1}", nLine2, nMAS);
        }



        /// <summary>
        /// Search diagonaly from X
        /// 0-----0
        /// -0---0-
        /// --0-0--
        /// ---X---
        /// --0-0--
        /// -0---0-
        /// 0-----0
        /// It goes with -1 or +1 with each itteration up and down
        /// </summary>
        /// <param name="nLine2"></param>
        /// <param name="nIndexX"></param>
        /// <param name="nCharToFind"></param>
        /// <param name="nValueDiag"></param>
        /// <param name="nDirection"></param>
        private static void SearchDiagForMAS(int nLine2, int nIndexX, int nCharToFind, int nValueDiag,int nDirection)
        {
            if (nCharToFind >= sMAS.Length)
            {
                nMAS++;
                return;
            }
            int nSignValue = Math.Sign(nValueDiag);
            int nSignDir = Math.Sign(nDirection);
            char cToFind = sMAS[nCharToFind];

            string line = sInputString[nLine2 + nDirection];

            if (line[nIndexX + nValueDiag] == cToFind) SearchDiagForMAS(nLine2, nIndexX, nCharToFind + 1, nValueDiag + (nSignValue * 1), nDirection + (nSignDir * 1));
        }

        /// <summary>
        /// Search to the left and right of The X
        /// </summary>
        /// <param name="nLine2"></param>
        /// <param name="nIndexX"></param>
        /// <param name="nCharToFind"></param>
        private static void SearchLongForMAS(int nLine2, int nIndexX, int nCharToFind)
        {
            string line2;
            line2 = sInputString[nLine2];

            bool bFound = true;

            if (IsSpaceLeft(nIndexX))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (line2[nIndexX - i - 1] != sMAS[i]) bFound = false;
                }

                if (bFound)
                {
                    nMAS++;
                }
            }

            bFound = true;

            if (IsSpaceRight(nIndexX))
            {
                for (int i = 0; i < 3; i++)
                {
                    if (line2[nIndexX + i + 1] != sMAS[i]) bFound = false;
                }

                if (bFound)
                {
                    nMAS++;
                }
            }
        }

        /// <summary>
        /// Can you search to the left of the line
        /// </summary>
        /// <param name="nIndexX"></param>
        /// <returns></returns>
        private static bool IsSpaceLeft(int nIndexX)
        {
            if (nIndexX < 3) return false;
            return true;
        }

        /// <summary>
        /// Can you search to the right of the line
        /// </summary>
        /// <param name="nIndexX"></param>
        /// <returns></returns>
        private static bool IsSpaceRight(int nIndexX)
        {
            if (nIndexX > sInputString[0].Length - 4) return false;
            return true;
        }

        /// <summary>
        /// Can you search above the line
        /// </summary>
        /// <param name="nLine2"></param>
        /// <returns></returns>
        private static bool IsSpaceAbove(int nLine2)
        {
            if (nLine2 < 3) return false;
            return true;
        }

        /// <summary>
        ///  Can you search below the line
        /// </summary>
        /// <param name="nLine2"></param>
        /// <returns></returns>
        private static bool IsSpaceBelow(int nLine2)
        {
            if (nLine2 > sInputString.Length - 4) return false;

            return true;
        }

        private static bool SearchAboveForMAS(int nLine2, int nIndexX, int nCharToFind)
        {
            bool bFound = true;

            for (int i = 0; i < 3; i++) 
            {
                if (sInputString[nLine2 - i - 1][nIndexX] != sMAS[i]) bFound = false;
            }

            return bFound;
        }


        private static bool SearchBelowForMAS(int nLine2, int nIndexX, int nCharToFind)
        {
            bool bFound = true;

            for (int i = 0; i < 3; i++)
            {
                if (sInputString[nLine2 + i + 1][nIndexX] != sMAS[i]) bFound = false;
            }

            return bFound;
        }

    }
}
