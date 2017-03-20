using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class ShortestPathGenerator
    {
        private readonly Dictionary<Link, int> _links;
        private Point _start;
        private Queue<Link> _shortestPath;
        private readonly HashSet<Point> _nodes;

        public int LinkCount => _links.Count;

        public ShortestPathGenerator()
        {
            _links = new Dictionary<Link, int>();
            _shortestPath = new Queue<Link>();
            _nodes = new HashSet<Point>();
        }
        public int ShortestPathLength
        { 
            get
            {
                return _shortestPath.Sum(link => link.Length);
            }
        }

        public void SetStart(Point start)
        {
            _start = start;
        }

        public void AddLinks(List<Link> links)
        {
            foreach (var link in links)
            {
                var distance = link.Length;
                if (_links.ContainsKey(link))
                {
                    var oldDistance = _links[link];
                    if (oldDistance <= link.Length) continue;
                    _links.Remove(link);
                    _links.Add(link, link.Length);
                }
                else
                {
                    _links.Add(link, link.Length);

                    if (!_nodes.Contains(link.Start)) _nodes.Add(link.Start);
                    if (!_nodes.Contains(link.End)) _nodes.Add(link.End);
                }
            }
            _start = links[0].Start;
        }

        public int ShortestPath()
        {
            if (_nodes.Count == 0 ) return -1;
            var nodesRemaining = new HashSet<Point>(_nodes);
            var paths = EnumerateAllPaths(_start, nodesRemaining);
            return GetShortest(paths);
        }

        public List<Queue<T>> EnumerateAllPaths<T>( T currentNode, HashSet<T> nodesRemaining )
        {
            if (nodesRemaining.Contains(currentNode)) nodesRemaining.Remove(currentNode);

            var returnList = new List<Queue<T>>();
            // Base case, all nodes in path
            if (nodesRemaining.Count == 0)
            {
                var newQueue = new Queue<T>();
                newQueue.Enqueue(currentNode);
                returnList.Add( newQueue);
                return returnList;
            }
            foreach (T node in nodesRemaining)
            {
                var nodesRemainingNew = new HashSet<T>(nodesRemaining);
                var newList = EnumerateAllPaths(node, nodesRemainingNew);
                foreach (var queue in newList)
                {
                    queue.Enqueue(currentNode);
                    returnList.Add(queue);
                }
            }
            return returnList;
        }

        private int GetShortest(List<Queue<Point>> paths)
        {
            int shortest = int.MaxValue;
            foreach (var path in paths)
            {
                Queue<Link> links;
                var cost = ComputeCost(path, out links);
                if (cost < shortest && cost != -1)
                {
                    shortest = cost;
                    _shortestPath = links;
                }
            }
            return shortest;
        }

        private int ComputeCost(Queue<Point> path, out Queue<Link> linksUsed)
        {
            var cost = 0;
            linksUsed = new Queue<Link>();
            for (var i = 0; i < path.Count - 1; i++)
            {
                var firstPoint = path.ElementAt(i);
                var secondPoint = path.ElementAt(i+1);
                    
                var link = new Link(firstPoint,secondPoint,-1);
                var linkBackwards = new Link(secondPoint, firstPoint, -1);
                if (_links.ContainsKey(link))
                {
                    cost += _links[link];
                    linksUsed.Enqueue(link);
                }
                else if (_links.ContainsKey(linkBackwards))
                {
                    cost += _links[linkBackwards];
                    linksUsed.Enqueue(linkBackwards);
                }
                else return -1;
            }
            return cost;

        }
    }
}
