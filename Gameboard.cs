using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Gameboard
    {
        public Gameboard() { }

        /// <summary>
        ///        |       |
        ///    -   |   -   |   -
        ///        |       |
        /// -------|-------|-------
        ///        |       |
        ///    -   |   -   |   -
        ///        |       |
        /// -------|-------|-------
        ///        |       |
        ///    -   |   -   |   -
        ///        |       |
        ///
        /// builds the gameboard. It looks like this at the start of the game.
        /// </summary>
        /// <param name="gameboard"></param>
        public void DrawBoard(char[,] gameboard, (int, int) position)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (j == position.Item2 && i == position.Item1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("       ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    if (j != 2)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }

                for (int k = 0; k < 3; k++)
                {
                    if (k == position.Item2 && i == position.Item1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("   ");
                        Console.Write(gameboard[i, k]);
                        Console.Write("   ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("   ");
                        Console.Write(gameboard[i, k]);
                        Console.Write("   ");
                    }
                    if (k != 2)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }

                for (int l = 0; l < 3; l++)
                {
                    if (l == position.Item2 && i == position.Item1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write("       ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("       ");
                    }
                    if (l != 2)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.WriteLine();
                    }
                }

                if (i != 2)
                {
                    Console.WriteLine("-------|-------|-------");
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        public void BillBoard(Player[] players)
        {
            Console.WriteLine("Scoreboard");
            Console.WriteLine("----------");
            Console.WriteLine($"{players[0].GetName()}: {players[0].GetScore()}");
            Console.WriteLine($"{players[1].GetName()}: {players[1].GetScore()}");
        }

        public void ControlInstructions()
        {
            Console.WriteLine("WASD or Arrow keys to move the red selection");
            Console.WriteLine("Press Enter to place your sign");
            Console.WriteLine("Press numpad or number keys to select respective fields");
        }

        public void AnnounceWinner(Player player, bool multipleRounds)
        {
            if (multipleRounds == false)
            {
                Console.WriteLine($"{player.GetName()} won the game!");
                Console.WriteLine("Game over! Press a key to return to main menu.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine(
                    $"{player.GetName()} won the game with {player.GetScore()} points!"

                );
            }
            
        }

        public void AnnounceDraw()
        {
            Console.WriteLine("Draw!");
            Console.WriteLine("Game over! Press a key to return to main menu.");
            Console.ReadLine();
        }

        public void WhoseTurn(Player player)
        {
            Console.WriteLine($"{player.GetName()}'s turn");
        }

        internal void AnnounceGameWinner(Player[] players)
        {
            throw new NotImplementedException();
        }
    }
}
