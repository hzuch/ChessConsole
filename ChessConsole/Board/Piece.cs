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

        public abstract bool[,] possibleMoves();
    }
}
