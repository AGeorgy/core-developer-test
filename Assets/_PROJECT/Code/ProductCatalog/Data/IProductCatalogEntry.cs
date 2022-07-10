namespace _PROJECT.Code.ProductCatalog.Data
{
    public interface IProductCatalogEntry
    {
        ItemTypes[] Item { get; }
        uint[] Amount { get; }
        string Name { get; }
        string Description { get; }
        uint Price { get; }
    }
}