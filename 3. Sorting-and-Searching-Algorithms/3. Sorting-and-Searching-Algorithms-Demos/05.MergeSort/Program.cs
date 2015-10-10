namespace _05.MergeSort
{
    using System;
    using System.Collections.Generic;

    // Highly parallelizable on multiple cores / machines 
    public static class MergeSort
    {
        private static readonly List<int> arr = RandomList(10);

        public static void Main()
        {
            PrintNumbers(arr);
            var sorted = Sort(arr);
            PrintNumbers(sorted);
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

        public static List<int> Sort(List<int> input)
        {
            if (input.Count <= 1)
            {
                return input;
            }

            var midpoint = input.Count / 2;
            var left = new List<int>();
            var right = new List<int>();

            for (var i = 0; i < midpoint; i++)
            {
                left.Add(input[i]);
            }

            for (var i = midpoint; i < input.Count; i++)
            {
                right.Add(input[i]);
            }

            left = Sort(left);
            right = Sort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(IReadOnlyList<int> left, IReadOnlyList<int> right)
        {
            var result = new List<int>();
            // http://codereview.stackexchange.com/questions/30545/merge-sort-implementation
            int leftIndex = 0;
            int rightIndex = 0;
            while (left.Count > leftIndex && right.Count > rightIndex)
            {
                if (left[leftIndex] < right[rightIndex])
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

        private static void PrintNumbers(IEnumerable<int> array)
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}