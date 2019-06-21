namespace MineGame
{
    public interface ISquare
    {
        Position Position { get;  }
        bool Completed { get; }

    }

    public class Square : ISquare
    {
        public Position Position { get; private set; }
        public bool Completed { get; private set; }

        public Square(Position position, bool completed = false)
        {
            Position = position;
            Completed = completed;
        }
    }
}
