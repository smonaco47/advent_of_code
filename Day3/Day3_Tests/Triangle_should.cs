using AdventOfCodeLibrary;
using Day3;
using NUnit.Framework;

namespace Day3_Tests
{
    public class Triangle_should
    {
        [Test]
        public void identify_invalid_triangle()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 + 1;
            bool isValid = new Triangle(side1, side2, side3).IsValid();

            Assert.AreEqual(false, isValid);
        }

        [Test]
        public void identify_valid_triangle_longest_last()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = new Triangle(side1, side2, side3).IsValid();

            Assert.AreEqual(true, isValid);
        }

        [Test]
        public void identify_valid_triangle_longest_second()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = new Triangle(side1, side2, side3).IsValid();

            Assert.AreEqual(true, isValid);
        }

        [Test]
        public void identify_valid_triangle_longest_first()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = new Triangle(side1, side2, side3).IsValid();

            Assert.AreEqual(true, isValid);
        }

        [Test]
        public void share_assigned_sides()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            var triangle = new Triangle(side1, side2, side3);

            Assert.AreEqual(side1, triangle.Sides[0]);
            Assert.AreEqual(side2, triangle.Sides[1]);
            Assert.AreEqual(side3, triangle.Sides[2]);
        }
    }
}
