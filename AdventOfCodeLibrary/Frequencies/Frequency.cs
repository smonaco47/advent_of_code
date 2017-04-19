using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCodeLibrary.Frequencies
{
    class Frequency
    {
        private readonly IEnumerable _name;
        private readonly List<FrequencyPair> _frequency = new List<FrequencyPair>();
        public HashSet<IComparable> ItemsToSkip= new HashSet<IComparable>();

        public Frequency(IEnumerable name)
        {
            this._name = name;
        }

        public void Build()
        {
            foreach (var item in _name)
            {

                if (ItemsToSkip.Contains((IComparable)item)) continue;
                if (_frequency.Exists(f => f.Name.Equals(item)))
                    _frequency.First(f => f.Name.Equals(item)).Count++;
                else
                {
                    _frequency.Add(new FrequencyPair() { Name = (IComparable)item, Count = 1 });
                }
            }
        }

        public IEnumerable<IComparable> TopN(int amountToReturn)
        {
            _frequency.Sort();
            return _frequency.Take(amountToReturn).Select(f => f.Name);
        }
    }
}
