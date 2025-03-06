namespace BisectionMethod
{
    public abstract record Result { };

    public record SuccessResult(
        double ArgumentThatProducesZero,
        ICollection<Range> Steps)
        : Result
    {
        public override string ToString()
            => $"\tWynik: {ArgumentThatProducesZero}\n"
                + $"\tLiczba kroków: {Steps.Count}\n"
                + $"\tKroki: {string.Join(", ", Steps)}";
    }

    public record ErrorResult(string Message) : Result
    {
        public override string ToString()
            => $"\tBłąd: \"{Message}\"";
    }
}