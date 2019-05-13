using System.Collections.Generic;

namespace MineGame
{
    public static class SquareGenerator
    {
        public static Square[] Generate(int xLength, int yLength)
        {
            var squares = new List<Square>();

            for (int y = 1; y <= yLength; y++)
                for (int x = 1; x <= xLength; x++)
                    squares.Add(new Square(new Position(x, y)));
                
            return squares.ToArray(); 
        }
    }
}
