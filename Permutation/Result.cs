using Permutation.Permutators;

namespace Permutation
{
    internal record Result(
        IPermutator Permutator,
        int[][] Permutations,
        TimeSpan GenerationTime,
        int SwappingCount);
}
