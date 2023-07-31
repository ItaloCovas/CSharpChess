using CSharpChess.Board.Exceptions;

namespace Board
{
    class ChessBoard
    {

        public int Rows { get; set; }

        public int Columns { get; set; }

        private Piece[,] pieces;

        public ChessBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[Rows, Columns];
        }

        public Piece GetPiece(int row, int col)
        {
            return pieces[row, col];
        }

        public Piece GetPiece(Position position)
        {
            return pieces[position.Row, position.Column];
        }

        public void InsertPiece(Piece piece, Position position)
        {
            if (PieceExists(position))
            {
                throw new ChessBoardException("There is already a piece in this position.");
            }
            pieces[position.Row, position.Column] = piece;
            piece.Position = position;
        }

        public Piece RemovePiece(Position position)
        {
            if (GetPiece(position) == null)
            {
                return null;
            }

            Piece aux = GetPiece(position);
            aux.Position = null;
            pieces[position.Row, position.Column] = null;

            return aux;
        }

        public bool PieceExists(Position position)
        {
            IsPositionValid(position);
            return GetPiece(position) != null;
        }
        public bool IsPositionValid(Position position)
        {
            if (position.Row < 0 || position.Row >= Rows || position.Column < 0 || position.Column >= Columns)
            {
                throw new ChessBoardException("Invalid position!");
            }

            return true;
        }


    }
}