using MineGame;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    class BoardTest
    {
        [Test]
        public void board_confirms_if_move_is_valid()
        {
            var squares = new List<Square>() { new Square(new Position(1,1)), new Square(new Position(1,2)) };
            var board = new Board(squares);

            Position position = new Position(1,2);
            var valid = board.IsValidMove(position);

            Assert.IsTrue(valid);
        }

        [Test]
        public void board_confirms_if_move_is_invalid()
        {
            var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(1, 2)) };
            var board = new Board(squares);

            Position position = new Position(3, 3);
            var valid = board.IsValidMove(position);

            Assert.IsFalse(valid);
        }

        [Test]
        public void squares_on_board_must_follow_numerical_sequence_on_x_axis()
        {
            string message = "";

            try
            {
                var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(5, 1)), new Square(new Position(3, 1)) };
                var board = new Board(squares);
            }
            catch(System.Exception e)
            {
                message = e.Message;
            }
            Assert.AreEqual("Board cannot be created, x axis squares not in sequence", message);
        }

        [Test]
        public void squares_on_board_must_follow_numerical_sequence_on_y_axis()
        {
            string message = "";

            try
            {
                var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(2, 1)), new Square(new Position(1, 2)), new Square(new Position(2, 3)) };
                var board = new Board(squares);
            }
            catch (System.Exception e)
            {
                message = e.Message;
            }
            Assert.AreEqual("Board cannot be created, y axis squares not in sequence", message);
        }
    }
}
