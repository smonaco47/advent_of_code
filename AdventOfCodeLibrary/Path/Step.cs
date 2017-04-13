
using System.IO;

namespace AdventOfCodeLibrary.Path
{
    public class Step
    {
        public BaseFollower.DirectionEnum Direction { get; set; }
        public int Steps { get; set; }
        public char Rotation { get; set; } // Expecting 'R' or 'L'
    }
}
