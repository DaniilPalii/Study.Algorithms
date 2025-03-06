using System.Collections;

namespace SubsetGeneration.Generators;

public class BinaryMaskSubsetGenerator
{
    public char[][] Generate(char[] initialSet)
    {
        var subsetNumber = (int)Math.Pow(2, initialSet.Length);
        var subsets = new char[subsetNumber][];

        for (var i = 0; i < subsetNumber; i++)
        {
            var bitMask = new BitArray(new[] { i });
            subsets[i] = ApplyBitMask(initialSet, bitMask);
        }

        return subsets;
    }

    private static char[] ApplyBitMask(char[] initialSet, BitArray bitMask)
    {
        var subset = new List<char>(capacity: initialSet.Length);

        for (var i = 0; i < initialSet.Length; i++)
        {
            if (bitMask[i])
                subset.Add(initialSet[i]);
        }

        return subset.ToArray();
    }
}