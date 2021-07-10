using System;
using board;
using chess;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessGame game = new ChessGame();

                while (!game.finished)
                {
                    Console.Clear();
                    Screen.printBoard(game.board);
                    Console.WriteLine();

                    Console.Write("enter origin: ");
                    Position origin = Screen.readPositionChess().toPosition();

                    bool[,] possiblePositions = game.board.piece(origin).possibleMoves();
                    
                    Console.Clear();
                    Screen.printBoard(game.board, possiblePositions);

                    Console.Write("enter target: ");
                    Position target = Screen.readPositionChess().toPosition();

                    game.makeMove(origin, target);

                }

                

            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message); ;
            }
        }
    }
}
