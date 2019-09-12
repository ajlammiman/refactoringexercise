namespace MineGame
{
    public class Square
    {
        public Position Position { get; private set; }
        public bool Completed { get; private set; }

        public bool IsMined { get; private set; }

        public Square(Position position, bool completed = false, bool mined = false)
        {
            Position = position;
            Completed = completed;
            IsMined = mined;
        }
    }
}
