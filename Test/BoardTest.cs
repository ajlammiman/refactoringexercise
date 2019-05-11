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
            var squares = new List<Square>() { new Square(new Position(1,1)), new Square(new Position(2,2)) };
            var board = new Board(squares);

            Position position = new Position(2,2);
            var valid = board.IsValidMove(position);

            Assert.IsTrue(valid);
        }

        [Test]
        public void board_confirms_if_move_is_invalid()
        {
            var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(2, 2)) };
            var board = new Board(squares);

            Position position = new Position(3, 3);
            var valid = board.IsValidMove(position);

            Assert.IsFalse(valid);
        }
    }
}
