namespace LongestIncreasingSubsequenceRecursive
{
    using System;
    using System.Collections.Generic;

    internal class LongestIncreasingSubsequenceRecursive
    {
        private const int NO_PREVIOUS = -1;

        private static readonly int[] sequence = { 3, 4, 8, 1, 2, 4, 32, 6, 2, 5, 33, 4, 38, 22 };

        private static readonly int[] lenghts = new int[sequence.Length];

        private static readonly int[] previousIndex = new int[sequence.Length];

        private static int bestLenghtOfLIS = -1;

        private static int indexOfLIS = -1;

        private static void Main()
        {
            //for (var i = 0; i < sequence.Length; i++)
            //{
            //    previousIndex[i] = NO_PREVIOUS;
            //}

            for (var i = 0; i < sequence.Length; i++)
            {
                CalcLongestIncreasingSubsequence(i);
            }

            Console.WriteLine("sequence = " + string.Join(", ", sequence));
            Console.WriteLine("lenghts = " + string.Join(", ", lenghts));
            Console.WriteLine("previousIndex = " + string.Join(", ", previousIndex));

            //var indexOfLIS = FindMaxElementIndex(lenghts);

            PrintLongestIncreasingSubsequence(indexOfLIS);
        }

        // Recursive
        private static void CalcLongestIncreasingSubsequence(int i)
        {
            if (lenghts[i] > 0)
            {
                // Memoization: if aLready calculated --> exit
                return;
            }

            lenghts[i] = 1;
            previousIndex[i] = NO_PREVIOUS;
            for (var previous = 0; previous <= i - 1; previous++)
            {
                if (sequence[previous] < sequence[i])
                {
                    CalcLongestIncreasingSubsequence(previous);
                    if (1 + lenghts[previous] > lenghts[i])
                    {
                        lenghts[i] = 1 + lenghts[previous];
                        previousIndex[i] = previous;
                        if (lenghts[i] > bestLenghtOfLIS)
                        {
                            bestLenghtOfLIS = lenghts[i];
                            indexOfLIS = i;
                        }
                    }
                }
            }
        }

        // Iterative
        private static int CalculateLongestIncreasingSubsequence()
        {
            var bestLenghtOfLIS = 0;
            var indexOfLIS = 0;
            for (var i = 0; i < sequence.Length; i++)
            {
                lenghts[i] = 1;
                previousIndex[i] = NO_PREVIOUS;
                for (var previous = 0; previous <= i - 1; previous++)
                {
                    // we start setting the values in lengthts and previousIndex
                    if (sequence[previous] < sequence[i])
                    {
                        if (1 + lenghts[previous] > lenghts[i])
                        {
                            lenghts[i] = 1 + lenghts[previous];
                            previousIndex[i] = previous;
                            if (lenghts[i] > bestLenghtOfLIS)
                            {
                                bestLenghtOfLIS = lenghts[i];
                                indexOfLIS = i;
                            }
                        }
                    }
                }
            }
            return indexOfLIS;
        }

        private static int FindMaxElementIndex(int[] seq)
        {
            var maxElement = seq[0];
            var maxElementIndex = 0;
            for (var i = 0; i < seq.Length; i++)
            {
                if (seq[i] > maxElement)
                {
                    maxElement = seq[i];
                    maxElementIndex = i;
                }
            }
            return maxElementIndex;
        }

        private static void PrintLongestIncreasingSubsequence(int index)
        {
            var longestIncreasingSequence = new List<int>();
            while (index != NO_PREVIOUS)
            {
                longestIncreasingSequence.Add(sequence[index]);
                index = previousIndex[index];
            }
            longestIncreasingSequence.Reverse();
            Console.WriteLine("subsequence = [{0}]", string.Join(", ", longestIncreasingSequence));
        }
    }
}