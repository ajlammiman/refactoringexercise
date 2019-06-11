using MineGame;

namespace MineGameConsole
{
    public class ConsoleGame
    {
        private IGame game;

        public ConsoleGame(IGame game)
        {
            this.game = game;
        }

        public string Start()
        {
            return "Welcome to the Mine Game, try to cross the board without hitting a Mine. W = Up, X = down, A = left and S = right.";
        }

        public string MoveRight()
        {
            var valid = game.MoveRight();

            return (valid) ? "You have moved one square right, your new position is Square 1,2" : "This move is not allowed, you will move off the board.";
        }
    }
}