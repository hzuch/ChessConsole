﻿using System;
using board;

namespace ChessConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Board B = new Board(8, 8);

            Console.WriteLine(B.ToString());
        }
    }
}
