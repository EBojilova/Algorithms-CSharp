namespace LongestCommonSubsequence
{
    using System;
    using System.Collections.Generic;

    internal class LongestCommonSubsequence
    {
        private const int NOT_CALCULATED = -1;

        private static readonly string rowsString = "GCGCAATG";

        private static readonly string colsString = "GCCCTAGCG";

        // Longest Common Subsequence (LCS)
        private static readonly int[,] lcs = new int[rowsString.Length, colsString.Length];

        private static void Main()
        {
            InitializeLCS();
            CalculateLCS(rowsString.Length - 1, colsString.Length - 1);
            PrintLCSmatrixCalculations();
            PrintLCS(rowsString.Length - 1, colsString.Length - 1);
        }

        private static void PrintLCSmatrixCalculations()
        {
            Console.Write("  ");
            Console.WriteLine(string.Join(" ", colsString.ToCharArray()));
            for (var row = 0; row < lcs.GetLength(0); row++)
            {
                Console.Write("{0} ", rowsString[row]);
                for (var col = 0; col < lcs.GetLength(1); col++)
                {
                    Console.Write("{0} ", lcs[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void InitializeLCS()
        {
            for (var row = 0; row < rowsString.Length; row++)
            {
                for (var col = 0; col < colsString.Length; col++)
                {
                    lcs[row, col] = NOT_CALCULATED;
                }
            }
        }

        private static int CalculateLCS(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                return 0;
            }

            // Memoization
            if (lcs[row, col] == NOT_CALCULATED)
            {
                var lcsFirstMinusOne = CalculateLCS(row - 1, col);
                var lcsSecondMinusOne = CalculateLCS(row, col - 1);
                lcs[row, col] = Math.Max(lcsFirstMinusOne, lcsSecondMinusOne);
                if (rowsString[row] == colsString[col])
                {
                    var lcsBothMinusOne = 1 + CalculateLCS(row - 1, col - 1);
                    lcs[row, col] = Math.Max(lcs[row, col], lcsBothMinusOne);
                }
            }

            return lcs[row, col];
        }

        private static void PrintLCS(int row, int col)
        {
            //Console.WriteLine("LCS = " + CalculateLCS(row, col));
             Console.WriteLine("LCS = {0}" ,lcs[row,col]);

            var lcsLetters = new List<char>();
            while (row >= 0 && col >= 0)
            {
                if ((rowsString[row] == colsString[col]) && (CalculateLCS(row - 1, col - 1) + 1 == lcs[row, col]))
                {
                    lcsLetters.Add(rowsString[row]);
                    row--;
                    col--;
                }
                else if (CalculateLCS(row - 1, col) == lcs[row, col])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }
            lcsLetters.Reverse();
            var lcsStr = string.Join("", lcsLetters);
            Console.WriteLine(lcsStr);
        }
    }
}