namespace GrayCode
{
    using System;

    internal class GrayCodeGenerator
    {
        private const int iterationsN = 4;

        private static readonly int[] array = new int[iterationsN];

        private static void Main()
        {
            ForwardGray(iterationsN - 1);
        }

        private static void ForwardGray(int loopsK)
        {
            if (loopsK < 0)
            {
                Print();
            }
            else
            {
                array[loopsK] = 0;
                ForwardGray(loopsK - 1);
                array[loopsK] = 1;
                BackwardGray(loopsK - 1);
            }
        }

        private static void BackwardGray(int loopsK)
        {
            if (loopsK < 0)
            {
                Print();
            }
            else
            {
                array[loopsK] = 1;
                ForwardGray(loopsK - 1);
                array[loopsK] = 0;
                BackwardGray(loopsK - 1);
            }
        }

        private static void Print()
        {
            Console.WriteLine("(" + string.Join(", ", array) + ")");
        }
    }
}