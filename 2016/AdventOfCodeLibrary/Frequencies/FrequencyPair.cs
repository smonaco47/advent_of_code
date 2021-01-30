using System;

namespace AdventOfCodeLibrary.Frequencies
{
    internal class FrequencyPair : IComparable
    {
        public IComparable Name { get; set; }
        public int Count { get; set; }

        public FrequencyPair()
        {
            this.Count = 0;
        }

        public int CompareTo(object obj)
        {
            var other = (FrequencyPair)obj;
            if (this.Count < other.Count)
            {
                return 1;
            }
            else if (this.Count > other.Count)
            {
                return -1;
            }
            return this.Name.CompareTo(other.Name);
        }
    }
}
