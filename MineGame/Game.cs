using System;

namespace MineGame
{
    public interface IGame
    {
        bool MoveDown();
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
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

        public bool MoveUp()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y + 1);
            var validMove = board.IsValidMove(newPosition);

            if (validMove)
                player.ChangePosition(newPosition);

            return validMove;
        }


        public bool MoveDown()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y - 1);
            var validMove = board.IsValidMove(newPosition);

            if (validMove)
                player.ChangePosition(newPosition);

            return validMove;
        }

        public bool MoveLeft()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X - 1, currentPosition.Y);
            var validMove = board.IsValidMove(newPosition);

            if (validMove)
                player.ChangePosition(newPosition);

            return validMove;
        }

        public bool MoveRight()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X + 1, currentPosition.Y);
            var validMove = board.IsValidMove(newPosition);

            if (validMove)
                player.ChangePosition(newPosition);

            return validMove;
        }
    }
}
