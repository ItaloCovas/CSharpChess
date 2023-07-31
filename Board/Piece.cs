using Board.Enums;

namespace Board
{
    class Piece
    {
        public Position Position { get; set; }

        public Color Color { get; set; }
        public int MovementAmount { get; protected set; }

        public ChessBoard Board { get; protected set; }

        public Piece(ChessBoard board, Color color)
        {
            Position = null;
            Color = color;
            Board = board;
            MovementAmount = 0;
        }

        public void IncreaseMovementAmount()
        {
            MovementAmount++;
        }

        public override string ToString()
        {
            return "";
        }

    }
}