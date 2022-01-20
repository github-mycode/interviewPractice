using Bussiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class Board
    {
        public Spot[,] Grid { get; set; }
        public int sizeOfBoard = 8;
        public Board()
        {
            Grid = new Spot[sizeOfBoard, sizeOfBoard];
        }
        public Spot GetSpot(Spot s)
        {
            if(s.X<0 || s.Y<0||s.X >= sizeOfBoard ||s.Y >= sizeOfBoard)
            {
                return null;
            }
            return Grid[s.X, s.Y];
        }
        public Spot GetSpot(int x, int y)
        {
            if (x < 0 || y < 0 || x >= sizeOfBoard || y >= sizeOfBoard)
            {
                return null;
            }
            return Grid[x, y];
        }
        public void ResetPieces(bool isFirstWhite)
        {
            Grid[0, 0] = new Spot(new Rook(isFirstWhite), 0, 0);
            Grid[0, 1] = new Spot(new Knight(isFirstWhite), 0, 1);
            Grid[0, 2] = new Spot(new Bishop(isFirstWhite), 0, 2);
            Grid[0, 3] = new Spot(new King(isFirstWhite), 0, 3);
            Grid[0, 4] = new Spot(new Queen(isFirstWhite), 0, 4);
            Grid[0, 5] = new Spot(new Bishop(isFirstWhite), 0, 5);
            Grid[0, 6] = new Spot(new Knight(isFirstWhite), 0, 6);
            Grid[0, 7] = new Spot(new Rook(isFirstWhite), 0, 8);

            for (int i = 0; i< sizeOfBoard; i++)
            {
                Grid[1, i] = new Spot(new Pawn(isFirstWhite), 1, i);
                Grid[sizeOfBoard - 2, i] = new Spot(new Pawn(!isFirstWhite), sizeOfBoard - 2, i);
            }

            Grid[sizeOfBoard - 1, 0] = new Spot(new Rook(!isFirstWhite), sizeOfBoard - 1, 0);
            Grid[sizeOfBoard - 1, 1] = new Spot(new Knight(!isFirstWhite), sizeOfBoard - 1, 1);
            Grid[sizeOfBoard - 1, 2] = new Spot(new Bishop(!isFirstWhite), sizeOfBoard - 1, 2);
            Grid[sizeOfBoard - 1, 3] = new Spot(new King(!isFirstWhite), sizeOfBoard - 1, 3);
            Grid[sizeOfBoard - 1, 4] = new Spot(new Queen(!isFirstWhite), sizeOfBoard - 1, 4);
            Grid[sizeOfBoard - 1, 5] = new Spot(new Bishop(!isFirstWhite), sizeOfBoard - 1, 5);
            Grid[sizeOfBoard - 1, 6] = new Spot(new Knight(!isFirstWhite), sizeOfBoard - 1, 6);
            Grid[sizeOfBoard - 1, 7] = new Spot(new Rook(!isFirstWhite), sizeOfBoard - 1, 7);
            for (int i = 0; i < sizeOfBoard; i++)
            {
                for(int j = 0; j<sizeOfBoard; j++)
                {
                    if(Grid[i,j] == null)
                    {
                        Grid[i, j] = new Spot(null, i,j);
                    }
                }
            }
        }
    }
}
