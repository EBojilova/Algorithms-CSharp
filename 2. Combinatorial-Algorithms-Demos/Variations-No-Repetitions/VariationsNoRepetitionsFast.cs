namespace Variations_No_Repetitions
{
    using System;

    internal class VariationsNoRepetitionsFast
    {
        private const int loopsK = 3;

        private const int iterationsN = 4;

        private static readonly int[] array = new int[loopsK];

        private static readonly int[] free = new int[iterationsN] { 1, 2, 3, 4 };

        private static void Main()
        {
            GenerateVariationsNoRepetitions(0);
        }

        private static void GenerateVariationsNoRepetitions(int index)
        {
            if (index >= loopsK)
            {
                PrintVariations();
            }
            else
            {
                for (var i = index; i < iterationsN; i++)
                {
                    array[index] = free[i];
                    Swap(ref free[i], ref free[index]);
                    GenerateVariationsNoRepetitions(index + 1);
                    Swap(ref free[i], ref free[index]);
                }
            }
        }

        private static void Swap(ref int v1, ref int v2)
        {
            var old = v1;
            v1 = v2;
            v2 = old;
        }

        private static void PrintVariations()
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}