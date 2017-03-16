using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    class RangeCompare
    {
        private SortedDictionary<long, long> _blocked;
        public long Length => _blocked.Count;
        private long _maxBlocked;
        private long _upperBound;

        public long First { get; private set; }
        public long Count { get; private set; }

        public RangeCompare(string[] input, long upperBound)
        {
            _blocked = new SortedDictionary<long, long>();
            BuildDictionary(input);
            _maxBlocked = -1;
            First = -1;
            Count = 0;
            _upperBound = upperBound;
        }

        private void BuildDictionary(string[] input)
        {
            foreach (string str in input)
            {
                long start;
                long end;
                ConvertInputToInt(str, out start, out end);
                if (_blocked.Keys.Contains(start))
                {
                    _blocked[start] = Math.Max(_blocked[start], end);
                }
                else
                {
                    _blocked[start] = end;
                }
            }
        }

        public void CalculateNonBlocked()
        {
            First = -1;
            _maxBlocked = -1;
            Count = 0;
            foreach (long key in _blocked.Keys)
            {
                if (key > _maxBlocked + 1 )
                {
                    _maxBlocked++;
                    Count = Count + (key - _maxBlocked);
                    if (First == -1) First = _maxBlocked;
                    _maxBlocked = key;
                }

                long endPoint = _blocked[key];
                if (endPoint > _maxBlocked)
                {
                    _maxBlocked = endPoint;
                }

            }
            if (First == -1) First = _maxBlocked + 1;
            if (_maxBlocked < _upperBound)
            {
                Count += _upperBound - (uint)_maxBlocked;
            }
        }

        public static void ConvertInputToInt(string input, out long start, out long end)
        {
            string[] pair = input.Split('-');
            long.TryParse(pair[0], out start);
            long.TryParse(pair[1], out end);
        }
    }
}
