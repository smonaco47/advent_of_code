using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class Any
    {

        private static Random _random = null;

        private static Random GetRandom()
        {
            if (_random == null)
                _random = new Random();
            return _random;
        }

        public static int GridLocation()
        {
            return GetRandom().Next();
        }

        public static Point Point()
        {
            return new Point(GridLocation(),GridLocation());
        }

        public static int Length()
        {
            return GetRandom().Next();
        }

        public static Link Link()
        {
            return new Link(Any.Point(), Any.Point(), Any.Length());
        }
    }
}
