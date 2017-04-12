using AdventOfCodeLibrary.Path;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Path
{
    class Maze_should
    {
        public Maze InitializeArray()
        {
            var mazeArray = new[] { "###########",
                "#3.1.....2#",
                "#.#######.#",
                "#4.......0#",
                "###########" };
            return new Maze('#', '.', mazeArray);
        }

        [Test]
        public void initialize_maze_from_array()
        {
            var maze = InitializeArray();
            Assert.AreEqual(maze.Height, 5);
            Assert.AreEqual(maze.Width, 11);
        }

        [Test]
        public void initialize_to_start_at_zero()
        {
            var maze = InitializeArray();
            Assert.AreEqual(maze.Start, new Coordinate(9,3));
        }

        [Test]
        public void get_points_of_interest()
        {

            var maze = InitializeArray();
            Assert.AreEqual(5, maze.Points.Count);
        }

        [Test]
        public void find_path_between_two_points()
        {
            var maze = InitializeArray();

            var shortPath = maze.ShortestPathBetween(new Coordinate(1, 1), new Coordinate(9, 3)); // 0 and 3 above

            Assert.AreEqual(10, shortPath.Length);
        }

        [Test]
        public void find_complex_path()
        {
            var mazeArray = new[] { "###########",
                "#0........#",
                "#.#######.#",
                "#.#######.#",
                "#2######..#",
                "#.......3.#",
                "###########" };
            var maze = new Maze('#', '.', mazeArray);
            var links = maze.getAllLinks();
            Assert.AreEqual(3, links.Count);
        }
    }
}
