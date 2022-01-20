using Bussiness;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessGame.Bussiness
{
    public class Game
    {
        public Player[] players;
        public Board board;
        public Player currentPlayer;
        public Game()
        {
            players = new Player[2];
            //while
            players[0] = new Player(true);
            //black
            players[1] = new Player(false);
            currentPlayer = players[0];
            board = new Board();
            board.ResetPieces(true);
        }
        public void MovePiece(int startX, int startY, int endX, int endY)
        {

            bool res = Move.MovePiece(board.GetSpot(startX, startY), board.GetSpot(endX, endY), board);
            if (res)
            {
                SwapPlayer();
            }
            else
            {
                Console.WriteLine("Invalid move.. Try Again.");
            }
            
        }
        public void SwapPlayer()
        {
            if(currentPlayer == players[0])
            {
                currentPlayer = players[1];
            }
            else
            {
                currentPlayer = players[0];
            }
        }
        public void PrintBoard()
        {
            Console.WriteLine("Current Player: " + currentPlayer.Name);
            for(int i = 0; i< board.sizeOfBoard; i++)
            {
                for(int j =0; j< board.sizeOfBoard; j++)
                {
                    if(board.Grid[i,j].Piece == null)
                    {
                        Console.Write("  ");
                    }
                    else
                    {
                        Console.Write(board.Grid[i, j].Piece.Lable + " ");
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
