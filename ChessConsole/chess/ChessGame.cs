using System.Collections.Generic;
using board;

namespace chess
{
    class ChessGame
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Colour activePlayer { get; private set; }
        public bool finished { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> captured;
        public bool check { get; private set; }

        public ChessGame()
        {
            board = new Board(8, 8);
            turn = 1;
            activePlayer = Colour.White;
            finished = false;
            pieces = new HashSet<Piece>();
            captured = new HashSet<Piece>();
            placePieces();
            check = false;
        }

        public Piece makeMove(Position origin, Position target)
        {
            Piece p = board.removePiece(origin);
            p.incrementMoveCount();
            Piece capturedPiece = board.removePiece(target);
            board.addPiece(p, target);
            if (capturedPiece != null)
            {
                captured.Add(capturedPiece);
            }
            return capturedPiece;
        }

        public void undoMovement(Position origin, Position target, Piece capturedPiece)
        {
            Piece p = board.removePiece(target);
            p.decrementMoveCount();
            if (capturedPiece != null)
            {
                board.addPiece(capturedPiece, target);
                captured.Remove(capturedPiece);
            }
            board.addPiece(p, origin);
        }

        public void playTurn(Position origin, Position target)
        {
            Piece capturedPiece = makeMove(origin, target);

            if (isInCheck(activePlayer))
            {
                undoMovement(origin, target, capturedPiece);
                throw new BoardException("You can't place yourself in check!");
            }

            if (isInCheck(enemy(activePlayer)))
            {
                check = true;
            }
            else
            {
                check = false;
            }
            if (testCheckMate(enemy(activePlayer)))
            {
                finished = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
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
            if (!board.piece(origin).possibleMove(target))
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

        public HashSet<Piece> capturedPieces(Colour colour)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in captured)
            {
                if (x.colour == colour)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Piece> piecesOnGame(Colour colour)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece x in pieces)
            {
                if (x.colour == colour)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(capturedPieces(colour));
            return aux;
        }

        private Colour enemy(Colour colour)
        {
            if (colour == Colour.White)
            {
                return Colour.Black;
            }
            else
            {
                return Colour.White;
            }
        }

        private Piece getKing(Colour colour)
        {
            foreach (Piece p in piecesOnGame(colour))
            {
                if (p is King)
                {
                    return p;
                }
            }
            return null;
        }

        public bool isInCheck(Colour colour)
        {
            Piece king = getKing(colour);
            if (king == null)
            {
                throw new BoardException("No King of colour" + colour + "found on board!");
            }
            foreach (Piece p in piecesOnGame(enemy(colour)))
            {
                bool[,] mat = p.possibleMoves();
                if (mat[king.position.line, king.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool testCheckMate(Colour colour)
        {
            if (!isInCheck(colour))
            {
                return false;
            }
            foreach (Piece p in piecesOnGame(colour))
            {
                bool[,] mat = p.possibleMoves();
                for (int i = 0; i < board.lines; i++)
                {
                    for (int j = 0; j < board.columns; j++)
                    {
                        if (mat[i,j])
                        {
                            Position origin = p.position;
                            Position target = new Position(i, j);
                            Piece capturedPiece = makeMove(origin, target);
                            bool testCheck = isInCheck(colour);
                            undoMovement(origin, target, capturedPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
                        }
                    }

                }
            }
            return true;
        }

        public void placeNewPiece(char column, int line, Piece piece)
        {
            board.addPiece(piece, new PositionChess(column, line).toPosition());
            pieces.Add(piece);
        }

        private void placePieces()
        {
            placeNewPiece('c', 1, new Rook(board, Colour.White));
            placeNewPiece('c', 2, new Rook(board, Colour.White));
            placeNewPiece('d', 2, new Rook(board, Colour.White));
            placeNewPiece('e', 2, new Rook(board, Colour.White));
            placeNewPiece('e', 1, new Rook(board, Colour.White));
            placeNewPiece('d', 1, new King(board, Colour.White));
            placeNewPiece('c', 8, new Rook(board, Colour.Black));
            placeNewPiece('c', 7, new Rook(board, Colour.Black));
            placeNewPiece('d', 7, new Rook(board, Colour.Black));
            placeNewPiece('e', 7, new Rook(board, Colour.Black));
            placeNewPiece('e', 8, new Rook(board, Colour.Black));
            placeNewPiece('d', 8, new King(board, Colour.Black));

        }
    }
}
