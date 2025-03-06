namespace Common
{
    public static class ConsoleExtensions
    {
        public static void WriteSeparatorLine()
            => Console.WriteLine($"\n{new string('-', Console.WindowWidth)}\n");

        public static bool UserAgree(string question)
        {
            Console.Write($"{question} (y/[n]): ");
            var userAnswer = Console.ReadLine();
            Console.WriteLine();

            return userAnswer?.Trim() == "y";
        }

        public static double ObtainDouble(string title)
            => Obtain(title, ObtainDouble);

        public static int ObtainInt(string title)
            => Obtain(title, ObtainInt);

        private static T Obtain<T>(string title, Func<T> obtain)
        {
            WritePleaseInputMessage(title);
            var obtainedValue = obtain();
            ClearPreviousLine();
            Console.WriteLine($"Wprowadzono {title}: {obtainedValue}");
            Console.WriteLine();

            return obtainedValue;
        }

        public static double ObtainDouble()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out var value))
                    return value;

                WriteBadValueMessage();
            }
        }

        public static int ObtainInt()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out var value))
                    return value;

                WriteBadValueMessage();
            }
        }

        public static void WritePleaseInputMessage(string title)
            => Console.Write($"Proszę wprowadzić {title}: ");

        public static void WriteBadValueMessage() 
            => Console.WriteLine("Zła wartość. Proszę wprowadzić jescze raz: ");

        public static void Write(string text, int padding = 0)
        {
            Console.CursorLeft += padding * 2;
            Console.WriteLine(text);
        }

        private static void ClearPreviousLine()
        {
            var currentPosition = Console.GetCursorPosition();
            Console.SetCursorPosition(left: 0, top: currentPosition.Top - 1);
            ClearCurrentLine();
        }

        private static void ClearCurrentLine() 
            => Console.Write(new string(' ', Console.WindowWidth) + "\r");
    }
}
