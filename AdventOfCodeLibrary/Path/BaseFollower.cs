using System;
using System.Collections.Generic;

namespace AdventOfCodeLibrary.Path
{
    public abstract class BaseFollower
    {
        protected int _xPos;
        protected int _yPos;
        protected DirectionEnum _direction;
        protected HashSet<Coordinate> _coordiantes;
        protected bool _stopOnRepeat;

        protected enum DirectionEnum
        {
            North,
            East,
            South,
            West
        }
        
        public Coordinate CurrentPosition => new Coordinate(_xPos,_yPos);

        public void FollowPath(string path, bool stopOnRepeat)
        {
            _coordiantes = new HashSet<Coordinate>();
            _stopOnRepeat = stopOnRepeat;
            var stringArray = path.Split(',');
            foreach (var dirStr in stringArray)
            {
                var input = dirStr.Trim();
                Rotate(input.Substring(0, 1));
                if (!Move(Convert.ToInt32(input.Substring(1)))) break;
            }
        }

        protected abstract void Rotate(string newDirection);
        protected abstract bool IsValidCoordinate(int xPos, int yPos);

        private bool Move(int steps)
        {
            bool newLocation = true;
            for (int i = 0; i < steps && (newLocation || !this._stopOnRepeat); i++)
            {
                newLocation = MoveOneStep();
            }
            return newLocation;
        }

        private bool MoveOneStep()
        {
            int newX = _xPos, newY = _yPos;
            switch (this._direction)
            {
                case DirectionEnum.North:
                    newY += 1;
                    break;
                case DirectionEnum.East:
                    newX += 1;
                    break;
                case DirectionEnum.South:
                    newY -= 1;
                    break;
                case DirectionEnum.West:
                    newX -= 1;
                    break;
                default:
                    break;
            }
            if (!IsValidCoordinate(newX, newY)) return true;
            _xPos = newX;
            _yPos = newY;
            return LogCoordinate();
        }

        private bool LogCoordinate()
        {
            var newCoordinate = new Coordinate(this._xPos, this._yPos);
            if (_coordiantes.Contains(newCoordinate)) return false;
            _coordiantes.Add(newCoordinate);
            return true;
        }

    }
}