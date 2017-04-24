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
    }
}
