using System.Collections.Generic;
using Moq;

namespace Day12
{
    class MockComputerBuilder
    {
        private readonly Dictionary<char, int> _defaultRegister = new Dictionary<char, int>();
        private IInstruction[] _instructions = new IInstruction[0];

        public MockComputerBuilder WithDefaultRegisterValue(char register, int registerValue)
        {
            _defaultRegister[register] = registerValue;
            return this;
        }

        public MockComputerBuilder WithInstructions(IInstruction[] instructions)
        {
            _instructions = instructions;
            return this;
        }

        public Computer Build()
        {
            var computer = new Computer(_instructions);
            foreach (var kvp in _defaultRegister)
            {
                computer[kvp.Key] = kvp.Value;
            }
            return computer;
        }
    }
}