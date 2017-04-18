using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLibrary.Path
{
    public class Keypad
    {
        private string[,] _keys;

        public Keypad() : this(3, 3)
        {
        }

        public Keypad(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this.MaxValue = width * height;
            var value = 1;
            _keys = new string[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    _keys[j, i] = (value++).ToString();
                }
            }
        }

        public int Width { get; }
        public int Height { get; }
        public int MaxValue { get; }

        public string getValue(Coordinate point)
        {
            if (point.X < 0 || point.Y < 0) return "";
            if (point.X < Width && point.Y < Height)
            {
                return _keys[point.X, point.Y];
            }
            return "";
        }

        public static Keypad DiamondKeypad()
        {
            var keypad = new Keypad(5,5);
            keypad._keys = new string[5, 5]
            {
                {"", "", "5", "", ""},
                {"", "2", "6", "A", ""},
                {"1", "3", "7", "B", "D"},
                {"", "4", "8", "C", ""},
                {"", "", "9", "", ""}
            };
            return keypad;
        }

        public void PrintKeypad()
        {
            var sb = new StringBuilder();
            for (int y = 0; y < this.Height; y++)
            {
                for (int x = 0; x < this.Width; x++)
                {
                    sb.Append(_keys[x, y]);
                }
                Console.WriteLine(sb);
                sb.Clear();
            }
        }

    }

}
