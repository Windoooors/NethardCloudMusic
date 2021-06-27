using System;
using System.Collections.Generic;

namespace Setchin.NethardMusic.Collections
{
    internal static class Enumerate
    {
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> enumerable, Func<TSource, TResult> func)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    yield return func.Invoke(enumerator.Current);
                }
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> enumerable, Func<T, bool> func)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            using (var enumerator = enumerable.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (func.Invoke(enumerator.Current))
                    {
                        yield return enumerator.Current;
                    }
                }
            }
        }

        public static T[] ToArray<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            var collection = enumerable as ICollection<T>;

            if (collection != null)
            {
                int count = collection.Count;

                if (count == 0)
                {
                    return Array.Empty<T>();
                }

                var array = new T[count];
                collection.CopyTo(array, 0);
                return array;
            }

            var builder = new ArrayBuilder<T>();
            var enumerator = enumerable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                builder.Add(enumerator.Current);
            }

            return builder.ToArray();
        }

        public static List<T> ToList<T>(this IEnumerable<T> enumerable)
        {
            if (enumerable == null)
            {
                throw new ArgumentNullException("enumerable");
            }

            return new List<T>(enumerable);
        }

        private struct ArrayBuilder<T>
        {
            private const int DefaultCapacity = 4;

            private T[] _array;
            private int _count;

            public ArrayBuilder(int capacity) : this()
            {
                if (capacity > 0)
                {
                    _array = new T[capacity];
                }
            }

            public T[] Buffer { get { return _array; } }

            public int Capacity { get { return _array == null ? 0 : _array.Length; } }

            public int Count { get { return _count; } }

            public void Add(T item)
            {
                EnsureCapacity(_count + 1);
                _array[_count++] = item;
            }

            public T[] ToArray()
            {
                if (Count == 0)
                {
                    return Array.Empty<T>();
                }

                var result = _array;

                if (_count < result.Length)
                {
                    result = new T[_count];
                    System.Array.Copy(_array, result, _count);
                }

                return result;
            }

            private void EnsureCapacity(int minimum)
            {
                int capacity = Capacity;

                if (minimum > capacity)
                {
                    if (capacity > 0)
                    {
                        int newCapacity = capacity * 2;
                        newCapacity = Math.Max(newCapacity, minimum);

                        if ((uint)newCapacity > (uint)Array.MaxLength)
                        {
                            newCapacity = Array.MaxLength;
                        }

                        var array = new T[newCapacity];
                        System.Array.Copy(_array, array, _count);

                        _array = array;
                    }
                    else
                    {
                        int newCapacity = Math.Max(DefaultCapacity, minimum);
                        _array = new T[newCapacity];
                    }
                }
            }
        }
    }
}
