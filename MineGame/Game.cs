using System;

namespace MineGame
{
    public class Game
    {
        private readonly IBoard board;
        private readonly IPlayer player;

        public Game()
        {
        }

        public Game(IBoard board, IPlayer player)
        {
            this.board = board;
            this.player = player;
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }
    }
}
