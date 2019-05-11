using System;
using System.Collections.Generic;
using System.Linq;

namespace MineGame
{
    public interface IBoard
    {
        bool IsValidMove(Position position);
    }

    public class Board : IBoard
    {
        public ISquare[] squares { get; private set; }

        public Board(IEnumerable<ISquare> squares)
        {
            this.squares = squares.ToArray();
        }

        public bool IsValidMove(Position position)
        {
            return squares.Any(s => s.Position.Equals(position));
        }
    }
}
