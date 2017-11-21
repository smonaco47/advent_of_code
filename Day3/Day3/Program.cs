using System;
using AdventOfCodeLibrary;
using AdventOfCodeLibrary.FileImport;
using AdventOfCodeLibrary.Triangles;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var triangleParser = new TriangleParser();
            triangleParser.ReadHorizontal = false;  // Part 1 : true, Part 2 : false
            var filereader = new FileImporter<Triangle>(triangleParser);
            var triangles = filereader.ReadFileToArray("..\\..\\input.txt");
            Console.Write("Valid : " + GetNumberValid(triangles));
            Console.ReadKey();
        }

        private static int GetNumberValid(Triangle[] triangles)
        {
            int count = 0;
            foreach (var triangle in triangles)
            {
                if (triangle.IsValid())
                {
                    count++;
                }
            }
            return count;
        }
    }
}
