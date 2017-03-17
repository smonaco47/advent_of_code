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

        public void EnumerateAllPaths()
        {
            
        }

    }
}
