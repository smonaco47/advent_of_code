using System.Collections.Generic;

namespace AdventOfCodeLibrary.FileImport
{
    public abstract class SetProcessor<T>
    {
        private readonly FileImporter<T> _importer;

        public SetProcessor(FileImporter<T> importer)
        {
            _importer = importer;
        }

        public void Process(string fileName)
        {
            var entities = _importer.ReadFileToArray(fileName);
            ProcessEachEntity(entities);
        }

        public void ProcessEachEntity(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                if (IsValid(entity))
                { 
                    DoAction(entity);
                }
            }
        }
        
        public abstract bool IsValid(T entity);

        public abstract void DoAction(T entity);
    }
}
