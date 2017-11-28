using System;
using System.Linq;
using AdventOfCodeLibrary;
using AdventOfCodeLibrary.FileImport;
using AdventOfCodeLibrary.Frequencies;

namespace Day6
{
    class Program
    {

        static void Main(string[] args)
        {
            Part1();
            Console.WriteLine();
            Part2();
            Console.ReadKey();
        }


        //Test should be easter
        //Input should be agmwzecr
        public static void Part1()
        {
            int sectorCount = 0;
            var fileIO = new FileImportAdapter();
            string[] invertedStrings = fileIO.ReadFileToArray("../../input.txt");
            var strings = Utilities.Transpose(invertedStrings.ToList());
            foreach (var str in strings)
            {
                var freq = new Frequency(str);
                freq.Build();
                 Console.Write(freq.TopItem()); 
            }
        }

        //Test should be advent
        //Input should be owlaxqvq
        public static void Part2()
        {
            int sectorCount = 0;
            var fileIO = new FileImportAdapter();
            string[] invertedStrings = fileIO.ReadFileToArray("../../input.txt");
            var strings = Utilities.Transpose(invertedStrings.ToList());
            foreach (var str in strings)
            {
                var freq = new Frequency(str);
                freq.Build();
                Console.Write(freq.BottomItem());
            }
        }
    }
}
