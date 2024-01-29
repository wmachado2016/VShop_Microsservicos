using AspNetCore.IQueryable.Extensions;
using AspNetCore.IQueryable.Extensions.Attributes;
using AspNetCore.IQueryable.Extensions.Filter;
using AspNetCore.IQueryable.Extensions.Pagination;
using AspNetCore.IQueryable.Extensions.Sort;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Models;

public class Category
{   
    public int CategoryId { get; set; }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set;}

    public static implicit operator CategoryViewModel(Category category)
    {
        return new CategoryViewModel
        {
            CategoryId = category.CategoryId,
            Name = category.Name,
            Products =  category.Products
        };
    }

    public static implicit operator Category(CategoryViewModel categoryViewModel)
    {
        return new CategoryViewModel
        {
            CategoryId = categoryViewModel.CategoryId,
            Name = categoryViewModel.Name,
            Products = categoryViewModel.Products
        };
    }
}
