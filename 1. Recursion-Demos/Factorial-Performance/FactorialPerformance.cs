using System;

namespace Factorial_Performance
{
    internal class FactorialPerformance
    {
        private static void Main()
        {
            var startTime = DateTime.Now;
            for (var i = 0; i < 1000000; i++)
            {
                decimal f = RecursiveFactorial(15);
            }
            var endTime = DateTime.Now;
            Console.WriteLine("Recursive factorial time: {0}", endTime - startTime);

            startTime = DateTime.Now;
            for (var i = 0; i < 1000000; i++)
            {
                decimal f = IterativeFactorial(15);
            }
            endTime = DateTime.Now;
            Console.WriteLine("Iterative factorial time: {0}", endTime - startTime);
        }

        private static long RecursiveFactorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }
            return n * RecursiveFactorial(n - 1);
        }

        private static long IterativeFactorial(int n)
        {
            long result = 1;
            for (var i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}