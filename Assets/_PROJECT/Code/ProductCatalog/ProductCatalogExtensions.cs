using System.Collections.Generic;
using _PROJECT.Code.ProductCatalog.Data;

namespace _PROJECT.Code.ProductCatalog
{
    public static partial class ProductCatalogExtensions
    {
        public static IReadOnlyList<IProductCatalogEntry> SortByName(this ProductCatalog pc, bool isAscendant = true)
        {
            return pc.SortBy(entry => entry.Name, Comparer<string>.Default, isAscendant);
        }

        public static IReadOnlyList<IProductCatalogEntry> SortByPrice(this ProductCatalog pc, bool isAscendant = true)
        {
            return pc.SortBy(entry => entry.Price, Comparer<uint>.Default, isAscendant);
        }

        public static IReadOnlyList<IProductCatalogEntry> SortByItems(this ProductCatalog pc, ItemTypes[] items, bool isAscendant = false)
        {
            return pc.SortBy(entry => entry.Item, new ProductCatalogComparers.ItemComparer(items), isAscendant);
        }

        public static IReadOnlyList<IProductCatalogEntry> FilterByItem(this ProductCatalog pc, ItemTypes[] item, bool isAscendant = true)
        {
            return pc.FilterBy(item, entry => entry.Item, new ProductCatalogComparers.ItemOrComparer(), isAscendant);
        }

        public static IReadOnlyList<IProductCatalogEntry> FilterByCoinsAndTickets(this ProductCatalog pc, bool isAscendant = true)
        {
            return pc.FilterBy(new[]{ItemTypes.Coins, ItemTypes.Tickets}, entry => entry.Item, new ProductCatalogComparers.ItemAndComparer(), isAscendant);
        }
        
        public static IReadOnlyList<IProductCatalogEntry> FilterByCoinsOrTickets(this ProductCatalog pc, bool isAscendant = true)
        {
            return pc.FilterBy(new[]{ItemTypes.Coins, ItemTypes.Tickets}, entry => entry.Item, new ProductCatalogComparers.ItemOrComparer(), isAscendant);
        }
    }
}