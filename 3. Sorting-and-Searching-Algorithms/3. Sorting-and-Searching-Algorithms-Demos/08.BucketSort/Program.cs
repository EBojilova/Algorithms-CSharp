namespace _08.BucketSort
{
    using System;
    using System.Collections.Generic;

    // minusa e che raboti samo s chisla, stable, not a comparison sort, similar to Counting Sort
    // will work fast if we use smaller number of buckets and the elements in each bucket are closer
    public static class Program
    {
        private static readonly List<int> arr = RandomList(10);

        public static void Main()
        {
            PrintNumbers(arr);
            BucketSort(3);
            PrintNumbers(arr);
        }

        public static void BucketSort(int bucketCount)
        {
            //Verify input
            if (arr == null || arr.Count == 0)
            {
                return;
            }
            //Find the maximum and minimum values in the array
            long maxValue = arr[0]; //start with first element
            long minValue = arr[0];
            //Note: start from index 1
            for (var i = 1; i < arr.Count; i++)
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

            var interval = ((double)(maxValue - minValue + 1)) / bucketCount; //range of one bucket
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
                var bucketIndex = (int)((value - minValue) / interval);
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
                // doing Quick sort for the subList
                MyQuickSort(bucketList, 0, bucketList.Count);
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

        private static void MyQuickSort(List<int> currentArray, int left, int right)
        {
            if (currentArray == null || currentArray.Count <= 1)
            {
                return;
            }

            if (left >= right)
            {
                return;
            }

            var pivotIdx = FindPivotIndex(currentArray, left, right);
            //PrintNumbers(arr);
            MyQuickSort(currentArray, left, pivotIdx - 1);
            MyQuickSort(currentArray, pivotIdx, right);
        }

        private static int FindPivotIndex(List<int> currentArray, int left, int right)
        {
            var start = left;
            // proizvolno izbirame pivot, no e po-dobre da izbrem srednoto mejdu nachalen, kraen i sreden po index element
            // nai-dobre e pivota da e mediana
            // minus ako pivota e v kraia
            var pivot = currentArray[start];

            left++;
            right--;

            while (true)
            {
                while (left <= right && currentArray[left] <= pivot)
                {
                    left++;
                }

                while (left <= right && currentArray[right] > pivot)
                {
                    right--;
                }

                if (left > right)
                {
                    // finalno sortrane ot liavo i ot diasno na pivota
                    currentArray[start] = currentArray[left - 1];
                    currentArray[left - 1] = pivot;

                    return left;
                }

                // razmeniame mestata na stoinostite ot liavo i ot diasno na pivota-t.e sortirame
                Swap(currentArray, left, right);
            }
        }

        private static void Swap(List<int> currentArray,int left, int right)
        {
            var temp = currentArray[left];
            currentArray[left] = currentArray[right];
            currentArray[right] = temp;
        }
    }
}