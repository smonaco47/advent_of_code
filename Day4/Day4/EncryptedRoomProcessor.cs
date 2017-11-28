using System;
using AdventOfCodeLibrary.FileImport;

namespace Day4
{
    class EncryptedRoomProcessor : SetProcessor<EncryptedRoom>
    {
        private int _sectorCount;
        public EncryptedRoomProcessor() : base(new FileImporter<EncryptedRoom>(new EncryptedRoomParser()))
        { }

        public override bool IsValid(EncryptedRoom room)
        {
            return room.IsValid();
        }

        public override void DoAction(EncryptedRoom room)
        {
            _sectorCount += room.SectorId;

            if (room.DecryptedName.Contains("north") || room.DecryptedName.Contains("toy"))
                Console.WriteLine("Name: " + room.DecryptedName + "\t\tSector : " + room.SectorId);
        }

        public void PrintResult()
        {
            Console.Write("Count: " + _sectorCount);
        }
    }
}
