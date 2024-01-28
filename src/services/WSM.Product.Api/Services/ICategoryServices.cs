using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Services;

public interface ICategoryServices
{
    Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync(CategoryViewModel categoryViewModel);
    Task<IEnumerable<CategoryViewModel>> GetAllCategoriesProductsAsync();
    Task<CategoryViewModel> GetCategoryByIdAsync(int id);
    Task AddCategory(CategoryViewModel categoryViewModel);
    Task UpdateCategory(CategoryViewModel categoryViewModel);
    Task RemoveCategory(int id);

}
