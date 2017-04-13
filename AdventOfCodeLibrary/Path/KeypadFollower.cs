using System;
using System.Collections.Generic;

namespace AdventOfCodeLibrary.Path
{
    public class KeypadFollower : BaseFollower
    {
        private readonly Keypad _keypad;

        public KeypadFollower(Coordinate start, Keypad keypad)
        {
            _keypad = keypad;
            _direction = DirectionEnum.North;
            resetStart(start);
        }

        public void resetStart(Coordinate start)
        {
            _xPos = start.X;
            _yPos = start.Y;
        }

        public int CurrentValue()
        {
            return _keypad.getValue(this.CurrentPosition);
        }

        protected override void Rotate(char rotation, DirectionEnum direction)
        {
            _direction = direction;
        }

        protected override bool IsValidCoordinate(int xPos, int yPos)
        {
            return (_keypad.getValue(new Coordinate(xPos, yPos))!=-1);
        }

        protected override List<Step> SplitPathString(string input)
        {
            var steps = new List<Step>();
            foreach (char str in input)
            {
                steps.Add(new Step()
                {
                    Direction = MapCharToDirection(str),
                    Steps = 1
                });
            }
            return steps;
        }

        private static DirectionEnum MapCharToDirection(char input)
        {
            var direction = DirectionEnum.North;
            switch (input)
            {
                case 'R': 
                    direction = DirectionEnum.East;
                    break;
                case 'D':
                    direction = DirectionEnum.South;
                    break;
                case 'L':
                    direction = DirectionEnum.West;
                    break;
            }
            return direction;
        }
    }
}
