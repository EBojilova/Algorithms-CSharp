namespace RecursiveFibonacciFast
{
    using System;

    internal class FastRecursiveFibonacci
    {
        private const int MaxFibоnacciSequenceMember = 1000;

        // tuka sahraniavame vsichki reshenia i posle gi vzimame direktno
        private static readonly decimal[] Fib = new decimal[MaxFibоnacciSequenceMember];

        private static decimal recursiveCallsCounter;

        private static void Main()
        {
            // num triabva da e po-malko ot MaxFibоnacciSequenceMember
            var num = 100;
            var fib = Fibonacci(num);
            Console.WriteLine("Fib({0}) = {1}", num, fib);
            Console.WriteLine("Recursive calls = {0}", recursiveCallsCounter);
        }

        private static decimal Fibonacci(int n)
        {
            recursiveCallsCounter++;
            // The value of fib[n] is still not calculated -> calculate it now
            if (Fib[n] == 0)
            {
                if ((n == 1) || (n == 2))
                {
                    Fib[n] = 1;
                }
                else
                {
                    Fib[n] = Fibonacci(n - 1) + Fibonacci(n - 2);
                }
            }
            return Fib[n];
        }
    }
}