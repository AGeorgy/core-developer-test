namespace ProductCatalog.Data
{
    public interface IProductCatalogEntry
    {
        ItemTypes[] Item { get; set; }
        uint[] Amount { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        uint Price { get; set; }
    }
}