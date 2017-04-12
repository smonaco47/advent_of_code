using AdventOfCodeLibrary.Instructions;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Instructions
{
    // ReSharper disable once InconsistentNaming
    class IncrementInstruction_should
    {
        [Test]
        public void increment_register()
        {

            var register = Any.Register();
            var initialRegisterValue = Any.RegisterValue();

            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(register,initialRegisterValue)
                .Build();
            var incrementInstruction = new IncrementInstruction(register);
            incrementInstruction.Execute(computer);
            
            Assert.AreEqual(initialRegisterValue+1,computer[register]);
        }
    }
}
