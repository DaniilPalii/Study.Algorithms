using Common;

namespace Permutation.Permutators
{
    internal class MinimalNeighbourTransposingPermutator : PermutatorBase
    {
        public override string AlgorythmName
            => "Permutacja nr 2 – przez minimalną liczbę transpozycji sąsiednich elementów";

        protected override IEnumerable<int[]> EnumeratePermutations(int size)
        {
            yield return CopyPermutation();

            var c = ArrayExtensions.CreateFilled(size, value: 0);
            var pr = ArrayExtensions.CreateFilled(size, value: true);

            var maxIndex = size - 1;
            c[maxIndex] = -1;

            for (var i = 0; i < maxIndex;)
            {
                i = 0;
                var x = 0;

                while (c[i] == maxIndex - i)
                {
                    pr[i] = !pr[i];
                    c[i] = 0;

                    if (pr[i])
                        x++;

                    i++;
                }

                if (i < maxIndex)
                {
                    var swapIndex = pr[i]
                        ? c[i] + x
                        : maxIndex - i - c[i] + x - 1;
                    SwapInPermutation(swapIndex, swapIndex + 1);

                    yield return CopyPermutation();

                    c[i]++;
                }
            }
        }
    }
}
