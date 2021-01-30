namespace AdventOfCodeLibrary.Instructions
{
    class CopyValueToRegisterInstruction : IInstruction
    {
        public char Register { get; }
        public int Value { get; }

        public CopyValueToRegisterInstruction(char register, int newValue)
        {
            Register = register;
            Value = newValue;
        }

        public void Execute(Computer computer)
        {
            computer[Register] = Value;
        }
    }
}
