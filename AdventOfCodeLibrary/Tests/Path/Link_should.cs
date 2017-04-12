using AdventOfCodeLibrary.Path;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Path
{
    class Link_should
    {
        [Test]
        public void provide_start_point()
        {
            var start = Any.Coordinate();
            var newPath = new Link(start, Any.Coordinate(), Any.Length());

            Assert.AreEqual(start, newPath.Start);
        }

        [Test]
        public void provide_end_point()
        {
           
            var end = Any.Coordinate();
            var newPath = new Link(Any.Coordinate(), end, Any.Length());

            Assert.AreEqual(end, newPath.End);
        }

        [Test]
        public void provide_distance()
        {
            var length = Any.Length();
            var newPath = new Link(Any.Coordinate(), Any.Coordinate(), length);

            Assert.AreEqual(length, newPath.Length);
        }
    }
}
