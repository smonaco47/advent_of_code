namespace AdventOfCodeLibrary.FileImport
{
    public interface IParser<TFrom, out TTo>
    {
        TFrom[] ParseInputSet(TFrom[] input);

        TTo ParseSingle(TFrom input);
    }
}
