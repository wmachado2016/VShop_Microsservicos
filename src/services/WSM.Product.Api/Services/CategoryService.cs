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

        public async Task<IEnumerable<CategoryViewModel>> GetCategoriesAsync(GetCategory categoryViewModel)
        {
            var lisCategory = await _categoryRepository.GetAll(categoryViewModel);
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
            Category category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.Create(category);
            categoryViewModel.CategoryId = category.CategoryId;
        }

        public async Task UpdateCategory(CategoryViewModel categoryViewModel)
        {
            Category category = _mapper.Map<Category>(categoryViewModel);
            await _categoryRepository.Update(category);
        }

        public async Task RemoveCategory(int id)
        {
            var categoryEntity = _categoryRepository.GetById(id).Result;
            await _categoryRepository.Delete(categoryEntity.CategoryId);
        }
        
    }
}
