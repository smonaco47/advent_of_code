using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLibrary.Path
{
    public class ShortestPathGenerator
    {
        private readonly Dictionary<Link, int> _links;
        private Coordinate _start;
        private Queue<Link> _shortestPath;
        private readonly HashSet<Coordinate> _nodes;

        public int LinkCount => _links.Count;
        public bool ReturnHome; 

        public ShortestPathGenerator()
        {
            _links = new Dictionary<Link, int>();
            _shortestPath = new Queue<Link>();
            _nodes = new HashSet<Coordinate>();
        }
        public int ShortestPathLength
        { 
            get
            {
                return _shortestPath.Sum(link => link.Length);
            }
        }

        public void SetStart(Coordinate start)
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
            var nodesRemaining = new HashSet<Coordinate>(_nodes);
            var paths = EnumerateAllPaths(_start, nodesRemaining, ReturnHome?_start:null);
            return GetShortest(paths);
        }

        public List<Queue<T>> EnumerateAllPaths<T>( T currentNode, HashSet<T> nodesRemaining, T start )
        {
            if (nodesRemaining.Contains(currentNode)) nodesRemaining.Remove(currentNode);

            var returnList = new List<Queue<T>>();
            // Base case, all nodes in path
            if (nodesRemaining.Count == 0)
            {
                var newQueue = new Queue<T>();
                if (start != null ) newQueue.Enqueue(start);
                newQueue.Enqueue(currentNode);
                returnList.Add( newQueue);
                return returnList;
            }
            foreach (T node in nodesRemaining)
            {
                var nodesRemainingNew = new HashSet<T>(nodesRemaining);
                var newList = EnumerateAllPaths(node, nodesRemainingNew, start);
                foreach (var queue in newList)
                {
                    queue.Enqueue(currentNode);
                    returnList.Add(queue);
                }
            }
            return returnList;
        }

        private int GetShortest(List<Queue<Coordinate>> paths)
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

        private int ComputeCost(Queue<Coordinate> path, out Queue<Link> linksUsed)
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
                    var distance = _links[link];
                    cost += distance;
                    link.Length = distance;
                    linksUsed.Enqueue(link);
                }
                else if (_links.ContainsKey(linkBackwards))
                {
                    var distance = _links[linkBackwards];
                    cost += distance;
                    linkBackwards.Length = distance;
                    linksUsed.Enqueue(linkBackwards);
                }
                else return -1;
            }
            return cost;

        }
        
    }
}
