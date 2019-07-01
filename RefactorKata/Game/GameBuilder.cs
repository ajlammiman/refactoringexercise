using MineGame;

namespace MineGameConsole
{ 
    public class GameBuilder
    {
        private ConsoleGame consoleGame { get; set; }

        public GameBuilder(int xLength, int yLength, int mines, Position start, Position finish, int lives)
        {
            var squares = GridBuilder.Build(xLength, yLength,mines,finish);
            var board = new Board(squares);
            var player = new Player(start, lives);
            var game = new Game(board,player);
            consoleGame = new ConsoleGame(game);
        }

        public ConsoleGame Build()
        {
            return consoleGame;
        }
    }
}
