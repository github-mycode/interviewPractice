using ChessGame.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussiness
{
    //one box of board
    public class Spot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Piece Piece { get; set; }
        public Spot(Piece p, int x, int y)
        {
            X = x;
            Y = y;
            Piece = p;
        }
    }
}
