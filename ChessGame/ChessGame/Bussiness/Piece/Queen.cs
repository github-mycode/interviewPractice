using Bussiness;
using ChessGame.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class Queen : Piece
    {
        public bool White { get; set; }
        public char Lable { get; set; }
        public Queen(bool white)
        {
            White = white;
            Lable = 'Q';
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
            if (start.X == end.X || start.Y == end.Y || x == y)
            {
                return true;
            }
            return false;
        }

        public List<Spot> GetAllPosibleMove(Spot start, Board board)
        {
            List<Spot> spots = new List<Spot>();
            //check all Direction
            for(int i = 0; i< board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null,i,start.Y), board))
                {
                    spots.Add(new Spot(null, i, start.Y));
                }
            }
            for (int i = 0; i < board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null,start.X, i), board))
                {
                    spots.Add(new Spot(null, start.X, i));
                }
            }
            for (int i = 0; i < board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null, start.X-i, start.Y-i), board))
                {
                    spots.Add(new Spot(null, start.X - i, start.Y - i));
                }
            }
            for (int i = 0; i < board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null, start.X + i, start.Y + i), board))
                {
                    spots.Add(new Spot(null, start.X + i, start.Y + i));
                }
            }
            for (int i = 0; i < board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null, start.X - i, start.Y + i), board))
                {
                    spots.Add(new Spot(null, start.X - i, start.Y + i));
                }
            }
            for (int i = 0; i < board.sizeOfBoard; i++)
            {
                if (CanMove(start, new Spot(null, start.X + i, start.Y - i), board))
                {
                    spots.Add(new Spot(null, start.X + i, start.Y - i));
                }
            }
            return spots;
        }
    }
}
