namespace ExamSequencesOfLimitedSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;

    internal class SortedSubsetSums
    {
        private static int[] numbers;

        private static int n;

        private static StringBuilder resutlt;

        private static int sum;

        private static void Main()
        {
            n = int.Parse(Console.ReadLine());
            numbers = Enumerable.Range(1, n)
                .ToArray();
            var subset = new List<int>();
            resutlt = new StringBuilder();
            sum = 0;
            MakeSubset(0, subset);
            Console.WriteLine(resutlt.ToString());
        }

        private static void MakeSubset(int index, List<int> subset)
        {
            var count = subset.Count;
            if (count > n)
            {
                return;
            }

            if (sum <= n && count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    resutlt.AppendFormat("{0} ", subset[i]);
                }
                resutlt.AppendLine();
            }
            
            for (var i = 0; i < numbers.Length; i++)
            {
                subset.Add(numbers[i]);
                sum += numbers[i];
                MakeSubset(i + 1, subset); // call MakeSubset recursively
                subset.RemoveAt(subset.Count - 1); // remove last element
                sum -= numbers[i];
            }
        }
    }
}