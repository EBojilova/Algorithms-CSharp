namespace SubsetSumsBetter
{
    using System;
    using System.Collections.Generic;

    internal class SubsetSumsNoRepeats
    {
        private const int TargetSum = 19;

        private static readonly int[] numbers = { 3, 5, -1, 10, 5, 7 };

        private static IDictionary<int, int> possibleSums = new Dictionary<int, int>();

        private static void Main(string[] args)
        {
            possibleSums = CalcPossibleSums();

            PrintSubset();
        }

        private static IDictionary<int, int> CalcPossibleSums()
        {
            Console.WriteLine("Possible sums with the numer:");
            possibleSums.Add(0, 0);
            foreach (var number in numbers)
            {
                Console.WriteLine("Possible sums with the numer {0}:", number);
                var newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSums.Keys)
                {
                    var newSum = sum + number;
                    if (!possibleSums.ContainsKey(newSum))
                    {
                        newSums.Add(newSum, number);
                    }
                }
                Console.WriteLine(string.Join(", ", newSums));
                foreach (var sum in newSums)
                {
                    possibleSums.Add(sum.Key, sum.Value);
                }
            }
            return possibleSums;
        }

        private static void PrintSubset()
        {
            // Print subset
            if (possibleSums.ContainsKey(TargetSum))
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
            var subset = new List<int>();
            while (targetSum > 0)
            {
                var lastNum = possibleSums[targetSum];
                subset.Add(lastNum);
                targetSum -= lastNum;
            }
            subset.Reverse();
            return subset;
        }
    }
}