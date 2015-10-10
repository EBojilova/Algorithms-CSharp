namespace _02.Variations_with_Incremention
{
    using System;

    internal class Program
    {
        public static int loopsK = 4;

        public static int iterationsN = 2;

        public static int[] array = new int[iterationsN];

        private static void Main(string[] args)
        {
            while (true)
            {
                Print(array);

                var i = iterationsN - 1;

                while (i >= 0)
                {
                    // uvelichavam stoinosta na kletkata
                    array[i]++;
                    if (array[i] == loopsK)
                    {
                        // setvam na 0 kletkata ot diasno
                        array[i] = 0;
                        // preminavam na liavo
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
                if (i < 0)
                {
                    break;
                }
            }
        }

        private static void Print(int[] ints)
        {
            Console.WriteLine(string.Join(", ", ints));
        }
    }
}