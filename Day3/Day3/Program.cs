using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLibrary;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var filereader = new FileImport();
            var input = filereader.ReadFileToArray("..\\..\\input.txt");
            var converted = TriangleParser.ConvertToHorizontal(input);
            Console.Write("Valid : " + TriangleParser.GetNumberValid(converted));
            Console.ReadKey();
        }
    }
}
