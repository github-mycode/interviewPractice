using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class Player
    {
        public bool White { get; set; }
        public string Name { get; set; }
        public Player(bool white)
        {
            White = white;
            Name = "Plyer" + white.ToString();
        }
    }
}
