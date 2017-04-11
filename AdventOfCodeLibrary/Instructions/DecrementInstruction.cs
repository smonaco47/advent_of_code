namespace AdventOfCodeLibrary.Instructions
{
    class DecrementInstruction : IInstruction
    {
        private readonly char _register;

        public DecrementInstruction(char register)
        {
            _register = register;
        }

        public void Execute(Computer computer)
        {
            computer[_register] -= 1;
        }
    }
}
