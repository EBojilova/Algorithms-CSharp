namespace Variations_Iterative
{
    using System;

    internal class VariationsIterative
    {
        private static void Main()
        {
            var iterationsN = 5;
            var loopK = 3;
            var arrray = new int[loopK];

            while (true)
            {
                Print(arrray);
                var digitIndex = loopK - 1;
                while (digitIndex >= 0 && arrray[digitIndex] == iterationsN - 1)
                {
                    digitIndex--;
                }
                if (digitIndex < 0)
                {
                    break;
                }
                arrray[digitIndex]++;
                for (var i = digitIndex + 1; i < loopK; i++)
                {
                    arrray[i] = 0;
                }
            }
        }

        private static void Print(int[] array)
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}