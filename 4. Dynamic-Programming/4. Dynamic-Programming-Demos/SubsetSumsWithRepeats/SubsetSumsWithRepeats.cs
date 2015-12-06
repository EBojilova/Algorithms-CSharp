namespace SubsetSumsBetter
{
    using System;
    using System.Collections.Generic;

    internal class SubsetSumsWithRepeats
    {
        private const int TargetSum = 50;

        private static readonly int[] numbers = { 2, 5, 10 };

        // the indexes will be from 0 to TargetSum
        // this will keep information about all sums smaller than TargetSum
        private static readonly bool[] isPossibleSum = new bool[TargetSum + 1];

        private static void Main(string[] args)
        {
            CalcPossibleSums();

            PrintSubset();
        }

        private static void CalcPossibleSums()
        {
            // we give true to index 0, so we can enter the loop first time
            // index==possible sum
            isPossibleSum[0] = true;
            for (var sum = 0; sum < isPossibleSum.Length; sum++)
            {
                if (isPossibleSum[sum])
                {
                    foreach (var number in numbers)
                    {
                        var newSum = sum + number;
                        if (newSum <= TargetSum)
                        {
                            isPossibleSum[newSum] = true;
                        }
                    }
                }
            }
        }

        private static void PrintSubset()
        {
            // Print subset
            if (isPossibleSum[TargetSum])
            {
                var subset = FindSubset(TargetSum);
                Console.WriteLine("{0} = {1}", TargetSum, string.Join(" + ", subset));
            }
            else
            {
                Console.WriteLine("Not possible sum: {0}", TargetSum);
            }
        }

        private static IEnumerable<int> FindSubset(int targetSum)
        {
            // ste nameri edno ot mnogoto vazmojni resheia, kato tuka ste zapochne ot nachaloto na masiva
            var subset = new List<int>();
            while (targetSum > 0)
            {
                foreach (var number in numbers)
                {
                    var newSum = targetSum - number;
                    if (newSum >= 0 && isPossibleSum[newSum])
                    {
                        targetSum = newSum;
                        subset.Add(number);
                    }
                }
            }

            return subset;
        }
    }
}