using Newtonsoft.Json;
using ProductCatalog.Data;

namespace ProductCatalog
{
    /// <summary>
    /// This class might implement any other functionality. But now it's simple, cause the meaning of it existing is to
    /// show the separation ProductCatalog from data loading.
    /// </summary>
    public class ProductCatalogLoader
    {
        private readonly string _json;

        public ProductCatalogLoader(string json)
        {
            _json = json;
        }

        public ProductCatalog Build()
        {
            var data = JsonConvert.DeserializeObject<ProductCatalogData>(_json);
            return new ProductCatalog(data);
        }
    }
}