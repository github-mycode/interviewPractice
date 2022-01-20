using Bussiness;
using ChessGame.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class Knight : Piece
    {
        public bool White { get; set; }
        public char Lable { get; set; }
        public Knight(bool white)
        {
            White = white;
            Lable = 'N';
        }
        public bool CanMove(Spot start, Spot end, Board board)
        {
            //if both same color ther return false or outof bound
            if (start == end || start.X < 0 || start.Y < 0 || end.X >= board.sizeOfBoard || end.Y >= board.sizeOfBoard || start.Piece.White == end.Piece.White)
            {
                return false;
            }
            int x = Math.Abs(start.X - end.X);
            int y = Math.Abs(start.Y - end.Y);
            if (x * y == 1)
            {
                return true;
            }
            return false;
        }

        public List<Spot> GetAllPosibleMove(Spot start, Board board)
        {
            throw new NotImplementedException();
        }
    }
}
