using System.IO;

namespace AdventOfCodeLibrary.FileImport
{
    public class FileImportAdapter
    {
        public virtual string[] ReadFileToArray(string filepath)
        {
            return File.ReadAllLines(filepath);
        }
    }
}
