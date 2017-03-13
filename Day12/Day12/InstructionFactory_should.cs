using NUnit.Framework;

namespace Day12
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

        //todo rest of implementation
    }
}
