using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    public static class Any
    {
        public static char Register()
        {
            return (char)(random.Next()%char.MaxValue);
        }

        public static int RegisterValue()
        {
            return random.Next();
        }

        public static int JumpDistance()
        {
            return random.Next(int.MinValue, int.MaxValue);
        }
        
        private static Random random = new Random();

        public static object NonZeroNumber()
        {
            return random.Next() + 1;
        }
    }
}
