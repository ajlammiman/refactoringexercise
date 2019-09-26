using System.Collections.Generic;

namespace MineGame
{
    public class Square
    {
        public KeyValuePair<int, int> Position { get; private set; }
        public bool Completed { get; private set; }

        public bool IsMined { get; private set; }

        public Square(KeyValuePair<int, int> position, bool completed = false, bool mined = false)
        {
            Position = position;
            Completed = completed;
            IsMined = mined;
        }
    }
}
