using System.Linq;
using System.Text;
using AdventOfCodeLibrary.Frequencies;

namespace AdventOfCodeLibrary
{
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

        public string Name
        {
            get { return this._encryptedName; }
            private set
            {
                this._encryptedName = value;
                 DecryptName();
            }
        }
        
        public int SectorId
        {
            get { return this._sectorId; }
            private set
            {
                this._sectorId = value;
                DecryptName();
            }
        }

        public string Checksum { get; }
        public string DecryptedName { get; private set; }

        private string _encryptedName;
        private int _sectorId;

        public bool IsValid()
        {
            return Checksum == buildChecksum();
        }

        private string buildChecksum()
        {
            var checksum = new StringBuilder();
            var frequency = new Frequency(this.Name.ToArray());
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
            string temp = _encryptedName;
            for (int i = 0; i < _encryptedName.Length; i++ )
            {
                var c = _encryptedName[i];
                if (c == '-')
                {
                    newString.Append(' ');
                    continue;
                }
                var intChar = (int) c;
                var intZ = (int) 'z';
                var intA = (int) 'a';
                newString.Append((char) (((intChar + SectorId - intA) % (intZ - intA + 1)) + intA));
            }
            DecryptedName = newString.ToString();
        }
    }
}
