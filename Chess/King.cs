using Board;
using Board.Enums;

namespace CSharpChess.Chess
{
    class King : Piece
    {
        public King(ChessBoard board, Color color) : base(board, color)
        {

        }

        public override string ToString()
        {
            return "K";
        }
    }
}