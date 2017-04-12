namespace AdventOfCodeLibrary.Instructions
{
    class IncrementInstruction : IInstruction
    {
        public IncrementInstruction(char register)
        {
            Register = register;
        }

        public void Execute(Computer computer)
        {
            computer[Register] += 1;
        }

        public char Register { get; }
    }
}
