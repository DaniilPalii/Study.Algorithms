namespace BisectionMethod
{
    public record NewtonsArgumentThatProducesZeroSearcher(
        Function Function,
        Func<double, double> Derivative,
        Range Range)
        : ArgumentThatProducesZeroSearcher(Function, Range)
    {
        public Result FindUsingNewtonMethod(double precision)
        {
            var steps = new List<Range>();
            var x = Range.Start;
            var y = Function.Calculate(x);
            steps.Add(new Range(x, Range.End));

            while (Math.Abs(y) > precision)
            {
                x -= y / Derivative(x);
                y = Function.Calculate(x);
                steps.Add(new Range(x, Range.End));
            }

            return new SuccessResult(x, steps);
        }

        public override string ToString()
            => base.ToString();
    }
}
