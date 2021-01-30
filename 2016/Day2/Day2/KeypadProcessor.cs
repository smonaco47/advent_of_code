using System;
using AdventOfCodeLibrary.FileImport;
using AdventOfCodeLibrary.Path;

namespace Day2
{
    class KeypadProcessor : SetProcessor<string>
    {
        private readonly KeypadFollower _keypadFollower;

        public KeypadProcessor(FileImporter<string> importer, KeypadFollower keypadFollower) : base(importer)
        {
            _keypadFollower = keypadFollower;
        }

        public override bool IsValid(string str) => true;

        public override void DoAction(string str)
        {
            _keypadFollower.FollowPath(str, false);
            Console.Write(_keypadFollower.CurrentValue());

        }
    }
}
