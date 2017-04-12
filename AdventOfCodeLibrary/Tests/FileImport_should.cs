using Moq;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests
{
    // ReSharper disable once InconsistentNaming
    class FileImport_should
    {
        [Test]
        public void read_input_stream_from_file()
        {
            string fileName = "";

            var mockFile = new Mock<FileImport>();
            mockFile.Setup(f => f.ReadFileToArray(fileName)).Returns(new[] {"cpy 1 a", "inc a"});

            string[] input = mockFile.Object.ReadFileToArray(fileName);
            Assert.AreEqual(2, input.Length);
        }
    }
}
