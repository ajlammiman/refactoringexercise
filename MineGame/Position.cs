namespace MineGame
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object that)
        {
            return that is Position position && X == position.X && Y == position.Y;
        }

        
    }
}