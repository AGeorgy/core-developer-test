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

            /*productCatalog.SortByPrice();
            productCatalog.SortByName(false);
            productCatalog.SortBy(entry => entry.Item, System.Collections.Generic.Comparer<ItemTypes>.Default, false);

            productCatalog.FilterByItem(ItemTypes.Gems);
            productCatalog.FilterBy(entry => entry.Price, System.Collections.Generic.Comparer<uint>.Default, 100, false);*/
        }
    }
}