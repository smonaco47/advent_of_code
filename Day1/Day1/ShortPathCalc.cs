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

        public void followPath(string path, bool stopOnRepeat)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            var stringArray = path.Split(',');
            foreach (string dirStr in stringArray)
            {
                moveInDirection(dirStr.Trim());
                //if (dict.Contains(value)) break;
                //dict.Add(xPos, yPos);
            }
        }



        private void moveInDirection(string dirStr)
        {
            Rotate(dirStr.Substring(0,1));
            Move(Convert.ToInt32(dirStr.Substring(1)));
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

        private void Move(int steps)
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
        }

        public int distanceFromStart()
        {
            return Math.Abs(xPos) + Math.Abs(yPos);
        }
    }
}
