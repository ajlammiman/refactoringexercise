using System.Collections.Generic;

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
        KeyValuePair<int, int> PlayerPosition { get; }
        bool Completed();
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
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key, currentPosition.Value + 1);

            return MakeAMove(newPosition);
        }

        public MoveState MoveDown()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key, currentPosition.Value - 1);

            return MakeAMove(newPosition);
        }

        public MoveState MoveLeft()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key - 1, currentPosition.Value);

            return MakeAMove(newPosition);
        }

        public MoveState MoveRight()
        {
            var currentPosition = player.CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key + 1, currentPosition.Value);

            return MakeAMove(newPosition);
        }

        private MoveState MakeAMove(KeyValuePair<int,int> newPosition) {
            
            var moveState = CalculateMoveState(newPosition);

            if (moveState == MoveState.Valid || moveState == MoveState.Mined)
                player.ChangePosition(newPosition);

            if (moveState == MoveState.Mined)
                LoseALife();

            return moveState;
        }

        private MoveState CalculateMoveState(KeyValuePair<int,int> newPosition)
        {
            var moveState = MoveState.Valid;

            var mined = board.HasMine(newPosition);

            if (mined)
                moveState = MoveState.Mined;

            return moveState;
        }

        private void LoseALife() => player.LoseALife();


        public int LivesLeft => player.Lives;

        public new KeyValuePair<int, int> PlayerPosition => player.CurrentPosition;

        public bool Completed() => board.IsCompleted(player.CurrentPosition);
        
    }
}
