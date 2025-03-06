using Common;

namespace Permutation.Permutators
{
    internal class MinimalTransposingPermutator : PermutatorBase
    {
        public override string AlgorythmName
            => "Permutacja nr 3 – przez minimalną liczbę transpozycji";

        protected override IEnumerable<int[]> EnumeratePermutations(int size)
        {
            permutations = new List<int[]>();
            Perm(m: size - 1);

            return permutations;
        }

        private void Perm(int m)
        {
            if (m == 0)
                permutations.Add(CopyPermutation());

            for (var i = 0; i <= m; i++)
            {
                Perm(m - 1);

                if (i < m)
                    SwapInPermutation(B(m, i), m);
            }
        }

        private static int B(int m, int i)
        {
            if (!m.IsEven() && m > 1)
            {
                return i < m - 1
                    ? i
                    : m - 2;
            }
            else
                return m - 1;
        }

        private List<int[]> permutations;
    }
}
