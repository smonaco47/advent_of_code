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

        public enum DirectionEnum
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
            var steps = SplitPathString(path);
            foreach (var step in steps)
            {
                Rotate(step.Rotation, step.Direction);
                if (!Move(step.Steps)) break;
            }
        }

        protected abstract void Rotate(char rotation, DirectionEnum direction);
        protected abstract bool IsValidCoordinate(int xPos, int yPos);
        protected abstract List<Step> SplitPathString(string input);

        private bool Move(int steps)
        {
            bool newLocation = true;
            for (int i = 0; i < steps && (newLocation || !this._stopOnRepeat); i++)
            {
                newLocation = MoveOneStep();
            }
            return (newLocation || !this._stopOnRepeat);
        }

        private bool MoveOneStep()
        {
            int newX = _xPos, newY = _yPos;
            switch (this._direction)
            {
                case DirectionEnum.North:
                    newY -= 1;
                    break;
                case DirectionEnum.East:
                    newX += 1;
                    break;
                case DirectionEnum.South:
                    newY += 1;
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