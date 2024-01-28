using WSM.Catalog.Api.Models;

namespace WSM.Catalog.Api.Repository
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll(Category category);
        Task<IEnumerable<Category>>GetCategorysProducts();
        Task<Category> GetById(int id);
        Task<Category> Create(Category category);
        Task<Category> Update(Category category);
        Task<Category> Delete(int id);
    }
}
