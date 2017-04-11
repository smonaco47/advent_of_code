using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using AdventOfCodeLibrary;

namespace AdventOfCode_16_1_1
{
    class Program
    {
        private static void Main(string[] args)
        {
            var pathFollower = new PathFollower();
            var path = File.ReadAllText("input1.txt");
            pathFollower.FollowPath(path, true);
            Console.Write(pathFollower.DistanceFromStart());
            Console.ReadKey();
        }
    }
}
