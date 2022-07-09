namespace _PROJECT.Code.Data
{
    public class Bundle : IProductCatalogEntry
    {
        public const uint CONTAINS_MAX = 3;
        
        public ItemTypes[] Item { get; }
        public uint[] Amount { get; }
        public string Name { get; }
        public string Description { get; }
        public uint Price { get; } // In cents
    }
}