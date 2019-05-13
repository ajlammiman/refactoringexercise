using MineGame;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    class GameTest
    {
        [Test]
        public void a_player_can_move_up_one_space()
        {
            var startPosition = new Position(1, 1);
            var player = new Player(startPosition);

            var squares = SquareGenerator.Generate(1,2);
            var board = new Board(squares);

            var game = new Game(board, player);
            
            var valid = game.MoveUp();
            var endPosition = new Position(1, 2);

            Assert.IsTrue(valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_down_one_space()
        {
            var startPosition = new Position(1, 2);
            var endPosition = new Position(1, 1);
            var squares = SquareGenerator.Generate(1, 2);

            var board = new Board(squares);
            var player = new Player(startPosition);

            var game = new Game(board, player);

            var valid = game.MoveDown();

            Assert.IsTrue(valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_left_one_space()
        {
            var startPosition = new Position(2, 1);
            var endPosition = new Position(1, 1);
            var squares = SquareGenerator.Generate(2, 1);

            var board = new Board(squares);
            var player = new Player(startPosition);

            var game = new Game(board, player);

            var valid = game.MoveLeft();

            Assert.IsTrue(valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_right_one_space()
        {
            var startPosition = new Position(1, 1);
            var endPosition = new Position(2, 1);
            var squares = SquareGenerator.Generate(2, 1);

            var board = new Board(squares);
            var player = new Player(startPosition);

            var game = new Game(board, player);

            var valid = game.MoveRight();

            Assert.IsTrue(valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_cannot_move_off_the_board()
        {
            var squares = SquareGenerator.Generate(1, 1);
            var board = new Board(squares);

            var playerStart = new Position(1, 1);
            var player = new Player(playerStart);

            var game = new Game(board, player);

            var valid = game.MoveRight();

            Assert.IsFalse(valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(playerStart));
        }

        [Test]
        public void a_player_cannot_move_to_a_space_less_than_start_space()
        {
            var squares = SquareGenerator.Generate(1, 1);
            var board = new Board(squares);

            var playerStart = new Position(1, 1);
            var player = new Player(playerStart);

            var game = new Game(board, player);

            var valid = game.MoveLeft();

            Assert.IsFalse(valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(playerStart));
        }
    }
}
