using Board;
using Board.Enums;
using CSharpChess.Board.Exceptions;
using CSharpChess.Chess;

namespace CSharpChess
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ChessBoard board = new ChessBoard(8, 8);

                board.InsertPiece(new King(board, Color.Red), new Position(0, 0));
                board.InsertPiece(new King(board, Color.Red), new Position(1, 3));
                board.InsertPiece(new King(board, Color.Red), new Position(0, 2));



                Screen.PrintBoard(board);
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}