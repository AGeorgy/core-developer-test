using System.Text;

namespace _PROJECT.Code.ProductCatalog.Data
{
    public class Bundle : IProductCatalogEntry
    {
        public const uint CONTAINS_MAX = 3;

        public string Type => nameof(Bundle);
        
        public ItemTypes[] Item { get; set; }
        public uint[] Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; } // In cents

        public override string ToString()
        {
            var s = new StringBuilder();
            for (var i = 0; i < Item.Length; i++)
            {
                s.Append(Item[i]);
                s.Append(", ");
                s.Append(Amount[i]);
                s.Append(", ");
            }

            return $"{Name}, {Description}, {Price}, {s}";
        }
    }
}