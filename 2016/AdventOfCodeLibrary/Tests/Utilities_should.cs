using System.Collections.Generic;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests
{
    class Utilities_should
    {
        [Test]
        public void transpose_a_string_list()
        {
           var originalList = new List<string>() {"abc", "def"};
           var expectedList = new List<string>() { "ad", "be", "cf" };
            Assert.AreEqual(Utilities.Transpose(originalList), expectedList);
        }
    }
}
