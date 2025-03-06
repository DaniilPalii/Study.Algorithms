using Common;

namespace Permutation.Permutators
{
    internal class LexicographicPermutator : PermutatorBase
    {
        public override string AlgorythmName
            => "Permutacja nr 1 – w porządku leksykograficznym";

        protected override IEnumerable<int[]> EnumeratePermutations(int size)
        {
            var maxIndex = size - 1;

            for (var i = 0; i >= 0;)
            {
                yield return CopyPermutation();

                // Znaleźć pierwszą od prawej strony pozycję i, dla której set[i] < set[i + 1]
                i = maxIndex - 1;
                while (Permutation[i] > Permutation[i + 1])
                {
                    i--;
                    if (i < 0)
                        yield break;
                }

                // Znaleźć set[j], najmniejszy element leżący na prawo od set[j] i większy od set[i]
                var j = maxIndex;
                while (Permutation[i] > Permutation[j])
                    j--;

                // Zamienić miesjcami set[i] z set[j] i odwrócić kolejność elementów set[i + 1],...set[initialSetSize]
                SwapInPermutation(i, j);
                var r = maxIndex;
                var s = i + 1;
                while (r > s)
                {
                    SwapInPermutation(r, s);
                    r--;
                    s++;
                }
            }
        }
    }
}
