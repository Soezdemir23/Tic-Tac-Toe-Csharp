using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Tic_Tac_Toe
{
    internal class Logic
    {
        Player[] Players { get; set; }
        int rounds { get; set; } = 0;
        bool multipleRounds { get; set; } = false;

        Gameboard board { get; set; }
        private bool secondPlayerTurn { get; set; } = false;

        (int, int) position { get; set; } = (1, 1);
        private char[,] playfield { get; set; } =
            new char[3, 3]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            };


        public Logic(Player[] players, Gameboard gameboard, bool multirounds)
        {
            if (multirounds == true) multipleRounds = true;
            Console.Clear();
            Players = players;
            board = gameboard;
            Player winner = new Player('µ', "a") ;
            while (true) // this loop is unimportant until we start using multiple rounds.
            {
                while (true)
                {
                    if (multipleRounds == true)
                    {
                        Console.WriteLine($"{players[0].GetName()} VS {players[1].GetName()}");
                        Console.WriteLine($"\tRound {rounds}");
                    }

                    gameboard.DrawBoard(playfield, position);
                    Console.WriteLine(
                        "Choose WASD or Arrow keys to choose the field and press enter."
                    );
                    Console.WriteLine("Also you can use the numpad or numbers or even the mouse!");
                    GetInput();
                    Console.Clear();
                    gameboard.DrawBoard(playfield, position);
                    if (CheckForWin(players[0]) == true)
                    {
                       winner = AnnounceWinner(players[0]);
                        break;
                    }
                    // the 2nde plyer is a bot and the player1 didn't get it into a draw yet.
                    if (Players[1].GetIsBot() == true && IsDraw() == false) // can be easily circumvented in a hotseat game, bleh
                    {
                        Random random = new Random();
                        while (true)
                        {
                            int x = random.Next(0, 3);
                            int y = random.Next(0, 3);
                            if (playfield[x, y] == '-')
                            {
                                playfield[x, y] = Players[1].GetSign();
                                break;
                            }
                        }
                    }// the draw has been pulled
                    else if (IsDraw() == true)
                    {
                        Console.WriteLine("We have a DRAW!");
                        if(multipleRounds == true)
                        {
                            Console.WriteLine("New Round!");
                            break;
                        }
                        else
                        {
                            return;
                        }  
                    }
                    else if (players[1].GetIsBot() == false && IsDraw() == false)
                    {
                        GetInput();
                    }
                    //check if the second player has won
                    if (CheckForWin(players[1]) == true)
                    {
                        winner = AnnounceWinner(players[1]);
                        gameboard.DrawBoard(playfield, position);
                        break;
                    }
                    
                    Console.Clear();
                }
                winner.GetIsBot();
                if (multipleRounds == true)
                {
                    if (rounds <5)
                    {
                        Console.WriteLine("Next round ");
                        rounds++;
                        //reset playfield
                        ResetPlayField();        
                        continue;

                    }
                    else
                    {
                        Console.WriteLine($"Player {winner.GetName()} has won with {winner.GetScore()} points.");
                        Console.Write("Press any key to get back to the menu");
                        Console.ReadKey();
                        Console.Clear();
                        return;
                    }
                }else
                {
                    return;
                }
            }
        }

        private bool IsDraw()
        {    
             for (int i = 0; i < 2; i++)
            {
                for (int j =0; j < 2; j++)
                {
                    if (playfield[i,j] == '-')
                    {
                        return false;
                    }
                }
            } return true;

        }

        private void ResetPlayField()
        {
            playfield = new char[3, 3]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            };
        }

        private Player AnnounceWinner(Player player)
        {
            Console.WriteLine($"{player.GetName()} has won!");
            player.AddScore();
            Console.WriteLine("Press any key to continue...");
            return player;
        }

        private void GetInput()
        {
            bool isEntered = false;

            while (isEntered == false)
            {
                var input = Console.ReadKey(true);
                Console.Clear();
                switch (input.Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (position.Item1 - 1 >= 0)
                        {
                            position = (position.Item1 - 1, position.Item2);
                        }

                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (position.Item2 - 1 >= 0)
                        {
                            position = (position.Item1, position.Item2 - 1);
                        }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (position.Item1 + 1 <= 2)
                        {
                            position = (position.Item1 + 1, position.Item2);
                        }
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (position.Item2 + 1 <= 2)
                        {
                            position = (position.Item1, position.Item2 + 1);
                        }
                        break;
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        position = (0, 0);
                        break;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        position = (0, 1);
                        break;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        position = (0, 2);
                        break;
                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        position = (1, 0);
                        break;
                    case ConsoleKey.NumPad5:
                    case ConsoleKey.D5:
                        position = (1, 1);
                        break;
                    case ConsoleKey.NumPad6:
                    case ConsoleKey.D6:
                        position = (1, 2);
                        break;
                    case ConsoleKey.NumPad7:
                    case ConsoleKey.D7:
                        position = (2, 0);
                        break;
                    case ConsoleKey.NumPad8:
                    case ConsoleKey.D8:
                        position = (2, 1);
                        break;
                    case ConsoleKey.NumPad9:
                    case ConsoleKey.D9:
                        position = (2, 2);
                        break;
                    case ConsoleKey.Enter:
                        if (playfield[position.Item1, position.Item2] == '-')
                        {
                            if (secondPlayerTurn == true)
                            {
                                playfield[position.Item1, position.Item2] = Players[1].GetSign();
                            }
                            else
                            {
                                playfield[position.Item1, position.Item2] = Players[0].GetSign();
                            }
                            isEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("This field is already taken!");
                        }
                        break;
                }
                Console.Clear();

                board.DrawBoard(playfield, position);
                Console.WriteLine(
    "Choose WASD or Arrow keys to choose the field and press enter."
);

            }
        }

        /**
         * win conditions
         * checks if somebody won... but not who...
         * how can we do this in the if conditions without too much work like right now?
         *
         * Maybe like this?:
         * first get the char sign.
         * then run the double loop for the inner list:
         *  0,i=0 -> 0,i=2
         *  check each time if the sign is same
         *  and then check if the sign is equal to player1 or player2 sign
         * then run the loop for the inner list vertically:
         *  i,0 -> i,0
         * */
        public bool CheckForWin(Player player)
        {
            var sign = player.GetSign();
            //check for horizontal win

            for (int i = 0; i < 3; i++)
            {
                //horizontal
                //should return 0,0 == 0,1 == 0,2, 1,0 == 1,1 == 1,2
                if (sign == playfield[i, 0] && playfield[i,0] == playfield[i, 1] && playfield[i, 1] == playfield[i, 2])
                {
                    return true;
                }
                //vertical
                if (sign == playfield[0,i] && playfield[0, i] == playfield[1, i] && playfield[1, i] == playfield[2, i])
                {
                    return true;
                }
            }
            if (
                sign == playfield[0,0] && playfield[0, 0] == playfield[1, 1] && playfield[1, 1] == playfield[2, 2]
                || sign == playfield[0,2] && playfield[0, 2] == playfield[1, 1] && playfield[1, 1] == playfield[2, 0]
            )
            {
                return true;
            }
            return false;
        }

        public char[,] getPlayfield()
        {
            return playfield;
        }
    }
}
