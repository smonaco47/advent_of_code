using NUnit.Framework;

namespace Day24
{
    class Maze_should
    {
        public Maze InitializeArray()
        {
            var mazeArray = new[] { "###########",
                "#0.1.....2#",
                "#.#######.#",
                "#4.......3#",
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
        public void get_points_of_interest()
        {

            var maze = InitializeArray();
            Assert.AreEqual(5, maze.Points.Count);
        }

        [Test]
        public void find_path_between_two_points()
        {
            var maze = InitializeArray();

            maze.ShortestPathBetween(new Point(1, 1), new Point(10, 3)); // 0 and 3 above

            Assert.AreEqual(5, maze.Points.Count);
        }

        [Test]
        public void find_complex_path()
        {
            var mazeArray = new[] { "###########",
                "#0........#",
                "#.#######.#",
                "#.#######.#",
                "#.######..#",
                "#.......3.#",
                "###########" };
            var maze = new Maze('#', '.', mazeArray);
            var links = maze.getLinks();
            Assert.AreEqual(5, maze.Points.Count);
        }
    }
}
