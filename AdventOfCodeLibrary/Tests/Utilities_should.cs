using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
