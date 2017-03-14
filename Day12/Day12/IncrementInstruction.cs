using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
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
