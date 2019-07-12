using System;
using System.Collections.Generic;
using System.Linq;

namespace MineGame
{
    public interface IBoard
    {
        bool IsValidMove(Position position);
        bool HasMine(Position newPosition);
        bool IsCompleted(Position position);
    }

    public class Board : IBoard
    {
        public ISquare[] Squares { get; private set; }

        public Board(IEnumerable<ISquare> squares)
        {
            Squares = squares.ToArray();
            ValidateBoard(Squares);
        }

        private void ValidateBoard(ISquare[] squares)
        {
            var ySequence = squares.Select(s => s.Position.Y).Distinct().ToArray();
            var checkSequence = Enumerable.Range(1, ySequence.Count()).ToArray();

            for (int i = 0; i < ySequence.Max(); i++)
            {
                if (i > ySequence.Length || ySequence[i] != checkSequence[i])
                    throw new Exception("Board cannot be created, y axis squares not in sequence");

                ValidateXAxis(squares, ySequence[i]);
            }

        }

        public bool IsCompleted(Position position)
        {
            return Squares.Where(s => s.Position.X == position.X && s.Position.Y == position.Y).Single().Completed;
        }

        private static void ValidateXAxis(ISquare[] squares, int y)
        {
            var xSequence = squares.Where(s => s.Position.Y == y).Select(s => s.Position.X).Distinct().ToArray();
            var checkSequence = Enumerable.Range(1, xSequence.Count()).ToArray();

            for (int i = 0; i < xSequence.Max(); i++)
                if (i > xSequence.Length || xSequence[i] != checkSequence[i])
                    throw new Exception("Board cannot be created, x axis squares not in sequence");
        }

        public bool IsValidMove(Position position)
        {
            return Squares.Any(s => s.Position.Equals(position));
        }

        public bool HasMine(Position newPosition)
        {
            return Squares.Any(s => s.Position.Equals(newPosition) && s.IsMined);
        }
    }
}
