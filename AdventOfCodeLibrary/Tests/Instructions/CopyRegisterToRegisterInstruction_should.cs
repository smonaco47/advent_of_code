using AdventOfCodeLibrary.Instructions;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Instructions
{
    // ReSharper disable once InconsistentNaming
    class CopyRegisterToRegisterInstruction_should
    {
        [Test]
        public void copy_register_to_register()
        {
            var registerSource = Any.Register();
            var registerValueToCopy = Any.RegisterValue();
            var registerDestination = (char)(registerSource + 1) ;
            var initialValue = registerValueToCopy + 1;

            var computer = new MockComputerBuilder()
                .WithDefaultRegisterValue(registerSource, registerValueToCopy)
                .WithDefaultRegisterValue(registerDestination, initialValue)
                .Build();

            var copyInstruction = new CopyRegisterToRegisterInstruction(registerSource, registerDestination);

            copyInstruction.Execute(computer);

            Assert.AreEqual(registerValueToCopy, computer[registerDestination]);
        }
    }
}
