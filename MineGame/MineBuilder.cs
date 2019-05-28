using System;
using System.Collections.Generic;
using System.Linq;

namespace MineGame
{
    public class MineBuilder
    {
        public static Position[] Generate(int xLength, int yLength, int mines)
        {
            var minePositions = new List<Position>();
            var positions = generateAllPositions(xLength, yLength);
            var rnd = new Random();
            var mineIds = positions.Select(p => p.Key).OrderBy(o => rnd.Next(positions.Count)).Take(mines).ToArray();
            minePositions = positions.Where(p => mineIds.Contains(p.Key)).Select(p => p.Value).ToList();

            return minePositions.ToArray();
        }

        private static Dictionary<int, Position> generateAllPositions(int xLength, int yLength)
        {
            var positions = new Dictionary<int, Position>();
            var positionCount = 0;

            for (int y = 1; y <= yLength; y++)
                for (int x = 1; x <= xLength; x++)
                {
                    positions.Add(positionCount, new Position(x, y, true));
                    positionCount++;
                }

            return positions;
        }

    }
}
