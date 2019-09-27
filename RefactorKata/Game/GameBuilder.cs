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
            var game = new Game(xLength, yLength, mines, finish, start, lives);
            consoleGame = new ConsoleGame(game);
        }

        public ConsoleGame Build()
        {
            return consoleGame;
        }
    }
}
