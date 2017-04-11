using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLibrary
{
    public class Triangle
    {
        public static bool IsValid(int side1, int side2, int side3)
        {
            var sides = new List<int>() {side1, side2, side3};
            sides.Sort();
            if ((sides[0] + sides[1]) > sides[2]) return true;
            return false;
        }
    }
}
