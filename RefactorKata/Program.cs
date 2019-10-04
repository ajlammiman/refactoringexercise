using System;
using System.Collections.Generic;

namespace MineGameConsole
{
    public class Program
    {
        public static void Main()
        {
            var consoleGame = new ConsoleGame(10, 10, 5, new KeyValuePair<int, int>(1, 1), new KeyValuePair<int, int>(10, 10), 3);

            Console.WriteLine(consoleGame.Start());

            string choice;
            do
            {
                choice = Console.ReadKey(true).Key.ToString().ToLower();
                switch(choice)
                {
                    case "w":
                        Console.WriteLine(consoleGame.Up());
                        break;
                    case "x":
                        Console.WriteLine(consoleGame.Down());
                        break;
                    case "a":
                        Console.WriteLine(consoleGame.Left());
                        break;
                    case "s":
                        Console.WriteLine(consoleGame.Right());
                        break;
                }
            }
            while (choice != "q");
        }
    }
}
