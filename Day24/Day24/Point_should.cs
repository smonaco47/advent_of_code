using NUnit.Framework;

namespace Day24
{
    class Point_should
    {
        [Test]
        public void initialize_horizontal()
        {
            var initialX = Any.GridLocation();
            var initialY = Any.GridLocation();
            var point = new Point(initialX,initialY);

            Assert.AreEqual(initialX, point.X);
        }

        [Test]
        public void initialize_vertical()
        {
            var initialX = Any.GridLocation();
            var initialY = Any.GridLocation();
            var point = new Point(initialX, initialY);
            
            Assert.AreEqual(initialY, point.Y);
        }
    }
}
