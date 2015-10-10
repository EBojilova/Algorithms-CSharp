namespace _08.BucketSort
{
    using System;
    using System.Collections.Generic;

    // minusa e che raboti samo s chisla, stable, not a comparison sort, similar to Counting Sort
    // will work fast if we use smaller number of buckets and the elements in each bucket are closer
    public static class Program
    {
        private static readonly int[] arr = RandomList(10).ToArray();

        public static void Main()
        {
            PrintNumbers(arr);
            int index = Array.BinarySearch(arr,1);
            BucketSort(3);
            PrintNumbers(arr);
        }

        public static void BucketSort(int bucketCount)
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

            double interval = ((double)(maxValue - minValue + 1)) / bucketCount; //range of one bucket
            //Create a temporary "bucket" to store the values in order
            var bucket = new List<int>[bucketCount];
            //Initialize the bucket
            for (var i = 0; i < bucket.Length; i++)
            {
                bucket[i] = new List<int>();
            }
            //Move items to bucket
            foreach (var value in arr)
            {
                int bucketIndex = (int)((value - minValue) / interval);
                bucket[bucketIndex].Add(value);
            }
            //Move items from the bucket back to the original array in order
            var k = 0; //index for original array
            foreach (var bucketList in bucket)
            {
                if (bucketList.Count <= 0)
                {
                    continue;
                }
                // TODO: to add merge sort from 05
                bucketList.Sort(); //mergeSort??? 
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