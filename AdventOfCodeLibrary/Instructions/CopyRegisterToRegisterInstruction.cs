namespace AdventOfCodeLibrary.Instructions
{
    class CopyRegisterToRegisterInstruction : IInstruction
    {
        public char Source { get; }
        public char Destination { get; }

        public CopyRegisterToRegisterInstruction(char source, char destination)
        {
            Source = source;
            Destination = destination;
        }

        public void Execute(Computer computer)
        {
            computer[Destination] = computer[Source];
        }
    }
}
