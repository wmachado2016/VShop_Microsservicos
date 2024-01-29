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

        public async Task<IEnumerable<ProductViewModel>> GetProductsAsync(GetProduct getProduct)
        {
            var lisProduct = await _productRepository.GetAll(getProduct);
            return _mapper.Map<IEnumerable<ProductViewModel>>(lisProduct);
        }

        public async Task<ProductViewModel> GetProductByIdAsync(int id)
        {
            var productEntity = await _productRepository.GetById(id);
            return _mapper.Map<ProductViewModel>(productEntity);
        }

        public async Task AddProduct(ProductViewModel productViewModel)
        {
            Product product = _mapper.Map<Product>(productViewModel);
            await _productRepository.Create(product);
            productViewModel.Id = product.Id;
        }

        public async Task UpdateProduct(ProductViewModel productViewModel)
        {
            Product productEntity = productViewModel;
            await _productRepository.Update(productEntity);
        }

        public async Task RemoveProduct(int id)
        {
            var productEntity = _productRepository.GetById(id).Result;
            await _productRepository.Delete(productEntity.Id);
        }
    }
}
