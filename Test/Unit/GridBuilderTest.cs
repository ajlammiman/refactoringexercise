using MineGame;
using NUnit.Framework;
using System;
using System.Linq;

namespace Test
{
    [TestFixture]
    class GridBuilderTest
    {
        private const int YLength = 8;
        private const int XLength = 8;

        [Test]
        public void y_axis_squares_in_grid_equal_to_seed_value()
        {
            var squares = GridBuilder.Build(1, YLength);

            Assert.That(squares.Select(s => s.Position.Y).Count(), Is.EqualTo(YLength));
        }

        [Test]
        public void x_axis_squares_in_grid_equal_to_seed_value()
        {
            var squares = GridBuilder.Build(XLength, 1);

            Assert.That(squares.Select(s => s.Position.X).Count(), Is.EqualTo(XLength));
        }

        [Test]
        public void x_and_y_values_must_be_greater_than_zero()
        {
            string message = "";
            try
            {
                GridBuilder.Build(0, 0);
            }
            catch(Exception e)
            {
                message = e.Message;
            }

            Assert.That(message, Is.EqualTo("X and Y values must be greater than 0."));
        }

        [Test]
        public void cannot_create_more_mines_than_squares_on_the_grid()
        {
            string message = "";
            try
            {
                GridBuilder.Build(2, 2, 9);
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            Assert.That(message, Is.EqualTo("There are more mines than squares on the grid."));
        }
        
    }
}
