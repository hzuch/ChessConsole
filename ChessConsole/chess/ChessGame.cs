using System;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        private int turn;
        private Colour activePlayer;
        public bool finished { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            activePlayer = Colour.White;
            finished = false;
            addPieces();
        }

        public void makeMove(Position origin, Position target)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoveCount();
            Piece capturedPiece = board.removePiece(target);
            board.addPiece(p, target);
        }

        private void addPieces()
        {
            board.addPiece(new Rook(board, Colour.White), new PositionChess('c',1).toPosition());
            board.addPiece(new Rook(board, Colour.White), new PositionChess('c',2).toPosition());
            board.addPiece(new Rook(board, Colour.White), new PositionChess('d',2).toPosition());
            board.addPiece(new Rook(board, Colour.White), new PositionChess('e',2).toPosition());
            board.addPiece(new Rook(board, Colour.White), new PositionChess('e',1).toPosition());
            board.addPiece(new King(board, Colour.White), new PositionChess('d',1).toPosition());

        }
    }
}
