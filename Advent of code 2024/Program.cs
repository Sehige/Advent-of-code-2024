
namespace Advent_of_code_2024
{
    class Program
    {
        static void Main()
        {
            string[] strings = GetTextInput();
            Day3.Run(strings);
        }

        static string[] GetTextInput()
        {
            string filePath = "C:\\Users\\SergiuAtAmbo\\source\\repos\\Advent of code 2024\\Advent of code 2024\\Day3\\Day3.txt";
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