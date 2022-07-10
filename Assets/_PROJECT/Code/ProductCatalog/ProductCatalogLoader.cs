using _PROJECT.Code.ProductCatalog.Data;
using UnityEngine;

namespace _PROJECT.Code.ProductCatalog
{
    public class ProductCatalogLoader
    {
        private readonly string _json;

        public ProductCatalogLoader(string json)
        {
            _json = json;
        }

        public ProductCatalog Build()
        {
            return new ProductCatalog(JsonUtility.FromJson<ProductCatalogData>(_json));
        }
    }
}