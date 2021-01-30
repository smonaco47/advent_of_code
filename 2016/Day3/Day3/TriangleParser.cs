using System;
using System.Collections.Generic;
using AdventOfCodeLibrary.FileImport;

namespace Day3
{
    public class TriangleParser : IParser<string, Triangle>
    {
        public bool ReadHorizontal { get; set; }

        public Triangle ParseSingle(string input)
        {
            var sides = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (sides.Length < 3)
            {
                throw new ArgumentException("Triangle must have three sides");
            }

            return new Triangle(int.Parse(sides[0]), int.Parse(sides[1]), int.Parse(sides[2]));
        }

        public string[] ParseInputSet(string[] input)
        {
            if (!ReadHorizontal)
            {
                input = ConvertToHorizontal(input);
            }
            return input;
        }

        private string[] ConvertToHorizontal(string[] input)
        {
            var stringList = new List<string>();
            for (var i = 0; i < input.Length - 2; i += 3)
            {
                var string1 = input[i].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var string2 = input[i + 1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var string3 = input[i + 2].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < string1.Length; j++)
                {
                    stringList.Add(string1[j] + " " + string2[j] + " " + string3[j]);
                }
            }
            return stringList.ToArray();
        }
    }
}


