namespace Board
{
    class ChessBoard
    {

        public int Rows { get; set; }

        public int Columns { get; set; }

        private Piece[,] pieces;

        public ChessBoard(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            pieces = new Piece[Rows, Columns];
        }

        public override string ToString()
        {
            return "";
        }

    }
}