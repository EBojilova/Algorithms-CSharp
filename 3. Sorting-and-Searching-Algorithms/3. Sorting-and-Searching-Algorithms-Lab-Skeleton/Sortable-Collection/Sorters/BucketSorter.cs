namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class BucketSorter : ISorter<int>
    {
        private int bucketCount;

        public BucketSorter(int bucketCount)
        {
            this.BucketCount = bucketCount;
        }

        public int BucketCount
        {
            get
            {
                return this.bucketCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Value must be >= 1.");
                }
                this.bucketCount = value;
            }
        }

        public void Sort(List<int> collection)
        {
            if (this.BucketCount ==1)
            {
                MyQuickSort(collection, 0, collection.Count);
            }
            else
            {
                BucketSort(collection, this.BucketCount);
            }
        }

        public static void BucketSort(List<int> collection, int bucketCount)
        {
            //Verify input
            if (collection == null || collection.Count == 0)
            {
                return;
            }
            //Find the maximum and minimum values in the array
            long maxValue = collection[0]; //start with first element
            long minValue = collection[0];
            //Note: start from index 1
            for (var i = 1; i < collection.Count; i++)
            {
                if (collection[i] > maxValue)
                {
                    maxValue = collection[i];
                }
                if (collection[i] < minValue)
                {
                    minValue = collection[i];
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
            foreach (var value in collection)
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
                    collection[k] = value;
                    k++;
                }
            }
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

        private static void Swap(List<int> currentArray, int left, int right)
        {
            var temp = currentArray[left];
            currentArray[left] = currentArray[right];
            currentArray[right] = temp;
        }
    }
}