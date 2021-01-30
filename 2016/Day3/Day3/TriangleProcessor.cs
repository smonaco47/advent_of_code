using AdventOfCodeLibrary.FileImport;

namespace Day3
{
    class TriangleProcessor : SetProcessor<Triangle>
    {
        private int _count;

        public TriangleProcessor(FileImporter<Triangle> importer) : base(importer)
        { }

        public override bool IsValid(Triangle entity)
        {
            return entity.IsValid();
        }

        public override void DoAction(Triangle entity)
        {
            _count++;
        }

        public int GetResult()
        {
            return _count;
        }
    }
}
