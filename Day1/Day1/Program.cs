using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AdventOfCode_16_1_1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var spc = new ShortPathCalc();
            var path = File.ReadAllText("input.txt");
            spc.FollowPath(path, true);
            Console.Write(spc.DistanceFromStart());
            Console.ReadKey();
        }
    }
}
