using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetProductsAsync(GetProduct productViewModel);
        Task<ProductViewModel> GetProductByIdAsync(int id);
        Task AddProduct(ProductViewModel productViewModel);
        Task UpdateProduct(ProductViewModel productViewModel);
        Task RemoveProduct(int id);
    }
}
