﻿using System.Collections.Generic;
using System.Linq;

namespace MineGame
{
    public static class GridBuilder
    {
        public static Square[] Build(int xLength, int yLength, int mines, Position completedPosition)
        {
            Validate(xLength, yLength, mines);

            var minePositions = MineBuilder.Generate(xLength, yLength, mines);
            var squares = new List<Square>();

            for (int y = 1; y <= yLength; y++)
                for (int x = 1; x <= xLength; x++)
                {
                    var isMined = minePositions.Where(m => m.Equals(new Position(x, y, true))).Any();
                    var isCompleted = (completedPosition.X == x && completedPosition.Y == y) ? true : false;

                    squares.Add(new Square(new Position(x, y, isMined), isCompleted));
                }
            return squares.ToArray();
        }

        private static void Validate(int xLength, int yLength, int mines)
        {
            if (xLength <= 0 || yLength <= 0)
                throw new System.Exception("X and Y values must be greater than 0.");

            if ((xLength * yLength) < mines)
                throw new System.Exception("There are more mines than squares on the grid.");

        }
    }
}
