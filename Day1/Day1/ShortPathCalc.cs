using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode_16_1_1
{
    class ShortPathCalc
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

        public ShortPathCalc ()
        {
            direction = directionEnum.North;
            xPos = 0;
            yPos = 0;
        }

        public void FollowPath(string path, bool stopOnRepeat)
        {
            var coordinates = new HashSet<Coordinate>();
            var stringArray = path.Split(',');
            foreach (var dirStr in stringArray)
            {
                dirStr = dirStr.Trim();
                Rotate(dirStr.Substring(0, 1));
                if (Move(Convert.ToInt32(dirStr.Substring(1)), coordinates)) break;
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

        private bool Move(int steps, HashSet<Coordinate> coordinates )
        {
            switch (this.direction)
            {
                case directionEnum.North:
                    yPos += steps;
                    break;
                case directionEnum.East:
                    xPos += steps;
                    break;
                case directionEnum.South:
                    yPos -= steps;
                    break;
                case directionEnum.West:
                    xPos -= steps;
                    break;
                default:
                    break;
            }
            var newCoordinate = new Coordinate(yPos, xPos);
            if (coordinates.Contains(newCoordinate)) return true;
            coordinates.Add(newCoordinate);
            //TODO need to add intermediate steps to the coordinates
            return false;
        }

        public int DistanceFromStart()
        {
            return Math.Abs(xPos) + Math.Abs(yPos);
        }
    }
}
