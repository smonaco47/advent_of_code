namespace Day12
{
    class CopyRegisterToRegisterInstruction : IInstruction
    {
        private readonly char _source;
        private readonly char _destination;

        public CopyRegisterToRegisterInstruction(char source, char destination)
        {
            _source = source;
            _destination = destination;
        }

        public void Execute(Computer computer)
        {
            computer[_destination] = computer[_source];
        }
    }
}
