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

        [Test]
        public void detect_a_palendrome()
        {
            string palendrome = "abccba";
            Assert.IsTrue(Utilities.IsPalendrome(palendrome));
        }

        [Test]
        public void detect_when_not_palendrome()
        {
            string palendrome = "abcbca";
            Assert.IsFalse(Utilities.IsPalendrome(palendrome));
        }

        [Test]
        public void detect_when_letter_repeated()
        {
            string palendrome = "aaaa";
            Assert.IsFalse(Utilities.IsPalendrome(palendrome, false));
        }

        [Test]
        public void detect_internal_palendrome()
        {
            string palendrome = "afdjiijfdsl";
            Assert.IsTrue(Utilities.ContainsPalendrome(palendrome, 4, false));
        }

        [Test]
        public void detect_solo_palendrome()
        {
            string palendrome = "abccba";
            Assert.IsTrue(Utilities.ContainsPalendrome(palendrome, 6, false));
        }

        [Test]
        public void detect_no_palendrome()
        {
            string palendrome = "abecba";
            Assert.IsFalse(Utilities.ContainsPalendrome(palendrome, 6, false));
        }

    }
}
