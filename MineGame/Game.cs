using System;

namespace MineGame
{
    public interface IGame
    {
        bool MoveDown();
        bool MoveLeft();
        bool MoveRight();
        bool MoveUp();
        int LivesLeft { get; }
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

            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        public bool MoveDown()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y - 1);

            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        public bool MoveLeft()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X - 1, currentPosition.Y);

            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        public bool MoveRight()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X + 1, currentPosition.Y);
            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        private bool MakeAMove(Position newPosition)
        {
            var validMove = board.IsValidMove(newPosition);

            if (validMove)
                player.ChangePosition(newPosition);

            return validMove;
        }

        private void CheckMined(Position newPosition)
        {
            if (board.HasMine(newPosition))
                player.LoseALife();
        }

        
        public int LivesLeft => player.Lives;
    }
}
