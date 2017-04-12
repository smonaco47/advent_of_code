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

        protected override void Rotate(string newDirection)
        {
            int newD = Convert.ToInt32(_direction);
            switch (newDirection)
            {
                case "R":
                    newD += 1;
                    break;
                case "L":
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
    }
}
