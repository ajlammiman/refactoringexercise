using System;
using System.Collections.Generic;

namespace MineGame
{
    public interface IPlayer
    {
        KeyValuePair<int, int> CurrentPosition { get; }
        void ChangePosition(KeyValuePair<int, int> newPosition);
        bool IsAlive { get; }
        int Lives { get; }
        void LoseALife();
    }
    public class Player : IPlayer
    {
        public int Lives { get; private set; }
        public KeyValuePair<int, int> CurrentPosition { get; private set; }

        public Player(KeyValuePair<int, int> start, int lives)
        {
            CurrentPosition = start;
            Lives = lives;
        }

        public void ChangePosition(KeyValuePair<int, int> newPosition)
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
