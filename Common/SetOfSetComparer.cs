namespace Common
{
    public static class SetOfSetComparer
    {
        public static bool AreSame<T>(T[][][] subsets)
        {
            for (var i = 0; i < subsets.Length - 1; i++)
            {
                if (!AreSame(subsets[i], subsets[i + 1]))
                    return false;
            }

            return true;
        }

        public static bool AreSame<T>(T[][] subset, T[][] otherSubset)
             => subset.Length == otherSubset.Length
                && ToComparableSetOfSet(subset).SetEquals(ToComparableSetOfSet(otherSubset));

        private static HashSet<HashSet<T>> ToComparableSetOfSet<T>(T[][] binaryMaskSubsets)
            => new(binaryMaskSubsets.Select(s => s.ToHashSet()), HashSet<T>.CreateSetComparer());
    }
}
