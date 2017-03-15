using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day20
{
    class RangeCompare
    {
        private SortedDictionary<int,int> _blocked;
        public int Length => _blocked.Count;
        private int _maxBlocked;
        private uint _upperBound;

        public int First { get; private set; }
        public uint Count { get; private set; }

        public RangeCompare(string[] input, uint upperBound)
        {
            _blocked = new SortedDictionary<int, int>();
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
                int start;
                int end;
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
            foreach (int key in _blocked.Keys)
            {
                if (key > _maxBlocked + 1 )
                {
                    Count++;
                    _maxBlocked++;
                    if (First == -1) First = _maxBlocked;
                }

                int endPoint = _blocked[key];
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

        public static void ConvertInputToInt(string input, out int start, out int end)
        {
            string[] pair = input.Split('-');
            int.TryParse(pair[0], out start);
            int.TryParse(pair[1], out end);
        }
    }
}
