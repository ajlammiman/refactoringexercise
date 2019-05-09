using System;

namespace MineGame
{
    public interface IPlayer
    {

    }
    public class Player : IPlayer
    {
        public Position CurrentPosition { get; private set; }
        public Player()
        {
        }

    }
}
