namespace LongestIncreasingSubsequence
{
    using System;
    using System.Collections.Generic;

    internal class LongestIncreasingSubsequence
    {
        private const int NO_PREVIOUS = -1;

        private static readonly int[] sequence = { 3, 4, 8, 1, 2, 4, 32, 6, 2, 5, 33, 4, 38, 22 };

        // LIS- longest increasing subsequence
        // len[i] = length of the LIS ending at the element seq[i]
        private static readonly int[] lenghts = new int[sequence.Length];

        // we keep the previous index of the lengthts
        private static readonly int[] previousIndex = new int[sequence.Length];

        private static void Main()
        {
            var bestIndex = CalculateLongestIncreasingSubsequence();
            Console.WriteLine("Best index: {0}", bestIndex);

            Console.WriteLine("sequence[]  = " + string.Join(", ", sequence));
            Console.WriteLine("lenghts[]  = " + string.Join(", ", lenghts));
            Console.WriteLine("previousIndex[] = " + string.Join(", ", previousIndex));

            PrintLongestIncreasingSubsequence(bestIndex);
        }

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
                    if (sequence[previous] < sequence[i] && 1 + lenghts[previous] > lenghts[i])
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
            return indexOfLIS;
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