using System;
using board;
using chess;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(8, 8);

            board.addPiece(new Rook(board, Colour.Black), new Position(0, 0));
            board.addPiece(new Rook(board, Colour.White), new Position(1, 3));
            board.addPiece(new King(board, Colour.Black), new Position(2, 4));
            
            Screen.printBoard(board);
        }
    }
}
