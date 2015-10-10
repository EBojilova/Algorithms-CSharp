namespace Variations_No_Repetitions
{
    using System;
    using System.Linq;

    internal class VariationsNoRepsSlow
    {
        private const int loopsK = 2;

        private const int iterationsN = 10;

        private static readonly string[] objects = new string[iterationsN]
                                                       {
                                                           "banana", "apple", "orange", "strawberry", "raspberry",
                                                           "apricot", "cherry", "lemon", "grapes", "melon"
                                                       };

        private static readonly int[] array = new int[loopsK];

        private static readonly bool[] used = new bool[iterationsN];

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
                for (var i = 0; i < iterationsN; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        array[index] = i;
                        GenerateVariationsNoRepetitions(index + 1);
                        used[i] = false;
                    }
                }
            }
        }

        private static void PrintVariations()
        {
            Console.WriteLine("({0}) --> ({1})", string.Join(", ", array), string.Join(", ", array.Select(i => objects[i])));
        }
    }
}