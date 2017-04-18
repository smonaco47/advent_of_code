using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLibrary
{
    internal class FrequencyPair : IComparable
    {
        public IComparable name { get; set; }
        public int count { get; set; }

        public FrequencyPair()
        {
            this.count = 0;
        }

        public int CompareTo(object obj)
        {
            var otherFP = (FrequencyPair) obj;
            if (this.count < otherFP.count)
            {
                return 1;
            }
            else if (this.count > otherFP.count)
            {
                return -1;
            }
            return this.name.CompareTo(otherFP.name);
        }
    }
    public class EncryptedRoom
    {
        const int CHECKSUM_LENGTH = 5;
        public EncryptedRoom(string input)
        {
            var indexOfBracket = input.IndexOf("[");
            var indexOfChecksum = indexOfBracket + 1;
            var indexOfSectorId = input.LastIndexOf("-") + 1;
            this.Name = input.Substring(0, indexOfSectorId-1);
            this.SectorId = int.Parse(input.Substring(indexOfSectorId, indexOfBracket - indexOfSectorId));
            this.Checksum = input.Substring(indexOfChecksum, CHECKSUM_LENGTH);
        }

        public string Name { get; }
        public int SectorId { get; }
        public string Checksum { get; }
        
        private List<FrequencyPair> _frequency = new List<FrequencyPair>();

        public bool IsValid()
        {
            return Checksum == buildChecksum();
        }

        private void buildFrequencyMap()
        {
            foreach (char c in Name)
            {

                if (c == '-') continue;
                var frequencyPair = new FrequencyPair() {name = c};
                if (_frequency.Exists(f=>(char)f.name == c))
                   _frequency.First(f => (char)f.name == c).count++;
                else
                {
                    _frequency.Add(new FrequencyPair() {name = c, count=1});
                }
            }
        }

        private string buildChecksum()
        {
            buildFrequencyMap();
            _frequency.Sort();
            var checksum = new StringBuilder();
            for (int i = 0; i < 5; i++)
                checksum.Append((char)_frequency[i].name);
            return checksum.ToString();
        }
    }
}
