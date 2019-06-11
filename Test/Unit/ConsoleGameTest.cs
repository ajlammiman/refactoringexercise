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
        private string startMessage;
        private const string expectedStartMessage = "Welcome to the Mine Game, try to cross the board without hitting a Mine. W = Up, X = down, A = left and S = right.";
        private const string expectedRightMessage = "You have moved one square right, your new position is Square 1,2";
        private const string expectedFailureMessage = "This move is not allowed, you will move off the board.";
        private const string expectedLifeLostMessage = "You have moved one square right and hit a mine, your new position is Square 1,2 and your number of lives is 1";
        private IGame game = Substitute.For<IGame>();

        [Test]
        public void when_beginning_game_start_message_is_displayed()
        {
            consoleGame = new ConsoleGame(game);
            startMessage = consoleGame.Start();

            Assert.AreEqual(startMessage, expectedStartMessage);
        }

        [Test]
        public void when_making_a_move_right_right_move_message_is_displayed()
        {
            var game = Substitute.For<IGame>();
            game.MoveRight().Returns(true);

            consoleGame = new ConsoleGame(game);

            string rightMessage = consoleGame.MoveRight();
            Assert.AreEqual(rightMessage, expectedRightMessage);
        }

        [Test]
        public void when_making_an_invalid_move_right_then_failure_message_is_displayed()
        {
            var game = Substitute.For<IGame>();
            game.MoveRight().Returns(false);

            consoleGame = new ConsoleGame(game);

            string rightMessage = consoleGame.MoveRight();
            Assert.AreEqual(rightMessage, expectedFailureMessage);
        }

        [Ignore("")]
        [Test]
        public void when_making_a_move_to_a_square_with_a_mines_a_life_is_lost()
        {
            var game = Substitute.For<IGame>();
            game.MoveRight().Returns(true);

            consoleGame = new ConsoleGame(game);

            string rightMessage = consoleGame.MoveRight();

            Assert.AreEqual(rightMessage, expectedLifeLostMessage);
        }
    }

}
