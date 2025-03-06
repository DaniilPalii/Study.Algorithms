static class Program
{
    static void Main()
    {
        var pairs = new (long, long)[]
        {
            //(445566, 333),
            //(12345000, 225),
            //(999999, 111),
            //(7744113366, 666),
            //(2244668800, 112233),
            //(14887700, 12),
            //(2000000000, 5)
            //(1000000000, 90000000)
            (1122334455, 5)
        };

        foreach (var (a, b) in pairs)
            Console.WriteLine($"{nameof(Euklid1)}({a}, {b}) = {Euklid1(a, b)}");

        Console.WriteLine();

        foreach (var (m, n) in pairs)
            Console.WriteLine($"{nameof(Euklid2)}({m}, {n}) = {Euklid2(m, n)}");
    }
    static Result Euklid1(long a, long b)
    {
        var iterations = 0;

        while (a != b)
        {
            iterations++;

            if (a > b)
                a -= b;
            else
                b -= a;
        }

        return new Result(a, iterations);
    }

    static Result Euklid2(long m, long n, int iterations = 0)
    {
        if (n == 0)
            return new Result(m, iterations);
        else
            return Euklid2(n, m % n, iterations + 1);
    }
}

record Result(long Value, int Iterations)
{
    public override string? ToString()
        => $"{Value} ({Iterations} iterations)";
}
