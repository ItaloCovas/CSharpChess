using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class Queen : Piece
    {
        public Queen(ChessBoard board, Color color) : base(board, color)
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

            // Left
            position.SetValues(position.Row, position.Column - 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row, position.Column - 1);
            }

            // Right
            position.SetValues(position.Row, position.Column + 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row, position.Column + 1);
            }

            // Above
            position.SetValues(position.Row - 1, position.Column);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row - 1, position.Column);
            }

            // Below
            position.SetValues(position.Row + 1, position.Column);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.SetValues(position.Row + 1, position.Column);
            }

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
            return "Q";
        }
    }
}