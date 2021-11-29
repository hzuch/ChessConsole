using board;

namespace chess
{
    class King : Piece
    {

        private ChessGame game;
        public King(Board board, Colour colour, ChessGame game) : base(board, colour)
        {
            this.game = game;
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

        private bool testRookCastling(Position pos)
        {
            Piece p = board.piece(pos);
            return p != null && p is Rook && p.colour == colour && p.moveCount == 0;
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

            // #specialmove castling
            if (moveCount == 0 && !game.check)
            {
                // short-side castling
                Position posR1 = new Position(position.line, position.column + 3);
                if (testRookCastling(posR1))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (board.piece(p1)==null && board.piece(p2)==null)
                    {
                        mat[position.line, position.column + 2] = true;
                    }
                }
                // long-side castling
                Position posR2 = new Position(position.line, position.column + 3);
                if (testRookCastling(posR2))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.piece(p1) == null && board.piece(p2) == null && board.piece(p3) == null)
                    {
                        mat[position.line, position.column - 2] = true;
                    }
                }
            }
            return mat;
        }

        
    }
}
