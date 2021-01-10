using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    [TestFixture]
    class Game_should_
    {
        private Game BuildGame (int playerCount)
        {
            var players = new IPlayer[playerCount];
            for (int i = 0; i < playerCount; i++)
            {
                var newPlayer = new Mock<IPlayer>();
                newPlayer.Setup(x => x.IsInGame()).Returns(true);
                players[i] = (newPlayer.Object);
            }
            return new Game(players);
        }

        [Test]
        public void initialize_with_players()
        {
            var game = BuildGame(2);
            Assert.AreEqual(2, game.TotalPlayers);
        }

        [Test]
        public void get_current_player_position()
        {
            var game = BuildGame(2);
            Assert.AreEqual(1, game.CurrentPlayer);
        }

        [Test]
        public void check_player_is_in_game_when_advancing()
        {
            var player1 = new Mock<IPlayer>();
            player1.Setup(x => x.IsInGame()).Returns(true);
            var player2 = new Mock<IPlayer>();
            player2.Setup(x => x.IsInGame()).Returns(false);
            var player3 = new Mock<IPlayer>();
            player3.Setup(x => x.IsInGame()).Returns(true);

            var game = new Game(new [] { player1.Object, player2.Object, player3.Object });

            game.AdvanceToNextPlayer();
            Assert.AreEqual(3, game.CurrentPlayer);
        }

        [Test]
        public void advance_to_next_player()
        {
            var game = BuildGame(2);
            game.AdvanceToNextPlayer();
            Assert.AreEqual(2, game.CurrentPlayer);
        }

        [Test]
        public void single_player_wins_the_game()
        {
            var game = BuildGame(1);
            game.Run();
            Assert.AreEqual(1, game.Winner);
        }
        
        [Test]
        public void remove_next_active_player()
        {
            var player1 = new Mock<IPlayer>();
            player1.Setup(x => x.IsInGame()).Returns(true);
            var player2 = new Mock<IPlayer>();
            player2.Setup(x => x.IsInGame()).Returns(true);
            var player3 = new Mock<IPlayer>();
            player3.Setup(x => x.IsInGame()).Returns(true);

            var game = new Game(new [] { player1.Object, player2.Object, player3.Object });

            game.ExecuteTurn();
            player2.Verify(x => x.RemoveFromGame(), Times.Once);
        }
    }
}
