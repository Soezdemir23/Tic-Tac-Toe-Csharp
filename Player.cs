using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Player
    {
        public char Sign { get; private set; }
        public string Name { get; private set; }
        private bool IsBot { get; set; }
        private int score { get; set; } = 0;

        public Player(char Sign, string Name)
        {
            if (Sign == null)
            {
                throw new ArgumentNullException("You entered less or more than one character");
            }
            else
            {
                this.Sign = Sign;
            }
            this.Name = Name;
        }

        public char GetSign()
        {
            return this.Sign;
        }

        public string GetName()
        {
            return Name;
        }

        public bool GetIsBot()
        {
            return IsBot;
        }

        public void setIsBot(bool isBot)
        {
            this.IsBot = isBot;
        }

        public void AddScore()
        {
            score++;
        }

        public int GetScore()
        {
            return score;
        }


       public static Player HandlePlayer(int number)
        {
            string name;
            string sign;
            while (true)
            {
                Console.WriteLine($"Please enter your name player {number}:");
                name = Console.ReadLine();
                if (name.Length > 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please try again");
                }
            }

            while (true)
            {
                Console.WriteLine("Please enter your sign:");
                sign = Console.ReadLine();
                if (sign.Length == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter one character, number, letter !");
                }

            }
            Console.WriteLine($"Welcome {name}! Your sign is {sign}");
            return new Player(sign[0], name);
        }

    }
}
