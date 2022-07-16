using System;
using System.Collections.Generic;

namespace _PROJECT.Code.ProductCatalog
{
    public abstract class ProductCatalogBase<T>
    {
        private readonly T[] _data;

        private ProductCatalogBase()
        {
            _data = Array.Empty<T>();
        }
        
        protected ProductCatalogBase(T[] data)
        {
            if(data == null) 
                _data = Array.Empty<T>();
            else
                _data = data;
        }

        protected (T[] SortedData, TKey[] Keys)  Sort<TKey>(Func<T, TKey> selector, Comparer<TKey> comparer)
        {
            var sortedData = new T[_data.Length];
            var keys = new TKey[_data.Length];
            for (var i = 0; i < _data.Length; i++)
            {
                sortedData[i] = _data[i];
                keys[i] = selector(_data[i]);
            }

            Array.Sort(keys, sortedData, 0, sortedData.Length, comparer);
            return (sortedData, keys);
        }

        protected int Filter<TKey>(TKey key, (T[] SortedData, TKey[] Keys) sortResult, Comparer<TKey> comparer)
        {
            return Array.BinarySearch(sortResult.Keys, key, comparer);
        }
    }
}