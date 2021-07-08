﻿namespace board
{
    class Board
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Board(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }

        public Piece piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece piece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }

        public bool pieceExists(Position pos)
        {
            validatePosition(pos);
            return piece(pos) != null;
        }
        public void addPiece(Piece p, Position pos)
        {
            if (pieceExists(pos))
            {
                throw new BoardException("There already is a piece on this position");
            }
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        public bool validPosition(Position pos)
        {
            if (pos.line < 0 || pos.line>=lines || pos.column<0 || pos.column>=columns)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void validatePosition(Position pos)
        {
            if (!validPosition(pos))
            {
                throw new BoardException("Invalid position!");
            }
        }
    }
}
