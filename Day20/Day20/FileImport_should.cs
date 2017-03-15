using System;
using Moq;
using NUnit.Framework;

namespace Day20
{
    // ReSharper disable once InconsistentNaming
    class FileImport_should
    {
        [Test]
        public void read_input_stream_from_file()
        {
            string fileName = "C:\\Source\\AdventOfCode\\Day20\\test.txt";

            var mockFile = new Mock<FileImport>();
            mockFile.Setup(f => f.ReadFileToArray(fileName)).Returns(new[] {"1", "2"});

            string[] input = mockFile.Object.ReadFileToArray(fileName);
            Assert.AreEqual(2, input.Length);
        }
    }
}
