using System;

class BinomialCoefficientsFast
{
    // proizvolno sme izbrali MAX
    const int MAX = 100;
    static decimal[,] binomCoeff = new decimal[MAX, MAX];

    static decimal Binom(int iterationsN, int loopsK)
    {
        if (loopsK > iterationsN)
            return 0;
        if (0 == loopsK || loopsK == iterationsN)
            return 1;
        if (binomCoeff[iterationsN, loopsK] == 0)
            binomCoeff[iterationsN, loopsK] = Binom(iterationsN - 1, loopsK - 1) + Binom(iterationsN - 1, loopsK);
        return binomCoeff[iterationsN, loopsK];
    }

    static void Main()
    {
        Console.WriteLine("C(2, 4) = " + Binom(4, 2));
        Console.WriteLine("C(4, 10) = " + Binom(10, 4));
        Console.WriteLine("C(7, 13) = " + Binom(13, 7));
        Console.WriteLine("C(13, 26) = " + Binom(26, 13));
        Console.WriteLine("C(12, 30) = " + Binom(30, 12));
        Console.WriteLine("C(22, 50) = " + Binom(50, 22));
        Console.WriteLine("C(25, 70) = " + Binom(70, 25));
    }
}
