using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCodeLibrary
{
    public class IpAddress
    {
        private List<string> allSequences;
        private List<string> sequences;
        private List<string> hypernetSequences;
        private const int WINDOW_SIZE = 4;

        public IpAddress(string input)
        {
            this.Address = input;
            sequences = new List<string>();
            hypernetSequences = new List<string>();
            allSequences = new List<string>();
            parseTls();
        }

        public string Address { get; }

        public bool SupportsTls
        {
            get
            {
                foreach (var item in hypernetSequences)
                {

                    if (Utilities.ContainsPalendrome(item, WINDOW_SIZE, false)) return false;
                }
                foreach (var item in sequences)
                {

                    if (Utilities.ContainsPalendrome(item, WINDOW_SIZE, false)) return true;
                }
                return false;
            }
        }

        private void parseTls()
        {
            allSequences = Address.Replace('[', '*').Replace(']','*').Split(new []{ '*' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = 0; i < allSequences.Count; i++)
            {
                if ( i % 2 == 0) sequences.Add(allSequences[i]);
                else hypernetSequences.Add(allSequences[i]);
            }
        }
    }
}
