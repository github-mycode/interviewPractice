using Bussiness;
using ChessGame.Bussiness.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public static class Move
    {
        public static bool MovePiece(Spot start, Spot end, Board board)
        {
            if(IsValidMove(start, end, board))
            {
                board.Grid[end.X, end.Y] = null;
                return true;
            }
            return false;
        }
        private static bool IsValidMove(Spot start, Spot end, Board board)
        {
            Piece p = start.Piece;
            if(p.CanMove(start, end, board))
            {
                return true;
            }
            return false;
        }
    }
}
