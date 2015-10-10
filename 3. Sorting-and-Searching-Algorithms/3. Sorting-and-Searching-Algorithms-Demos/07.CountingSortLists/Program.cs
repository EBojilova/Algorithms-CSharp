namespace _08.BucketSort
{
    using System;
    using System.Collections.Generic;

    // minusa e che raboti samo s chisla, stable, not a comparison sort, similar to Counting Sort
    public static class Program
    {
        private static readonly int[] arr = RandomList(10).ToArray();

        public static void Main()
        {
            PrintNumbers(arr);
            BucketSort();
            PrintNumbers(arr);
        }

        public static void BucketSort()
        {
            //Verify input
            if (arr == null || arr.Length == 0)
            {
                return;
            }
            //Find the maximum and minimum values in the array
            var maxValue = arr[0]; //start with first element
            var minValue = arr[0];
            //Note: start from index 1
            for (var i = 1; i < arr.Length; i++)
            {
                if (arr[i] > maxValue)
                {
                    maxValue = arr[i];
                }
                if (arr[i] < minValue)
                {
                    minValue = arr[i];
                }
            }
            //Create a temporary "bucket" to store the values in order
            //each value will be stored in its corresponding index
            //e.g. 34 => index at 34 - minValue
            var bucket = new List<int>[maxValue - minValue + 1];
            //Initialize the bucket
            for (var i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }
            //Move items to bucket
            foreach (var value in arr)
            {
                bucket[value - minValue].Add(value);
            }
            //Move items in the bucket back to the original array in order
            var k = 0; //index for original array
            foreach (var bucketList in bucket)
            {
                if (bucketList.Count <= 0)
                {
                    continue;
                }
                foreach (var value in bucketList)
                {
                    arr[k] = value;
                    k++;
                }
            }
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