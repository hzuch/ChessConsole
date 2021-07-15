namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Colour colour { get; protected set; }
        public int moveCount { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Board board, Colour colour)
        {
            this.position = null;
            this.board = board;
            this.colour = colour;
            this.moveCount = 0;
        }

        public void incrementMoveCount()
        {
            moveCount++;
        }
        public void decrementMoveCount()
        {
            moveCount--;
        }

        public bool possibleMovesExist()
        {
            bool[,] mat = possibleMoves();
            for (int i = 0; i < board.lines; i++)
            {
                for (int j = 0; j < board.columns; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool possibleMove(Position pos)
        {
            return possibleMoves()[pos.line, pos.column];
        }

        public abstract bool[,] possibleMoves();
    }
}
