using Common;
using LagrangePolinomialInterpolation;

Console.WriteLine("Wyliczenie wielomianu interpolacyjnego Lagrange'a\n");

// Prepared points
{
    var polinomial = new LagrangePolinomial(
        new Point[] { new(0, 1), new(1, 3), new(3, 2) });
    double x = 2;

    Console.WriteLine($"Punkty: {polinomial}\nArgument: {x}\nInterpolacja: {polinomial.Interpolate(x)}\n");

    while (true)
    {
        Console.Write("Spróbować inny argument (y/[n])? ");
        if (Console.ReadLine() != "y")
            break;

        Console.Write("Wprowadź argument: ");
        x = ConsoleExtensions.ObtainDouble();

        try
        {
            Console.WriteLine($"Punkty: {polinomial}\nArgument: {x}\nInterpolacja: {polinomial.Interpolate(x)}\n");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}

// User points
while (true)
{
    Console.Write("Spróbować inne punkty (y/[n])? ");
    if (Console.ReadLine() != "y")
        break;

    Console.WriteLine("Wprowadź punkty (przykład: \"11,12; 21,22; 31,32;\")");
    var inputPoints = Console.ReadLine().Split(';');
    var points = inputPoints.Select(ip =>
    {
        var parts = ip.Split(',');

        return new Point(
            X: double.Parse(parts[0]),
            Y: double.Parse(parts[1]));
    });
    var polinomial = new LagrangePolinomial(points.ToArray());

    Console.Write("Wprowadź argument: ");
    var x = ConsoleExtensions.ObtainDouble();

    try
    {
        Console.WriteLine($"Punkty: {polinomial}\nArgument: {x}\nInterpolacja: {polinomial.Interpolate(x)}\n");
    }
    catch (ArgumentException e)
    {
        Console.WriteLine(e.Message);
    }

    while (true)
    {
        Console.Write("Spróbować inny argument (y/[n])? ");
        if (Console.ReadLine() != "y")
            break;

        Console.Write("Wprowadź argument: ");
        x = ConsoleExtensions.ObtainDouble();

        try
        {
            Console.WriteLine($"Punkty: {polinomial}\nArgument: {x}\nInterpolacja: {polinomial.Interpolate(x)}\n");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}