using System.Collections.Generic;
using System.Text;

namespace AdventOfCodeLibrary.Path
{
    public class Maze
    {
        private char _wall;
        private char _open;
        private char _start;
        private char[,] _maze;

        public int Height { get; internal set; }
        public int Width { get; internal set; }

        public List<Point> Points { get; internal set; }
        public Point Start { get; set; }

        public Maze(char wall, char open, string[] mazeArray)
        {
            this._wall = wall;
            this._open = open;
            this._start = '0';

            Points = new List<Point>();

            StoreMaze(mazeArray);
        }

        private void StoreMaze(string[] mazeArray)
        {
            if (mazeArray.Length == 0) return;
            Height = mazeArray.Length;
            Width = mazeArray[0].Length;
            _maze = new char[Width, Height];
            for (int i = 0; i < Width; i++ )
            {
                for(int j = 0; j < Height; j++)
                {
                    char mazeElement = mazeArray[j][i];
                    _maze[i, j] = mazeElement;
                    if (IsEndpoint(mazeElement))
                    {
                        var point = new Point(i, j);
                        Points.Add(point);
                        if (mazeElement == _start) Start = point;
                    }
                   
                }
            }

        }
        
        public List<Link> getAllLinks()
        {
            var links = new List<Link>();
            for ( int i = 0; i < Points.Count-1; i++)
            {
                for (int j = i+1; j < Points.Count; j++)
                {
                    links.Add(ShortestPathBetween(Points[i], Points[j]));
                }
            }
            return links;
        }

        public Link ShortestPathBetween(Point point1, Point point2)
        {
            var mazeCopy = MazeCopy();
            var found = false;
            var visitedHash = new HashSet<Point>();
            var currentStack = new Stack<Point>();
            var nextStack = new Stack<Point>();
            var count = 0;
            var foundCount = -1;
            currentStack.Push(point1);

            while (!found && (currentStack.Count > 0))
            {
                while (currentStack.Count != 0)
                {
                    Point point = currentStack.Pop();
                    var value = GetPointValue(point);
                    if (IsBlocking(value)) continue; // Dead end
                    if (visitedHash.Contains(point)) continue; //Already visited
                    visitedHash.Add(point);
                    AddNeighbors(point, nextStack);

                    if (point.Equals(point2))
                    {
                        found = true;
                        foundCount = count;
                        break;
                    }
                }
                count++;
                while (nextStack.Count != 0)
                {
                    currentStack.Push(nextStack.Pop());
                }
            }
            return new Link(point1, point2, foundCount);
        }

        private void AddNeighbors(Point point, Stack<Point> nextStack)
        {
            if (point.X > 0)
            {
                nextStack.Push(new Point(point.X-1, point.Y));
            }
            if (point.X < Width-1)
            {
                nextStack.Push(new Point(point.X+1, point.Y));
            }
            if (point.Y > 0)
            {
                nextStack.Push(new Point(point.X, point.Y-1));
            }
            if (point.Y < Width-1)
            {
                nextStack.Push(new Point(point.X, point.Y+1));
            }
        }

        private char GetPointValue(Point point)
        {
            return _maze[point.X, point.Y];
        }

        private char[,] MazeCopy()
        {
            var mazeCopy = new char[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    mazeCopy[i, j] = _maze[i, j];
                }
            }
            return mazeCopy;
        }

        public string ToString(char[,] maze)
        {
            if (maze == null) maze = _maze;
            var sb =  new StringBuilder();
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    sb.Append(_maze[i, j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        private bool IsEndpoint(char mazeElement)
        {
            if (mazeElement == _open || IsBlocking(mazeElement)) return false;
            return true;
        }

        private bool IsBlocking(char mazeElement)
        {
            if (mazeElement == _wall) return true;
            return false;
        }
    }
}
