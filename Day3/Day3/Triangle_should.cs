using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Day3
{
    class Triangle_should
    {
        [Test]
        public void identify_invalid_triangle()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 + 1;
            bool isValid = Triangle.IsValid(side1, side2, side3);

            Assert.AreEqual(false, isValid);
        }

        [Test]
        public void identify_valid_triangle_longest_last()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 -1;
            bool isValid = Triangle.IsValid(side1, side2, side3);

            Assert.AreEqual(true, isValid);
        }


        [Test]
        public void identify_valid_triangle_longest_second()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = Triangle.IsValid(side2, side3, side1);

            Assert.AreEqual(true, isValid);
        }


        [Test]
        public void identify_valid_triangle_longest_first()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = Triangle.IsValid(side3, side2, side1);

            Assert.AreEqual(true, isValid);
        }
    }
}
