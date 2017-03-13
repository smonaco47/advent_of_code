using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class CopyValueToRegisterInstruction : IInstruction
    {
        private readonly char _register;
        private readonly int _newValue;

        public CopyValueToRegisterInstruction(char register, int newValue)
        {
            _register = register;
            _newValue = newValue;
        }

        public void Execute(Computer computer)
        {
            computer[_register] = _newValue;
        }
    }
}
