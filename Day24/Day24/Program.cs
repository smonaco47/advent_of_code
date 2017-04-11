using System;
using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Path;

namespace Day24
{
    class Program
    {
        static void Main(string[] args)
        {
            FileImport fi = new FileImport();
            var mazeArray = fi.ReadFileToArray("input.txt");
            if (mazeArray.Length == 0) return;
            var maze = new Maze('#', '.', mazeArray);
            var links = maze.getAllLinks();
            var path = new ShortestPathGenerator();
            path.AddLinks(links);
            path.ReturnHome = true;
            path.SetStart(maze.Start);
            int shortest = path.ShortestPath();
            Console.Write(shortest);
            Console.ReadKey();
        }
    }
}
