using Board;
using Board.Enums;
using CSharpChess.Chess;

namespace CSharpChess
{
    class Screen
    {

        public static void PrintMatch(Match match)
        {
            PrintBoard(match.Board);
            Console.WriteLine();
            PrintCapturedPieces(match);
            Console.WriteLine();
            Console.WriteLine($"Round: {match.Round}");

            if (!match.Finished)
            {
                Console.WriteLine($"Waiting for move: {match.CurrentPlayer}");
                if (match.Check)
                {
                    Console.WriteLine("CHECK!!!");

                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!!!");
                Console.WriteLine($"Winner: {match.CurrentPlayer}");
            }


        }

        public static void PrintCapturedPieces(Match match)
        {
            Console.WriteLine("Captured pieces:");
            Console.Write("White: ");
            PrintPieces(match.GetCapturedPieces(Color.White));
            Console.WriteLine("");
            Console.Write(" Black: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            PrintPieces(match.GetCapturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine("");
        }

        public static void PrintPieces(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece piece in pieces)
            {
                Console.Write($"{piece} ");
            }
            Console.Write("]");
        }

        public static ChessPosition ReadChessPosition()
        {
            string s = Console.ReadLine();

            char column = s[0];
            int row = int.Parse(s[1] + "");

            return new ChessPosition(column, row);
        }
        public static void PrintBoard(ChessBoard board)
        {
            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    PrintPiece(board.GetPiece(i, j));
                }
                Console.WriteLine("");
            }
            Console.WriteLine("  A B C D E F G H");
        }

        public static void PrintBoard(ChessBoard board, bool[,] possiblePositions)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor customBackground = ConsoleColor.DarkGray;


            for (int i = 0; i < board.Rows; i++)
            {
                Console.Write($"{8 - i} ");
                for (int j = 0; j < board.Columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = customBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;

                    }
                    PrintPiece(board.GetPiece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine("");
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = originalBackground;
        }

        public static void PrintPiece(Piece piece)
        {
            if (piece == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }

    }
}