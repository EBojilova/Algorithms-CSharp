namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class Quicksorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            MyQuickSort(collection, 0, collection.Count);
        }

        private static void MyQuickSort(IList<T> collection, int left, int right)
        {
            if (collection == null || collection.Count <= 1)
            {
                return;
            }

            if (left >= right)
            {
                return;
            }

            var pivotIdx = FindPivotIndex(collection, left, right);
            MyQuickSort(collection, left, pivotIdx - 1);
            MyQuickSort(collection, pivotIdx, right);
        }

        private static int FindPivotIndex(IList<T> collection, int left, int right)
        {
            //We pick a pivot element, this is the first element of an unsorted partition. 
            //The goal is to move the pivot to its correct place in the array. 
            // minus ako pivota e v kraia
            var start = left;
            var pivot = collection[start];

            // veche sme vaveli che pivota e collection[storeIndex] i ste pravim proverki kato sapostaviame stoinostite
            left++;
            // zaradi rekursiata pochvame s edin znak navan collection.Count
            right--;

            while (true)
            {
                while (left <= right && collection[left].CompareTo(pivot) <= 0)
                {
                    left++;
                }

                while (left <= right && collection[right].CompareTo(pivot) > 0)
                {
                    right--;
                }

                // left-right=1;
                // right==left-1
                if (left > right)
                {
                    // move the pivot to its correct place in the array
                    collection[start] = collection[left - 1];
                    collection[left - 1] = pivot;

                    return left;
                }

                // razmeniame mestata na stoinostite ot liavo i ot diasno na pivota-t.e sortirame ot liavo i diasno na pivota
                Swap(collection, left, right);
            }
        }

        private static void Swap(IList<T> collection, int left, int right)
        {
            var temp = collection[left];
            collection[left] = collection[right];
            collection[right] = temp;
        }
    }
}