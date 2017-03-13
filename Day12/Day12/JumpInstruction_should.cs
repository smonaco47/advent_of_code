using System;
using NUnit.Framework;

namespace Day12
{
    // ReSharper disable once InconsistentNaming
    class JumpInstruction_should
    {
        [Test]
        public void stay_for_zero_value_registry()
        {
            var register = Any.Register();
            var jumpDistance = Any.JumpDistance();
            Computer computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(register, 0)
                .Build();
            var initialPosition = computer[Computer.InstructionPointer];

            var instruction = new JumpInstruction(register, jumpDistance);
            instruction.Execute(computer);

            Assert.AreEqual(initialPosition, computer[Computer.InstructionPointer]);
        }

        [Test]
        public void move_by_jump_amount_when_register_non_zero()
        {
            var register = Any.Register();
            var registerValue = Any.RegisterValue() + 1;
            var jumpDistance = Any.JumpDistance();
            Computer computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(register, registerValue)
                .Build();
            var initialPosition = computer[Computer.InstructionPointer];

            var instruction = new JumpInstruction(register, jumpDistance);
            instruction.Execute(computer);

            Assert.AreEqual(initialPosition + jumpDistance-1, computer[Computer.InstructionPointer]);
        }
        
    }
}
