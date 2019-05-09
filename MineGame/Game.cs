using System;

namespace MineGame
{
    public interface IGame
    {
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void MoveUp();
    }

    public class Game : IGame
    {
        private readonly IBoard board;
        private readonly IPlayer player;


        public Game(IBoard board, IPlayer player)
        {
            this.board = board;
            this.player = player;
        }

        public void MoveUp()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y + 1);
            player.ChangePosition(newPosition);
        }


        public void MoveDown()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y - 1);
            player.ChangePosition(newPosition);
        }

        public void MoveLeft()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X - 1, currentPosition.Y);
            player.ChangePosition(newPosition);
        }

        public void MoveRight()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X + 1, currentPosition.Y);
            player.ChangePosition(newPosition);
        }
    }
}
