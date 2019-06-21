using System;

namespace MineGame
{
    public enum MoveState
    {
        Valid,
        Invalid,
        Mined,
        Completed
    }

    public interface IGame
    {
        MoveState MoveDown();
        MoveState MoveLeft();
        MoveState MoveRight();
        MoveState MoveUp();
        int LivesLeft { get; }
        Position PlayerPosition { get; }
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

        public MoveState MoveUp()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y + 1);

            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        public MoveState MoveDown()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y - 1);

            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        public MoveState MoveLeft()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X - 1, currentPosition.Y);

            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        public MoveState MoveRight()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X + 1, currentPosition.Y);
            CheckMined(newPosition);

            return MakeAMove(newPosition);
        }

        private MoveState MakeAMove(Position newPosition)
        {
            var validMove = board.IsValidMove(newPosition);
            var moveState = (validMove) ? MoveState.Valid : MoveState.Invalid;

            if (validMove)
            {
                player.ChangePosition(newPosition);
                moveState = (board.IsCompleted(newPosition)) ? MoveState.Completed : moveState;
            }

            return moveState;
        }

        private void CheckMined(Position newPosition)
        {
            if (board.HasMine(newPosition))
                player.LoseALife();
        }

        
        public int LivesLeft => player.Lives;

        public Position PlayerPosition => player.CurrentPosition;
    }
}
