using System.Collections.Generic;
using ProductCatalog.Data;

namespace ProductCatalog
{
    /// <summary>
    /// Extend basic functionality of ProductCatalog putting those supplies to this partial class.
    /// It allows to marge new extensions to ProductCatalog package with no pain.
    /// </summary>
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

        public static IReadOnlyList<IProductCatalogEntry> FilterByCoinsAndTickets(this ProductCatalog pc, bool isAscendant = true)
        {
            var items = new[] {ItemTypes.Coins, ItemTypes.Tickets};
            return pc.FilterBy(items, entry => entry.Item, new ProductCatalogComparers.ItemAndComparer(items), isAscendant);
        }
        
        public static IReadOnlyList<IProductCatalogEntry> FilterByCoinsOrTickets(this ProductCatalog pc, bool isAscendant = true)
        {
            var items = new[] {ItemTypes.Coins, ItemTypes.Tickets};
            return pc.FilterBy(items, entry => entry.Item, new ProductCatalogComparers.ItemOrComparer(items), isAscendant);
        }
    }
}