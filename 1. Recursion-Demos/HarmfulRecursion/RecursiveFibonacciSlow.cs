namespace HarmfulRecursion
{
    using System;

    internal class RecursiveFibonacciSlow
    {
        private static decimal Fibonacci(int n)
        {
            if ((n == 1) || (n == 2))
            {
                return 1;
            }
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        private static void Main()
        {
            Console.Write("Fib(10) = ");
            var fib10 = Fibonacci(10);
            Console.WriteLine(fib10);

            Console.Write("Fib(50) = ");
            var fib50 = Fibonacci(50);
            Console.WriteLine(fib50);
        }
    }
}