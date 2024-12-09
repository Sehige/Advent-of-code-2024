using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    partial class Day4
    {
        public static int nXMAS = 0;

        private static void SearchForA(int nLine)
        {
            string line2 = sInputString[nLine];

            for (int nIndexA = 1; nIndexA < line2.Length - 1; nIndexA++)
            {
                if (line2[nIndexA] != 'A') continue;

                string lineAbove = sInputString[nLine - 1];
                string lineBelow = sInputString[nLine + 1];

                bool bMAS1 = (lineAbove[nIndexA - 1] == 'M' && lineBelow[nIndexA + 1] == 'S') || (lineAbove[nIndexA - 1] == 'S' && lineBelow[nIndexA + 1] == 'M');
                bool bMAX2 = (lineBelow[nIndexA - 1] == 'M' && lineAbove[nIndexA + 1] == 'S') || (lineBelow[nIndexA - 1] == 'S' && lineAbove[nIndexA + 1] == 'M');

                if (bMAS1 && bMAX2)
                {
                    nXMAS++;
                }
            }
        }
    }
}
