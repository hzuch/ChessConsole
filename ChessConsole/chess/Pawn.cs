using board;

namespace chess
{
    class Pawn : Piece
    {
        private ChessGame game;
        public Pawn(Board board, Colour colour, ChessGame game) : base(board, colour)
        {
            this.game = game;
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

                // #specialmove en passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.validPosition(left) && enemyExists(left) && board.piece(left) == game.enPassantVulnerable)
                    {
                        mat[left.line - 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column - 1);
                    if (board.validPosition(right) && enemyExists(right) && board.piece(right) == game.enPassantVulnerable)
                    {
                        mat[right.line + 1, right.column] = true;
                    }
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

                // #specialmove en passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);
                    if (board.validPosition(left) && enemyExists(left) && board.piece(left) == game.enPassantVulnerable)
                    {
                        mat[left.line + 1, left.column] = true;
                    }
                    Position right = new Position(position.line, position.column - 1);
                    if (board.validPosition(right) && enemyExists(right) && board.piece(right) == game.enPassantVulnerable)
                    {
                        mat[right.line - 1, right.column] = true;
                    }
                }
            }

            return mat;
        }

    }
}
