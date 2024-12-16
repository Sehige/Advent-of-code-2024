using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    public class Day8
    {
        public static char[,] dataGrid; // 2D array
        public static char[,] dataGridFinal; // 2D array
        public static int nSum = 0;

        public static bool bP2 = false;

        public static void Run(string[] sInput)
        {
            nSum = 0;
            GenerateGrids(sInput);

            for (int i = 0; i < sInput.Length; i++)
            {
                for (int j = 0; j < sInput[i].Length; j++)
                {
                    if (char.IsDigit(dataGrid[i, j]) || char.IsLetter(dataGrid[i, j]))
                    {
                        CheckForAntena(i, j);
                    }
                }
            }

            for (int i = 0; i < dataGridFinal.GetLength(0); i++)
            {
                for (int j = 0; j < dataGridFinal.GetLength(1); j++)
                {
                    if (dataGridFinal[i, j] != '.')
                    {
                        nSum++;
                    }
                    Console.Write(dataGridFinal[i, j]);
                }
                Console.WriteLine();
            }

            Console.WriteLine(nSum);
        }

        private static void CheckForAntena(int nPosX1, int nPosY1)
        {
            char cAntena = dataGrid[nPosX1, nPosY1];

            for (int nPosX2 = nPosX1 + 1; nPosX2 < dataGrid.GetLength(0); nPosX2++)
            {
                for (int nPosY2 = 0; nPosY2 < dataGrid.GetLength(1); nPosY2++)
                {
                    if (dataGrid[nPosX2, nPosY2] != cAntena) continue;

                    AddAntena(nPosX1, nPosY1, nPosX2, nPosY2);
                }
            }
        }

        private static void AddAntena(int nPosX1, int nPosY1, int nPosX2, int nPosY2)
        {
            int fVectorX = nPosX2 - nPosX1;
            int fVectorY = nPosY2 - nPosY1;

            bool bCanPutAntena = true;

            nPosX1 -= fVectorX;
            nPosY1 -= fVectorY;

            nPosX2 += fVectorX;
            nPosY2 += fVectorY;

            /// If Part 2 is active, we do the antena untill we exit the grid
            /// If Part 1 is active, we only do the antena 1 iteration
            while (bCanPutAntena == true)
            {
                bCanPutAntena = false;

                if ((nPosX1 > -1 && nPosX1 < dataGrid.GetLength(0)) &&
                    (nPosY1 > -1 && nPosY1 < dataGrid.GetLength(0)))
                {
                    bCanPutAntena |= bP2;
                    dataGridFinal[nPosX1, nPosY1] = '#';
                }

                if ((nPosX2 > -1 && nPosX2 < dataGrid.GetLength(0)) &&
                    (nPosY2 > -1 && nPosY2 < dataGrid.GetLength(0)))
                {
                    bCanPutAntena |= bP2;
                    dataGridFinal[nPosX2, nPosY2] = '#';
                }

                nPosX1 -= fVectorX;
                nPosY1 -= fVectorY;

                nPosX2 += fVectorX;
                nPosY2 += fVectorY;
            }
        }

        private static void GenerateGrids(string[] sInput)
        {
            dataGrid = new char[sInput[0].Length, sInput.Length];
            dataGridFinal = new char[sInput[0].Length, sInput.Length];

            for (int i = 0; i < sInput.Length; i++)
            {
                for (int j = 0; j < sInput[i].Length; j++)
                {
                    dataGrid[i, j] = sInput[i][j];
                    dataGridFinal[i, j] = sInput[i][j];
                }
            }
        }
    }
}
