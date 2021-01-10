using System;
using AdventOfCodeLibrary.FileImport;

namespace Day3
{
    class Program
    {
        static void Main()
        {
            var triangleParser = new TriangleParser
            {
                ReadHorizontal = false  // Part 1 : true, Part 2 : false
            };
            var filereader = new FileImporter<Triangle>(triangleParser);
            var processor = new TriangleProcessor(filereader);
            processor.Process("..\\..\\input.txt");
            Console.Write("Valid : " + processor.GetResult());
            Console.ReadKey();
        }
    }
}
