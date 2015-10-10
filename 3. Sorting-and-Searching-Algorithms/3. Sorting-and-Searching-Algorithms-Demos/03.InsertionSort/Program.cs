namespace _01.SelectionSort_Slow
{
    using System;

    internal class Program
    {
        public static int[] arr = { 2, 6, 9, 1, 0 };

        // slow but stable, mostly used together with selection sort(unstable)
        private static void Main(string[] args)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var j = i;
                while (j > 0)
                {
                    if (arr[j - 1] > arr[j])
                    {
                        Swap(j-1, j);
                        j--;
                    }
                    else
                    {
                        break;
                    }
                }

                Console.WriteLine(string.Join(" ", arr));

                Console.ReadKey();
            }
        }

        private static void Swap(int current, int minIndex)
        {
            var temp = arr[current];
            arr[current] = arr[minIndex];
            arr[minIndex] = temp;
        }
    }
}