using System;
using System.Collections.Generic;

namespace AdventOfCodeLibrary.Path
{
    public class PathFollower : BaseFollower
    {
        public PathFollower()
        {
            _direction = DirectionEnum.North;
            _xPos = 0;
            _yPos = 0;
        }

        public double DistanceFromStart()
        {
            return Math.Abs(_xPos) + Math.Abs(_yPos);
        }

        protected override void Rotate(char rotation, DirectionEnum direction)
        {
            int newD = Convert.ToInt32(_direction);
            switch (rotation)
            {
                case 'R':
                    newD += 1;
                    break;
                case 'L':
                    newD += 3;
                    break;
                default:
                    break;
            }
            newD %= 4;
            Enum.TryParse(newD.ToString(), out _direction);
        }

        protected override bool IsValidCoordinate(int xPos, int yPos)
        {
            return true;
        }

        protected override List<Step> SplitPathString(string input)
        {
            int numSteps;
            char rotation;
            var stringArray = input.Split(',');
            var steps = new List<Step>();
            foreach (var dirStr in stringArray)
            {
                var trimmed = dirStr.Trim();
                rotation = trimmed.Substring(0, 1)[0];
                numSteps = Convert.ToInt32(trimmed.Substring(1));
                steps.Add(new Step() {Rotation=rotation, Steps = numSteps});
            }
            return steps;
        }
    }
}
