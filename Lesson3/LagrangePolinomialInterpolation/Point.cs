namespace LagrangePolinomialInterpolation
{
    public record Point(double X, double Y)
    {
        public override string ToString()
            => $"({X}, {Y})";
    }
}
