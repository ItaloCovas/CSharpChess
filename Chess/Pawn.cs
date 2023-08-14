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
                    Position esquerda = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(esquerda) && HasEnemy(esquerda) && Board.GetPiece(esquerda) == Match.vulneravelEnPassant)
                    {
                        movements[esquerda.Row - 1, esquerda.Column] = true;
                    }
                    Position direita = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(direita) && HasEnemy(direita) && Board.GetPiece(direita) == Match.vulneravelEnPassant)
                    {
                        movements[direita.Row - 1, direita.Column] = true;
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
                    Position esquerda = new Position(Position.Row, Position.Column - 1);
                    if (Board.IsPositionValid(esquerda) && HasEnemy(esquerda) && Board.GetPiece(esquerda) == Match.vulneravelEnPassant)
                    {
                        movements[esquerda.Row + 1, esquerda.Column] = true;
                    }
                    Position direita = new Position(Position.Row, Position.Column + 1);
                    if (Board.IsPositionValid(direita) && HasEnemy(direita) && Board.GetPiece(direita) == Match.vulneravelEnPassant)
                    {
                        movements[direita.Row + 1, direita.Column] = true;
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