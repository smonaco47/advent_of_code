using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day12
{
    class InstructionFactory
    {
        public IInstruction Create(string input)
        {
            string[] split = input.Split(' ');
            string command = split[0];
            char register = split[1][0];

            switch (command)
            {
                case "inc":
                    return new IncrementInstruction(register);
                case "dec":
                    return new DecrementInstruction(register);
            }
            return new IncrementInstruction(register); //todo good to have null implementation of the interface
        }
    }
}
