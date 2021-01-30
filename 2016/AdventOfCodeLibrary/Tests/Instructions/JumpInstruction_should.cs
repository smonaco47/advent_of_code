using AdventOfCodeLibrary.Instructions;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Instructions
{
    // ReSharper disable once InconsistentNaming
    class JumpInstruction_should
    {
        [Test]
        public void stay_for_zero_value_registry()
        {
            var register = Any.Register();
            var jumpDistance = Any.JumpDistance();
            AdventOfCodeLibrary.Instructions.Computer computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(register, 0)
                .Build();
            var initialPosition = computer[AdventOfCodeLibrary.Instructions.Computer.InstructionPointer];

            var instruction = new JumpInstruction(register, jumpDistance);
            instruction.Execute(computer);

            Assert.AreEqual(initialPosition, computer[AdventOfCodeLibrary.Instructions.Computer.InstructionPointer]);
        }

        [Test]
        public void move_by_jump_amount_when_register_non_zero()
        {
            var register = Any.Register();
            var registerValue = Any.RegisterValue() + 1;
            var jumpDistance = Any.JumpDistance();
            AdventOfCodeLibrary.Instructions.Computer computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(register, registerValue)
                .Build();
            var initialPosition = computer[AdventOfCodeLibrary.Instructions.Computer.InstructionPointer];

            var instruction = new JumpInstruction(register, jumpDistance);
            instruction.Execute(computer);

            Assert.AreEqual(initialPosition + jumpDistance-1, computer[AdventOfCodeLibrary.Instructions.Computer.InstructionPointer]);
        }

        [Test]
        public void move_by_jump_amount_when_integer()
        {
            var nonZeroNumber = Any.NonZeroNumber();
            var jumpDistance = Any.JumpDistance();
            var computer = new MockComputerBuilder()
                .Build();
            var initialPosition = computer[AdventOfCodeLibrary.Instructions.Computer.InstructionPointer];

            var instruction = new JumpInstruction(1, jumpDistance);
            instruction.Execute(computer);

            Assert.AreEqual(initialPosition + jumpDistance - 1, computer[AdventOfCodeLibrary.Instructions.Computer.InstructionPointer]);
        }

    }
}
