using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class Knight : Piece
    {
        public Knight(ChessBoard board, Color color) : base(board, color)
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

            position.SetValues(position.Row - 1, position.Column - 2);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }
            position.SetValues(position.Row - 2, position.Column - 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }
            position.SetValues(position.Row - 2, position.Column + 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }
            position.SetValues(position.Row - 1, position.Column + 2);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }
            position.SetValues(position.Row + 1, position.Column + 2);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }
            position.SetValues(position.Row + 2, position.Column + 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }
            position.SetValues(position.Row + 2, position.Column - 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }
            position.SetValues(position.Row + 1, position.Column - 2);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            return movements;

        }


        public override string ToString()
        {
            return "C";
        }
    }
}