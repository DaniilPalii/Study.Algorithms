using Common;
using System.Diagnostics;

namespace Permutation.Permutators
{
    internal abstract class PermutatorBase : IPermutator
    {
        public abstract string AlgorythmName { get; }

        public Result Permutate(int size)
        {
            swappingCount = 0;
            Permutation = ArrayExtensions.CreateFilledWithNumbers(from: 1, size);

            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var permutations = size == 1
                    ? new[] { Permutation }
                    : EnumeratePermutations(size).ToArray();

            stopwatch.Stop();

            return new Result(this, permutations, stopwatch.Elapsed, swappingCount);
        }

        protected int[] Permutation { get; private set; }

        protected abstract IEnumerable<int[]> EnumeratePermutations(int setSize);

        protected int[] CopyPermutation()
            => Permutation.Copy();

        protected void SwapInPermutation(int index1, int index2)
        {
            Permutation.Swap(index1, index2);
            swappingCount++;
        }

        private int swappingCount;
    }
}
