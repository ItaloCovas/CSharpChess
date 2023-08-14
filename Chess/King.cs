using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class King : Piece
    {
        private Match Match;

        public King(ChessBoard board, Color color, Match match) : base(board, color)
        {
            Match = match;
        }

        private bool CanMove(Position position)
        {
            Piece piece = Board.GetPiece(position);

            return piece == null || piece.Color != Color;
        }

        private bool RookCastling(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece is Rook && piece.Color == Color && piece.MovementAmount == 0;
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

            // Special move "Castling"
            if (MovementAmount == 0 && !Match.Check)
            {
                // Short Castling
                Position rookPosition = new Position(Position.Row, Position.Column + 3);
                if (RookCastling(rookPosition))
                {
                    Position p1 = new Position(Position.Row, Position.Column + 1);
                    Position p2 = new Position(Position.Row, Position.Column + 2);
                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null)
                    {
                        movements[Position.Row, Position.Column + 2] = true;
                    }
                }

                // Long Castling
                Position rookPosition2 = new Position(Position.Row, Position.Column - 4);
                if (RookCastling(rookPosition2))
                {
                    Position p1 = new Position(Position.Row, Position.Column - 1);
                    Position p2 = new Position(Position.Row, Position.Column - 2);
                    Position p3 = new Position(Position.Row, Position.Column - 3);

                    if (Board.GetPiece(p1) == null && Board.GetPiece(p2) == null && Board.GetPiece(p3) == null)
                    {
                        movements[Position.Row, Position.Column - 2] = true;
                    }
                }
            }

            return movements;

        }


        public override string ToString()
        {
            return "K";
        }
    }
}