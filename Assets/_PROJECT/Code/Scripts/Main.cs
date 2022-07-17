using System.Collections.Generic;
using _PROJECT.Code.ProductCatalog;
using _PROJECT.Code.ProductCatalog.Data;
using UnityEngine;
using static System.IO.File;

namespace _PROJECT.Code.Scripts
{
    public class Main : MonoBehaviour
    {
        private void Start()
        {
            var path = $"{Application.streamingAssetsPath}/data.json";
            var json = ReadAllText(path);
            
            var loader = new ProductCatalogLoader(json);
            var productCatalog = loader.Build();

            IReadOnlyList<IProductCatalogEntry> entries = productCatalog.SortByPrice();
            PrintResult(entries, 1);
            entries = productCatalog.SortByName(false);
            PrintResult(entries, 2);
            entries = productCatalog.SortByItems(new []{ItemTypes.Coins, ItemTypes.Gems, ItemTypes.Tickets});
            PrintResult(entries, 3);
            entries = productCatalog.SortBy(entry => entry.Item,
                new ProductCatalogComparers.ItemComparer(new[] {ItemTypes.Tickets, ItemTypes.Coins, ItemTypes.Gems}),
                false);
            PrintResult(entries, 4);
            entries = productCatalog.FilterBy<uint>(100, entry => entry.Price, Comparer<uint>.Default);
            PrintResult(entries, 5);
            entries = productCatalog.FilterByCoinsAndTickets();
            PrintResult(entries, 6);
            entries = productCatalog.FilterByCoinsOrTickets();
            PrintResult(entries, 7);
            
        }

        private static void PrintResult(IEnumerable<IProductCatalogEntry> productCatalogEntries, int index)
        {
            Debug.Log($"{index} --------------");
            foreach (var entry in productCatalogEntries)
            {
                Debug.Log(entry);
            }
        }
    }
}