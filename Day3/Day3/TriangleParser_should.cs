using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Day3
{
    class TriangleParser_should
    {
        [Test]
        public void identify_invalid_triangle()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 + 1;
            bool isValid = TriangleParser.IsValidTriangle(side1, side2, side3);

            Assert.AreEqual(false, isValid);
        }

        [Test]
        public void identify_valid_triangle_longest_last()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = TriangleParser.IsValidTriangle(side1, side2, side3);

            Assert.AreEqual(true, isValid);
        }


        [Test]
        public void identify_valid_triangle_longest_second()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = TriangleParser.IsValidTriangle(side2, side3, side1);

            Assert.AreEqual(true, isValid);
        }


        [Test]
        public void identify_valid_triangle_longest_first()
        {
            var side1 = Any.TriangleSideLength();
            var side2 = Any.TriangleSideLength();
            var side3 = side1 + side2 - 1;
            bool isValid = TriangleParser.IsValidTriangle(side3, side2, side1);

            Assert.AreEqual(true, isValid);
        }

        [Test]
        public void parse_input_string_to_sides()
        {
            var input =" 330  143  338";
            int a=0, b=0, c=0;
            bool passed = TriangleParser.ParseSides(input, ref a, ref b, ref c);

            Assert.AreEqual(true, passed);
            Assert.AreEqual(a, 330);
            Assert.AreEqual(b, 143);
            Assert.AreEqual(c, 338);
        }

        [Test]
        public void handle_too_few_sides_in_string()
        {
            var input = "1 2";
            int a = 0, b = 0, c = 0;
            bool passed = TriangleParser.ParseSides(input, ref a, ref b, ref c);

            Assert.AreEqual(passed, false);
        }

        [Test]
        public void handle_invalid_sides_in_string()
        {
            var input = "1 2 a";
            int a = 0, b = 0, c = 0;
            bool passed = TriangleParser.ParseSides(input, ref a, ref b, ref c);

            Assert.AreEqual(passed, false);
        }


        [Test]
        public void get_count_valid()
        {
            var input = new []{ "1 2 a", "3 4 5", "1 30 20"};
            int count = TriangleParser.GetNumberValid(input);

            Assert.AreEqual(1, count);
        }

        [Test]
        public void convert_from_vertical_to_horizontal()
        {
            var input = new[]
                {" 101 301 501",
                "102 302 502",
                "103 303 503",
                "201 401 601",
                "202 402 602",
                "203 403 603" };
            var converted = TriangleParser.ConvertToHorizontal(input);
            Assert.AreEqual("501 502 503", converted[2]);
            Assert.AreEqual("401 402 403", converted[4]);

        }
    }
}
