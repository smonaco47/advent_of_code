using System.Collections.Generic;
using AdventOfCodeLibrary.FileImport;
using Moq;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.FileImport
{
    class FileImporterShoulds
    {
        [Test]
        public void import_and_parse_each_line_of_code()
        {
            var expectedLine1 = Any.Length();
            var expectedLine2 = Any.Length();
            var expectedFileName = "expectedFileName";

            var parserStub = new Mock<IParser<string, int>>();
            parserStub.Setup(p => p.ParseSingle("a")).Returns(expectedLine1);
            parserStub.Setup(p => p.ParseSingle("b")).Returns(expectedLine2);
            var fileImportAdapterStub = new Mock<FileImportAdapter>();
            fileImportAdapterStub.Setup(f => f.ReadFileToArray(expectedFileName))
                .Returns(new List<string> {"a", "b"}.ToArray());
            var fileImporter = new FileImporter<int>(parserStub.Object, 
                fileImportAdapterStub.Object);

            var result = fileImporter.ReadFileToArray(expectedFileName);

            Assert.AreEqual(2, result.Length);
            Assert.AreEqual(expectedLine1, result[0]);
            Assert.AreEqual(expectedLine2, result[1]);
        }
    }
}
