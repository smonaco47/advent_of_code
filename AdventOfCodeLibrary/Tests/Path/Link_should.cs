using AdventOfCodeLibrary.Path;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Path
{
    class Link_should
    {
        [Test]
        public void provide_start_point()
        {
            var start = Any.Point();
            var newPath = new Link(start, Any.Point(), Any.Length());

            Assert.AreEqual(start, newPath.Start);
        }

        [Test]
        public void provide_end_point()
        {
           
            var end = Any.Point();
            var newPath = new Link(Any.Point(), end, Any.Length());

            Assert.AreEqual(end, newPath.End);
        }

        [Test]
        public void provide_distance()
        {
            var length = Any.Length();
            var newPath = new Link(Any.Point(), Any.Point(), length);

            Assert.AreEqual(length, newPath.Length);
        }
    }
}
