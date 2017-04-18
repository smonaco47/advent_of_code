using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLibrary;

namespace Day4
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
            int sectorCount = 0; 
            var fileIO = new FileImport();
            string[] roomStrings = fileIO.ReadFileToArray("../../input.txt");
            foreach (var roomString in roomStrings)
            {
                var room = new EncryptedRoom(roomString);
                if (room.IsValid())
                    sectorCount += room.SectorId;
            }

            Console.Write("Count: " + sectorCount);

        }

        public static void Part2()
        {
            var fileIo = new FileImport();
            string[] roomStrings = fileIo.ReadFileToArray("../../input.txt");
            foreach (var roomString in roomStrings)
            {
                var room = new EncryptedRoom(roomString);
                if (room.IsValid() && (room.DecryptedName.Contains("north") || room.DecryptedName.Contains("toy")))
                    Console.WriteLine("Name: " + room.DecryptedName + "\t\tSector : " + room.SectorId);
            }
        }
    }
}
