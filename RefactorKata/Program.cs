using System;
using System.Collections.Generic;

namespace MineGameConsole
{
    public class Program
    {
        public static void Main()
        {
            var game = new ConsoleGame(10, 10, 5, new KeyValuePair<int, int>(1, 1), new KeyValuePair<int, int>(10, 10), 3);

            Console.WriteLine(game.Start());

            string choice;
            do
            {
                choice = Console.ReadKey(true).Key.ToString().ToLower();
                switch(choice)
                {
                    case "w":
                        Console.WriteLine(game.Change("up"));
                        break;
                    case "x":
                        Console.WriteLine(game.Change("down"));
                        break;
                    case "a":
                        Console.WriteLine(game.Change("left"));
                        break;
                    case "s":
                        Console.WriteLine(game.Change("right"));
                        break;
                }
            }
            while (choice != "q");
        }
    }
}
