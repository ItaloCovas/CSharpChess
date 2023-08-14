using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class Bishop : Piece
    {
        public Bishop(ChessBoard board, Color color) : base(board, color)
        {

        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);

            return piece == null || piece.Color != Color;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[Board.Rows, Board.Columns];

            Position position = new Position(0, 0);

            // NO
            position.SetValues(position.Row - 1, position.Column - 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row - 1, position.Column - 1);
            }

            // NE
            position.SetValues(position.Row - 1, position.Column + 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row - 1, position.Column + 1);
            }

            // SE
            position.SetValues(position.Row + 1, position.Column + 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row + 1, position.Column + 1);
            }

            // SO
            position.SetValues(position.Row + 1, position.Column - 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row + 1, position.Column - 1);
            }

            return movements;

        }


        public override string ToString()
        {
            return "B";
        }
    }
}