namespace Generating01Vectors
{
    using System;

    internal class Vectors01Generator
    {
        private static void Main()
        {
            Console.Write("n = ");
            var n = int.Parse(Console.ReadLine());

            var vector = new int[n];

            Gen01(n - 1, vector);
        }

        private static void Gen01(int index, int[] vector)
        {
            if (index < 0)
            {
                Print(vector);
            }
            else
            {
                for (var i = 0; i <= 1; i++)
                {
                    vector[index] = i;
                    // generirame ot diasno na liavo
                    Gen01(index - 1, vector);
                }
            }
        }

        private static void Print(int[] vector)
        {
            Console.WriteLine(string.Join(" ", vector));
        }
    }
}