namespace AdventOfCodeLibrary.FileImport
{
    public class FileImporter<T>
    {
    private readonly IParser<string, T> _parser;
        private readonly FileImportAdapter _fileImportAdapter;

        internal FileImporter(IParser<string, T> parser, FileImportAdapter fileImportAdapter)
        {
            _parser = parser;
            _fileImportAdapter = fileImportAdapter;
        }
        public FileImporter(IParser<string, T> parser) : this(parser, new FileImportAdapter())
        { }

        public virtual T[] ReadFileToArray(string filepath)
    {
        try
        {
            var stringArray = _fileImportAdapter.ReadFileToArray(filepath);
            stringArray = _parser.ParseInputSet(stringArray);
            var tArray = new T[stringArray.Length];
            for (var i = 0; i < stringArray.Length; i++)
            {
                tArray[i] = _parser.ParseSingle(stringArray[i]);
            }
            return tArray;
        }
        catch
        {
            return new T[0];
        }
    }
    }
}
