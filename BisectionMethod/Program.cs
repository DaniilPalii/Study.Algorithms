using BisectionMethod;
var Sin = Math.Sin;
var Pow = Math.Pow;

var function1 = new Function(
    x => Pow(x, 3) * (x + Sin(Pow(x, 2) - 1) - 1) - 1,
    Title: "x^3 * (x + sin(x^2 - 1) - 1) - 1");
var function2 = new Function(
    x => (2 * Pow(x, 4)) + (24 * Pow(x, 3)) + (61 * Pow(x, 2)) - (16 * x) + 1,
    Title: "2x^4 + 24x^3 + 61x^2 - 16c + 1");

var searchers = new ArgumentThatProducesZeroSearcher[]
{
    new(function1, Range: new(-1, 0)),
    new(function1, Range: new(1, 2)),
    new(function2, Range: new(0.12, 0.1222)),
    new(function2, Range: new(0.1226, 0.1237)),
    new(
        Function: new(
            Calculate: x => Pow(x, 3) - (6 * Pow(x, 2)) + (11 * x) - 6,
            Title: "x^3 - 6x^2 + 11x - 6"),
        Range: new(0.5, 1.8)),
    new(
        Function: new(
            x => x - Sin(x) - 0.25,
            Title: "x - sin(x) - 0.25"), 
        Range: new(1, 2)),
    new(
        Function: new(
            x => Pow(x, 7) + 3 * Pow(x, 4) - 3,
            Title: "x^7 + 3x^4 - 3"), 
        Range: new(0.75, 1)),
    new(
        Function: new(
            x => Pow(x, 3) - Pow(Math.E, -x) - 2, 
            Title: "x^3 - e^(-x) - 2"),
        Range: new(1, 2.5)),
    new NewtonsArgumentThatProducesZeroSearcher(
        Function: new(
            x => x.Pow(7) + (3 * x.Pow(4)) - 3, 
            Title: "x^7 + 3x^4 - 3"),
        Derivative: x => 7 * x.Pow(6) + 12 * x.Pow(3),
        Range: new(0.75, 1)),

};


while (true)
{
    Console.WriteLine("====================================\n");

    Console.Write("Wprowadź dokładność: ");
    if (!double.TryParse(Console.ReadLine(), out var precision))
    {
        Console.WriteLine("Zła wartość");
        continue;
    }
    Console.WriteLine();

    foreach (var searcher in searchers)
    {
        Console.WriteLine(searcher);

        Console.WriteLine("Metoda bisekcji");
        Console.WriteLine(searcher.FindUsingBisection(precision));

        Console.WriteLine("Regula falsi");
        Console.WriteLine(searcher.FindUsingRegulaFalsi(precision));

        if (searcher is NewtonsArgumentThatProducesZeroSearcher newtonSearcher)
        {
            Console.WriteLine("Metoda newtona");
            Console.WriteLine(newtonSearcher.FindUsingNewtonMethod(precision));
        }

        Console.WriteLine();
    }

    Console.ReadLine();
}