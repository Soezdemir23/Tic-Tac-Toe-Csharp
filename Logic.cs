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
        private Player[] players { get; set; }
        private int rounds { get; set; } = 0;
        private bool multipleRounds { get; set; } = false;

        private Gameboard gameboard { get; set; }
        private bool secondPlayerTurn { get; set; } = false;

        public (int, int) position { get; set; } = (1, 1);
        private char[,] playfield { get; set; } =
            new char[3, 3]
            {
                { '-', '-', '-' },
                { '-', '-', '-' },
                { '-', '-', '-' }
            };

        public Logic(Player[] players, Gameboard gameboard, bool multipleRounds)
        {
            this.players = players;
            this.gameboard = gameboard;
            this.multipleRounds = multipleRounds;
            Console.Clear();
            if (multipleRounds)
            {
                GameWithRounds();
            }
            else
            {
                GameWithNoRounds();
            }

            Console.Clear();
        }

        public void GameWithNoRounds()
        {
            while (true)
            {
                gameboard.WhoseTurn(players[0]);
                gameboard.DrawBoard(playfield, position);
                gameboard.ControlInstructions();
                GetInput(); // we draw the board inside the getinput method and the control since
                if (CheckForWin(players[0]))
                {
                    gameboard.AnnounceWinner(players[0], multipleRounds);
                    return;
                }
                else if (IsDraw() == true)
                {
                    gameboard.AnnounceDraw();
                    Thread.Sleep(500);
                    return;
                }
                secondPlayerTurn = true;
                Console.Clear();
                gameboard.WhoseTurn(players[1]);
                gameboard.DrawBoard(playfield, position);
                gameboard.ControlInstructions();
                if (players[1].GetIsBot() == true)
                {
                    
                    GetComputerInput();
                    Console.Clear();
                    gameboard.WhoseTurn(players[1]);
                    gameboard.DrawBoard(playfield, position);
                    gameboard.ControlInstructions();
                    Thread.Sleep(1000);
                }
                else
                {
                    
                    GetInput();
                }
                if (CheckForWin(players[1]))
                {
                    gameboard.AnnounceWinner(players[1], multipleRounds);
                    return;
                }
                else if (IsDraw() == true)
                {
                    gameboard.AnnounceDraw();
                    return;
                }
                secondPlayerTurn = false;
                Console.Clear();
            }
        }

        public void GameWithRounds() 
        {
        
            while (rounds <= 5)
            {
                Console.Clear();
                gameboard.BillBoard(players);
                gameboard.WhoseTurn(players[0]);
                gameboard.DrawBoard(playfield, position);
                gameboard.ControlInstructions();

                GetInput();
                if (CheckForWin(players[0]))
                {
                    AnnounceRoundWinner(players[0]);
                    Thread.Sleep(1000);
                    ResetPlayField();
                    rounds++;
                    position = (1, 1);
                    continue;
                }
                else if (IsDraw() == true)
                {
                    Console.WriteLine("Draw!");
                    Thread.Sleep(500);
                    ResetPlayField();
                    rounds++;
                    continue;
                }
                secondPlayerTurn = true;
                Console.Clear();
                gameboard.BillBoard(players);
                gameboard.WhoseTurn(players[1]);
                gameboard.DrawBoard(playfield, position);
                gameboard.ControlInstructions();
                
                if (players[1].GetIsBot() == true)
                {
                    GetComputerInput();
                    Thread.Sleep(1000);
                    Console.Clear();
                    gameboard.BillBoard(players);
                    gameboard.WhoseTurn(players[1]);
                    gameboard.DrawBoard(playfield, position);
                    gameboard.ControlInstructions();
                }
                else
                {
                    GetInput();
                }

                if (CheckForWin(players[1]))
                {
                    AnnounceRoundWinner(players[1]);
                    ResetPlayField();
                    rounds++;
                    position = (1, 1);
                    continue;
                }
                else if (IsDraw() == true)
                {
                    Console.WriteLine("Draw!");
                    Thread.Sleep(500);
                    ResetPlayField();
                    rounds++;
                    position = (1, 1);
                    continue;
                }
                secondPlayerTurn = false;
            }
            Console.WriteLine("Game Over! Multiple Rounds!");
        }

        public void GetComputerInput()
        {
            while (true)
            {
                int x = new Random().Next(0, 3);
                int y = new Random().Next(0, 3);
                if (playfield[x, y] == '-')
                {
                    playfield[x, y] = players[1].GetSign();
                    return;
                }
            }
        }

        private bool IsDraw()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (playfield[i, j] == '-')
                    {
                        return false;
                    }
                }
            }
            return true;
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

        private Player AnnounceRoundWinner(Player player)
        {
            Console.WriteLine($"{player.GetName()} won this round!");
            Console.WriteLine($"{player.GetName()} has {player.GetScore()} points!");
            player.AddScore();
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
                                playfield[position.Item1, position.Item2] = players[1].GetSign();
                            }
                            else
                            {
                                playfield[position.Item1, position.Item2] = players[0].GetSign();
                            }
                            isEntered = true;
                        }
                        else
                        {
                            Console.WriteLine("This field is already taken!");
                        }
                        break;
                }
                // here we draw the board and the control instructions
                if (multipleRounds == true)
                {
                    gameboard.BillBoard(players);
                }
                if (secondPlayerTurn == true)
                {
                    gameboard.WhoseTurn(players[1]);
                }
                else
                {
                    gameboard.WhoseTurn(players[0]);
                }
                gameboard.DrawBoard(playfield, position);
                gameboard.ControlInstructions();
                
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
                if (
                    sign == playfield[i, 0]
                    && playfield[i, 0] == playfield[i, 1]
                    && playfield[i, 1] == playfield[i, 2]
                )
                {
                    return true;
                }
                //vertical
                if (
                    sign == playfield[0, i]
                    && playfield[0, i] == playfield[1, i]
                    && playfield[1, i] == playfield[2, i]
                )
                {
                    return true;
                }
            }
            if (
                sign == playfield[0, 0]
                    && playfield[0, 0] == playfield[1, 1]
                    && playfield[1, 1] == playfield[2, 2]
                || sign == playfield[0, 2]
                    && playfield[0, 2] == playfield[1, 1]
                    && playfield[1, 1] == playfield[2, 0]
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
