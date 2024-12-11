using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024
{
    partial class Day6
    {
        public static int nCopPos = 0, nLineIndex = 0;
        public static string[] sTextInputLocal, controlString;
        public static char cCopSymbol = '^';


        public static void RunP1(string[] sTextInput)
        {
            sTextInputLocal = sTextInput;
            controlString = sTextInput;
            List<string> groups = new List<string>(sTextInput.ToList());
            nLineIndex = 0;

            for (int i = 0; i < sTextInput.Length; i++)
            {
                string sLine = sTextInput[i];

                if (sLine.Contains('^') == false) continue;

                nLineIndex = i;
                nCopPos = sLine.IndexOf('^');
            }

            bool bExit = false;
            while (bExit == false)
            {
                switch (cCopSymbol)
                {
                    case '^':
                        bExit = GoUpP1();
                        break;
                    case 'v':
                        bExit = GoDownP1();
                        break;
                    case '<':
                        bExit = GoLeftP1();
                        break;
                    case '>':
                        bExit = GoRightP1();
                        break;
                }
            }

            foreach (string s in controlString)
            {
                Console.WriteLine(s);
            }

            int count = 0;
            foreach (string s in controlString)
            {
                count += s.Count(c => c == 'X');
            }
            Console.WriteLine($"Number of 'X' characters: {count}");
        }

        private static bool GoUpP1()
        {
            if (cCopSymbol != '^')
            {
                return false;
            }
            if (nLineIndex < 0) return true;

            string sLine = sTextInputLocal[nLineIndex];
            if (sLine[nCopPos] == '#')
            {
                nLineIndex++;
                cCopSymbol = '>';
                return false;
            }
            char[] chars = controlString[nLineIndex].ToCharArray();

            chars[nCopPos] = 'X';
            controlString[nLineIndex] = new string(chars);

            nLineIndex--;
            GoUpP1();

            return false;
        }

        private static bool GoDownP1()
        {
            if (cCopSymbol != 'v')
            {
                return false;
            }

            if (nLineIndex >= sTextInputLocal.Length) return true;

            string sLine = sTextInputLocal[nLineIndex];
            if (sLine[nCopPos] == '#')
            {
                nLineIndex--;
                cCopSymbol = '<';
                return false;
            }

            char[] chars = controlString[nLineIndex].ToCharArray();

            chars[nCopPos] = 'X';
            controlString[nLineIndex] = new string(chars);

            nLineIndex++;
            GoDownP1();
            return false;
        }

        private static bool GoLeftP1()
        {
            if (cCopSymbol != '<')
            {
                return false;
            }

            if (nCopPos < 0) return true;

            string sLine = sTextInputLocal[nLineIndex];
            if (sLine[nCopPos] == '#')
            {
                nCopPos++;
                cCopSymbol = '^';
                return false;
            }

            char[] chars = controlString[nLineIndex].ToCharArray();

            chars[nCopPos] = 'X';
            controlString[nLineIndex] = new string(chars);

            nCopPos--;
            GoLeftP1();

            return false;
        }

        private static bool GoRightP1()
        {
            if (cCopSymbol != '>')
            {
                return false;
            }
            if (nCopPos >= sTextInputLocal[0].Length) return true;
            string sLine = sTextInputLocal[nLineIndex];
            if (sLine[nCopPos] == '#')
            {
                nCopPos--;
                cCopSymbol = 'v';
                return false;
            }

            char[] chars = controlString[nLineIndex].ToCharArray();

            chars[nCopPos] = 'X';
            controlString[nLineIndex] = new string(chars);

            nCopPos++;
            GoRightP1();
            return false;
        }
    }
}
