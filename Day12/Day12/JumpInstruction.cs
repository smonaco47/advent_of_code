namespace Day12
{
    class JumpInstruction : IInstruction
    {
        private readonly char _register;
        private readonly int _jumpDistance;

        public JumpInstruction(char register, int jumpDistance)
        {
            _register = register;
            _jumpDistance = jumpDistance;
        }

        public void Execute(Computer computer)
        {
            if (computer[_register] == 0) return;

            computer[Computer.InstructionPointer] += _jumpDistance - 1;
        }
    }
}
