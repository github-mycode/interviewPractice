using Bussiness;
using ChessGame.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class Pawn : Piece
    {
        public bool White { get; set; }
        public char Lable { get; set; }
        public Pawn(bool white)
        {
            White = white;
            Lable = 'P';
        }
        public bool CanMove(Spot start, Spot end, Board board)
        {
            //if both same color ther return false or outof bound
            if (start == end || start.X < 0 || start.Y < 0 || end.X >= board.sizeOfBoard || end.Y >= board.sizeOfBoard || start.Piece.White == end.Piece.White)
            {
                return false;
            }
            int y = start.Y - end.Y;
            if (y == 1)
            {
                return true;
            }
            return false;
        }

        public List<Spot> GetAllPosibleMove(Spot start, Board board)
        {
            List<Spot> spots = new List<Spot>();

            if (CanMove(start, new Spot(null, start.X, start.Y + 1), board))
            {
                spots.Add(board.Grid[start.X, start.Y + 1]);
            }
            return spots;
        }
    }
}
