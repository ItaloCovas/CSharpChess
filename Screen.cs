using Board;
using Board.Enums;

namespace CSharpChess
{
    class Screen
    {
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (board.GetPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        PrintPiece(board.GetPiece(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece.Color == Color.White)
            {
                Console.Write(piece);
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = aux;
            }
        }
    }
}