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
            Assert.IsTrue(MakeAMove(1,2, new Position(1,2)));
        }

        [Test]
        public void board_confirms_if_move_is_invalid()
        {
            Assert.IsFalse(MakeAMove(2, 1, new Position(3, 3)));
        }

        private bool MakeAMove(int xLength, int yLength, Position checkPosition)
        {
            var squares = GridBuilder.Build(xLength, yLength);

            var board = new Board(squares);

            return board.IsValidMove(checkPosition);
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
