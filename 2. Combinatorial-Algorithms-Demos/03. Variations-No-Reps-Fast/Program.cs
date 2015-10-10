namespace _03.Variations_No_Reps_Fast
{
    using System;

    internal class VariationsNoRepsSlow
    {
        private const int loopsK = 3;

        private const int iterationsN = 4;

        private static readonly int[] array = new int[loopsK];

        private static readonly int[] free = { 100, 200, 300, 400};

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
                // itterations is till n-index
                for (var i = 0; i < iterationsN - index; i++)
                {
                    array[index] = free[i];
                    Swap(ref free[i], ref free[iterationsN - index - 1]);
                    GenerateVariationsNoRepetitions(index + 1);
                    Swap(ref free[i], ref free[iterationsN - index - 1]);
                }
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            var temp = first;
            first = second;
            second = temp;
        }

        private static void PrintVariations()
        {
            Console.WriteLine("({0})", string.Join(", ", array));
        }
    }
}