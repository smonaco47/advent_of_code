using System;
using System.IO;
using AdventOfCodeLibrary.Path;

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
