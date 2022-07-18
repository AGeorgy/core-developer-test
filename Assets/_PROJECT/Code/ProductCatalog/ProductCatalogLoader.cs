using _PROJECT.Code.ProductCatalog.Data;
using Newtonsoft.Json;

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
            var data = JsonConvert.DeserializeObject<ProductCatalogData>(_json);
            return new ProductCatalog(data);
        }
    }
}