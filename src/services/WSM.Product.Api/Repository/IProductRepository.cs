using WSM.Catalog.Api.Models;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll(GetProduct product);
        Task<Product> GetById(int id);
        Task<Product> Create(Product product);
        Task<Product> Update(Product product);
        Task<Product> Delete(int id);
    }
}
