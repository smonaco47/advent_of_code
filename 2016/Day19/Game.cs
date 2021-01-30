using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day19
{
    internal class Game
    {
        public Game(IPlayer [] players)
        {
            CurrentPlayer = 1;
            Players = players;
        }

        public int TotalPlayers {
            get
            {
                return Players.Length;
            }
        }

        public int CurrentPlayer { get; private set; } 

        private int CurrentPlayerIndex
        {
            get
            {
                return CurrentPlayer - 1;
            }
        }

        internal IPlayer[] Players { get; set; }
        public int Winner { get; private set; }

        internal virtual void AdvanceToNextPlayer()
        {
            var next = GetNextActivePlayer();
            if (next == CurrentPlayer) Winner = CurrentPlayer;
            else CurrentPlayer = next;
        }

        private int GetNextActivePlayer()
        {
            int player = NextPlayer(CurrentPlayer);
            while (!Players[player- 1].IsInGame() && player != CurrentPlayer)
                player = NextPlayer(player);
            return player;
        }

        private int NextPlayer(int currentPlayer)
        {
            return currentPlayer % TotalPlayers + 1;
        }

        internal virtual void ExecuteTurn()
        {
            int nextPlayer = GetNextActivePlayer();
            Players[nextPlayer-1].RemoveFromGame();
            AdvanceToNextPlayer();
        }
        
        internal virtual void Run()
        {
            while (Winner == 0)
            {
                ExecuteTurn();
            }
        }
    }
}
