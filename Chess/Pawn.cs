using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class Pawn : Piece
    {
        private Match Match;
        public Pawn(ChessBoard board, Color color, Match match) : base(board, color)
        {
            Match = match;
        }

        private bool HasEnemy(Position position)
        {
            Piece piece = Board.GetPiece(position);
            return piece != null && piece.Color != Color;
        }

        private bool IsVacant(Position position)
        {
            return Board.GetPiece(position) == null;
        }

        public override bool[,] PossibleMovements()
        {
            bool[,] movements = new bool[Board.Rows, Board.Columns];

            Position pos = new Position(0, 0);

            if (Color == Color.White)
            {
                pos.SetValues(Position.Row - 1, Position.Column);
                if (Board.IsPositionValid(pos) && IsVacant(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 2, Position.Column);
                Position p2 = new Position(Position.Row - 1, Position.Column);
                if (Board.IsPositionValid(p2) && IsVacant(p2) && Board.IsPositionValid(pos) && IsVacant(pos) && MovementAmount == 0)
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row - 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }

                // Special move "en passant"
                if (Position.Row == 3)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && HasEnemy(left) && Board.GetPiece(left) == Match.VulnerableEnPassant)
                    {
                        movements[left.Row - 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && HasEnemy(right) && Board.GetPiece(right) == Match.VulnerableEnPassant)
                    {
                        movements[right.Row - 1, right.Column] = true;
                    }
                }
            }
            else
            {
                pos.SetValues(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(pos) && IsVacant(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 2, Position.Column);
                Position p2 = new Position(Position.Row + 1, Position.Column);
                if (Board.IsPositionValid(p2) && IsVacant(p2) && Board.IsPositionValid(pos) && IsVacant(pos) && MovementAmount == 0)
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 1, Position.Column - 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }
                pos.SetValues(Position.Row + 1, Position.Column + 1);
                if (Board.IsPositionValid(pos) && HasEnemy(pos))
                {
                    movements[pos.Row, pos.Column] = true;
                }

                // Special move "en passant"
                if (Position.Row == 4)
                {
                    Position left = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(left) && HasEnemy(left) && Board.GetPiece(left) == Match.VulnerableEnPassant)
                    {
                        movements[left.Row + 1, left.Column] = true;
                    }
                    Position right = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(right) && HasEnemy(right) && Board.GetPiece(right) == Match.VulnerableEnPassant)
                    {
                        movements[right.Row + 1, right.Column] = true;
                    }
                }
            }

            return movements;
        }


        public override string ToString()
        {
            return "P";
        }
    }
}