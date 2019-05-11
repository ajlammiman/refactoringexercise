﻿using MineGame;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace Test
{
    [TestFixture]
    class GameTetst
    {
        [Test]
        public void a_player_can_move_up_one_space()
        {
            var startPosition = new Position(1, 1);
            var endPosition = new Position(1, 2);
            var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(1, 2)) };

            var board = new Board(squares);
            var player = new Player(startPosition);

            var game = new Game(board, player);
            
            game.MoveUp();

            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }


        [Test]
        public void a_player_can_move_down_one_space()
        {
            var startPosition = new Position(1, 2);
            var endPosition = new Position(1, 1);
            var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(1, 2)) };

            var board = new Board(squares);
            var player = new Player(startPosition);

            var game = new Game(board, player);

            game.MoveDown();

            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_left_one_space()
        {
            var startPosition = new Position(2, 1);
            var endPosition = new Position(1, 1);
            var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(1, 2)) };

            var board = new Board(squares);
            var player = new Player(startPosition);

            var game = new Game(board, player);

            game.MoveLeft();

            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_can_move_right_one_space()
        {
            var startPosition = new Position(1, 1);
            var endPosition = new Position(2, 1);
            var squares = new List<Square>() { new Square(new Position(1, 1)), new Square(new Position(2, 1)) };

            var board = new Board(squares);
            var player = new Player(startPosition);

            var game = new Game(board, player);

            game.MoveRight();

            Assert.That(player.CurrentPosition, Is.EqualTo(endPosition));
        }

        [Test]
        public void a_player_cannot_move_off_the_board()
        {
            var squares = new List<Square>() { new Square(new Position(1, 1)) };
            var board = new Board(squares);

            var playerStart = new Position(1, 1);
            var player = new Player(playerStart);

            var game = new Game(board, player);

            game.MoveRight();

            Assert.That(player.CurrentPosition, Is.EqualTo(playerStart));
        }
    }
}
