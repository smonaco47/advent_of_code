using System.Collections.Generic;

namespace Day3
{
    public class Triangle
    {
        public List<int> Sides { get; }

        public Triangle(int side1, int side2, int side3)
        {
            Sides = new List<int> { side1, side2, side3 };
            Sides.Sort();
        }

        public bool IsValid()
        {
            if ((Sides[0] + Sides[1]) > Sides[2]) return true;
            return false;
        }
    }
}
