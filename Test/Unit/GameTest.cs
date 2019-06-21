using MineGame;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    class GameTest
    {
        private const int lives = 1;

        [Test]
        public void a_player_can_move_up_one_space()
        {
            var startPosition = new Position(1, 1);
            var player = new Player(startPosition, lives);

            var squares = GridBuilder.Build(1, 2, 0, new Position(1, 1));
            var board = new Board(squares);

            var game = new Game(board, player);

            var move = game.MoveUp();
            var endPosition = new Position(1, 2);

            Assert.AreEqual(move, MoveState.Valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_down_one_space()
        {
            var startPosition = new Position(1, 2);
            var endPosition = new Position(1, 1);
            var squares = GridBuilder.Build(1, 2, 0, new Position(1, 2));

            var board = new Board(squares);
            var player = new Player(startPosition, lives);

            var game = new Game(board, player);

            var move = game.MoveDown();

            Assert.AreEqual(move, MoveState.Valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_left_one_space()
        {
            var startPosition = new Position(2, 1);
            var endPosition = new Position(1, 1);
            var squares = GridBuilder.Build(2, 1, 0, new Position(2, 1));

            var board = new Board(squares);
            var player = new Player(startPosition, lives);

            var game = new Game(board, player);

            var move = game.MoveLeft();

            Assert.AreEqual(move, MoveState.Valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_right_one_space()
        {
            var startPosition = new Position(1, 1);
            var endPosition = new Position(2, 1);
            var squares = GridBuilder.Build(2, 1, 0, new Position(1, 1));

            var board = new Board(squares);
            var player = new Player(startPosition, lives);

            var game = new Game(board, player);

            var move = game.MoveRight();

            Assert.AreEqual(move, MoveState.Valid);
            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_cannot_move_off_the_board()
        {
            var squares = GridBuilder.Build(1, 1, 0, new Position(1, 1));
            var board = new Board(squares);

            var playerStart = new Position(1, 1);
            var player = new Player(playerStart, lives);

            var game = new Game(board, player);

            var move = game.MoveRight();

            Assert.AreEqual(move, MoveState.Invalid);
            Assert.That(player.CurrentPosition, Is.EqualTo(playerStart));
        }

        [Test]
        public void a_player_cannot_move_to_a_space_less_than_start_space()
        {
            var squares = GridBuilder.Build(1, 1, 0, new Position(1, 1));
            var board = new Board(squares);

            var playerStart = new Position(1, 1);
            var player = new Player(playerStart, lives);

            var game = new Game(board, player);

            var move = game.MoveLeft();

            Assert.AreEqual(move, MoveState.Invalid);
            Assert.That(player.CurrentPosition, Is.EqualTo(playerStart));
        }

        [Test]
        public void a_player_moves_to_mined_square_loses_a_life()
        {
            var squares = GridBuilder.Build(2, 1, 2, new Position(1, 1));
            var board = new Board(squares);

            var playerStart = new Position(1, 1);
            
            var player = new Player(playerStart,lives);

            var game = new Game(board, player);

            var move = game.MoveRight();

            Assert.AreEqual(move, MoveState.Invalid);
            Assert.That(game.LivesLeft, Is.EqualTo(lives - 1));
        }

        [Test]
        public void a_player_moves_to_game_completed_square_completes_game()
        {
            var squares = GridBuilder.Build(2, 1, 0, new Position(2,1));
            var board = new Board(squares);

            var playerStart = new Position(1, 1);

            var player = new Player(playerStart, lives);

            var game = new Game(board, player);

            var move = game.MoveRight();

            Assert.AreEqual(move, MoveState.Completed);
        }
    }
}
