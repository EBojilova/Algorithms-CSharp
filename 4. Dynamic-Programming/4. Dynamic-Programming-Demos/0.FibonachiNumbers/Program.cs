namespace _0.FibonachiNumbers
{
    using System;
    using System.Diagnostics;

    internal class Program
    {
        private static readonly decimal[] memo = new decimal[100];

        private static void Main(string[] args)
        {
            var watch = Stopwatch.StartNew();
            Console.WriteLine(FibonacciDivide(30));
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            watch = Stopwatch.StartNew();
            Console.WriteLine(Fibonacci(30));
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);

            watch = Stopwatch.StartNew();
            Console.WriteLine(FibonacciBottomUp(30));
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine(elapsedMs);
        }

        // Divide-and-conquer calculation  very slow!
        private static decimal FibonacciDivide(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            return FibonacciDivide(n - 1) + FibonacciDivide(n - 2);
        }

        // top-down calculation with memoization
        private static decimal Fibonacci(int n)
        {
            if (memo[n] != 0)
            {
                return memo[n];
            }
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
            return memo[n];
        }

        // Fibonacci in bottom-up order, iteratively
        private static decimal FibonacciBottomUp(int n)
        {
            var fib = new decimal[n + 2];
            fib[0] = 0;
            fib[1] = 1;
            for (var i = 2; i <= n; i++)
            {
                fib[i] = fib[i - 1] + fib[i - 2];
            }
            return fib[n];
        }
    }
}