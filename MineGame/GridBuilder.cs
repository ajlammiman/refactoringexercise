using System.Collections.Generic;
using System.Linq;

namespace MineGame
{
    public static class GridBuilder
    {
        public static Square[] Build(int xLength, int yLength, int mines = 0)
        {
            if (xLength <= 0 || yLength <= 0)
                throw new System.Exception("X and Y values must be greater than 0.");

            var squares = new List<Square>();

            for (int y = 1; y <= yLength; y++)
                for (int x = 1; x <= xLength; x++)
                {
                    var isMined = (squares.Select(s => s.Position.IsMined).Count() < mines) ? true : false;

                    squares.Add(new Square(new Position(x, y, isMined)));
                }
            return squares.ToArray(); 
        }
    }
}
