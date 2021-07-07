using System;
using Board;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Position P;

            P = new Position(3, 4);

            Console.WriteLine(P.ToString());
        }
    }
}
