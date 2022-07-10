using _PROJECT.Code.ProductCatalog.Data;
using Newtonsoft.Json;
using UnityEngine;
using static System.IO.File;

namespace _PROJECT.Code.ProductCatalog
{
    public class ProductCatalogLoader
    {
        private readonly string _json;

        public ProductCatalogLoader(string json)
        {
            _json = json;
            
            /*var pc = new ProductCatalogData()
            {
                Entries = new IProductCatalogEntry[]
                {
                    new Bundle
                    {
                        Item = new [] {ItemTypes.Tickets, ItemTypes.Gems, ItemTypes.Gems},
                        Amount = new uint[]{1, 2, 3},
                        Name = "SuperBundle1",
                        Description = "Descr1",
                        Price = 150
                    },
                    new Product
                    {
                        Item = new [] {ItemTypes.Coins},
                        Amount = new uint[]{2},
                        Name = "SuperProduct1",
                        Description = "Descr1",
                        Price = 50
                    }
                }
            };
            
            var jsonString = JsonConvert.SerializeObject(pc);
            var path = $"{Application.streamingAssetsPath}/data.json";
            WriteAllText(path, jsonString);*/
        }

        public ProductCatalog Build()
        {
            var data = JsonConvert.DeserializeObject<ProductCatalogData>(_json);
            return new ProductCatalog(data);
        }
    }
}