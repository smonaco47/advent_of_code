using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLibrary
{
    public static class Utilities
    {
        public static List<string> Transpose(List<string> originalList)
        {
            var length = originalList[0].Length;
            var newList = new List<string>() {Capacity= length};
            for (int i = 0; i < length; i++ ) newList.Add("");
            foreach (var item in originalList)
            {
                if (item.Length != length) throw new InvalidDataException();
                for (int i = 0; i < length; i++)
                {
                    newList[i] = newList[i] + item[i];
                }
            }
            return newList;
        }

        public static bool IsPalendrome(string input, bool allowRepeats = true)
        {
            if (input.Length % 2 != 0) return false;
            var previous = ' ';
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - 1 - i]) return false;
                if (input[i] == previous && !allowRepeats) return false;
                previous = input[i];
            }
            return true;
        }

        public static bool ContainsPalendrome(string input, int slidingScale, bool allowRepeats = true)
        {
            for (int i = 0; i < input.Length - slidingScale + 1; i++ )
                if (IsPalendrome(input.Substring(i, slidingScale), allowRepeats)) return true;
            return false;
        }
    }
}
