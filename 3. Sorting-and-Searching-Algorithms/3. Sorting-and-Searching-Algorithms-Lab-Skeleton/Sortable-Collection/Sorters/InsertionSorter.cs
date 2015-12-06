namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class InsertionSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            InsertionSort(collection);
        }

        private static void InsertionSort(List<T> collection)
        {
            for (var i = 1; i < collection.Count; i++)
            {
                var j = i;
                while (j > 0 && collection[j].CompareTo(collection[j - 1]) < 0)
                {
                    Swap(collection, j - 1, j);
                    j--;
                }
            }
        }

        private static void Swap(IList<T> collection, int current, int minIndex)
        {
            var temp = collection[current];
            collection[current] = collection[minIndex];
            collection[minIndex] = temp;
        }
    }
}