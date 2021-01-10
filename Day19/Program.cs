using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    class Program
    {
        const int NUM_ELVES = 3004953;
        static void Main(string[] args)
        {
            var elves = new Elf[NUM_ELVES];
            for (int i = 0; i < NUM_ELVES; i ++)
            {
                elves[i] = new Elf();
            }
            var game = new Game(elves);
            game.Run();
            Console.Write(game.Winner);
            Console.ReadKey();
        }
    }
}
