using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    internal class Day15
    {
        public static void Run(string[] sTextInput)
        {
            (string[] sRoomInput, string[] sInstructions) = SplitByEmpty(sTextInput);

            string[,] room = new string[sRoomInput.Length, sRoomInput[0].Length];
            int robotX = -1;
            int robotY = -1;

            for (int i = 0; i < sRoomInput.Length; i++)
            {
                string s = sRoomInput[i];
                for (int j = 0; j < s.Length; j++)
                {
                    room[i, j] = s[j].ToString();
                    if (s[j].ToString() == "@")
                    {
                        robotX = i;
                        robotY = j;
                    }
                }
            }

            Console.WriteLine("Initial Position:" + robotX + "," + robotY);

            foreach (string sSetOfActions in sInstructions)
            {
                foreach (char cAction in sSetOfActions)
                {
                    bool bMove = false;

                    switch (cAction)
                    {
                        case '<':
                            bMove = CanMove(ref room, robotX, robotY, 0, -1);
                            if (bMove == true)
                            {
                                robotY--;
                            }
                            break;
                        case '>':
                            bMove = CanMove(ref room, robotX, robotY, 0, +1);
                            if (bMove == true)
                            {
                                robotY++;
                            }
                            break;
                        case '^':
                            bMove = CanMove(ref room, robotX, robotY, -1,  0);
                            if (bMove == true)
                            {
                                robotX--;
                            }
                            break;
                        case 'v':
                            bMove = CanMove(ref room, robotX, robotY, +1,  0);
                            if (bMove == true)
                            {
                                robotX++;
                            }
                            break;
                    }

                    //Console.WriteLine("Action: " + cAction);
                    //Print2DArray(room);
                    //Console.WriteLine();
                }
            }

            float nSum = 0;

            for (int i = 0; i < room.GetLength(0); i++)
            {
                for(int j = 0; j < room.GetLength(1); j++)
                {
                    if (room[i, j] != "O") continue;

                    nSum += 100 * i + j;
                }
            }

            Console.WriteLine(nSum);
        }

        public static bool CanMove(ref string[,] room, int FromX, int FromY, int ModifierX, int ModifierY)
        {
            int ToX = FromX + ModifierX;
            int ToY = FromY + ModifierY;

            if (room[ToX, ToY] == "#") return false;
            else if (room[ToX, ToY] == ".")
            {
                (room[FromX, FromY], room[ToX, ToY]) = (room[ToX, ToY], room[FromX, FromY]);
                return true;
            }
            else if (room[ToX, ToY] == "O")
            {
                bool bMoved = CanMove(ref room, ToX, ToY, ModifierX, ModifierY);
                if (bMoved == true)
                {
                    (room[FromX, FromY], room[ToX, ToY]) = (room[ToX, ToY], room[FromX, FromY]);
                    return true;
                }
            }

            return false;
        }
        public static void Print2DArray(string[,] array)
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static (string[] first, string[] second) SplitByEmpty(string[] input)
        {
            int index = Array.IndexOf(input, "");
            if (index == -1)
                return (input, Array.Empty<string>());
            var first = input.Take(index).ToArray();
            var second = input.Skip(index + 1).ToArray();
            return (first, second);
        }
    }
}
