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
                    Console.Write("Origem: ");
                    Position origin = Screen.ReadChessPosition().ToPosition();

                    Console.Write("Destino: ");
                    Position destiny = Screen.ReadChessPosition().ToPosition();

                    match.MakeMovement(origin, destiny);
                }

                Screen.PrintBoard(match.Board);
            }
            catch (ChessBoardException e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}