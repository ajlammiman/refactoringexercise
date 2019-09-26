using System;
using System.Collections.Generic;
using System.Linq;

namespace MineGame
{
    public interface IBoard
    {
        bool IsValidMove(KeyValuePair<int, int> position);
        bool HasMine(KeyValuePair<int, int> newPosition);
        bool IsCompleted(KeyValuePair<int, int> position);
    }

    public class Board : IBoard
    {
        public Square[] Squares { get; private set; }

        public Board(IEnumerable<Square> squares)
        {
            Squares = squares.ToArray();
        }

        public bool IsCompleted(KeyValuePair<int, int> position)
        {
            return Squares.Where(s => s.Position.Key == position.Key && s.Position.Value == position.Value).Single().Completed;
        }
              
        public bool IsValidMove(KeyValuePair<int, int> position)
        {
            return Squares.Any(s => s.Position.Equals(position));
        }

        public bool HasMine(KeyValuePair<int,int> newPosition)
        {
            return Squares.Any(s => s.Position.Key == newPosition.Key && s.Position.Value == newPosition.Value && s.IsMined);
        }
    }
}
