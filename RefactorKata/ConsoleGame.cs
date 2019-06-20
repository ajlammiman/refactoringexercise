using System;
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

        public string MoveUp()
        {
            var moveState = game.MoveUp();
            return MoveMessage(moveState, "up");
        }
        public string MoveDown()
        {
            var moveState = game.MoveDown();
            return MoveMessage(moveState, "down");
        }
        public string MoveLeft()
        {
            var moveState = game.MoveLeft();
            return MoveMessage(moveState, "left");
        }
        public string MoveRight()
        {
            var moveState = game.MoveRight();
            return MoveMessage(moveState, "right");
        }

        private string MoveMessage(MoveState moveState, string direction)
        {
            var playerPosition = $"Square {game.PlayerPosition.X},{game.PlayerPosition.Y}";

            switch (moveState)
            {
                case MoveState.Invalid:
                    return "This move is not allowed, you will move off the board.";
                case MoveState.Mined:
                    return (game.LivesLeft > 0) ? $"You have moved one square {direction} and hit a mine, your new position is {playerPosition} and your number of lives is {game.LivesLeft}" : "You have lost your last life, GAME OVER!";
                default:
                    return $"You have moved one square {direction}, your new position is {playerPosition}";
            }
        }
    }
}