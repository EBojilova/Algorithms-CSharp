namespace _07.Queens_8queensPuzzlePermutation
{
    using System;

    internal class Backtracking

    {
        private const int Size = 8;

        private static readonly int[] Chessboard = new int[Size];

        private static int solutionsFound;

        private static void Main(string[] args)
        {
            PutQueens(0);
            Console.WriteLine(solutionsFound);
        }

        private static void PutQueens(int row)
        {
            if (row == Size)
            {
                PrintBoard();
                solutionsFound++;
            }

            else
            {
                for (var col = 0; col < Size; col++)
                {
                    // zapazvame kato stoinosti value
                    Chessboard[row] = col;
                    if (CanPlaceQueen(row))
                    {
                        PutQueens(row + 1);
                    }
                }
            }
        }

        private static bool CanPlaceQueen(int row)
        {
            // proveriavame samo do indexa row, tai kato na tam sme siguri, che niama da ima zaeti kletki
            for (var col = 0; col < row; col++)
            {
                if (Chessboard[col] == Chessboard[row])
                {
                    return false; // same column
                }
                if ((Chessboard[col] - Chessboard[row]) == (row - col))
                {
                    return false; // same major left diagonal
                }
                if ((Chessboard[row] - Chessboard[col]) == (row - col))
                {
                    return false; // same minor right diagonal
                }
            }
            return true;
        }

        private static void PrintBoard()
        {
            for (var row = 0; row < Size; row++)
            {
                //Console.Write(Chessboard[row]);
                for (var col = 0; col < Size; col++)
                {
                    // slagame carica samo ako stoinosta na kletkata savpada s value
                    Console.Write(Chessboard[row] == col ? "Q " : "- ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}