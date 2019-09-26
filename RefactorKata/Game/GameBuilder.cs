using System;
using System.Collections.Generic;
using System.Linq;
using MineGame;

namespace MineGameConsole
{ 
    public class GameBuilder
    {
        ConsoleGame consoleGame;

        public GameBuilder(int xLength, int yLength, int mines, KeyValuePair<int, int> start, KeyValuePair<int, int> finish, int lives)
        {
            var board = Build(xLength, yLength, mines, finish);
            var player = new Player(start, lives);
            var game = new Game(board,player);
            consoleGame = new ConsoleGame(game);
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
                    var p = new KeyValuePair<int, int>(x,y);
                    squares.Add(new Tuple<int, int, bool, bool>(p.Key, p.Value, isCompleted, isMined));
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
