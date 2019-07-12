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
            var squares = GridBuilder.Build(1, YLength, 0, new Position(1, 1));

            Assert.That(squares.Select(s => s.Position.Y).Count(), Is.EqualTo(YLength));
        }

        [Test]
        public void x_axis_squares_in_grid_equal_to_seed_value()
        {
            var squares = GridBuilder.Build(XLength, 1, 0, new Position(1, 1));

            Assert.That(squares.Select(s => s.Position.X).Count(), Is.EqualTo(XLength));
        }

        [Test]
        public void x_and_y_values_must_be_greater_than_zero()
        {
            string message = "";
            try
            {
                GridBuilder.Build(0, 0, 0, new Position(0, 0));
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
                GridBuilder.Build(2, 2, 9, new Position(1, 1));
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            Assert.That(message, Is.EqualTo("There are more mines than squares on the grid."));
        }

        [Test]
        public void grid_contains_a_game_completed_square()
        {
            var completedPosition = new Position(1, 1);
            var squares = GridBuilder.Build(1, 1, 0, completedPosition);

            Assert.That(squares.Where(s => s.Position.Equals(completedPosition)).Single().Completed, Is.True);
        }

        [Test]
        public void completed_square_cannot_be_off_the_board()
        {
            string message = "";
            try
            {
                GridBuilder.Build(1, 1, 0, new Position(2, 2));
            }
            catch (Exception e)
            {
                message = e.Message;
            }

            Assert.That(message, Is.EqualTo("The completed square must be valid."));
        }

        [Test]
        public void grid_contains_all_mined_squares()
        {
            var mines = 3;
            var squares = GridBuilder.Build(5, 5, mines, new Position(2, 2));

            Assert.That(squares.Where(s => s.IsMined).Count, Is.EqualTo(mines));
        }

    }
}
