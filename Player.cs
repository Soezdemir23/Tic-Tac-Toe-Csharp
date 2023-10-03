using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Player
    {
        private char Sign { get; set; }
        private string Name { get; set; }
        private bool IsBot { get; set; }

        public Player(char Sign, string Name)
        {
            if (Sign == null)
            {
                throw new ArgumentNullException("You entered less or more than one character");
            }else
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
    }
}
