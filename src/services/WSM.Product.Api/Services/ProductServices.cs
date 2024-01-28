using AutoMapper;
using WSM.Catalog.Api.Models;
using WSM.Catalog.Api.Repository;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Services
{
    public class ProductServices : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductServices(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync(ProductViewModel productViewModel)
        {
            Product product = productViewModel;
            var lisProduct = await _productRepository.GetAll(product);
            return _mapper.Map<IEnumerable<ProductViewModel>>(lisProduct);
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var categoryEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(categoryEntity);
        }

        public async Task AddProduct(ProductViewModel categoryViewModel)
        {
            Product categoryEntity = categoryViewModel;
            await _productRepository.Create(categoryEntity);
            categoryViewModel.CategoryId = categoryEntity.CategoryId;
        }

        public async Task UpdateProduct(ProductViewModel productViewModel)
        {
            Product categoryEntity = productViewModel;
            await _productRepository.Update(categoryEntity);
        }

        public async Task RemoveProduct(int id)
        {
            var categoryEntity = _productRepository.GetById(id).Result;
            await _productRepository.Delete(categoryEntity.CategoryId);
        }
    }
}
