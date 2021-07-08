using System;
using board;
using chess;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionChess pos = new PositionChess('c', 7);
            Console.WriteLine(pos.ToString());
            Console.WriteLine(pos.toPosition());
            
        }
    }
}
