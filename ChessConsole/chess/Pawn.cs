using board;

namespace chess
{
    class Pawn : Piece
    {
        public Pawn(Board board, Colour colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "P";
        }

        private bool enemyExists(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p.colour != colour;
        }

        private bool freePosition(Position pos)
        {
            return board.piece(pos) == null;
        }

        public override bool[,] possibleMoves()
        {
            bool[,] mat = new bool[board.lines, board.columns];

            Position pos = new Position(0, 0);

            if (colour == Colour.White)
            {
                //one movement ahead
                pos.defineValues(position.line - 1, position.column);
                if (board.validPosition(pos) && freePosition(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                //two movements ahead if first movement
                pos.defineValues(position.line - 2, position.column);
                if (board.validPosition(pos) && freePosition(pos) && moveCount == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                //check if enemy piece on diagonal
                pos.defineValues(position.line - 1, position.column -1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line - 1, position.column + 1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }
            //black pieces
            else
            {
                //one movement ahead
                pos.defineValues(position.line + 1, position.column);
                if (board.validPosition(pos) && freePosition(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                //two movements ahead if first movement
                pos.defineValues(position.line + 2, position.column);
                if (board.validPosition(pos) && freePosition(pos) && moveCount == 0)
                {
                    mat[pos.line, pos.column] = true;
                }
                //check if enemy piece on diagonal
                pos.defineValues(position.line + 1, position.column - 1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
                pos.defineValues(position.line + 1, position.column + 1);
                if (board.validPosition(pos) && enemyExists(pos))
                {
                    mat[pos.line, pos.column] = true;
                }
            }

            return mat;
        }

    }
}
