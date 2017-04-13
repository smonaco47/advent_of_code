using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Path;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
        }

        public static void Part1()
        {
            var fileIo = new FileImport();
            var inputStrings = fileIo.ReadFileToArray("../../input.txt");
            var keypadFollower = new KeypadFollower(new Coordinate(1,1), new Keypad());
            foreach (string str in inputStrings)
            {
                keypadFollower.FollowPath(str, false);
                Console.Write(keypadFollower.CurrentValue());
            }
            Console.ReadKey();
        }
    }
}
