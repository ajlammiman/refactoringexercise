using MineGame;
using MineGameConsole;
using NSubstitute;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    class ConsoleGameTest
    {
        private ConsoleGame consoleGame;
        private IGame game = Substitute.For<IGame>();

        [Test]
        public void when_beginning_game_start_message_is_displayed()
        {
            consoleGame = new ConsoleGame(game);
            var message = consoleGame.Start();

            Assert.AreEqual(message, "Welcome to the Mine Game, try to cross the board without hitting a Mine. W = Up, X = down, A = left and S = right.");
        }

        [Test]
        [TestCase("up")]
        [TestCase("down")]
        [TestCase("left")]
        [TestCase("right")]
        public void when_making_a_move_valid_move_correct_message_is_displayed(string direction)
        {
            var game = Substitute.For<IGame>();
            game.MoveRight().Returns(MoveState.Valid);
            game.MoveLeft().Returns(MoveState.Valid);
            game.MoveUp().Returns(MoveState.Valid);
            game.MoveDown().Returns(MoveState.Valid);

            game.PlayerPosition.Returns(new Position(1, 2));

            consoleGame = new ConsoleGame(game);
            string message = "";

            switch (direction)
            {
                case "up":
                    message = consoleGame.MoveUp();
                    game.Received().MoveUp();
                    break;
                case "down":
                    message = consoleGame.MoveDown();
                    game.Received().MoveDown();
                    break;
                case "left":
                    message = consoleGame.MoveLeft();
                    game.Received().MoveLeft();
                    break;
                case "right":
                    message = consoleGame.MoveRight();
                    game.Received().MoveRight();
                    break;
            }

            Assert.AreEqual(message, $"You have moved one square {direction}, your new position is Square 1,2");
        }

        [Test]
        public void when_making_an_invalid_move_then_correct_failure_message_is_displayed()
        {
            var game = Substitute.For<IGame>();
            game.MoveRight().Returns(MoveState.Invalid);
            game.PlayerPosition.Returns(new Position(1, 2));

            consoleGame = new ConsoleGame(game);

            string message = consoleGame.MoveRight();
            Assert.AreEqual(message, "This move is not allowed, you will move off the board.");
        }

         [Test]
        public void when_making_a_move_to_a_square_with_a_mines_a_life_is_lost()
        {
            var game = Substitute.For<IGame>();
            game.MoveRight().Returns(MoveState.Mined);
            game.LivesLeft.Returns(1);
            game.PlayerPosition.Returns(new Position(1, 2));

            consoleGame = new ConsoleGame(game);

            string message = consoleGame.MoveRight();

            Assert.AreEqual(message, "You have moved one square right and hit a mine, your new position is Square 1,2 and your number of lives is 1");
        }

        [Test]
        public void when_last_life_is_lost_game_is_over()
        {
            var game = Substitute.For<IGame>();
            game.MoveRight().Returns(MoveState.Mined);
            game.LivesLeft.Returns(0);
            game.PlayerPosition.Returns(new Position(1, 2));

            consoleGame = new ConsoleGame(game);
            string message = consoleGame.MoveRight();

            Assert.AreEqual(message, "You have lost your last life, GAME OVER!");
        }
    }

}
