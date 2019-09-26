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
        public Tuple<int, int, bool, bool>[] Squares { get; private set; }

        public Board(IEnumerable<Tuple<int, int, bool, bool>> squares)
        {
            Squares = squares.ToArray();
        }

        public bool IsCompleted(KeyValuePair<int, int> position)
        {
            return Squares.Where(s => s.Item1 == position.Key && s.Item2 == position.Value).Single().Item3;
        }
              
        public bool IsValidMove(KeyValuePair<int, int> position)
        {
            return Squares.Any(s => s.Item1.Equals(position.Value));
        }

        public bool HasMine(KeyValuePair<int,int> newPosition)
        {
            return Squares.Any(s => s.Item1 == newPosition.Key && s.Item2 == newPosition.Value && s.Item4);
        }
    }
}
