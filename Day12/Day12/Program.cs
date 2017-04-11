using System;
using AdventOfCodeLibrary;
using AdventOfCodeLibrary.Instructions;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "C:\\Source\\AdventOfCode\\Day12\\input.txt";
            FileImport file = new FileImport();
            string[] instructions = file.ReadFileToArray(fileName);
            IInstruction[] instructionList = (new InstructionFactory()).CreateForList(instructions);
            Computer computer = new Computer(instructionList) { ['c'] = 1 };  // FOR PART 2
            computer.ExecuteAll();
            //Assert.AreEqual(317993, computer['a']);
            Console.Write(computer['a']);
            Console.ReadKey();
        }
    }
}
