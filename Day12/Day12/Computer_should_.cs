using Moq;
using NUnit.Framework;

namespace Day12
{
    // ReSharper disable once InconsistentNaming
    class Computer_should_
    {
        [TestCase('a')]
        [TestCase('b')]
        [TestCase('c')]
        [TestCase('d')]
        [TestCase(Computer.InstructionPointer)]
        public void default_registers_to_zero(char register)
        {
            var computer = new Computer();

            Assert.AreEqual(0,computer[register]);
        }

        [Test]
        public void set_register_value()
        {
            var computer = new Computer();
            var register = Any.Register();
            computer[register] = 1;

            Assert.AreEqual(1,computer[register]);
        }

        //[Test]
        //public void set_register_if_not_exists()
        //{
        //    var computer = new Computer();
        //    var register = Any.Register();
        //    computer[register] = 1;

        //    Assert.AreEqual(1, computer[register]);
        //}

        [Test]
        public void execute_step_at_instruction_pointer_address()
        {
            var instruction = new Mock<IInstruction>();
            var instructions = new [] {instruction.Object};
            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(Computer.InstructionPointer,0)
                .WithInstructions(instructions)
                .Build();

            computer.ExecuteStep();

            instruction.Verify(i => i.Execute(computer), Times.Once);
        }

        [Test]
        public void advance_instruction_pointer_after_execute_step()
        {
            var instruction = new Mock<IInstruction>();
            var instructions = new[] {instruction.Object};
            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(Computer.InstructionPointer, 0)
                .WithInstructions(instructions)
                .Build();
            var currentInstructionPointer = computer[Computer.InstructionPointer];
            computer.ExecuteStep();

            Assert.AreEqual(currentInstructionPointer+1, computer[Computer.InstructionPointer]);
        }

        [Test]
        public void execute_each_instruction_on_execute_all() // not actually doing each here, could do one then complete flag
        {
            var instruction1 = new Mock<IInstruction>();
            var instruction2 = new Mock<IInstruction>();
            var instruction3 = new Mock<IInstruction>();
            var instructions = new[] {instruction1.Object, instruction2.Object , instruction3.Object };
            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(Computer.InstructionPointer, 0)
                .WithInstructions(instructions)
                .Build();

            computer.ExecuteAll();
            
            instruction1.Verify(i =>i.Execute(computer), Times.Once);
            instruction2.Verify(i => i.Execute(computer), Times.Once);
            instruction3.Verify(i => i.Execute(computer), Times.Once);
        }

        [Test]
        public void stop_execution_when_all_executed()
        {
            var instruction = new Mock<IInstruction>();
            var instructions = new[] { instruction.Object };
            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(Computer.InstructionPointer, 0)
                .WithInstructions(instructions)
                .Build();
            computer.ExecuteAll();

            computer.ExecuteStep();

            instruction.Verify(i => i.Execute(computer), Times.Once);
        }
        
        [Test]
        public void execute_empty_instructions()
        {
            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(Computer.InstructionPointer, 0)
                .Build();
            var initPointer = computer[Computer.InstructionPointer];
            
            computer.ExecuteAll();

            Assert.AreEqual(initPointer, computer[Computer.InstructionPointer]);
        }

        [Test]
        public void execute_each_instruction_on_execute_all_with_jump()
        {
            var instructions = new IInstruction[6];
            instructions[0] = new CopyValueToRegisterInstruction('a',41);
            instructions[1] = new IncrementInstruction('a');
            instructions[2] = new IncrementInstruction('a');
            instructions[3] = new DecrementInstruction('a');
            instructions[4] = new JumpInstruction('a', 2);
            instructions[5] = new DecrementInstruction('a');

            var computer = new MockComputerBuilder()
                .WithInstructions(instructions)
                .Build();

            computer.ExecuteAll();

            Assert.AreEqual(42, computer['a']);
        }
    }
}
