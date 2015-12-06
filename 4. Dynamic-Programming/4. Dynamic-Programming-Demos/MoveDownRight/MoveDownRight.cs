namespace MoveDownRight
{
    using System;

    internal class MoveDownRight
    {
        private static readonly int[,] cells =
            {
                { 2, 6, 1, 8, 9, 4, 2 }, 
                { 1, 8, 0, 3, 5, 6, 7 },
                { 3, 4, 8, 7, 2, 1, 8 }, 
                { 0, 9, 2, 8, 1, 7, 9 },
                { 2, 7, 1, 9, 7, 8, 2 }, 
                { 4, 5, 6, 1, 2, 5, 6 },
                { 9, 3, 5, 2, 8, 1, 9 }, 
                { 2, 3, 4, 1, 7, 2, 8 }
            };

        private static readonly int rowsCount = cells.GetLength(0);

        private static readonly int colsCount = cells.GetLength(1);

        private static readonly long[,] sum = new long[rowsCount, colsCount];

        private static readonly bool[,] isCellOnPath = new bool[rowsCount, colsCount];

        private static void Main()
        {
            
            Console.WriteLine("Matrix of the subsums");
            CalculateTheMaximumSums();

            Console.WriteLine();
            MarkThePathFromBottomRigthCornerToTopLeftCorner();

            PrintMatrixAndMaxSum();
        }

        private static void CalculateTheMaximumSums()
        {
            // Calculate sum[,] - the maximum sums 
            for (var row = 0; row < rowsCount; row++)
            {
                for (var col = 0; col < colsCount; col++)
                {
                    var maxPrevCell = long.MinValue;
                    if (col > 0 && sum[row, col - 1] > maxPrevCell)
                    {
                        maxPrevCell = sum[row, col - 1];
                    }
                    if (row > 0 && sum[row - 1, col] > maxPrevCell)
                    {
                        maxPrevCell = sum[row - 1, col];
                    }
                    sum[row, col] = cells[row, col];
                    if (maxPrevCell != long.MinValue)
                    {
                        sum[row, col] += maxPrevCell;
                    }
                    Console.Write("{0, 3}", sum[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MarkThePathFromBottomRigthCornerToTopLeftCorner()
        {
            // Mark the path from bottom-Right corner to the top-left corner
            var row = rowsCount - 1;
            var col = colsCount - 1;
            while (row >= 0 && col >= 0)
            {
                isCellOnPath[row, col] = true;
                if (col > 0 && sum[row, col] == sum[row, col - 1] + cells[row, col])
                {
                    col--;
                }
                else
                {
                    row--;
                }
            }
        }

        private static void PrintMatrixAndMaxSum()
        {
            // Print the path in the matrix
            for (var row = 0; row < rowsCount; row++)
            {
                for (var col = 0; col < colsCount; col++)
                {
                    if (isCellOnPath[row, col])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    Console.Write("{0, 3}", cells[row, col]);
                }
                Console.WriteLine();
            }

            // Print the max sum in the matrix
            Console.WriteLine();
            Console.WriteLine("Max sum = {0}", sum[cells.GetLength(0) - 1, cells.GetLength(1) - 1]);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine();
        }
    }
}