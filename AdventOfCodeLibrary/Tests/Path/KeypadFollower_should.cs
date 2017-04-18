using AdventOfCodeLibrary.Path;
using Moq;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Path
{
    class KeypadFollower_should
    {
        [Test]
        public void split_input_into_steps()
        {
            string input = "UL";
            var keypad = new Mock<Keypad>();
            var keypadFollower = new KeypadFollower(new Coordinate(1,1), keypad.Object);
            keypadFollower.FollowPath(input, false);
            Assert.AreEqual("1", keypadFollower.CurrentValue());
        }


        [Test]
        public void read_correct_final_location()
        {
            string input = "ULL";
            var keypad = new Mock<Keypad>();
            var keypadFollower = new KeypadFollower(new Coordinate(1, 1), keypad.Object);
            keypadFollower.FollowPath(input, false);
            Assert.AreEqual(new Coordinate(0,0), keypadFollower.CurrentPosition);
            Assert.AreEqual(0, keypadFollower.CurrentPosition.X);
            Assert.AreEqual(0, keypadFollower.CurrentPosition.Y);
        }

        [Test]
        public void reset_the_start_position()
        {
            string input = "LURDL";
            var keypad = new Mock<Keypad>();
            var keypadFollower = new KeypadFollower(new Coordinate(1, 2), keypad.Object);
            keypadFollower.FollowPath(input, false);
            keypadFollower.resetStart(new Coordinate(1,2));
            Assert.AreEqual(1, keypadFollower.CurrentPosition.X);
            Assert.AreEqual(2, keypadFollower.CurrentPosition.Y);
            Assert.AreEqual(new Coordinate(1,2), keypadFollower.CurrentPosition);
        }

        [Test]
        public void reuse_same_location()
        {
            string input = "LRLDUD";
            var keypad = new Mock<Keypad>();
            var keypadFollower = new KeypadFollower(new Coordinate(1, 1), keypad.Object);
            keypadFollower.FollowPath(input, false);
            Assert.AreEqual(0, keypadFollower.CurrentPosition.X);
            Assert.AreEqual(2, keypadFollower.CurrentPosition.Y);
        }
    }
}
