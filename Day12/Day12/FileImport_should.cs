using System;
using Moq;
using NUnit.Framework;

namespace Day12
{
    // ReSharper disable once InconsistentNaming
    class FileImport_should
    {
        [Test]
        public void read_input_stream_from_file()
        {
            string fileName = "C:\\Source\\AdventOfCode\\Day12\\test.txt";

            var mockFile = new Mock<FileImport>();
            mockFile.Setup(f => f.ReadFileToArray(fileName)).Returns(new[] {"cpy 1 a", "inc a"});

            string[] input = mockFile.Object.ReadFileToArray(fileName);
            Assert.AreEqual(2, input.Length);
        }

        [Test]
        // End to end
        public void execute_instructions_from_file()
        {
            string fileName = "C:\\Source\\AdventOfCode\\Day12\\input.txt";
            FileImport file = new FileImport();
            string[] instructions = file.ReadFileToArray(fileName);
            IInstruction[] instructionList = (new InstructionFactory()).CreateForList(instructions);
            Computer computer = new Computer(instructionList);
            computer.ExecuteAll();
            Assert.AreEqual(317993, computer['a']);
        }

        [Test]
        // End to end
        public void execute_instructions_from_file_override_c()
        {
            string fileName = "C:\\Source\\AdventOfCode\\Day12\\input.txt";
            FileImport file = new FileImport();
            string[] instructions = file.ReadFileToArray(fileName);
            IInstruction[] instructionList = (new InstructionFactory()).CreateForList(instructions);
            Computer computer = new Computer(instructionList) {['c'] = 1};
            computer.ExecuteAll();
            Assert.AreEqual(317993, computer['a']);
        }
    }
}
