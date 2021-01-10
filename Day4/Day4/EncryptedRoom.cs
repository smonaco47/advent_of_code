using System;
using System.Linq;
using System.Text;
using AdventOfCodeLibrary.Frequencies;

namespace Day4
{
    public class EncryptedRoom
    {
        const int ChecksumLength = 5;
        public EncryptedRoom(string input)
        {
            var indexOfBracket = input.IndexOf("[", StringComparison.Ordinal);
            var indexOfChecksum = indexOfBracket + 1;
            var indexOfSectorId = input.LastIndexOf("-", StringComparison.Ordinal) + 1;
            Name = input.Substring(0, indexOfSectorId - 1);
            SectorId = int.Parse(input.Substring(indexOfSectorId, indexOfBracket - indexOfSectorId));
            Checksum = input.Substring(indexOfChecksum, ChecksumLength);
        }

        public string Name
        {
            get { return _encryptedName; }
            private set
            {
                _encryptedName = value;
                DecryptName();
            }
        }

        public int SectorId
        {
            get { return _sectorId; }
            private set
            {
                _sectorId = value;
                DecryptName();
            }
        }

        public string Checksum { get; }
        public string DecryptedName { get; private set; }

        private string _encryptedName;
        private int _sectorId;

        public bool IsValid()
        {
            return Checksum == BuildChecksum();
        }

        private string BuildChecksum()
        {
            var checksum = new StringBuilder();
            var frequency = new Frequency(Name.ToArray());
            frequency.ItemsToSkip.Add('-');
            frequency.Build();
            var topFive = frequency.TopN(5);
            foreach (var item in topFive)
                checksum.Append((char)item);
            return checksum.ToString();
        }

        private void DecryptName()
        {
            var newString = new StringBuilder();
            for (int i = 0; i < _encryptedName.Length; i++)
            {
                var c = _encryptedName[i];
                if (c == '-')
                {
                    newString.Append(' ');
                    continue;
                }
                var intChar = (int)c;
                var intZ = (int)'z';
                var intA = (int)'a';
                newString.Append((char)(((intChar + SectorId - intA) % (intZ - intA + 1)) + intA));
            }
            DecryptedName = newString.ToString();
        }
    }
}
