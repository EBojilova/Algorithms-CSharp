namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class HeapSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        private static int unsortedIndex;

        public void Sort(List<T> collection)
        {
            unsortedIndex = collection.Count - 1;
            BuildHeap(collection);
            var hasSwapped = true;
            while (unsortedIndex >= 0 && hasSwapped)
            {
                hasSwapped = false;
                if (collection[0].CompareTo(collection[unsortedIndex]) != 0)
                {
                    hasSwapped = true;
                    // In the heap the max is always first, so we put it 
                    Swap(collection, 0, unsortedIndex);
                }
                unsortedIndex--;
                Heapify(collection, 0);
                //PrintNumbers(collection);
            }
        }

        private static void BuildHeap(IList<T> collection)
        {
            for (var i = collection.Count - 1 / 2; i >= 0; i--)
            {
                Heapify(collection, i);
                //PrintNumbers(collection);
            }
        }

        private static void Heapify(IList<T> collection, int i)
        {
            var leftIndex = 2 * i + 1;
            var rightIndex = 2 * i + 2;
            var maxIndex = i;
            if (leftIndex <= unsortedIndex && collection[leftIndex].CompareTo(collection[i]) > 0)
            {
                maxIndex = leftIndex;
            }

            if (rightIndex <= unsortedIndex && collection[rightIndex].CompareTo(collection[maxIndex]) > 0)
            {
                maxIndex = rightIndex;
            }

            if (maxIndex != i)
            {
                // the sorting is done here
                Swap(collection, i, maxIndex);
                Heapify(collection, maxIndex);
            }
        }

        private static void Swap(IList<T> collection, int x, int y) //function to swap elements
        {
            var temp = collection[x];
            collection[x] = collection[y];
            collection[y] = temp;
        }
    }
}