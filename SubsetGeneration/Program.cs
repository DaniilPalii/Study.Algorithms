using Common;
using SubsetGeneration.Generators;
using System.Diagnostics;

Console.WriteLine("Generowanie podzbiorów");

var alphabeth = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

while (true)
{
    ConsoleExtensions.WriteSeparatorLine();

    var initialSetSize = ConsoleExtensions.ObtainInt("rozmiar podstawowego zbioru");
    var initialSet = alphabeth[0..initialSetSize];
    Console.WriteLine($"Podstawowy zbior: {{ {string.Join(", ", initialSet)} }}");

    if (ConsoleExtensions.UserAgree("Generować podzbiory każdej długości?"))
    {
        var binaryMaskStopwatch = new Stopwatch();
        var binaryMaskSubsets = Array.Empty<char[]>();
        var binaryMaskTask = Task.Run(() =>
        {
            binaryMaskStopwatch.Start();
            binaryMaskSubsets = new BinaryMaskSubsetGenerator().Generate(initialSet);
            binaryMaskStopwatch.Stop();
        });

        var greyStopwatch = new Stopwatch();
        var greySubsets = Array.Empty<char[]>();
        var greyTask = Task.Run(() =>
        {
            greyStopwatch.Start();
            greySubsets = new GreySubsetGenerator().Generate(initialSet);
            greyStopwatch.Stop();
        });

        var kElementStopwatch = new Stopwatch();
        var kElementSubsets = Array.Empty<char[]>();
        var kElementTask = Task.Run(() =>
        {
            kElementStopwatch.Start();
            kElementSubsets = new KElementSubsetGenerator().Generate(initialSet);
            kElementStopwatch.Stop();
        });

        await Task.WhenAll(binaryMaskTask, greyTask, kElementTask);

        Console.WriteLine($"\nPodzbiory wygenerowane metodą binarną:");
        var i = 1;
        foreach (var subset in binaryMaskSubsets)
            Console.WriteLine($"  {i++,3:##)} {{ {string.Join(", ", subset)} }}");

        Console.WriteLine($"\nPodzbiory wygenerowane metodą Grey'a:");
        i = 1;
        foreach (var subset in greySubsets)
            Console.WriteLine($"  {i++,3:##)} {{ {string.Join(", ", subset)} }}");

        Console.WriteLine($"\nPodzbiory wygenerowane metodą k-elementową:");
        i = 1;
        foreach (var subset in kElementSubsets)
            Console.WriteLine($"  {i++,3:##)} {{ {string.Join(", ", subset)} }}");

        if (SetOfSetComparer.AreSame(binaryMaskSubsets, kElementSubsets)
            && SetOfSetComparer.AreSame(binaryMaskSubsets, greySubsets))
            Console.WriteLine("\nWszystkie metody wygenerowały te same podzbiory.");
        else
            Console.WriteLine("\nBłąd: metody wygenerowały różne podzbiory.");

        Console.WriteLine($"\nCzas generowania");
        Console.WriteLine($"  metodą maski binarnej:\t{binaryMaskStopwatch.Elapsed}");
        Console.WriteLine($"  metodą Grey'a:\t\t{greyStopwatch.Elapsed}");
        Console.WriteLine($"  metodą k-elementową:\t\t{kElementStopwatch.Elapsed}");

        Console.WriteLine($"\nIlość podzbiorów: {binaryMaskSubsets.Length}");
        foreach (var lenghtGroup in binaryMaskSubsets.GroupBy(s => s.Length).OrderBy(g => g.Key))
            Console.WriteLine($"Ilość {lenghtGroup.Key}-elementowych podzbiorów: {lenghtGroup.Count()}");

        Console.WriteLine();
    }
    else
    {
        var subsetSize = ConsoleExtensions.ObtainInt("rozmiar podzbioru");

        var binaryMaskStopwatch = new Stopwatch();
        var binaryMaskSubsets = Array.Empty<char[]>();
        var binaryMaskTask = Task.Run(() =>
        {
            binaryMaskStopwatch.Start();
            binaryMaskSubsets = new BinaryMaskSubsetGenerator()
                .Generate(initialSet)
                .Where(subset => subset.Length == subsetSize)
                .ToArray();
            binaryMaskStopwatch.Stop();
        });

        var greyStopwatch = new Stopwatch();
        var greySubsets = Array.Empty<char[]>();
        var greyTask = Task.Run(() =>
        {
            greyStopwatch.Start();
            greySubsets = new GreySubsetGenerator()
                .Generate(initialSet)
                .Where(subset => subset.Length == subsetSize)
                .ToArray();
            greyStopwatch.Stop();
        });

        var kElementStopwatch = new Stopwatch();
        var kElementSubsets = Array.Empty<char[]>();
        var kElementTask = Task.Run(() =>
        {
            kElementStopwatch.Start();
            kElementSubsets = new KElementSubsetGenerator().Generate(initialSet, subsetSize);
            kElementStopwatch.Stop();
        });

        await Task.WhenAll(binaryMaskTask, greyTask, kElementTask);

        Console.WriteLine($"\nPodzbiory wygenerowane metodą binarną:");
        var i = 1;
        foreach (var subset in binaryMaskSubsets)
            Console.WriteLine($"  {i++,3:##)} {{ {string.Join(", ", subset)} }}");

        Console.WriteLine($"\nPodzbiory wygenerowane metodą Grey'a:");
        i = 1;
        foreach (var subset in greySubsets)
            Console.WriteLine($"  {i++,3:##)} {{ {string.Join(", ", subset)} }}");

        Console.WriteLine($"\nPodzbiory wygenerowane metodą k-elementową:");
        i = 1;
        foreach (var subset in kElementSubsets)
            Console.WriteLine($"  {i++,3:##)} {{ {string.Join(", ", subset)} }}");

        if (SetOfSetComparer.AreSame(binaryMaskSubsets, kElementSubsets)
            && SetOfSetComparer.AreSame(binaryMaskSubsets, greySubsets))
            Console.WriteLine("\nWszystkie metody wygenerowały te same podzbiory.");
        else
            Console.WriteLine("\nBłąd: metody wygenerowały różne podzbiory.");

        Console.WriteLine($"\nCzas generowania");
        Console.WriteLine($"  metodą maski binarnej:\t{binaryMaskStopwatch.Elapsed}");
        Console.WriteLine($"  metodą Grey'a:\t\t{greyStopwatch.Elapsed}");
        Console.WriteLine($"  metodą k-elementową:\t\t{kElementStopwatch.Elapsed}");

        Console.WriteLine($"\nIlość podzbiorów: {binaryMaskSubsets.Length}");
        foreach (var lenghtGroup in binaryMaskSubsets.GroupBy(s => s.Length).OrderBy(g => g.Key))
            Console.WriteLine($"Ilość {lenghtGroup.Key}-elementowych podzbiorów: {lenghtGroup.Count()}");

        Console.WriteLine();
    }
}