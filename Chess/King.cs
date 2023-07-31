using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class King : Piece
    {
        public King(ChessBoard board, Color color) : base(board, color)
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
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            //Below
            position.SetValues(Position.Row + 1, Position.Column);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            //Right
            position.SetValues(Position.Row, Position.Column + 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            //Left
            position.SetValues(Position.Row, Position.Column - 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            //Northeast
            position.SetValues(Position.Row - 1, Position.Column + 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            //Nortwest
            position.SetValues(Position.Row - 1, Position.Column - 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            //Southeast
            position.SetValues(Position.Row + 1, Position.Column + 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            //Soutwest
            position.SetValues(Position.Row + 1, Position.Column - 1);
            if (Board.IsPositionValid(position) && CanMove(position))
            {
                movements[position.Row, position.Column] = true;
            }

            return movements;

        }


        public override string ToString()
        {
            return "K";
        }
    }
}