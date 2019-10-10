using System;
using System.Collections.Generic;
using System.Linq;

namespace MineGameConsole
{
    public enum MoveState
    {
        Valid,
        Mined
    }
    public class ConsoleGame
    {
        public readonly Tuple<int, int, bool, bool>[] board;
        public KeyValuePair<int, int> position { get; set; }
        public int Lives { get; set; }
        public ConsoleGame(int xLength, int yLength, int mines, KeyValuePair<int, int> start, KeyValuePair<int, int> finish, int lives)
        {
            this.board = Build(xLength, yLength, mines, finish);
            position = start;
            Lives = lives;
        }

        public string NewMakeAMove(string move)
        {
            var moveState = MoveState.Valid;
            var newPosition = new KeyValuePair<int, int>();

            if (move == "right")
            {
                newPosition = new KeyValuePair<int, int>(position.Key + 1, position.Value);
            }
            else if (move == "left")
            {
                newPosition = new KeyValuePair<int, int>(position.Key - 1, position.Value);
            }
            else if (move == "down")
            {
                newPosition = new KeyValuePair<int, int>(position.Key, position.Value - 1);
            }
            else if (move == "up")
            {
                newPosition = new KeyValuePair<int, int>(position.Key, position.Value + 1);
            }

            var mined = board.Any(s => s.Item1 == newPosition.Key && s.Item2 == newPosition.Value && s.Item4);

            if (mined)
                moveState = MoveState.Mined;

            if (moveState == MoveState.Valid || moveState == MoveState.Mined)
                position = newPosition;

            if (moveState == MoveState.Mined)
                Lives--;

            return MoveMessage(moveState, move);
        }


        private MoveState MakeAMove(KeyValuePair<int, int> newPosition)
        {
            var moveState = MoveState.Valid;

            var mined = board.Any(s => s.Item1 == newPosition.Key && s.Item2 == newPosition.Value && s.Item4);

            if (mined)
                moveState = MoveState.Mined;

            if (moveState == MoveState.Valid || moveState == MoveState.Mined)
                position = newPosition;

            if (moveState == MoveState.Mined)
                Lives--;

            return moveState;
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
            var playerPosition = $"Square {position.Key},{position.Value}";
            string messsage;

            if (moveState == MoveState.Mined && Lives > 0)
                messsage = $"You have moved one square {direction} and hit a mine, your new position is {playerPosition} and your number of lives is {Lives}";
            else if (moveState == MoveState.Mined && Lives == 0)
                messsage = "You have lost your last life, GAME OVER!";
            else if ((moveState == MoveState.Mined || moveState == MoveState.Valid) && Lives > 0 && board.Where(s => s.Item1 == position.Key && s.Item2 == position.Value).Single().Item3)
                messsage = "Game completed. Congratulations, you've won!";
            else
                messsage = $"You have moved one square {direction}, your new position is {playerPosition}";

            return messsage;
        }
    }
}