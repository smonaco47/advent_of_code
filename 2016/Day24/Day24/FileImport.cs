using System.IO;

namespace Day20
{
    public class FileImport
    {
        public virtual string[] ReadFileToArray(string filepath)
        {
            try
            {
                return File.ReadAllLines(filepath);
            }
            catch
            {
                return new string[0];
            }
        }
    }
}
