using Board.Enums;

namespace Board
{
    class Piece
    {
        public Position Position { get; set; }

        public Color Color { get; set; }
        public int MovementAmount { get; protected set; }

        public ChessBoard Board { get; protected set; }

        public Piece(Position position, ChessBoard board, Color color)
        {
            Position = position;
            Color = color;
            Board = board;
            MovementAmount = 0;
        }

        public override string ToString()
        {
            return "";
        }

    }
}