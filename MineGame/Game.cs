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
        public KeyValuePair<int, int> CurrentPosition { get; set; }
        int Lives { get; set; }

        public Game(Tuple<int, int, bool, bool>[] board, KeyValuePair<int, int> start, int lives)
        {
            this.board = board;
            CurrentPosition = start;
            Lives = lives;
        }

        public MoveState MoveUp()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key, currentPosition.Value + 1);

            return MakeAMove(newPosition);
        }

        public MoveState MoveDown()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key, currentPosition.Value - 1);

            return MakeAMove(newPosition);
        }

        public MoveState MoveLeft()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key - 1, currentPosition.Value);

            return MakeAMove(newPosition);
        }

        public MoveState MoveRight()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key + 1, currentPosition.Value);

            return MakeAMove(newPosition);
        }

        private MoveState MakeAMove(KeyValuePair<int,int> newPosition) {
            
            var moveState = CalculateMoveState(newPosition);

            if (moveState == MoveState.Valid || moveState == MoveState.Mined)
                ChangePosition(newPosition);

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

        private void LoseALife() => Lives--;


        public int LivesLeft => Lives;

        public new KeyValuePair<int, int> PlayerPosition => CurrentPosition;

        public bool Completed() => board.Where(s => s.Item1 == CurrentPosition.Key && s.Item2 == CurrentPosition.Value).Single().Item3;

        public void ChangePosition(KeyValuePair<int, int> newPosition)
        {
            CurrentPosition = newPosition;
        }
    }
}
