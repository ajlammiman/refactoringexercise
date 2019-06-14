using System;

namespace MineGame
{
    public enum MoveState
    {
        Valid,
        Invalid,
        Mined
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

            if (validMove)
                player.ChangePosition(newPosition);


            return (validMove) ? MoveState.Valid : MoveState.Invalid;
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
