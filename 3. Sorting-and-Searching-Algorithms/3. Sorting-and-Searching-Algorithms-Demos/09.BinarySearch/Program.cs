namespace _09.BinarySearch
{
    using System;

    // po-barzo e ot lineinoto tarsene, no minusa e, che elementite triabva da sa sortirani
    // prilaga se ako imame edna baza danni, koiato v koiato riadko dobaviame i kato ia sortirame vednaj, 
    //posle barzo ste tarsim
    internal class Program
    {
        private static readonly int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };

        private static void Main(string[] args)
        {
            var first = BinarySearchIterative(0, 0, arr.Length - 1);
            var last = BinarySearchRecursive(arr.Length - 1, 0, arr.Length - 1);
            Console.WriteLine(first);
            Console.WriteLine(last);
        }

        public static int BinarySearchIterative(int key, int min, int max)
        {
            while (min <= max)
            {
                var mid = (min + max) / 2;
                if (key == arr[mid])
                {
                    return mid;
                }
                if (key < arr[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        public static int BinarySearchRecursive(int key, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }
            var mid = (min + max) / 2;
            if (key == arr[mid])
            {
                return mid;
            }
            if (key < arr[mid])
            {
                return BinarySearchRecursive(key, min, mid - 1);
            }
            return BinarySearchRecursive(key, mid + 1, max);
        }
    }
}