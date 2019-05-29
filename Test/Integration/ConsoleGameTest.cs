using MineGameConsole;
using NUnit.Framework;
using System;
using System.IO;

namespace Test
{
    [TestFixture]
    class ConsoleGameTest
    {
        private const string startMessage = "Your starting position is square 1,1. W is up, Z is up, A is left and S is right, where too next?";

        [Test]
        public void when_beginning_game_start_message_is_displayed()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var consoleGame = new ConsoleGame();
                consoleGame.Start();

                Assert.AreEqual(sw.ToString().Trim(), startMessage);
            }
        }
    }
}
