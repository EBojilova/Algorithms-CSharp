namespace PascalTriangle
{
    using System;

    internal class PascalTriangle
    {
        private static void Main()
        {
            var iterationsN = 10;
            var pascal = new decimal[iterationsN + 1];

            for (var row = 0; row <= iterationsN; row++)
            {
                for (var col = row; col >= 0; col--)
                {
                    if (col == 0 || col == row)
                    {
                        pascal[col] = 1;
                    }
                    else
                    {
                        pascal[col] = pascal[col] + pascal[col - 1];
                    }
                    Console.Write(pascal[col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}