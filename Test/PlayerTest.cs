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

            var player = new Player(startPosition);

            Assert.That(player.CurrentPosition, Is.EqualTo(startPosition));

            player.ChangePosition(endPosition);

            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }
    }
}
