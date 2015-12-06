namespace Bridges
{
    using System;
    using System.Linq;

    internal class Program
    {
        private const int NOT_CALCULATED = -1;

        private static int[] north;

        private static int[] south;

        // Longest Common Subsequence (LCS)== maxBridges
        private static int[,] maxBridges;

        private static void Main(string[] args)
        {
            north = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            south = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            InitializeLCS();
            CalculateLCS(north.Length - 1, south.Length - 1);
            //PrintLCSmatrixCalculations();
            Console.WriteLine(maxBridges[north.Length - 1, south.Length - 1]);
        }

        private static void InitializeLCS()
        {
            maxBridges = new int[north.Length, south.Length];
            for (var row = 0; row < north.Length; row++)
            {
                for (var col = 0; col < south.Length; col++)
                {
                    maxBridges[row, col] = NOT_CALCULATED;
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
            if (maxBridges[row, col] == NOT_CALCULATED)
            {
                var lcsNorthMinusOne = CalculateLCS(row - 1, col);
                var lcsSouthMinusOne = CalculateLCS(row, col - 1);
                var maxBridgesLeft = Math.Max(lcsNorthMinusOne, lcsSouthMinusOne);
                // tai kato moje ot edno miasto da tragvat niakolko bridge- zadachata se razlichava ot 7. LongestCommonSubsequence
                if (north[row] == south[col])
                {
                    maxBridges[row, col] = 1 + maxBridgesLeft;
                }
                else
                {
                    maxBridges[row, col] = maxBridgesLeft;
                }
            }

            return maxBridges[row, col];
        }

        private static void PrintLCSmatrixCalculations()
        {
            Console.Write("  ");
            Console.WriteLine(string.Join(" ", south));
            for (var row = 0; row < maxBridges.GetLength(0); row++)
            {
                Console.Write("{0} ", north[row]);
                for (var col = 0; col < maxBridges.GetLength(1); col++)
                {
                    Console.Write("{0} ", maxBridges[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}