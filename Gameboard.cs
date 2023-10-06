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
    }
}
