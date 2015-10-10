namespace _03.Variations_without_Repetition
{
    using System;

    internal class Program
    {
        public static int loopsK = 4;

        public static int iterationsN = 2;

        public static int[] arrray = new int[iterationsN];

        public static bool[] used = new bool[loopsK];

        private static void Main(string[] args)
        {
            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index >= iterationsN)
            {
                Print(arrray);
            }
            else
            {
                for (var i = 0; i < loopsK; i++)
                {
                    if (used[i])
                    {
                        continue;
                    }
                    used[i] = true;
                    arrray[index] = i;
                    GenerateVariations(index + 1);
                    used[i] = false;
                }
            }
        }

        private static void Print(int[] ints)
        {
            Console.WriteLine(string.Join(", ", ints));
        }
    }
}