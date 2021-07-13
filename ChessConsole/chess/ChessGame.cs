using System;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Colour activePlayer { get; private set; }
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

        public void playTurn(Position origin, Position target)
        {
            makeMove(origin, target);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.piece(pos) == null)
            {
                throw new BoardException("No piece exists at chosen position of origin!");
            }
            if (activePlayer != board.piece(pos).colour)
            {
                throw new BoardException("Chosen piece is not yours!");
            }
            if (!board.piece(pos).possibleMovesExist())
            {
                throw new BoardException("There are no possible movement for chosen piece!");
            }
        }

        public void validateTargetPosition(Position origin, Position target)
        {
            if (!board.piece(origin).mayMoveTo(target))
            {
                throw new BoardException("Target position is invalid!");
            }
        }

        private void changePlayer()
        {
            if (activePlayer == Colour.White)
            {
                activePlayer = Colour.Black;
            }
            else
            {
                activePlayer = Colour.White;
            }
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
