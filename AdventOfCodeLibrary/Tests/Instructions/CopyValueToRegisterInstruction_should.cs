using AdventOfCodeLibrary.Instructions;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Instructions
{
    // ReSharper disable once InconsistentNaming
    class CopyValueToRegisterInstruction_should
    {
        [Test]
        public void copy_value_to_register()
        {
            var register = Any.Register();
            var initialValue = Any.RegisterValue();
            var newValue = Any.RegisterValue();

            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(register, initialValue)
                .Build();

            var copyInstruction = new CopyValueToRegisterInstruction(register, newValue);

            copyInstruction.Execute(computer);

            Assert.AreEqual(newValue, computer[register]);
        }
    }
}
