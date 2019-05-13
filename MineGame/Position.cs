namespace MineGame
{
    public class Position
    {

        public int X { get; set; }
        public int Y { get; set; }
        public readonly bool IsMined;

        public Position(int x, int y, bool isMined = false)
        {
            X = x;
            Y = y;
            IsMined = isMined;
        }

        public override bool Equals(object that)
        {
            return that is Position position && X == position.X && Y == position.Y && IsMined == position.IsMined;
        }

        public override int GetHashCode()
        {
            var hashCode = -317897967;
            hashCode = hashCode * -1521134295 + X.GetHashCode();
            hashCode = hashCode * -1521134295 + Y.GetHashCode();
            hashCode = hashCode * -1521134295 + IsMined.GetHashCode();
            return hashCode;
        }
    }
}