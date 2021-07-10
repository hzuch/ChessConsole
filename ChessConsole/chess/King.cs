using board;

namespace chess
{
    class King : Piece
    {
        public King(Board board, Colour colour) : base(board, colour)
        {
        }
        public override string ToString()
        {
            return "K";
        }

        private bool mayMove(Position pos)
        {
            Piece p = board.piece(pos);
            return p == null || p.colour != colour;
        }

        public override bool[,] possibleMoves() {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            //up
            pos.defineValues(position.line - 1, position.column);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //up right
            pos.defineValues(position.line - 1, position.column + 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // right
            pos.defineValues(position.line, position.column + 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //down right
            pos.defineValues(position.line + 1, position.column + 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //down
            pos.defineValues(position.line + 1, position.column);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //down left
            pos.defineValues(position.line + 1, position.column - 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            // left
            pos.defineValues(position.line, position.column - 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            //up left
            pos.defineValues(position.line - 1, position.column - 1);
            if (board.validPosition(pos) && mayMove(pos))
            {
                mat[pos.line, pos.column] = true;
            }
            return mat;
        }

        
    }
}
