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
            Console.WriteLine();
            Part2();
            Console.ReadKey();
        }

        public static void Part1()
        {
            var fileIo = new FileImport();
            var inputStrings = fileIo.ReadFileToArray("../../test.txt");
            var keypad = new Keypad();
            keypad.PrintKeypad();

            var keypadFollower = new KeypadFollower(new Coordinate(1,1),keypad );
            foreach (string str in inputStrings)
            {
                keypadFollower.FollowPath(str, false);
                Console.Write(keypadFollower.CurrentValue());
            }
        }

        public static void Part2()
        {
            var fileIo = new FileImport();
            var inputStrings = fileIo.ReadFileToArray("../../input.txt");
            var keypad = Keypad.DiamondKeypad();
            keypad.PrintKeypad();
            var keypadFollower = new KeypadFollower(new Coordinate(0, 3), keypad);
            foreach (string str in inputStrings)
            {
                keypadFollower.FollowPath(str, false);
                Console.Write(keypadFollower.CurrentValue());
            }
            Console.ReadKey();
        }
    }
}
