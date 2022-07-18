using System;
using System.Collections.Generic;
using _PROJECT.Code.ProductCatalog.Data;

namespace _PROJECT.Code.ProductCatalog
{
    public sealed class ProductCatalog : ProductCatalogBase<IProductCatalogEntry>
    {
        public ProductCatalog(ProductCatalogData productCatalogData) : base(productCatalogData.Entries)
        {
        }

        public IReadOnlyList<IProductCatalogEntry> SortBy<TKey>(Func<IProductCatalogEntry, TKey> selector,
            Comparer<TKey> comparer, bool isAscendant = false)
        {
            var sortResult = Sort(selector, comparer);
            return new Range<IProductCatalogEntry>(sortResult.SortedData, 0, sortResult.SortedData.Length - 1, isAscendant);
        }

        public IReadOnlyList<IProductCatalogEntry> FilterBy<TKey>(TKey key, Func<IProductCatalogEntry, TKey> selector,
            Comparer<TKey> comparer, bool isAscendant = false)
        {
            var sortResult = Sort(selector, comparer);
            var startIndex = Filter(key, sortResult, comparer);

            return startIndex < 0
                ? new Range<IProductCatalogEntry>(sortResult.SortedData, ~startIndex, sortResult.SortedData.Length - 1, isAscendant)
                : new Range<IProductCatalogEntry>(sortResult.SortedData, startIndex - 1, sortResult.SortedData.Length - 1,
                    isAscendant);
        }

        public IReadOnlyList<IProductCatalogEntry> FilterBy<TKey>(TKey keyStart, TKey keyEnd,
            Func<IProductCatalogEntry, TKey> selector, Comparer<TKey> comparer, bool isAscendant = false)
        {
            if (Comparer<TKey>.Default.Compare(keyStart, keyEnd) > 0)
            {
                (keyStart, keyEnd) = (keyEnd, keyStart);
            }
            var sortResult = Sort(selector, comparer);
            var startIndex = Filter(keyStart, sortResult, comparer);
            var endIndex = Filter(keyEnd, sortResult, comparer);

            if (startIndex > 0 && endIndex > 0)
            {
                startIndex -= 1;
                return new Range<IProductCatalogEntry>(sortResult.SortedData, startIndex, endIndex, isAscendant);
            }

            if (startIndex < 0 && endIndex > 0)
            {
                startIndex = ~startIndex;
                endIndex -= 1;
                return new Range<IProductCatalogEntry>(sortResult.SortedData, startIndex, endIndex, isAscendant);
            }

            if (startIndex > 0 && endIndex < 0)
            {
                startIndex -= 1;
                endIndex = ~endIndex;
                return new Range<IProductCatalogEntry>(sortResult.SortedData, startIndex, endIndex, isAscendant);
            }

            startIndex = ~startIndex;
            endIndex = ~endIndex;
            return new Range<IProductCatalogEntry>(sortResult.SortedData, startIndex, endIndex - 1, isAscendant);
        }
    }
}