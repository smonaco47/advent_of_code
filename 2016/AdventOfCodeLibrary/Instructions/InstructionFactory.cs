namespace AdventOfCodeLibrary.Instructions
{
    public class InstructionFactory
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
                case "cpy":
                    char destinationRegister = split[2][0];
                    int value;
                    if (int.TryParse(split[1], out value))
                    {
                        return new CopyValueToRegisterInstruction(destinationRegister, value);
                    }
                    return new CopyRegisterToRegisterInstruction(register, destinationRegister);
                case "jnz":
                    int jumpDistance, staticValue;
                    int.TryParse(split[2], out jumpDistance);
                    if (int.TryParse(split[1], out staticValue))
                    {
                        return new JumpInstruction(staticValue, jumpDistance);
                    }
                    return new JumpInstruction(register, jumpDistance);
            }
            return new NullInstruction();
        }

        public IInstruction[] CreateForList(string[] inputList)
        {
            var instructionList = new IInstruction[inputList.Length];
            for (int i = 0; i < inputList.Length; i++)
            {
                instructionList[i] = Create(inputList[i]);
            }
            return instructionList;
        }
    }
}
