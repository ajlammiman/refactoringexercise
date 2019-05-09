using NSubstitute;
using NUnit.Framework;

namespace MineGame
{
    [TestFixture]
    class GameTest
    {
        [Test]
        public void a_player_can_move_up()
        {
            var x = 2;
            var y = 2;
            var position = new Position(x, y);
            var board = Substitute.For<IBoard>();
            var player = new Player();

            var game = new Game(board, player);
            
            game.MoveUp();

            Assert.That(player.CurrentPosition.X, Is.EqualTo(position.X));
            Assert.That(player.CurrentPosition.Y, Is.EqualTo(position.Y));
        }

    }
}
