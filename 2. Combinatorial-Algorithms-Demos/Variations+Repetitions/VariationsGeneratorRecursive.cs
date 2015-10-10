namespace Variations_Repetitions
{
    using System;
    using System.Linq;

    internal class VariationsGeneratorRecursive
    {
        private const int loopsK = 3;

        private const int iterationsN = 10;

        private static readonly string[] objects = new string[iterationsN]
                                                       {
                                                           "banana", "apple", "orange", "strawberry", "raspberry",
                                                           "apricot", "cherry", "lemon", "grapes", "melon"
                                                       };

        private static readonly int[] array = new int[loopsK];

        private static void Main()
        {
            GenerateVariationsWithRepetitions(0);
        }

        private static void GenerateVariationsWithRepetitions(int index)
        {
            if (index >= loopsK)
            {
                PrintVariations();
            }
            else
            {
                for (var i = 0; i < iterationsN; i++)
                {
                    array[index] = i;
                    GenerateVariationsWithRepetitions(index + 1);
                }
            }
        }

        private static void PrintVariations()
        {
            Console.WriteLine(
                "({0}) --> ({1})",
                string.Join(", ", array),
                string.Join(", ", array.Select(i => objects[i])));
        }
    }
}