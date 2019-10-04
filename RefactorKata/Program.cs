﻿using MineGame;
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
                        Console.WriteLine(consoleGame.MoveUp());
                        break;
                    case "x":
                        Console.WriteLine(consoleGame.MoveDown());
                        break;
                    case "a":
                        Console.WriteLine(consoleGame.MoveLeft());
                        break;
                    case "s":
                        Console.WriteLine(consoleGame.MoveRight());
                        break;
                }
            }
            while (choice != "q");
        }
    }
}
