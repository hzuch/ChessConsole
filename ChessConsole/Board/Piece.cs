namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Colour colour { get; protected set; }
        public int movCount { get; protected set; }
        public Board board { get; protected set; }

        public Piece(Position position, Board board, Colour colour)
        {
            this.position = position;
            this.board = board;
            this.colour = colour;
            this.movCount = 0;
        }
    }
}
