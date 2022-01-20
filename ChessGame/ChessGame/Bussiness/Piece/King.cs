using Bussiness;
using ChessGame.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class King : Piece
    {
        public bool White { get; set; }
        public char Lable { get; set; }
        public King(bool white)
        {
            White = white;
            Lable = 'K';
        }
        public bool CanMove(Spot start, Spot end, Board board)
        {
            //if both same color ther return false or outof bound
            if (start == end || start.X<0 || start.Y<0 || end.X>=board.sizeOfBoard || end.Y>= board.sizeOfBoard|| start.Piece.White == end.Piece.White) { 
                return false;
            }
            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);
            if(x*y == 2)
            {
                return true;
            }
            return false;
        }
        public List<Spot> GetAllPosibleMove(Spot start, Board board)
        {
            List<Spot> spots = new List<Spot>();

            //check left
            int x = start.X - 2;
            int y = start.Y -1;
            if(CanMove(start, new Spot(null, x, y), board))
            {
                spots.Add(board.Grid[x, y]);
            }
            //check right
            x = start.X - 2 ;
            y = start.Y + 1;
            if (CanMove(start, new Spot(null, x, y), board))
            {
                spots.Add(board.Grid[x, y]);
            }
            //check up
            x = start.X + 2;
            y = start.Y + 1;
            if (CanMove(start, new Spot(null, x, y), board))
            {
                spots.Add(board.Grid[x, y]);
            }
            //check bottom
            x = start.X + 2;
            y = start.Y - 1;
            if (CanMove(start, new Spot(null, x, y), board))
            {
                spots.Add(board.Grid[x, y]);
            }
            return spots;
        }
    }
}
