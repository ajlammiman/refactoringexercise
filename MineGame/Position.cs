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

        public override int GetHashCode()
        {
            var hashCode = -317897967;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            return hashCode;
        }
    }
}