namespace _02.Variations_with_Repetition_Iterative
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
                // Start from 0,0,0...
                Print(array);
                var index = iterationsN - 1;
                //If the last element reaches its maximum, i.e.iterationsN - 1
                while (index >= 0 && array[index] == loopsK - 1)
                {
                    //increment the element of the left
                    index--;
                }
                if (index < 0)
                {
                    // all elements have reached their maximum
                    break;
                }
                // increment the last element
                array[index]++;
                // make 0 the elements on the right
                for (var i = index + 1; i < iterationsN; i++)
                {
                    array[i] = 0;
                }
            }
        }

        private static void Print(int[] ints)
        {
            Console.WriteLine(string.Join(", ", ints));
        }
    }
}