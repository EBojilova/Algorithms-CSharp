namespace _07.CountingSort
{
    using System;
    using System.Collections.Generic;

    // minusa e che raboti samo s chisla, stable, not a comparison sort
    public static class CountingSortProgram
    {
        private static readonly int[] arr = RandomList(10).ToArray();

        public static void Main()
        {
            PrintNumbers(arr);
            var sorted = CountingSort(arr);
            PrintNumbers(sorted);
        }

        public static int[] CountingSort(int[] array)
        {
            // find smallest and largest value
            var minVal = array[0];
            var maxVal = array[0];
            for (var i = 1; i < array.Length; i++)
            {
                if (array[i] < minVal)
                {
                    minVal = array[i];
                }
                else if (array[i] > maxVal)
                {
                    maxVal = array[i];
                }
            }

            // init array of frequencies
            var counts = new int[maxVal - minVal + 1];

            // count the frequencies
            foreach (int value in array)
            {
                counts[value - minVal]++;
            }
            //PrintNumbers(counts);

            // recalculate- counted keeps the indexes of the values in the sorted array
            counts[0]--;
            for (var i = 1; i < counts.Length; i++)
            {
                counts[i] = counts[i] + counts[i - 1];
            }
            PrintNumbers(counts);

            var sortedArray = new int[array.Length];

            // Sort the array increasing
            for (var i = array.Length - 1; i >= 0; i--)
            {
                // 1) look up in the array of occurences the last occurence of the given value
                var value = array[i] - minVal;
                var sortedIndex = counts[value];
                // 2) place it into the sorted array
                sortedArray[sortedIndex] = array[i];
                // 3) decrement the index of the last occurence of the given value
                counts[value]--;
            }

            return sortedArray;
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