using AdventOfCodeLibrary.Path;
using NUnit.Framework;

namespace AdventOfCodeLibrary.Tests.Path
{
    class Keypad_should
    {
        [Test]
        public void initialize_with_length_and_height()
        {
            int width = Any.keypadLength();
            int height = Any.keypadLength();
            var keypad = new Keypad(width, height);
            Assert.AreEqual(width, keypad.Width);
            Assert.AreEqual(height, keypad.Height);
        }

        [Test]
        public void initialize_with_correct_numbers()
        {
            int width = Any.keypadLength();
            int height = Any.keypadLength();
            var keypad = new Keypad(width, height);
            Assert.AreEqual(width*height, keypad.MaxValue);
        }

        [Test]
        public void initialize_with_correct_number_arrangement()
        {
            int width = Any.keypadLength();
            int height = Any.keypadLength();
            var keypad = new Keypad(width, height);
            Assert.AreEqual(width * height-1, keypad.getValue(new Coordinate(width-2, height-1)));
        }


        [Test]
        public void read_coordinate_value()
        {
            int width = Any.keypadLength();
            int height = Any.keypadLength();
            var keypad = new Keypad(width, height);
            Assert.AreEqual(1, keypad.getValue(new Coordinate(0, 0)));
            Assert.AreEqual(width * height, keypad.getValue(new Coordinate(width - 1, height - 1)));
        }

        [Test]
        public void return_neg_one_when_invalid_coordinate()
        {
            int width = Any.keypadLength();
            int height = Any.keypadLength();
            var keypad = new Keypad(width, height);
            Assert.AreEqual(-1, keypad.getValue(new Coordinate(width, height - 1)));
            Assert.AreEqual(-1, keypad.getValue(new Coordinate(width - 1, height)));
        }
    }
}
