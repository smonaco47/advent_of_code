using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class Program
    {
        static void Main(string[] args)
        {

            var mazeArray = new[] { "###########",
                "#0........#",
                "#.#######.#",
                "#.#######.#",
                "#.######..#",
                "#.......3.#",
                "###########" };
            var maze = new Maze('#', '.', mazeArray);
            Console.WriteLine(maze.ToString(null));
            Console.ReadKey();
        }
    }
}
