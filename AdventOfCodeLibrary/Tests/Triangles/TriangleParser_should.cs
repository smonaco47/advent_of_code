using System;
using AdventOfCodeLibrary.Triangles;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests
{
    public class TriangleParser_should
    {
        public void parse_input_string_to_sides()
        {
            var input = " 330  143  338";
            var triangle = new TriangleParser().ParseSingle(input);

            Assert.AreEqual(143, triangle.Sides[0]);
            Assert.AreEqual(330, triangle.Sides[1]);
            Assert.AreEqual(338, triangle.Sides[2]);
        }

        [Test]
        public void handle_too_few_sides_in_string()
        {
            var input = "1 2";
            var triangleParser = new TriangleParser();

            Assert.Throws<ArgumentException>(() => triangleParser.ParseSingle(input));
        }

        [Test]
        public void handle_invalid_sides_in_string()
        {
            var input = "1 2 a";
            var triangleParser = new TriangleParser();

            Assert.Throws<FormatException>(() => triangleParser.ParseSingle(input));
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
            var converted = new TriangleParser().ParseInputSet(input);
            Assert.AreEqual("501 502 503", converted[2]);
            Assert.AreEqual("401 402 403", converted[4]);

        }
    }
}
