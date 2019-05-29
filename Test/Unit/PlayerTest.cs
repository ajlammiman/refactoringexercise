using MineGame;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    class PlayerTest
    {
       
        [Test]
        public void change_position()
        {
            var startPosition = new Position(1, 1);
            var endPosition = new Position(2, 2);

            var player = new Player(startPosition,1);

            Assert.That(player.CurrentPosition, Is.EqualTo(startPosition));

            player.ChangePosition(endPosition);

            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void has_lives()
        {
            int lives = 3;
            var player = new Player(new Position(1,1), lives);

            Assert.That(player.IsAlive, Is.EqualTo(true));
        }

        [Test]
        public void has_no_lives()
        {
            int lives = 0;
            var player = new Player(new Position(1, 1), lives);

            Assert.That(player.IsAlive, Is.EqualTo(false));
        }

    }
}
