using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    class ShortestPathGenerator
    {
        private Dictionary<Link, int> _links;
        private Point _start;
        private Queue<Link> _shortestPath;
        private HashSet<Point> _nodes;

        public int LinkCount => _links.Count;

        public ShortestPathGenerator()
        {
            _links = new Dictionary<Link, int>();
            _shortestPath = new Queue<Link>();
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
                    int oldDistance = _links[link];
                    if (oldDistance > link.Length)
                    {
                        _links.Remove(link);
                        _links.Add(link, link.Length);
                    }
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

        public void FindAllPaths()
        {
            //var path = new Queue<Link>();
            foreach (var link in _links.Keys)
            {
                _shortestPath.Enqueue(link);
            }
            //path.Enqueue(_links.Keys.First());
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
    }
}
