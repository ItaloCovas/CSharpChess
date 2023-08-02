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
                Match match = new Match();

                while (!match.Finished)
                {
                    Console.Clear();
                    Screen.PrintBoard(match.Board);
                    Console.WriteLine();
                    Console.WriteLine($"Round: {match.Round}");
                    Console.WriteLine($"Waiting for move: {match.CurrentPlayer}");



                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    bool[,] possiblePositions = match.Board.GetPiece(origin).PossibleMovements();


                    Console.Clear();
                    Screen.PrintBoard(match.Board, possiblePositions);

                    Console.WriteLine();

                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.MakeMove(origin, destiny);
                }
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e);
                Console.WriteLine(e.Message);
            }
        }
    }
}