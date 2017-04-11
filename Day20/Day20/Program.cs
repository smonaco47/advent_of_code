using System;
using AdventOfCodeLibrary;

namespace Day20
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Source\\AdventOfCode\\Day20\\input.txt";
            FileImport file = new FileImport();
            string[] input = file.ReadFileToArray(fileName);
            var rangeCompare = new RangeCompare(input, uint.MaxValue);
            rangeCompare.CalculateNonBlocked();
            Console.Write("Lowest : " + rangeCompare.First);
            Console.Write(" IP Count : " + rangeCompare.Count);
            Console.ReadKey();
        }
    }
}
