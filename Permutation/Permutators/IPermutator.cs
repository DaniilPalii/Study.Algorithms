namespace Permutation.Permutators
{
    internal interface IPermutator
    {
        string AlgorythmName { get; }

        Result Permutate(int initialSetSize);
    }
}