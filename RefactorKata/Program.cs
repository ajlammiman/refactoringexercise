﻿using MineGame;
using System;
using System.Collections.Generic;

namespace MineGameConsole
{
    public class Program
    {
        public static void Main()
        {
            var consoleGame = new GameBuilder(10, 10, 5, new KeyValuePair<int, int>(1, 1), new KeyValuePair<int, int>(10, 10), 3).Build();

            Console.WriteLine(consoleGame.Start());

            ConsoleKey choice;
            do
            {
                choice = Console.ReadKey(true).Key;
                switch(choice)
                {
                    case ConsoleKey.W:
                        Console.WriteLine(consoleGame.MoveUp());
                        break;
                    case ConsoleKey.X:
                        Console.WriteLine(consoleGame.MoveDown());
                        break;
                    case ConsoleKey.A:
                        Console.WriteLine(consoleGame.MoveLeft());
                        break;
                    case ConsoleKey.S:
                        Console.WriteLine(consoleGame.MoveRight());
                        break;
                }
            }
            while (choice != ConsoleKey.Escape);
        }
    }
}
