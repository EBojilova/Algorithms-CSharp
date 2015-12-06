namespace SubSetSums
{
    using System;
    using System.Collections.Generic;

    internal class SubSetSums
    {
        private const int TargetSum = 26;

        private static readonly int[] numbers = { 5, 5, 15, 20, 1 };

        private static readonly bool[,] possibleSum = new bool[numbers.Length, TargetSum + 1];

        private static readonly bool[,] isCalculated = new bool[numbers.Length, TargetSum + 1];

        private static void Main()
        {
            var isFoundSubset = CalcPossibleSums(numbers.Length - 1, TargetSum);

            PrintSubset(isFoundSubset);
        }

        private static bool CalcPossibleSums(int i, int sum)
        {
            if (sum < 0 || i < 0)
            {
                return false;
            }

            // Memoization
            if (!isCalculated[i, sum])
            {
                // razgledjdame 3 varinata:
                // 1. ako sumata e ravna na tekustoto chislo;
                // 2. ako sumata e ravna na niakoe ot predishnite chisla- s rekursia
                // 3. kogato v sumata ne e vklucheno tekustoto chislo i sumata e ravna na predishnia element- s rekursia
                possibleSum[i, sum] = (numbers[i] == sum) || 
                                      CalcPossibleSums(i - 1, sum) || 
                                      CalcPossibleSums(i - 1, sum - numbers[i]);
                isCalculated[i, sum] = true;
            }

            return possibleSum[i, sum];
        }

        private static void PrintSubset(bool isFoundSubset)
        {
            if (isFoundSubset)
            {
                var subset = FindSubset(numbers.Length - 1, TargetSum);
                Console.WriteLine("{0} = {1}", TargetSum, string.Join(" + ", subset));
            }
            else
            {
                Console.WriteLine("Not possible!");
            }
        }

        private static IEnumerable<int> FindSubset(int i, int sum)
        {
            var subset = new List<int>();
            while (true)
            {
                if (numbers[i] == sum)
                {
                    // Take the last number
                    subset.Add(numbers[i]);
                    break;
                }
                // zapochvame ot poslednoto chislo
                if (CalcPossibleSums(i - 1, sum - numbers[i]))
                {
                    // Take numbers[i]
                    subset.Add(numbers[i]);
                    sum = sum - numbers[i];
                }

                i = i - 1;
            }
            return subset;
        }
    }
}