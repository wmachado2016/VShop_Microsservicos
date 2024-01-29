using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Models;

public class Product { 
   
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public long Stock { get; set; }
    public string ImagenUrl { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }  

    public static implicit operator ProductViewModel(Product product)
    {
        return new ProductViewModel
        {
            Id = product.Id,
            Name = product.Category?.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImagenUrl = product.ImagenUrl,
            Category = product.Category,
            CategoryId = product.CategoryId
        };
    }

    public static implicit operator Product(ProductViewModel product)
    {
        return new Product
        {
            Id = product.Id,
            Name = product.Category?.Name,
            Description = product.Description,
            Price = product.Price,
            Stock = product.Stock,
            ImagenUrl = product.ImagenUrl,
            Category = product.Category,
            CategoryId = product.CategoryId
        };
    }

}
