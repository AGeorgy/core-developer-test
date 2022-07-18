using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ProductCatalog.Data
{
    public class ProductCatalogData
    {
        [JsonConverter(typeof(ProductCatalogEntriesConverter))]
        public IProductCatalogEntry[] Entries { get; set; }
    }

    public class ProductCatalogEntriesConverter : JsonConverter
    {
        public override bool CanWrite => true;
        public override bool CanRead => true;
        
        public override bool CanConvert(Type objectType)
        {
            return typeof(IProductCatalogEntry).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            if (value is Bundle bundle)
            {
                serializer.Serialize(writer, bundle);
            }
            else if (value is Product product)
            {
                serializer.Serialize(writer, product);
            }
            else
            {
                serializer.Serialize(writer, value);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            var jsonArray = JArray.Load(reader);
            
            var entries = new IProductCatalogEntry[jsonArray.Count];
            for (var i = 0; i < jsonArray.Count; i++)
            {
                var entry = jsonArray[i];
                switch (entry["Type"].Value<string>())
                {
                    case nameof(Bundle):
                        entries[i] = new Bundle();
                        serializer.Populate(entry.CreateReader(), entries[i]);
                        break;
                    case nameof(Product):
                        entries[i] = new Product();
                        serializer.Populate(entry.CreateReader(), entries[i]);
                        break;
                }
            }

            // Populate the object properties
            serializer.Populate(jsonArray.CreateReader(), entries);
            return entries;
        }
    }
}