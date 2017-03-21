using System.Collections.Generic;
using NUnit.Framework;

namespace Day24
{
    class ShortestPathGenerator_should
    {
        [Test]
        public void intialize_with_paths()
        {
            var pathGenerator = new ShortestPathGenerator();

            pathGenerator.AddLinks(new List<Link> {Any.Link()});

            Assert.AreEqual(1, pathGenerator.LinkCount);
        }

        [Test]
        public void intialize_with_duplicate_paths()
        {
            var pathGenerator = new ShortestPathGenerator();
            var link = Any.Link();
            var linkCpy = link;
            var linkCpy2 = link;
            linkCpy.Length += 1;
            linkCpy2.Length -= 1;

            pathGenerator.AddLinks(new List<Link> { link, linkCpy, linkCpy2 });

            Assert.AreEqual(1, pathGenerator.LinkCount);
        }

        [Test]
        public void intialize_with_duplicate_paths_keep_lowest()
        {
            var pathGenerator = new ShortestPathGenerator();
            var link = Any.Link();
            var linkCpy = link;
            var linkCpy2 = link;
            linkCpy.Length += 1;
            linkCpy2.Length -= 1;

            pathGenerator.AddLinks(new List<Link> { link, linkCpy, linkCpy2 });
            pathGenerator.ShortestPath();

            Assert.AreEqual(linkCpy2.Length, pathGenerator.ShortestPathLength);
        }

        [Test]
        public void find_path_length_when_only_two_locations()
        {
            var pathGenerator = new ShortestPathGenerator();
            var link = Any.Link();
            pathGenerator.AddLinks(new List<Link> { link });
            pathGenerator.ShortestPath();

            Assert.AreEqual(link.Length, pathGenerator.ShortestPathLength);
        }

        [Test]
        public void find_shortest_path_length_count_with_multiple_locations()
        {
            var pathGenerator = new ShortestPathGenerator();
            var point1 = new Point(0,0);
            var point2 = new Point(1,0);
            var point3 = new Point(2,0);
            var link1 = new Link(point1, point2, 15);
            var link2 = new Link(point1, point3, 5);
            var link3 = new Link(point2, point3, 5);
            pathGenerator.AddLinks(new List<Link> { link1, link2, link3 });
            pathGenerator.ShortestPath();

            Assert.AreEqual(link2.Length + link3.Length, pathGenerator.ShortestPathLength);
        }

        
        [Test]
        public void find_shortest_path_when_sides_missing()
        {
            var pathGenerator = new ShortestPathGenerator();
            var point1 = new Point(0, 0);
            var point2 = new Point(1, 0);
            var point3 = new Point(2, 0);
            var point4 = new Point(3, 0);
            var link1 = new Link(point1, point2, 5);
            var link2 = new Link(point1, point3, 10);
            var link3 = new Link(point1, point4, 15);
            //var link4 = new Link(point2, point3, 20); // Intentionally leaving out
            var link5 = new Link(point2, point4, 25);
            var link6 = new Link(point3, point4, 30);

            pathGenerator.AddLinks(new List<Link> { link1, link2, link3, link5, link6 });
            pathGenerator.ShortestPath();

            Assert.AreEqual(link1.Length + link5.Length + link6.Length, pathGenerator.ShortestPathLength);
        }

         [Test]
        public void create_all_permutations()
        {
            var pathGenerator = new ShortestPathGenerator();
            var items = new HashSet<int>();
            for (var i = 0; i < 4; i++)
            {
                items.Add(i);
            }

            var retVal = pathGenerator.EnumerateAllPaths<int>(0, items);
            Assert.AreEqual(6, retVal.Count);
        }

        [Test]
        public void create_all_permutations_of_points()
        {
            var pathGenerator = new ShortestPathGenerator();
            var points = new HashSet<Point>();
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < 2; j++)
                {
                    points.Add(new Point(i, j));
                }
            }

            var retVal = pathGenerator.EnumerateAllPaths<Point>(new Point(0, 0), points);
            Assert.AreEqual(6, retVal.Count);
        }

    }
}
