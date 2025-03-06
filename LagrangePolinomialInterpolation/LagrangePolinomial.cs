namespace LagrangePolinomialInterpolation
{
    public record LagrangePolinomial(Point[] Points)
    {
        public double Interpolate(double x)
        {
            var arguments = Points.Select(p => p.X).ToArray();

            if (x < arguments.Min() || x > arguments.Max())
                throw new ArgumentException($"Argument {x} nie mieści się w znanych punktach {this}.");

            double sum = 0;
            for (var j = 0; j < Points.Length; j++)
            {
                var numerator = CalculateNumerator(x, arguments, j);
                var denumerator = CalculateDenumerator(arguments, j);

                sum += (Points[j].Y * (numerator / denumerator));
            }

            return sum;
        }

        public override string ToString()
            => string.Join(separator: ", ", Points.AsEnumerable());

        private bool ContainsX(double x)
        {
            var arguments = Points.Select(p => p.X).ToList();

            return x >= arguments.Min()
                && x <= arguments.Max();
        }

        private double CalculateNumerator(double x, double[] arguments, int j)
        {
            double numerator = 1;

            for (var i = 0; i < Points.Length; i++)
            {
                if (i != j)
                    numerator *= (x - arguments[i]);
            }

            return numerator;
        }

        private double CalculateDenumerator(double[] arguments, int j)
        {
            double denumerator = 1;
            var xj = arguments[j];

            for (var i = 0; i < Points.Length; i++)
            {
                if (i != j)
                    denumerator *= (xj - arguments[i]);
            }

            return denumerator;
        }
    }
}
