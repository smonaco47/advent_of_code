using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests
{
    class EncryptedRoom_should
    {
        [Test]
        public void initialize_encryption_from_input_string()
        {
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var room = new EncryptedRoom(input);
            Assert.AreEqual("aaaaa-bbb-z-y-x", room.Name);
        }


        [Test]
        public void initialize_sector_id_from_input_string()
        {
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var room = new EncryptedRoom(input);
            Assert.AreEqual(123, room.SectorId);
        }


        [Test]
        public void initialize_checksum_from_input_string()
        {
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var room = new EncryptedRoom(input);
            Assert.AreEqual("abxyz", room.Checksum);
        }

        [Test]
        public void validate_if_checksum_matches_count()
        {
            string input = "aaaaa-bbb-z-y-x-123[abxyz]";
            var room = new EncryptedRoom(input);
            Assert.IsTrue(room.IsValid());
        }

        [Test]
        public void validate_if_checksum_matches_count_with_ordering()
        {
            string input = "a-b-c-d-e-f-g-h-987[abcde]";
            var room = new EncryptedRoom(input);
            Assert.IsTrue(room.IsValid());
        }

        [Test]
        public void validate_if_checksum_does_not_always_match()
        {
            string input = "totally-real-room-200[decoy]";
            var room = new EncryptedRoom(input);
            Assert.IsFalse(room.IsValid());
        }
    }
}
