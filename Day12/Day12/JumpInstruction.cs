namespace Day12
{
    class JumpInstruction : IInstruction
    {
        public char Register { get; }
        public int JumpDistance { get; }
        public int StaticValue { get; }
        public bool SkipRegister { get; }

        public JumpInstruction(char register, int jumpDistance)
        {
            Register = register;
            JumpDistance = jumpDistance;
        }

        public JumpInstruction(int value, int jumpDistance)
        {
            SkipRegister = true;
            StaticValue = value;
            JumpDistance = jumpDistance;
        }

        public void Execute(Computer computer)
        {
            if (!SkipRegister && computer[Register] == 0) return;
            if (SkipRegister && StaticValue == 0) return;

            computer[Computer.InstructionPointer] += JumpDistance - 1;
        }
    }
}
