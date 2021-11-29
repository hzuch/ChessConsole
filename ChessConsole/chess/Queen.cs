﻿using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Colour colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "Q";
        }

        private bool mayMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.colour != colour;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //up
            pos.defineValues(position.line - 1, position.column);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.line = pos.line - 1;
            }
            //down
            pos.defineValues(position.line + 1, position.column);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.line = pos.line + 1;
            }
            //right
            pos.defineValues(position.line, position.column + 1);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.column = pos.column + 1;
            }
            //left
            pos.defineValues(position.line, position.column - 1);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.column = pos.column - 1;
            }
            //NW
            pos.defineValues(position.line - 1, position.column - 1);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValues(position.line - 1, position.column - 1);
            }
            //NE
            pos.defineValues(position.line - 1, position.column + 1);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValues(position.line - 1, position.column + 1);
            }
            //SE
            pos.defineValues(position.line + 1, position.column - 1);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValues(position.line + 1, position.column - 1);
            }
            //SW
            pos.defineValues(position.line + 1, position.column - 1);
            while (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
                if (board.piece(pos) != null && board.piece(pos).colour != colour)
                {
                    break;
                }
                pos.defineValues(position.line + 1, position.column - 1);
            }

            return mat;
        }

    }
}
