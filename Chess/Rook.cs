using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class Rook : Piece
    {
        public Rook(ChessBoard board, Color color) : base(board, color)
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

            //Above
            position.SetValues(Position.Row - 1, Position.Column);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.Row = position.Row - 1;
            }

            //Below
            position.SetValues(Position.Row + 1, Position.Column);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.Row = position.Row + 1;
            }

            //Right
            position.SetValues(Position.Row, Position.Column + 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column + 1;
            }

            //Left
            position.SetValues(Position.Row, Position.Column - 1);
            while (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
                if (Board.GetPiece(position) != null && Board.GetPiece(position).Color != Color)
                {
                    break;
                }
                position.Column = position.Column - 1;
            }


            return movements;

        }


        public override string ToString()
        {
            return "R";
        }
    }
}