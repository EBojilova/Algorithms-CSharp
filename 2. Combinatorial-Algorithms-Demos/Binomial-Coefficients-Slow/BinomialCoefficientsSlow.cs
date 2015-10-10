using System;

internal class BinomialCoefficientsSlow
{
    private static void Main()
    {
        // taka se smiata triagalnik na Pascal
        Console.WriteLine("C(2, 4) = " + Binom(4, 2));
        Console.WriteLine("C(4, 10) = " + Binom(10, 4));
        Console.WriteLine("C(7, 13) = " + Binom(13, 7));
        Console.WriteLine("C(13, 26) = " + Binom(26, 13));
        Console.WriteLine("C(12, 30) = " + Binom(30, 12));
    }

    private static decimal Binom(int iterationsN, int loopsK)
    {
        //Console.WriteLine("Calculating Binom({0}, {1})", iterationsN, loopsK);
        if (loopsK > iterationsN)
        {
            return 0;
        }
        if (loopsK == 0 || loopsK == iterationsN)
        {
            return 1;
        }
        return Binom(iterationsN - 1, loopsK - 1) + Binom(iterationsN - 1, loopsK);
    }
}