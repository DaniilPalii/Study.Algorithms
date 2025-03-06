namespace SubsetGeneration.Generators;

public class GreySubsetGenerator
{
    public char[][] Generate(char[] initialSet)
    {
        var subsetNumber = (int)Math.Pow(2, initialSet.Length);
        var subsets = new char[subsetNumber][];

        for (var i = 0; i < subsetNumber; i++)
            subsets[i] = ApplyBitMask(initialSet, CreateBitMask(i, initialSet.Length));

        return subsets;
    }

    private static bool[] CreateBitMask(int maskIndex, int initialSetLength)
    {
        var mask = new bool[initialSetLength];

        var i = maskIndex;
        int bitIndex;
        int j;
        do
        {
            bitIndex = 0;
            j = i + 1;

            while (j % 2 == 0)
            {
                j /= 2;
                bitIndex++;
            }

            if (bitIndex < initialSetLength)
                mask[bitIndex] = !mask[bitIndex];

            i++;
        } while (bitIndex < initialSetLength);

        return mask;
    }

    private static char[] ApplyBitMask(char[] initialSet, bool[] bitMask)
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