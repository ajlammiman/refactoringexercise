using MineGame;
using MineGameConsole;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    class ConsoleGameTest
    {
        private ConsoleGame consoleGame;
        
        [Test]
        public void when_beginning_game_start_message_is_displayed()
        {
            consoleGame = buildGame(1,1, new KeyValuePair<int, int>(0,0), new KeyValuePair<int, int>(2, 2), 0, 1, false);
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
            consoleGame = buildGame(3, 3, new KeyValuePair<int, int>(2,2), new KeyValuePair<int, int>(3, 3), 0, 1, false);
            string message = "";
            string expectedMessage = "";
            
            switch (direction)
            {
                case "up":
                    message = consoleGame.MoveUp();
                    expectedMessage = $"You have moved one square {direction}, your new position is Square 2,3";
                    break;
                case "down":
                    message = consoleGame.MoveDown();
                    expectedMessage = $"You have moved one square {direction}, your new position is Square 2,1";
                    break;
                case "left":
                    message = consoleGame.MoveLeft();
                    expectedMessage = $"You have moved one square {direction}, your new position is Square 1,2";
                    break;
                case "right":
                    message = consoleGame.MoveRight();
                    expectedMessage = $"You have moved one square {direction}, your new position is Square 3,2";
                    break;
            }

            Assert.AreEqual(expectedMessage, message);
        }

        


        [Test]
        public void when_making_an_invalid_move_then_correct_failure_message_is_displayed()
        {
            consoleGame = buildGame(1, 1, new KeyValuePair<int, int>(1, 1), new KeyValuePair<int, int>(2, 2), 0, 1, false);

            try
            {
                string message = consoleGame.MoveRight();
            }
            catch(Exception e)
            {
                Assert.AreEqual(e.Message, "Sequence contains no elements");
            }
        }

         [Test]
        public void when_making_a_move_to_a_square_with_a_mine_a_life_is_lost()
        {
            consoleGame = buildGame(2, 2, new KeyValuePair<int, int>(1, 2), new KeyValuePair<int, int>(4, 4), 4, 2, false);

            string message = consoleGame.MoveRight();

            Assert.AreEqual("You have moved one square right and hit a mine, your new position is Square 2,2 and your number of lives is 1", message);
        }

        [Test]
        public void when_last_life_is_lost_game_is_over()
        {
            consoleGame = buildGame(2, 2, new KeyValuePair<int, int>(1, 2), new KeyValuePair<int, int>(2, 2), 4, 1, false);

            string message = consoleGame.MoveRight();

            Assert.AreEqual(message, "You have lost your last life, GAME OVER!");
        }

        [Test]
        public void when_destination_reached_game_is_won()
        {
            consoleGame = buildGame(2, 2, new KeyValuePair<int, int>(1, 2), new KeyValuePair<int, int>(2, 2), 0, 1, true);
            string message = consoleGame.MoveRight();

            Assert.AreEqual(message, "Game completed. Congratulations, you've won!");

        }

        private ConsoleGame buildGame(int xLength, int yLength, KeyValuePair<int, int> start, KeyValuePair<int, int> finish, int mines, int lives, bool completed)
        {
            var game = new Game(xLength, yLength, mines, finish, start, lives);
            return new ConsoleGame(game);
        }
    }

}
