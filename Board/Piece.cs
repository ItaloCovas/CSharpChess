using Board.Enums;

namespace Board
{
    abstract class Piece
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

        public void DecreaseMovementAmount()
        {
            MovementAmount--;
        }

        public bool HasPossibleMovements()
        {
            bool[,] arr = PossibleMovements();

            for (int i = 0; i < Board.Rows; i++)
            {
                for (int j = 0; j < Board.Columns; j++)
                {
                    if (arr[i, j] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool CanMoveTo(Position position)
        {
            return PossibleMovements()[position.Row, position.Column];
        }

        public abstract bool[,] PossibleMovements();

    }
}