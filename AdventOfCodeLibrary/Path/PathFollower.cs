using System;
using System.Collections.Generic;

namespace AdventOfCodeLibrary.Path
{
    public class PathFollower
    {
        private enum directionEnum
        {
            North,
            East,
            South,
            West
        }

        private enum Rotations
        {
            Left,
            Right
        }

        private directionEnum direction;
        private int xPos;
        private int yPos;
        private HashSet<Coordinate> _coordiantes;

        public PathFollower ()
        {
            direction = directionEnum.North;
            xPos = 0;
            yPos = 0;
        }

        public void FollowPath(string path, bool stopOnRepeat)
        {
            _coordiantes = new HashSet<Coordinate>();
            var stringArray = path.Split(',');
            foreach (var dirStr in stringArray)
            {
                var input = dirStr.Trim();
                Rotate(input.Substring(0, 1));
                if (!Move(Convert.ToInt32(input.Substring(1)))) break;
            }
        }
        

        private void Rotate(string newDirection)
        {
            int newD = Convert.ToInt32(direction);
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
            Enum.TryParse(newD.ToString(), out direction);
        }

        private bool Move( int steps )
        {
            bool newLocation = true;
            for (int i = 0; i < steps && newLocation; i++)
            {
                newLocation= MoveOneStep();
            }
            return newLocation;
        }

        private bool MoveOneStep()
        {
            switch (this.direction)
            {
                case directionEnum.North:
                    yPos += 1;
                    break;
                case directionEnum.East:
                    xPos += 1;
                    break;
                case directionEnum.South:
                    yPos -= 1;
                    break;
                case directionEnum.West:
                    xPos -= 1;
                    break;
                default:
                    break;
            }
            return LogCoordinate(xPos, yPos);
        }

        private bool LogCoordinate( int xPos, int yPos )
        {
            var newCoordinate = new Coordinate(this.xPos, yPos);
            if (_coordiantes.Contains(newCoordinate)) return false;
            _coordiantes.Add(newCoordinate);
            return true;
        }

        public int DistanceFromStart()
        {
            return Math.Abs(xPos) + Math.Abs(yPos);
        }
    }
}
