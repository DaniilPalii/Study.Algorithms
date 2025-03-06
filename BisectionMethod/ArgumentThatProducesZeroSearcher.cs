namespace BisectionMethod
{
    public record ArgumentThatProducesZeroSearcher(
        Function Function,
        Range Range)
    {
        public Result FindUsingBisection(double precision) 
        {
            var workingRange = Range;
            var funtionValueInStartOfWorkingRange = Function.Calculate(workingRange.Start);
            var steps = new List<Range> { workingRange };

            double argument;
            do
            {
                argument = workingRange.GetMiddle();
                var functionValue = Function.Calculate(argument);

                if (functionValue == 0)
                    return new SuccessResult(argument, steps);

                if (funtionValueInStartOfWorkingRange * functionValue < 0) // have different signs
                {
                    workingRange.End = argument;
                }
                else
                {
                    workingRange.Start = argument;
                    funtionValueInStartOfWorkingRange = functionValue;
                }

                steps.Add(workingRange);
            } while (workingRange.GetLength() >= precision);

            return new SuccessResult(argument, steps);
        }

        public Result FindUsingRegulaFalsi(double precision)
        {
            var a = Range.Start;
            var b = Range.End;

            var fa = Function.Calculate(a);
            var fb = Function.Calculate(b);
            var x1 = a;
            var x0 = b;

            if (fa * fb > 0)
                return new ErrorResult("Funkcja nie spełnia założeń");

            var steps = new List<Range>();

            double f0 = 0;
            while(Math.Abs(x1 - x0) > precision)
            {
                steps.Add(new (a, b));

                x1 = x0;
                x0 = a - fa * ((b - a) / (fb - fa));
                f0 = Function.Calculate(x0);

                if (Math.Abs(f0) < precision)
                    break;

                if (fa * f0 < 0)
                {
                    b = x0;
                    fb = f0;
                }
                else
                {
                    a = x0;
                    fa = f0;
                }
            }

            return new SuccessResult(x0, steps);
        }

        public override string ToString()
            => $"Funkcja: {Function}\n"
                + $"Przedział: {Range}";
    }
}