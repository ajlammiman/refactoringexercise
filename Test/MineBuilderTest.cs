using MineGame;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Test
{
    [TestFixture]
    class MineBuilderTest
    {
        private const int xMax = 5;
        private const int yMax = 4;
        private const int mines = 9;

        [Test]
        public void position_coordinates_are_always_generated_less_than_or_equal_to_max()
        {
            var minePosition = MineBuilder.Generate(xMax, yMax, mines);

            Assert.That(minePosition.All(m => m.X <= xMax), Is.True);
            Assert.That(minePosition.All(m => m.Y <= yMax), Is.True);
        }

        [Test]
        public void number_of_mines_generated_are_equal_to_mine_count()
        {
            var positions = MineBuilder.Generate(xMax, yMax, mines);
            Assert.That(positions.Length, Is.EqualTo(mines));
        }


    }
}
