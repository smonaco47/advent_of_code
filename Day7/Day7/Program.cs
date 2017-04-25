using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCodeLibrary;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Console.ReadKey();
        }

        private static void Part1()
        {
            var fileIo = new FileImport();
            var input = fileIo.ReadFileToArray("../../input.txt");
            var count = 0;
            foreach (var str in input)
            {
                var ip = new IpAddress(str);
                if (ip.SupportsTls) count++;
            }
            Console.WriteLine("Number valid : " + count);
        }
    }
}
