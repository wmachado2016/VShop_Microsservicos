using AutoMapper;
using WSM.Catalog.Api.Models;
using WSM.Catalog.Api.Repository;
using WSM.Catalog.Api.ViewModels;

namespace WSM.Catalog.Api.Services
{
    public class CategoryService : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync(CategoryViewModel categoryViewModel)
        {
            Category category = categoryViewModel;
            var lisCategory = await _categoryRepository.GetAll(category);
            return _mapper.Map<IEnumerable<CategoryViewModel>>(lisCategory);
        }

        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesProductsAsync()
        {
            var categoryEntity = await _categoryRepository.GetCategorysProducts();
            return _mapper.Map<IEnumerable<CategoryViewModel>>(categoryEntity);
        }       

        public async Task<CategoryViewModel> GetCategoryByIdAsync(int id)
        {
            var categoryEntity = await _categoryRepository.GetById(id);
            return _mapper.Map<CategoryViewModel>(categoryEntity);
        }

        public async Task AddCategory(CategoryViewModel categoryViewModel)
        {
            Category categoryEntity = categoryViewModel;
            await _categoryRepository.Create(categoryEntity);
            categoryViewModel.CategoryId = categoryEntity.CategoryId;
        }

        public async Task UpdateCategory(CategoryViewModel categoryViewModel)
        {
            Category categoryEntity = categoryViewModel;
            await _categoryRepository.Update(categoryEntity);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }
        
    }
}
