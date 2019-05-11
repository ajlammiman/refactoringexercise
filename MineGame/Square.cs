namespace MineGame
{
    public interface ISquare
    {
        Position Position { get;  }
    }

    public class Square : ISquare
    {
        public Position Position { get; private set; }

        public Square(Position position)
        {
            Position = position;
        }
    }
}
