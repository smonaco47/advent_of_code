using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests
{
    class IpAddress_should
    {
        [Test]
        public void initialize_with_address()
        {
            var input = "abba[mnop]qrst";
            var ipAddress = new IpAddress(input);
            Assert.AreEqual(input, ipAddress.Address);
        }

        [Test]
        public void recognize_valid_first_chunk()
        {
            var input = "abba[mnop]qrst";
            var ipAddress = new IpAddress(input);
            Assert.IsTrue(ipAddress.SupportsTls);
        }

        [Test]
        public void recognize_valid_last_chunk()
        {
            var input = "abcd[bdcb]xyyx";
            var ipAddress = new IpAddress(input);
            Assert.IsTrue(ipAddress.SupportsTls);
        }

        [Test]
        public void recognize_invalid_repeats()
        {
            var input = "aaaa[bdcb]xyyx";
            var ipAddress = new IpAddress(input);
            Assert.IsTrue(ipAddress.SupportsTls);
        }

       [Test]
        public void recognize_valid_within_larger_string()
        {
            var input = "ioxxoj[asdfgh]zxcvbn";
            var ipAddress = new IpAddress(input);
            Assert.IsTrue(ipAddress.SupportsTls);
        }

        [Test]
        public void recognize_invalid_with_basic_string()
        {
            var input = "abcd[mnnm]qrst";
            var ipAddress = new IpAddress(input);
            Assert.IsFalse(ipAddress.SupportsTls);
        }

        [Test]
        public void recognize_invalid_with_longer_string()
        {
            var input = "abcd[amnnmop]qrst";
            var ipAddress = new IpAddress(input);
            Assert.IsFalse(ipAddress.SupportsTls);
        }

        [Test]
        public void recognize_invalid_with_multiple_brackets()
        {
            var input = "abcd[amnnop]qrst[amma]";
            var ipAddress = new IpAddress(input);
            Assert.IsFalse(ipAddress.SupportsTls);
        }
    }
}
