using System;
using System.Collections.Generic;
using System.Linq;
using MineGame;

namespace MineGameConsole
{
    public class ConsoleGame
    {
        private readonly Tuple<int, int, bool, bool>[] board;
        public KeyValuePair<int, int> CurrentPosition { get; set; }
        int Lives { get; set; }
        public ConsoleGame(int xLength, int yLength, int mines, KeyValuePair<int, int> start, KeyValuePair<int, int> finish, int lives)
        {
            this.board = Build(xLength, yLength, mines, finish);
            CurrentPosition = start;
            Lives = lives;
        }

        public string MoveUp()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key, currentPosition.Value + 1);

            var moveState = MakeAMove(newPosition);
            return MoveMessage(moveState, "up");
        }

        public string MoveDown()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key, currentPosition.Value - 1);

            var moveState = MakeAMove(newPosition);
            return MoveMessage(moveState, "down");
        }

        public string MoveLeft()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key - 1, currentPosition.Value);

            var moveState = MakeAMove(newPosition);

            return MoveMessage(moveState, "left");
        }

        public string MoveRight()
        {
            var currentPosition = CurrentPosition;
            var newPosition = new KeyValuePair<int, int>(currentPosition.Key + 1, currentPosition.Value);

            var moveState = MakeAMove(newPosition);

            return MoveMessage(moveState, "right");
        }

        private MoveState MakeAMove(KeyValuePair<int, int> newPosition)
        {
             var moveState = CalculateMoveState(newPosition);

            if (moveState == MoveState.Valid || moveState == MoveState.Mined)
                ChangePosition(newPosition);

            if (moveState == MoveState.Mined)
                LoseALife();

            return moveState;
        }

        private MoveState CalculateMoveState(KeyValuePair<int, int> newPosition)
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

        public static Tuple<int, int, bool, bool>[] Build(int length1, int length2, int number, KeyValuePair<int, int> completedPosition)
        {
            var pm = new Dictionary<int, KeyValuePair<int, int>>();
            var counter = 0;

            for (int y = 1; y <= length2; y++)
            {
                for (int x = 1; x <= length1; x++)
                {
                    pm.Add(counter, new KeyValuePair<int, int>(x, y));
                    counter++;
                }
            }
            var r = new Random();
            var mineIds = pm.Select(p => p.Key).OrderBy(o => r.Next(pm.Count)).Take(number).ToArray();

            var mines = pm.Where(p => mineIds.Contains(p.Key)).Select(p => p.Value).ToList();

            var squares = new List<Tuple<int, int, bool, bool>>();

            for (int y = 1; y <= length2; y++)
            {
                for (int x = 1; x <= length1; x++)
                {
                    var isMined = mines.Where(m => m.Equals(new KeyValuePair<int, int>(x, y))).Any();
                    var isCompleted = (completedPosition.Key == x && completedPosition.Value == y) ? true : false;
                    var p = new KeyValuePair<int, int>(x, y);
                    squares.Add(new Tuple<int, int, bool, bool>(p.Key, p.Value, isCompleted, isMined));
                }
            }
            return squares.ToArray();
        }

        public string Start()
        {
            return "Welcome to the Mine Game, try to cross the board without hitting a Mine. W = Up, X = down, A = left and S = right.";
        }

        
        private string MoveMessage(MoveState moveState, string direction)
        {
            var playerPosition = $"Square {PlayerPosition.Key},{PlayerPosition.Value}";
            string messsage;

            if (moveState == MoveState.Invalid)
                messsage = "This move is not allowed, you will move off the board.";
            else if (moveState == MoveState.Mined && LivesLeft > 0)
                messsage = $"You have moved one square {direction} and hit a mine, your new position is {playerPosition} and your number of lives is {LivesLeft}";
            else if (moveState == MoveState.Mined && LivesLeft == 0)
                messsage = "You have lost your last life, GAME OVER!";
            else if ((moveState == MoveState.Mined || moveState == MoveState.Valid) && LivesLeft > 0 && Completed())
                messsage = "Game completed. Congratulations, you've won!";
            else
                messsage = $"You have moved one square {direction}, your new position is {playerPosition}";

            return messsage;
        }
    }
}