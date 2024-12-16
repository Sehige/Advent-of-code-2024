
namespace Advent_of_code_2024
{
    class Program
    {
        static void Main()
        {
            string[] strings = GetTextInput("7");
            Day7.RunP1(strings);
        }

        static string[] GetTextInput(string sDay)
        {
            string filePath = string.Format("C:\\Users\\SergiuAtAmbo\\source\\repos\\Advent of code 2024\\Advent of code 2024\\Day{0}\\Day{0}.txt" , sDay);
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