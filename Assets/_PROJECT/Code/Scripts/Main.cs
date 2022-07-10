using System.Collections.Generic;
using System.Linq;
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

            // Range r1 = productCatalog.SortByPrice();
            // Range r2 = productCatalog.SortByName(false);
            IReadOnlyList<IProductCatalogEntry> r3 = productCatalog.SortBy(entry => entry.Item.FirstOrDefault(), Comparer<ItemTypes>.Default, false);
            //
            // Range r4 = productCatalog.FilterByItem(ItemTypes.Gems);
            // Range r5 = productCatalog.FilterBy(entry => entry.Price, System.Collections.Generic.Comparer<uint>.Default, 100, false);
        }
    }
}