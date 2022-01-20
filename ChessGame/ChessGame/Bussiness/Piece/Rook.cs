using Bussiness;
using ChessGame.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class Rook : Piece
    {
        public bool White { get; set; }
        public char Lable { get; set; }
        public Rook(bool white)
        {
            White = white;
            Lable = 'R';
        }
        public bool CanMove(Spot start, Spot end, Board board)
        {
            //if both same color ther return false or outof bound
            if (start == end || start.X < 0 || start.Y < 0 || end.X >= board.sizeOfBoard || end.Y >= board.sizeOfBoard || start.Piece.White == end.Piece.White)
            {
                return false;
            }
            if (start.X == end.X || start.Y == end.Y)
            {
                return true;
            }
            return false;
        }

        public List<Spot> GetAllPosibleMove(Spot start, Board board)
        {
            List<Spot> spots = new List<Spot>();
            //check all Direction
            for (int i = 0; i < board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null, i, start.Y), board))
                {
                    spots.Add(new Spot(null, i, start.Y));
                }
            }
            for (int i = 0; i < board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null, start.X, i), board))
                {
                    spots.Add(new Spot(null, start.X, i));
                }
            }
            return spots;
        }
    }
}
