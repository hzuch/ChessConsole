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
                    try
                    {
                        Console.Clear();
                        Screen.printGame(game);
                        
                        Console.WriteLine();

                        Console.Write("Enter origin: ");
                        Position origin = Screen.readPositionChess().toPosition();
                        game.validateOriginPosition(origin);

                        bool[,] possiblePositions = game.board.piece(origin).possibleMoves();

                        Console.Clear();
                        Screen.printBoard(game.board, possiblePositions);

                        Console.Write("Enter target: ");
                        Position target = Screen.readPositionChess().toPosition();
                        game.validateTargetPosition(origin, target);

                        game.playTurn(origin, target);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }

                

            }
            catch (BoardException e)
            {

                Console.WriteLine(e.Message); ;
            }
        }
    }
}
