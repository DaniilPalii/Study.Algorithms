namespace BisectionMethod
{
    public record struct Range(
        double Start, 
        double End)
    {
        public double GetMiddle()
            => (Start + End) / 2;

        public double GetLength()
            => End - Start;

        public override string? ToString()
            => $"<{Start}, {End}>";
    }
}