using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board board, Colour colour) : base(board, colour)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
