using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class Rook : Piece
    {
        public Rook(ChessBoard board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "R";
        }
    }
}