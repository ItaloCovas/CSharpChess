using Board;
using Board.Enums;
using CSharpChess.Board.Exceptions;

namespace CSharpChess.Chess
{
    class Match
    {
        public ChessBoard Board { get; private set; }

        public int Round { get; private set; }

        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; private set; }

        private HashSet<Piece> Pieces;
        private HashSet<Piece> CapturedPieces;


        public Match()
        {
            Board = new ChessBoard(8, 8);
            Round = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            Pieces = new HashSet<Piece>();
            CapturedPieces = new HashSet<Piece>();
            InsertPieces();
        }

        private void MakePieceMovement(Position origin, Position destiny)
        {
            Piece piece = Board.RemovePiece(origin);
            piece.IncreaseMovementAmount();
            Piece capturedPiece = Board.RemovePiece(destiny);
            Board.InsertPiece(piece, destiny);

            if (capturedPiece != null)
            {
                CapturedPieces.Add(capturedPiece);
            }
        }

        public void MakeMove(Position origin, Position destiny)
        {
            MakePieceMovement(origin, destiny);
            Round++;
            ChangePlayer();
        }

        private void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            }
            else
            {
                CurrentPlayer = Color.White;
            }
        }

        public void ValidateOriginPosition(Position position)
        {
            if (Board.GetPiece(position) == null)
            {
                throw new ChessBoardException("There is no piece in this position.");
            }

            if (CurrentPlayer != Board.GetPiece(position).Color)
            {
                throw new ChessBoardException($"This piece is not yours, you can move just {CurrentPlayer} pieces.");

            }

            if (!Board.GetPiece(position).HasPossibleMovements())
            {
                throw new ChessBoardException("There is possible movements for this piece.");

            }
        }

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.GetPiece(origin).CanMoveTo(destiny))
            {
                throw new ChessBoardException("Invalid destiny position!");
            }
        }

        public HashSet<Piece> InGamePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in Pieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }


        public HashSet<Piece> GetCapturedPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();

            foreach (Piece x in CapturedPieces)
            {
                if (x.Color == color)
                {
                    aux.Add(x);
                }
            }

            return aux;
        }
        public void InsertNewPiece(char column, int row, Piece piece)
        {
            Board.InsertPiece(piece, new ChessPosition(column, row).ToPosition());
            Pieces.Add(piece);
        }
        private void InsertPieces()
        {
            InsertNewPiece('c', 1, new Rook(Board, Color.White));
            InsertNewPiece('c', 2, new Rook(Board, Color.White));
            InsertNewPiece('d', 2, new Rook(Board, Color.White));
            InsertNewPiece('e', 2, new Rook(Board, Color.White));
            InsertNewPiece('e', 1, new Rook(Board, Color.White));
            InsertNewPiece('d', 1, new Rook(Board, Color.White));

            InsertNewPiece('c', 7, new Rook(Board, Color.White));
            InsertNewPiece('c', 8, new Rook(Board, Color.White));
            InsertNewPiece('d', 7, new Rook(Board, Color.White));
            InsertNewPiece('e', 7, new Rook(Board, Color.White));
            InsertNewPiece('e', 8, new Rook(Board, Color.White));
            InsertNewPiece('d', 8, new King(Board, Color.Black));



        }
        public override string ToString()
        {
            return "K";
        }
    }
}