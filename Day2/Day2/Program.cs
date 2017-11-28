using System;
using AdventOfCodeLibrary.FileImport;
using AdventOfCodeLibrary.Path;

namespace Day2
{
    class Program
    {
        static void Main()
        {
            Part1();
            Console.WriteLine();
            Part2();
            Console.ReadKey();
        }

        public static void Part1()
        {
            var fileIo = new FileImporter<string>(new NullParser());
            var keypad = new Keypad();
            keypad.PrintKeypad();
            var keypadFollower = new KeypadFollower(new Coordinate(1,1),keypad );
            var processor = new KeypadProcessor(fileIo, keypadFollower);
            processor.Process("../../input.txt");
        }

        public static void Part2()
        {
            var fileIo = new FileImporter<string>(new NullParser());
            var keypad = Keypad.DiamondKeypad();
            keypad.PrintKeypad();
            var keypadFollower = new KeypadFollower(new Coordinate(0, 3), keypad);
            var processor = new KeypadProcessor(fileIo, keypadFollower);
            processor.Process("../../input.txt");
            Console.ReadKey();
        }
    }
}
