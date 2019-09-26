using System;
using System.Collections.Generic;
using System.Linq;

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
        private readonly Tuple<int, int, bool, bool>[] board;
        private readonly IPlayer player;


        public Game(Tuple<int, int, bool, bool>[] board, IPlayer player)
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

            var mined = board.Any(s => s.Item1 == newPosition.Key && s.Item2 == newPosition.Value && s.Item4);

            if (mined)
                moveState = MoveState.Mined;

            return moveState;
        }

        private void LoseALife() => player.LoseALife();


        public int LivesLeft => player.Lives;

        public new KeyValuePair<int, int> PlayerPosition => player.CurrentPosition;

        public bool Completed() => board.Where(s => s.Item1 == player.CurrentPosition.Key && s.Item2 == player.CurrentPosition.Value).Single().Item3;
        
    }
}
