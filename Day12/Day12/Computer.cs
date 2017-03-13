using System.Collections.Generic;

namespace Day12
{
    public class Computer
    {
        private readonly IInstruction[] _instructions;
        private readonly Dictionary<char, int> _registers;
        private bool _complete;

        public const char InstructionPointer = 'i';
        
        public Computer() : this(null) { }

        public Computer(IInstruction[] instructions = null)
        {
            _instructions = instructions ?? new IInstruction[0];
            _registers = new Dictionary<char, int>();
        }

        public virtual int this[char i]
        {
            get
            {
                return _registers.ContainsKey(i) ? _registers[i] : 0;
            }
            set { _registers[i] = value; }
        }

        public void ExecuteStep()
        {
            if (this[InstructionPointer] >= _instructions.Length)
            {
                _complete = true;
                return;
            }

            _instructions[this[InstructionPointer]].Execute(this);
            this[InstructionPointer] += 1;  // could move this into instruction

        }

        public void ExecuteAll()
        {
            while (!_complete)
            {
                ExecuteStep();
            }
        }
    }
}
