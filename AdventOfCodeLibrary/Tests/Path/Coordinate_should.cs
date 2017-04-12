using AdventOfCodeLibrary.Path;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Path
{
    class Coordinate_should
    {
        [Test]
        public void initialize_horizontal()
        {
            var initialX = Any.GridLocation();
            var initialY = Any.GridLocation();
            var point = new Coordinate(initialX,initialY);

            Assert.AreEqual(initialX, point.X);
        }

        [Test]
        public void initialize_vertical()
        {
            var initialX = Any.GridLocation();
            var initialY = Any.GridLocation();
            var point = new Coordinate(initialX, initialY);
            
            Assert.AreEqual(initialY, point.Y);
        }
    }
}
