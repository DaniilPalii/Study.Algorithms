using Common;

namespace Permutation
{
    internal record ConsoleWriter(IReadOnlyCollection<Result> Results)
    {
        public void Write()
        {
            WritePermutations();
            WritePermutationComparing();
            WriteSummary();
        }

        private void WritePermutations()
        {
            if (Results.Any(r => r.Permutations.Length >= LargePermutationsNumber))
            {
                if (!ConsoleExtensions.UserAgree(
                    $"Wygenerowano powyżej {LargePermutationsNumber} permutacji. Wyświetlić wszystkie?"))
                    return;
            }

            Write("Permutację");
            foreach (var result in Results)
            {
                Write(result.Permutator.AlgorythmName, padding: 1);
                Write(result.Permutations, padding: 2);
                Console.WriteLine();
            }
        }

        private void WritePermutationComparing()
        {
            if (Results.Count < 2)
                return;

            if (SetOfSetComparer.AreSame(Results.Select(r => r.Permutations).ToArray()))
                Write("Wyniki wszystkich algorytmów są takie same.\n");
            else
                Write("Błąd: wyniki algorytmów różnią się!");
        }

        private void WriteSummary()
        {
            foreach (var result in Results)
            {
                Write(result.Permutator.AlgorythmName);
                Write($"Czas generowania: {result.GenerationTime}", padding: 1);
                Write($"Ilość transpozycji: {result.SwappingCount}", padding: 1);
                Console.WriteLine();
            }
        }

        private static void Write(int[][] permutations, int padding = 0)
        {
            var i = 1;

            foreach (var permutation in permutations)
                Write($"{i++,3:##)} {ToString(permutation)}", padding);
        }

        private static string ToString(int[] set)
            => $"{{ {string.Join(", ", set)} }}";

        private static void Write(string text, int padding = 0)
        {
            Console.CursorLeft += padding * 2;
            Console.WriteLine(text);
        }

        private const int LargePermutationsNumber = 1000;
    }
}
