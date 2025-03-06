using System.Diagnostics;

namespace FindingAllNumberDivisions
{
    internal class AllNumberDivisions
    {
        public AllNumberDivisions(int number)
        {
            Number = number;
            FindDivisionsMeasuringTime();
        }

        public int Number { get; }

        public IReadOnlyList<IReadOnlyList<int>> Divisions
            => divisions;

        public TimeSpan CalculationTime
            => calculationStopwatch.Elapsed;

        private void FindDivisionsMeasuringTime() 
        {
            calculationStopwatch.Start();
            FindDivisions();
            calculationStopwatch.Stop();
        }

        private void FindDivisions()
        {
            var components = new int[Number];
            var componentCounts = new int[Number];
            components[0] = Number;
            componentCounts[0] = 1;
            var i = 0;

            AddDivision(components, componentCounts, i);

            while (components[0] > 1)
            {
                var sum = 0;

                if (components[i] == 1)
                {
                    sum += componentCounts[i];
                    i--;
                }

                sum += components[i];
                componentCounts[i]--;
                var l = components[i] - 1;

                if (componentCounts[i] > 0)
                    i++;

                components[i] = l;
                componentCounts[i] = sum / l;
                l = sum % l;

                if (l != 0)
                {
                    i++;
                    components[i] = l;
                    componentCounts[i] = 1;
                }

                AddDivision(components, componentCounts, i);
            }
        }

        private void AddDivision(int[] components, int[] componentCounts, int maxIndex)
        {
            var division = new List<int>();

            for (var i = 0; i <= maxIndex; i++)
            {
                for (var j = 0; j < componentCounts[i]; j++)
                    division.Add(components[i]);
            }

            divisions.Add(division);
        }

        private readonly List<List<int>> divisions = new();
        private readonly Stopwatch calculationStopwatch = new();

        private record Component(
            int Value,
            int Count);
    }
}
