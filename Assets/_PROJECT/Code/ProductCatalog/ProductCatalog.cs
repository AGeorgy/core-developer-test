using System;
using System.Collections.Generic;
using _PROJECT.Code.ProductCatalog.Data;

namespace _PROJECT.Code.ProductCatalog
{
    public class ProductCatalog : ProductCatalogBase<IProductCatalogEntry>
    {
        public ProductCatalog(ProductCatalogData productCatalogData) : base(productCatalogData.Entries)
        {
        }

        public IReadOnlyList<IProductCatalogEntry> SortBy<TKey>(Func<IProductCatalogEntry, TKey> selector, Comparer<TKey> comparer, bool isAscendant = true)
        {
            IProductCatalogEntry[] sortedData = Sort(selector, comparer);
            return new Range<IProductCatalogEntry>(sortedData, 0, sortedData.Length - 1, isAscendant);
        }
    }
}