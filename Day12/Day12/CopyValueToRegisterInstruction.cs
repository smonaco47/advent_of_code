using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
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
