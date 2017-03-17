using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class Any
    {
        public static int GridLocation()
        {
            var randomInt = new Random();
            return randomInt.Next();
        }

        public static Point Point()
        {
            return new Point(GridLocation(),GridLocation());
        }

        public static int Length()
        {
            var randomInt = new Random();
            return randomInt.Next();
        }

        public static Link Link()
        {
            return new Link(Any.Point(),Any.Point(), Any.Length());
        }
    }
}
