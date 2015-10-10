namespace _10.InterpolationSearch
{
    using System;

    // analogichno na binary serch, no mid se opredelia po-precizno
    // po-barzo e ot lineinoto tarsene, no minusa e, che elementite triabva da sa sortirani i da sa ravnomerno razpredeleni
    // ako gapa mejdu stoinostite na elementite e mnogo goliama, ne e podhodiast metod
    //ako imame edna baza danni, koiato v koiato riadko dobaviame i kato ia sortirame vednaj, 
    //posle barzo ste tarsim
    internal class Program
    {
        private static readonly int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7 };

        private static void Main(string[] args)
        {
            var first = InterpolationSearchIterative(0, 0, arr.Length - 1);
            var last = InterpolationSearchRecursive(arr.Length - 1, 0, arr.Length - 1);
            Console.WriteLine(first);
            Console.WriteLine(last);
        }

        public static int InterpolationSearchIterative(int key, int min, int max)
        {
            while (min <= max)
            {
                var mid = min + ((key - arr[min]) * (max - min)) / (arr[max] - arr[min]);
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

        public static int InterpolationSearchRecursive(int key, int min, int max)
        {
            if (min > max)
            {
                return -1;
            }
            var mid = min + ((key - arr[min]) * (max - min)) / (arr[max] - arr[min]);
            if (key == arr[mid])
            {
                return mid;
            }
            if (key < arr[mid])
            {
                return InterpolationSearchRecursive(key, min, mid - 1);
            }
            return InterpolationSearchRecursive(key, mid + 1, max);
        }
    }
}