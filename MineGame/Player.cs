using System;

namespace MineGame
{
    public interface IPlayer
    {
        Position CurrentPosition { get; }
        void ChangePosition(Position newPosition);
    }
    public class Player : IPlayer
    {
        public Position CurrentPosition { get; private set; }
        public Player(Position start)
        {
            CurrentPosition = start;
        }

        public void ChangePosition(Position newPosition)
        {
            CurrentPosition = newPosition;
        }
    }
}
