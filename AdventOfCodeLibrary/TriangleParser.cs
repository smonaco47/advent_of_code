using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCodeLibrary
{
    public static class TriangleParser
    {
        public static int GetNumberValid(string[] input)
        {
            int a = 0, b = 0, c = 0;
            int count = 0;
            foreach (var str in input)
            {
                if (ParseSides(str, ref a, ref b, ref c) && IsValidTriangle(a, b, c))
                {
                    count++;
                }
            }
            return count;
        }

        public static int GetNumberValidVertically(string[] input)
        {
            input = ConvertToHorizontal(input);
            int a = 0, b = 0, c = 0;
            int count = 0;
            foreach (var str in input)
            {
                if (ParseSides(str, ref a, ref b, ref c) && IsValidTriangle(a, b, c))
                {
                    count++;
                }
            }
            return count;
        }

        public static string[] ConvertToHorizontal(string[] input)
        {
            var stringList = new List<string>();
            for (var i = 0; i < input.Length - 2; i += 3)
            {
                var string1 = input[i].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var string2 = input[i+1].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var string3 = input[i+2].Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (var j = 0; j < string1.Length; j++)
                {
                    stringList.Add(string1[j]+ " " + string2[j] + " " + string3[j]);
                }
            }
            return stringList.ToArray();
        }

        public static bool ParseSides(string input, ref int side1, ref int side2, ref int side3)
        {
            var sides = input.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            if (sides.Length < 3) return false;
            try
            {
                side1 = int.Parse(sides[0]);
                side2 = int.Parse(sides[1]);
                side3 = int.Parse(sides[2]);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public static bool IsValidTriangle(int side1, int side2, int side3)
        {
            var sides = new List<int>() { side1, side2, side3 };
            sides.Sort();
            if ((sides[0] + sides[1]) > sides[2]) return true;
            return false;
        }
    }
}

    
