namespace Setchin.NethardMusic.Collections
{
    internal static class Array
    {
        public static readonly int MaxLength = 0X7FFFFFC7;

        public static T[] Empty<T>()
        {
            return EmptyArray<T>.Value;
        }

        private static class EmptyArray<T>
        {
            public static readonly T[] Value = new T[0];
        }
    }
}
