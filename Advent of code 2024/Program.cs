
namespace Advent_of_code_2024
{
    class Program
    {
        static void Main()
        {
            string[] strings = GetTextInput();
            Day2.Run(strings, false);
        }

        static string[] GetTextInput()
        {
            string filePath = "C:\\Users\\SergiuAtAmbo\\source\\repos\\Advent of code 2024\\Advent of code 2024\\Day2\\Day2.txt";
            if (File.Exists(filePath))
            {
                return File.ReadAllLines(filePath);
            }
            else
            {
                Console.WriteLine("File not found.");
                return Array.Empty<string>();
            }
        }
    }
}