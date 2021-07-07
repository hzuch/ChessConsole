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
    }
}
