using Bussiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness.Interface
{
    public interface Piece
    {
        public bool White { get; set; }
        public Char Lable { get; set; }
        public bool CanMove(Spot start, Spot end, Board board);
        public List<Spot> GetAllPosibleMove(Spot start, Board board);
    }
}
