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

            return MakeAMove(newPosition);
        }

        public MoveState MoveDown()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X, currentPosition.Y - 1);

            return MakeAMove(newPosition);
        }

        public MoveState MoveLeft()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X - 1, currentPosition.Y);

            return MakeAMove(newPosition);
        }

        public MoveState MoveRight()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new Position(currentPosition.X + 1, currentPosition.Y);

            return MakeAMove(newPosition);
        }

        private MoveState MakeAMove(Position newPosition) {
            
            var moveState = CalculateMoveState(newPosition);

            if (moveState == MoveState.Valid || moveState == MoveState.Mined)
                player.ChangePosition(newPosition);

            if (moveState == MoveState.Mined)
                LoseALife();

            return moveState;
        }

        private MoveState CalculateMoveState(Position newPosition)
        {
            var moveState = MoveState.Invalid;

            var validMove = board.IsValidMove(newPosition);
            var mined = board.HasMine(newPosition);

            if (validMove && !mined)
                moveState = MoveState.Valid;
            else if (mined)
                moveState = MoveState.Mined;
            
            return moveState;
        }

        private void LoseALife() => player.LoseALife();


        public int LivesLeft => player.Lives;

        public Position PlayerPosition => player.CurrentPosition;

        public bool Completed() => board.IsCompleted(player.CurrentPosition);
        
    }
}
