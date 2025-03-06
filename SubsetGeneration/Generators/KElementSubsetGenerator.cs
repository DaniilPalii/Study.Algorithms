using Common;

namespace SubsetGeneration.Generators
{
    public class KElementSubsetGenerator
    {
        public char[][] Generate(char[] initialSet)
        {
            var subsetNumber = (int)Math.Pow(2, initialSet.Length);
            var subsets = new char[subsetNumber][];
            var i = 0;

            for (var subsetSize = 0; subsetSize <= initialSet.Length; subsetSize++)
            {
                var subsetsOfSize = Generate(initialSet, subsetSize);

                foreach (var subset in subsetsOfSize)
                {
                    subsets[i] = subset;
                    i++;
                }
            }

            return subsets;
        }

        public char[][] Generate(char[] initialSet, int subsetSize)
            => GenerateSubsetsOfIndexes(initialSet.Length, subsetSize)
                .Select(indexes => ReplaceIndexesWithValues(indexes, initialSet))
                .ToArray();

        private static IEnumerable<int[]> GenerateSubsetsOfIndexes(int initialSetSize, int subsetSize)
        {
            var subsetIndexes = new int[subsetSize];

            if (subsetSize == 0)
            {
                yield return subsetIndexes;
                yield break;
            }

            for (var i = 0; i < subsetSize; i++)
                subsetIndexes[i] = i;

            if (subsetSize == initialSetSize)
            {
                yield return subsetIndexes;
                yield break;
            }

            var p = subsetSize - 1;

            while (p >= 0)
            {
                yield return subsetIndexes;
                subsetIndexes = subsetIndexes.Copy();

                if (subsetIndexes[subsetSize - 1] == initialSetSize - 1)
                    p--;
                else
                    p = subsetSize - 1;

                if (p >= 0)
                {
                    for (var i = subsetSize - 1; i >= p; i--)
                        subsetIndexes[i] = subsetIndexes[p] + i - p + 1;
                }
            }
        }

        private static char[] ReplaceIndexesWithValues(int[] indexes, char[] initialSet)
        {
            var subset = new char[indexes.Length];

            for (var i = 0; i < subset.Length; i++)
                subset[i] = initialSet[indexes[i]];

            return subset;
        }
    }
}
