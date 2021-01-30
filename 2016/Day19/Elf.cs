using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    class Elf : IPlayer
    {
        public Elf()
        {
            HasGift = true;
        }

        public bool HasGift { get; private set; }

        public bool IsInGame()
        {
            return HasGift;
        }

        public void RemoveFromGame()
        {
            HasGift = false;
        }

        internal void ClearGifts()
        {
            HasGift = false;
        }

        internal void StealGifts(Elf source)
        {
            source.ClearGifts();
        }
    }
}
