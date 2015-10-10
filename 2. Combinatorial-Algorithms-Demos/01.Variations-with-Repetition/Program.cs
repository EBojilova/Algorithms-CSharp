namespace _01.Variations_with_Repetition
{
    using System;

    internal class Program
    {
        public static int loopsK = 4;

        public static int iterationsN = 2;

        public static int[] array = new int[iterationsN];

        private static void Main(string[] args)
        {
            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index >= iterationsN)
            {
                Print(array);
            }
            else
            {
                for (var i = 0; i < loopsK; i++)
                {
                    array[index] = i;
                    GenerateVariations(index + 1);
                }
            }
        }

        private static void Print(int[] ints)
        {
            Console.WriteLine(string.Join(", ", ints));
        }
    }
}