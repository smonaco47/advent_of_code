namespace AdventOfCodeLibrary.FileImport
{
    public class NullParser : IParser<string, string>
    {
        public string[] ParseInputSet(string[] input)
        {
            return input;
        }

        public string ParseSingle(string input)
        {
            return input;
        }
    }
}
