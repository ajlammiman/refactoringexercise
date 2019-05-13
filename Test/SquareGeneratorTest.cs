using MineGame;
using NUnit.Framework;
using System.Linq;

namespace Test
{
    [TestFixture]
    class SquareGeneratorTest
    {
        [Test]
        public void number_of_y_axis_squares_equal_to_seed_value()
        {
            var yLength = 8;
            var squares = SquareGenerator.Generate(1, yLength);

            Assert.That(squares.Select(s => s.Position.Y).Count(), Is.EqualTo(yLength));
        }

        [Test]
        public void number_of_x_axis_squares_equal_to_seed_value()
        {
            var xLength = 8;
            var squares = SquareGenerator.Generate(xLength, 1);

            Assert.That(squares.Select(s => s.Position.X).Count(), Is.EqualTo(xLength));
        }
    }
}
