namespace BisectionMethod
{
    public record Function(
        Func<double, double> Calculate,
        string Title)
    {
        public override string? ToString()
            => $"f(x) = {Title}";
    }
}
