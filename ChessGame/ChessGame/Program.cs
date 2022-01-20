using ChessGame.Bussiness;
using System;

namespace ChessGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game loading");
            Game game = new Game();
            while (true)
            {
                game.PrintBoard();
                int startX = Int32.Parse(Console.ReadLine());
                int startY = Int32.Parse(Console.ReadLine());
                int endX = Int32.Parse(Console.ReadLine());
                int endY = Int32.Parse(Console.ReadLine());

                game.MovePiece(startX, startY, endX, endY);
            }
        }
    }
}
