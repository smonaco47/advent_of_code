using AdventOfCodeLibrary.Instructions;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Instructions
{
    class InstructionFactory_should
    {
        [Test]
        public void create_increment_instruction()
        {
            string input = "inc d";
            var factory = new InstructionFactory();
            IInstruction newInstruction = factory.Create(input);

            Assert.IsInstanceOf<IncrementInstruction>(newInstruction);
            Assert.AreEqual('d', ((IncrementInstruction)newInstruction).Register);
            
        }

        [Test]
        public void create_decrement_instruction()
        {
            string input = "dec d";
            var factory = new InstructionFactory();
            IInstruction newInstruction = factory.Create(input);

            Assert.IsInstanceOf<DecrementInstruction>(newInstruction);
        }

        [Test]
        public void create_copy_register_to_register_instruction()
        {
            string input = "cpy a b";
            var factory = new InstructionFactory();
            IInstruction newInstruction = factory.Create(input);

            Assert.IsInstanceOf<CopyRegisterToRegisterInstruction>(newInstruction);
            Assert.AreEqual('a',((CopyRegisterToRegisterInstruction)newInstruction).Source);
            Assert.AreEqual('b', ((CopyRegisterToRegisterInstruction)newInstruction).Destination);
        }

        [Test]
        public void create_copy_value_to_register_instruction()
        {
            string input = "cpy 50 a";
            var factory = new InstructionFactory();
            IInstruction newInstruction = factory.Create(input);

            Assert.IsInstanceOf<CopyValueToRegisterInstruction>(newInstruction);
            Assert.AreEqual('a', ((CopyValueToRegisterInstruction)newInstruction).Register);
            Assert.AreEqual(50, ((CopyValueToRegisterInstruction)newInstruction).Value);
        }

        [Test]
        public void create_jump_instruction_with_registry()
        {
            string input = "jnz x -50";
            var factory = new InstructionFactory();
            IInstruction newInstruction = factory.Create(input);

            Assert.IsInstanceOf<JumpInstruction>(newInstruction);
            Assert.AreEqual('x', ((JumpInstruction)newInstruction).Register);
            Assert.AreEqual(-50, ((JumpInstruction)newInstruction).JumpDistance);
        }

        [Test]
        public void create_jump_instruction_with_integer()
        {
            string input = "jnz 1 50";
            var factory = new InstructionFactory();
            IInstruction newInstruction = factory.Create(input);

            Assert.IsInstanceOf<JumpInstruction>(newInstruction);
            Assert.AreEqual(1, ((JumpInstruction)newInstruction).StaticValue);
            Assert.AreEqual(true, ((JumpInstruction)newInstruction).SkipRegister);
            Assert.AreEqual(50, ((JumpInstruction)newInstruction).JumpDistance);
        }

        [Test]
        public void get_instructions_from_instruction_array()
        {
            var inputList = new []{"cpy 50 a", "inc a"};
            var factory = new InstructionFactory();

            IInstruction[] instructionList = factory.CreateForList(inputList);

            Assert.AreEqual(inputList.Length, instructionList.Length);
            Assert.IsInstanceOf<CopyValueToRegisterInstruction>(instructionList[0]);
            Assert.IsInstanceOf<IncrementInstruction>(instructionList[1]);
        }
    }
}
