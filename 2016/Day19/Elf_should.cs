using NUnit.Framework;

namespace Day19
{
    [TestFixture]
    class Elf_should
    {
        [Test]
        public void intialize_with_gift()
        {
            var elf = new Elf();
            Assert.True(elf.HasGift);
        }

        [Test]
        public void mark_gift_stolen()
        {
            var elf = new Elf();
            elf.ClearGifts();
            Assert.False(elf.HasGift);
        }

        [Test]
        public void steal_gift_from_another_elf()
        {
            var target = new Elf();
            var source = new Elf();
            target.StealGifts(source);
            Assert.False(source.HasGift);
            Assert.True(target.HasGift);
        }

        [Test]
        public void leave_the_game_when_no_gifts()
        {
            var elf = new Elf();
            elf.RemoveFromGame();
            Assert.False(elf.IsInGame());
        }

        [Test]
        public void be_in_game_when_have_gift()
        {
            var elf = new Elf();

            Assert.True(elf.HasGift);
            Assert.True(elf.IsInGame());
        }
        
    }
}
