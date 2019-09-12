using System;
using System.Collections.Generic;
using System.Linq;
using MineGame;

namespace MineGameConsole
{ 
    public class GameBuilder
    {
        private ConsoleGame consoleGame { get; set; }

        public GameBuilder(int xLength, int yLength, int mines, Position start, Position finish, int lives)
        {
            var squares = Build(xLength, yLength,mines,finish);
            var board = new Board(squares);
            var player = new Player(start, lives);
            var game = new Game(board,player);
            consoleGame = new ConsoleGame(game);
        }

        public static Square[] Build(int length1, int length2, int number, Position completedPosition)
        {
            var pm = new Dictionary<int, Position>();
            var counter = 0;

            for (int y = 1; y <= length2; y++)
            {
                for (int x = 1; x <= length1; x++)
                {
                    pm.Add(counter, new Position(x, y));
                    counter++;
                }
            }
            var r = new Random();
            var mineIds = pm.Select(p => p.Key).OrderBy(o => r.Next(pm.Count)).Take(number).ToArray();

            var mines = pm.Where(p => mineIds.Contains(p.Key)).Select(p => p.Value).ToList();

            var squares = new List<Square>();

            for (int y = 1; y <= length2; y++)
            {
                for (int x = 1; x <= length1; x++)
                {
                    var isMined = mines.Where(m => m.Equals(new Position(x, y))).Any();
                    var isCompleted = (completedPosition.X == x && completedPosition.Y == y) ? true : false;

                    squares.Add(new Square(new Position(x, y), isCompleted, isMined));
                }
            }
            return squares.ToArray();
        }


        public ConsoleGame Build()
        {
            return consoleGame;
        }
    }
}
