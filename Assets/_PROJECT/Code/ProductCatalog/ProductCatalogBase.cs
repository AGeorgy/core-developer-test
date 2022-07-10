using System;
using System.Collections.Generic;

namespace _PROJECT.Code.ProductCatalog
{
    public abstract class ProductCatalogBase<T>
    {
        private readonly T[] _data;

        protected ProductCatalogBase(T[] data)
        {
            _data = data;
        }

        protected T[] Sort<TKey>(Func<T, TKey> selector, Comparer<TKey> comparer)
        {
            var sortedData = new T[_data.Length];
            var keys = new TKey[_data.Length];
            for (var i = 0; i < _data.Length; i++)
            {
                sortedData[i] = _data[i];
                keys[i] = selector(_data[i]);
            }

            Array.Sort(keys, sortedData, 0, sortedData.Length, comparer);
            return sortedData;
        }
    }
}