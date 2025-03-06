static class Program
{
    static void Main()
    {
        Console.WriteLine("Interpolacja");

        var integrals = new[]
        {
            //new Integral(
            //    Title: "nr1",
            //    Function: x => (2 * x) - Math.Sqrt(x) + (3 * Math.Pow(x, 2d / 3)) + 1,
            //    Start: 0,
            //    End: 1),
            //new Integral(
            //    Title: "nr2",
            //    Function: x => Math.Sin(x) + Math.Cos(x),
            //    Start: 0,
            //    End: Math.PI),
            //new Integral(
            //    Title: "nr3",
            //    Function: x => Math.Sqrt(1 + 2 * x),
            //    Start: 0,
            //    End: 1),
            //new Integral(
            //    Title: "nr4",
            //    Function: x => 1 / Math.Pow(x, 2),
            //    Start: 1,
            //    End: 2),


            new Integral(
                Title: "x^2/(1+x^6)",
                Function: x => Math.Pow(x, 2) / (1 + Math.Pow(x, 6)),
                Start: -1,
                End: 1),
            new Integral(
                Title: "cosx/(1+sinx)",
                Function: x => Math.Cos(x) / (1 + Math.Sin(x)),
                Start: 0,
                End: Math.PI / 2),
            new Integral(
                Title: "(3x^2+2)/(x^(2/3))",
                Function: x => (3 * Math.Pow(x, 2) + 2) / Math.Pow(Math.Pow(x, 2), 1d / 3),
                Start: -1,
                End: 1),
        };

        while (true)
        {
            Console.ReadKey(intercept: true);
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("\nIle kawałków użyć?");
            var partsUserResponse = Console.ReadLine();

            if (!int.TryParse(partsUserResponse, out var parts) || parts <= 0)
            {
                Console.WriteLine("Błąd wczytywania. Oczekuję całej liczby większej od zera.");

                continue;
            }
            
            Console.WriteLine("\nMetoda trapezów\n");

            foreach (var integral in integrals)
                Console.WriteLine($"{integral} wynosi {integral.ObliczMetodąTrapezów(parts)}");

            if (IsOdd(parts))
            {
                Console.WriteLine("\nMetoda parabol nie działa dla nieparzystej liczby kawałków.");

                continue;
            }

            Console.WriteLine("\nMetoda parabol\n");

            foreach (var integral in integrals)
                Console.WriteLine($"{integral} wynosi {integral.ObliczMetodąParabol(parts)}");
        }
    }

    static bool IsOdd(int number)
        => number % 2 != 0;
}

record Integral(
    string Title,
    Func<double, double> Function,
    double Start,
    double End)
{

    public double ObliczMetodąTrapezów(int parts)
    {
        var sum = 0d;
        var partSize = (End - Start) / parts;

        for (var i = 0; i < parts; i++)
            sum
                += (Function(Start + (i * partSize))
                    + Function(Start + ((i + 1) * partSize)))
                / 2
                * partSize;

        return sum;
    }

    public double ObliczMetodąParabol(int parts)
    {
        var sum = 0d;
        var partSize = (End - Start) / parts;

        for (var i = 0; i < parts - 1; i += 2)
            sum
                += (Function(Start + (i * partSize))
                    + 4* Function(Start + ((i + 1) * partSize))
                    + Function(Start + ((i + 2) * partSize)))
                / 3
                * partSize;

        return sum;
    }

    public override string? ToString()
        => $"Całka {Title} od {Start} do {End}";
}

record Result(double Value, double LastPoint);