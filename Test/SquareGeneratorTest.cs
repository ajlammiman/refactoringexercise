using MineGame;
using NUnit.Framework;
using System.Linq;

namespace Test
{
    [TestFixture]
    class SquareGeneratorTest
    {
        private const int YLength = 8;
        private const int XLength = 8;
        private const int Mines = 8;

        [Test]
        public void number_of_y_axis_squares_equal_to_seed_value()
        {
            var squares = GridBuilder.Build(1, YLength);

            Assert.That(squares.Select(s => s.Position.Y).Count(), Is.EqualTo(YLength));
        }

        [Test]
        public void number_of_x_axis_squares_equal_to_seed_value()
        {
            var squares = GridBuilder.Build(XLength, 1);

            Assert.That(squares.Select(s => s.Position.X).Count(), Is.EqualTo(XLength));
        }

        [Test]
        public void number_of_mines_on_board_equals_seed_value()
        {
            var mines = 9;
            var squares = GridBuilder.Build(XLength, YLength, mines);

            Assert.That(squares.Where(s => s.Position.IsMined).Count(), Is.EqualTo(mines));
        }
    }
}
