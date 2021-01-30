using Moq;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.FileImport
{
    // ReSharper disable once InconsistentNaming
    class FileImportAdapter_should
    {
        [Test]
        public void read_input_stream_from_file()
        {
            string fileName = "";

            var mockFile = new Mock<AdventOfCodeLibrary.FileImport.FileImportAdapter>();
            mockFile.Setup(f => f.ReadFileToArray(fileName)).Returns(new[] {"cpy 1 a", "inc a"});

            string[] input = mockFile.Object.ReadFileToArray(fileName);
            Assert.AreEqual(2, input.Length);
        }
    }
}
