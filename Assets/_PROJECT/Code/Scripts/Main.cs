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

            IReadOnlyList<IProductCatalogEntry> r1 = productCatalog.SortByPrice();
            IReadOnlyList<IProductCatalogEntry> r2 = productCatalog.SortByName(false);
            IReadOnlyList<IProductCatalogEntry> r3 = productCatalog.SortBy(entry => entry.Item, new ItemComparer(), false);
            //
            IReadOnlyList<IProductCatalogEntry> r4 = productCatalog.FilterByItem(new []{ItemTypes.Gems});
            IReadOnlyList<IProductCatalogEntry> r5 = productCatalog.FilterBy<uint>(100, entry => entry.Price, Comparer<uint>.Default, false);
        }
    }
}