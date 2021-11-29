using board;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Colour colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "N";
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

            pos.defineValues(position.line - 1, position.column - 2);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line - 2, position.column - 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line - 2, position.column + 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line - 1, position.column + 2);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 1, position.column + 2);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 2, position.column + 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 2, position.column - 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            pos.defineValues(position.line + 1, position.column - 2);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }

            return mat;
        }

    }
}
