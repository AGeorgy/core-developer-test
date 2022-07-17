namespace _PROJECT.Code.ProductCatalog.Data
{
    public class Product : IProductCatalogEntry
    {
        public const uint CONTAINS_MAX = 1;
        
        public string Type => nameof(Product);
        
        public ItemTypes[] Item { get; set; }
        public uint[] Amount { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public uint Price { get; set; } // In cents

        public override string ToString()
        {
            return $"{Name}, {Description}, {Price}, {Item[0]}, {Amount[0]}";
        }
    }
}