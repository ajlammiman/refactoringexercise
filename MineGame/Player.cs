using System;

namespace MineGame
{
    public interface IPlayer
    {
        Position CurrentPosition { get; }
        void ChangePosition(Position newPosition);
        bool IsAlive { get; }
        int Lives { get; }
        void LoseALife();
    }
    public class Player : IPlayer
    {
        private Position position;
        public int Lives { get; private set; }
        public Position CurrentPosition { get; private set; }

        public Player(Position start, int lives)
        {
            CurrentPosition = start;
            Lives = lives;
        }

        public void ChangePosition(Position newPosition)
        {
            CurrentPosition = newPosition;
        }

        public void LoseALife()
        {
            Lives--;
        }

        public bool IsAlive => Lives > 0;

    }
}
