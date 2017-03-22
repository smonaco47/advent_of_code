using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class Maze
    {
        private char _wall;
        private char _open;
        private char _visited;
        private char[,] _maze;

        public int Height { get; internal set; }
        public int Width { get; internal set; }

        public List<Point> Points { get; internal set; }

        public Maze(char wall, char open, string[] mazeArray)
        {
            this._wall = wall;
            this._open = open;
            this._visited = '~';

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
                        Points.Add(new Point(i, j));
                    }
                }
            }

        }
        
        internal List<Link> getLinks()
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

            throw new NotImplementedException();
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
            if (mazeElement == _wall  || mazeElement == _visited) return true;
            return false;
        }
    }
}
