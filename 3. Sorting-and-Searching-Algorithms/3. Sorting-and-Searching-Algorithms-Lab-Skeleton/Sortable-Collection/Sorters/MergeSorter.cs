namespace Sortable_Collection.Sorters
{
    using System;
    using System.Collections.Generic;

    using Sortable_Collection.Contracts;

    public class MergeSorter<T> : ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(List<T> collection)
        {
            var result = MergeSort(collection);
            for (var i = 0; i < result.Count; i++)
            {
                collection[i] = result[i];
            }
        }

        private static List<T> MergeSort(List<T> input)
        {
            if (input.Count <= 1)
            {
                return input;
            }

            var midpoint = input.Count / 2;
            var left = new List<T>();
            var right = new List<T>();

            for (var i = 0; i < midpoint; i++)
            {
                left.Add(input[i]);
            }

            for (var i = midpoint; i < input.Count; i++)
            {
                right.Add(input[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<T> Merge(IReadOnlyList<T> left, IReadOnlyList<T> right)
        {
            var result = new List<T>();
            // http://codereview.stackexchange.com/questions/30545/merge-sort-implementation
            var leftIndex = 0;
            var rightIndex = 0;
            while (left.Count > leftIndex && right.Count > rightIndex)
            {
                if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    result.Add(left[leftIndex]);
                    leftIndex++;
                }
                else
                {
                    result.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            while (left.Count > leftIndex)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }

            while (right.Count > rightIndex)
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }

            return result;
        }
    }
}