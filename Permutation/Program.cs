using Common;
using Permutation;
using Permutation.Permutators;

Console.WriteLine("Permutacja");

var permutators = new IPermutator[]
{
    new LexicographicPermutator(),
    new MinimalNeighbourTransposingPermutator(),
    new MinimalTransposingPermutator(),
};

while (true)
{
    ConsoleExtensions.WriteSeparatorLine();
    var setSize = ConsoleExtensions.ObtainInt("rozmiar zbioru");
    var results = new Result[permutators.Length];

    await Task.WhenAll(
        permutators.Select(
            (permutator, i) => Task.Run(
                () => results[i] = permutator.Permutate(setSize))));

    new ConsoleWriter(results).Write();
}
