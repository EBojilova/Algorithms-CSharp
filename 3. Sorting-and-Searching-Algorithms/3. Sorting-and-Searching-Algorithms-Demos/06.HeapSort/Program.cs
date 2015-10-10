namespace _06.HeapSort
{
    using System;
    using System.Collections.Generic;

    // tova e variant na selection sort, unstable
    public static class Program
    {
        private static readonly int[] arr = RandomList(10).ToArray();

        private static int unsortedIndex = arr.Length - 1;

        public static void Main()
        {
            PrintNumbers(arr);
            BuildHeap();
            //PrintNumbers(arr);
            var hasSwapped = true;
            while (unsortedIndex >= 0 && hasSwapped)
            {
                hasSwapped = false;
                if (arr[0] != arr[unsortedIndex])
                {
                    hasSwapped = true;
                    // In the heap the max is always first, so we put it 
                    Swap(0, unsortedIndex);
                }
                unsortedIndex--;
                Heapify(0);
                //PrintNumbers(arr);
            }
            PrintNumbers(arr);
        }

        private static void BuildHeap()
        {
            for (var i = arr.Length - 1 / 2; i >= 0; i--)
            {
                Heapify(i);
                //PrintNumbers(arr);
            }
        }

        private static void Heapify(int i)
        {
            var left = 2 * i + 1;
            var right = 2 * i + 2;
            var maxIndex = i;
            if (left <= unsortedIndex && arr[left] > arr[i])
            {
                maxIndex = left;
            }

            if (right <= unsortedIndex && arr[right] > arr[maxIndex])
            {
                maxIndex = right;
            }

            if (maxIndex != i)
            {
                Swap(i, maxIndex);
                Heapify(maxIndex);
            }
        }

        private static void Swap(int x, int y) //function to swap elements
        {
            var temp = arr[x];
            arr[x] = arr[y];
            arr[y] = temp;
        }

        private static List<int> RandomList(int size)
        {
            var numbers = new List<int>(size);
            var rand = new Random(1);
            for (var i = 0; i < size; i++)
            {
                numbers.Add(rand.Next(size));
            }
            return numbers;
        }

        private static void PrintNumbers(IEnumerable<int> array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}