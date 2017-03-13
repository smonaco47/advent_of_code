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
        static void Main(string[] args)
        {
            ShortPathCalc spc = new ShortPathCalc();
            string path = File.ReadAllText("input.txt");
            spc.followPath(path, true);
            Console.Write(spc.distanceFromStart());
            Console.ReadKey();
        }
    }
}
