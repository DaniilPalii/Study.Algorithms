using Common;

namespace FindingAllNumberDivisions
{
    internal record ConsoleWriter(AllNumberDivisions AllNumberDivisions)
    {
        public void Write()
        {
            WriteDivisions();
            WriteSummary();
        }

        private void WriteDivisions()
        {
            Console.WriteLine("Podziały");

            var i = 1;
            foreach (var division in AllNumberDivisions.Divisions)
            {
                ConsoleExtensions.Write(
                    $"{i++}) {string.Join(separator: " + ", division)}",
                    padding: 1);
            }

            Console.WriteLine();
        }

        private void WriteSummary()
        {
            Console.WriteLine($"Czas generowania: {AllNumberDivisions.CalculationTime}");
            Console.WriteLine();
        }
    }
}
