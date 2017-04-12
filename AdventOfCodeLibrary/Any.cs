using System;
using AdventOfCodeLibrary.Path;

namespace AdventOfCodeLibrary
{
    public static class Any
    {
        private static Random _random = null;

        private static Random GetRandom()
        {
            if (_random == null)
                _random = new Random();
            return _random;
        }

        public static char Register()
        {
            return (char)(GetRandom().Next()%char.MaxValue);
        }

        public static int RegisterValue()
        {
            return GetRandom().Next();
        }

        public static int JumpDistance()
        {
            return GetRandom().Next(int.MinValue, int.MaxValue);
        }

        public static object NonZeroNumber()
        {
            return GetRandom().Next() + 1;
        }

        public static int TriangleSideLength()
        {
            return GetRandom().Next() % ((int.MaxValue/3)+1);
        }

        public static int GridLocation()
        {
            return GetRandom().Next();
        }

        public static Coordinate Coordinate()
        {
            return new Coordinate(GridLocation(), GridLocation());
        }

        public static int Length()
        {
            return GetRandom().Next();
        }

        public static Link Link()
        {
            return new Link(Any.Coordinate(), Any.Coordinate(), Any.Length());
        }

    }
}
