namespace Common
{
    public static class ArrayExtensions
    {
        public static T[] Copy<T>(this T[] integers)
            => (T[])integers.Clone();

        public static void Swap<T>(this T[] array, int index1, int index2)
        {
            (array[index2], array[index1]) = (array[index1], array[index2]);
        }

        public static T[] CreateFilled<T>(int size, T value)
        {
            var array = new T[size];
            Array.Fill(array, value);

            return array;
        }

        public static int[] CreateFilledWithNumbers(int from, int size)
        {
            var array = new int[size];
            var value = from;

            for (var i = 0; i < size; i++)
            {
                array[i] = value;
                value++;
            }

            return array;
        }
    }
}
