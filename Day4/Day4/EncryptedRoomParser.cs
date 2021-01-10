using AdventOfCodeLibrary.FileImport;

namespace Day4
{
    public class EncryptedRoomParser : IParser<string, EncryptedRoom>
    {
        public string[] ParseInputSet(string[] input)
        {
            return input;
        }

        public EncryptedRoom ParseSingle(string input)
        {
            return new EncryptedRoom(input);
        }
    }
}
