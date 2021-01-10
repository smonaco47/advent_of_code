using System;
using AdventOfCodeLibrary.FileImport;

namespace Day4
{
    class Program
    {
        static void Main()
        {
            var processor = new EncryptedRoomProcessor();
            processor.Process("../../input.txt");
            Console.WriteLine();
            processor.PrintResult();
            Console.ReadKey();
        }
        
    }
}
