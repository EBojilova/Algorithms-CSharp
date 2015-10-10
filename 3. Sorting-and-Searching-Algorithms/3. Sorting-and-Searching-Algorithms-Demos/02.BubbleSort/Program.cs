namespace _01.SelectionSort_Slow
{
    using System;

    internal class Program
    {
        public static int[] arr = { 2, 6, 9, 1, 0 };

        // slow but stable
        private static void Main(string[] args)
        {
            var swaped = false;
            do
            {
                swaped = false;
                for (var sort = 0; sort < arr.Length - 1; sort++)
                {
                    if (arr[sort] <= arr[sort + 1])
                    {
                        continue;
                    }
                    Swap(sort + 1, sort);
                    swaped = true;
                }
            }
            while (swaped);

            Console.WriteLine(string.Join(" ", arr));

            Console.ReadKey();
        }

        private static void Swap(int current, int minIndex)
        {
            var temp = arr[current];
            arr[current] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
}