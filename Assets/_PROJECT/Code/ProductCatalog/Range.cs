using System;
using System.Collections;
using System.Collections.Generic;

namespace _PROJECT.Code.ProductCatalog
{
    internal readonly struct Range<T> : IReadOnlyList<T>
    {
        private readonly T[] _data;
        private readonly int _left;
        private readonly int _right;
        private readonly bool _isAscendant;

        public static IReadOnlyList<T> Empty()
        {
            return new Range<T>(Array.Empty<T>(), -1, 0, true);
        }
        
        public Range(T[] data, int left, int right, bool isAscendant)
        {
            _data = data;
            _left = left;
            _right = right;
            _isAscendant = isAscendant;
        }

        public int Count => _right - _left + 1;

        public T this[int index] => _isAscendant ? _data[_left + index] : _data[_right - index];

        public IEnumerator<T> GetEnumerator()
        {
            var count = Count;
            for (var i = 0; i < count; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}