namespace _PROJECT.Code.ProductCatalog.Data
{
    public class Product : IProductCatalogEntry
    {
        public const uint CONTAINS_MAX = 1;
        
        public ItemTypes[] Item { get; }
        public uint[] Amount { get; }
        public string Name { get; }
        public string Description { get; }
        public uint Price { get; } // In cents
    }
}