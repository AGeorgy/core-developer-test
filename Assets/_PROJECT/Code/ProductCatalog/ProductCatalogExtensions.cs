using System.Collections.Generic;
using _PROJECT.Code.ProductCatalog.Data;

namespace _PROJECT.Code.ProductCatalog
{
    public static class ProductCatalogExtensions
    {
        public static IReadOnlyList<IProductCatalogEntry> SortByName(this ProductCatalog pc, bool isAscendant = true)
        {
            return pc.SortBy(entry => entry.Name, Comparer<string>.Default, isAscendant);
        }

        public static IReadOnlyList<IProductCatalogEntry> SortByPrice(this ProductCatalog pc, bool isAscendant = true)
        {
            return pc.SortBy(entry => entry.Price, Comparer<uint>.Default, isAscendant);
        }

        public static IReadOnlyList<IProductCatalogEntry> FilterByItem(this ProductCatalog pc, ItemTypes[] item, bool isAscendant = true)
        {
            return pc.FilterBy(item, entry => entry.Item, new ItemComparer(), isAscendant);
        }
    }
}