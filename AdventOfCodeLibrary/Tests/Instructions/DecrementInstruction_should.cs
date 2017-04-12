using AdventOfCodeLibrary.Instructions;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Instructions
{
    // ReSharper disable once InconsistentNaming
    class DecrementInstruction_should
    {
        [Test]
        public void decrement_register()
        {
            
            var register = Any.Register();
            var initialRegisterValue = Any.RegisterValue();

            var computer = new MockComputerBuilder().
                WithDefaultRegisterValue(register, initialRegisterValue)
                .Build();

            var instruction = new DecrementInstruction(register);
  
            instruction.Execute(computer);

            Assert.AreEqual(initialRegisterValue-1, computer[register]);
        }
    }
}
