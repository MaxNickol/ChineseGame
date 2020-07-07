using System;
using System.Security.Cryptography.X509Certificates;

namespace ChineseGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game game = new Game();
            Player pl = new Player();
            AIPLayer ai = new AIPLayer();

            Console.WriteLine("How many sticks do you want to play?");

            game.Sticks = int.Parse(Console.ReadLine());

            Console.WriteLine($"{game.Sticks} sticks left.");

            game.GameStatus = GameStatus.InProgress;

            int moveCounter = 1;

            while (game.GameStatus == GameStatus.InProgress)
            {
                if (moveCounter % 2 == 0)
                {
                    int parsed = 0;

                    game.RegisterOnMoveDelegate(new Game.MoveDelegate(ai.Turn));

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("The turn of the computer");

                    //using delegate to store the move of the AI;
                    Game._del(game, parsed);
                    Console.WriteLine($"{ai.Move}");
                    Console.WriteLine($"{game.Sticks} sticks left.");
                    Console.ResetColor();

                    if (game.Sticks <= 0)
                    {
                        game.GameStatus = GameStatus.End;
                        Console.WriteLine($"{game.GameStatus}");
                        Console.WriteLine($"The Player won!");
                        break;
                    }
                    moveCounter++;
                }
                else
                {
                    Console.WriteLine($"Player {pl.ID} it is your turn");
                    int parsedPl = int.Parse(Console.ReadLine());

                    //creating delegate to store the methods of turn;
                    game.RegisterOnMoveDelegate(new Game.MoveDelegate(pl.Turn));
                    Game._del(game, parsedPl);

                    if (parsedPl < 1 || parsedPl > 3)
                    {
                        while (parsedPl < 1 || parsedPl > 3)
                        {
                            Console.WriteLine("You should input only from 1 to 3");
                            parsedPl = int.Parse(Console.ReadLine());
                        }
                    }

                    Console.WriteLine($"{game.Sticks} sticks left.");
                    if (game.Sticks <= 0)
                    {
                        game.GameStatus = GameStatus.End;
                        Console.WriteLine($"{game.GameStatus}");
                        Console.WriteLine("Computer won!");
                        break;
                    }
                    moveCounter++;
                }
            }
        }
    }
}