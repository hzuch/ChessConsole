using System;
using System.Collections.Generic;
using board;
using chess;

namespace ChessConsole
{
    class Screen
    {

        public static void printGame(ChessGame game)
        {
            printBoard(game.board);
            Console.WriteLine();
            printCapturedPieces(game);
            Console.WriteLine();
            Console.WriteLine("Turn: " + game.turn);
            if (!game.finished)
            {
                Console.WriteLine("Awaiting move: " + game.activePlayer);
                if (game.check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE");
                Console.WriteLine("Winner: " + game.activePlayer);
            }
            
        }

        public static void printCapturedPieces(ChessGame game)
        {
            Console.WriteLine("Captured Pieces:");
            Console.Write("White: ");
            printSet(game.capturedPieces(Colour.White));
            Console.WriteLine();
            ConsoleColor aux = Console.ForegroundColor;
            Console.Write("Black: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            printSet(game.capturedPieces(Colour.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printSet(HashSet<Piece> sett)
        {
            Console.Write("[");
            foreach (Piece p in sett)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }
        public static void printBoard(Board board)
        {
            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board board, bool[,] possiblePositions)
        {
            ConsoleColor originalBg = Console.BackgroundColor;
            ConsoleColor alteredBg = ConsoleColor.DarkGray;

            for (int i = 0; i < board.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < board.columns; j++)
                {
                    if (possiblePositions[i,j])
                    {
                        Console.BackgroundColor = alteredBg;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBg;
                    }
                    printPiece(board.piece(i, j));
                }
                Console.WriteLine();
                Console.BackgroundColor = originalBg;
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBg;

        }

        public static PositionChess readPositionChess()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new PositionChess(column, line);
        }

        public static void printPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (piece.colour == Colour.White)
                {
                    Console.Write(piece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(piece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
