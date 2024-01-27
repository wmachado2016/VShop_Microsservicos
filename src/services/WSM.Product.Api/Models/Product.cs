namespace WSM.Catalog.Api.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public string ImagenUrl { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }
}
